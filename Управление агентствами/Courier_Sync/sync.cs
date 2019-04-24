using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Courier_Sync
{
    public class sync
    {
        public class Zakaz
        {
            public uint ID;
            public DateTime Date;
            public TimeSpan Time;
        }

        public class Address
        {
            public uint ID;
        }

        public class Boxes
        {
            public int PacketNumber;
            public DateTime SendingDate;
            public String Kurier;
            public String State;
        }

        private const string vlogText = "Пакет договоров № ";
        private static string ConnectionString = string.Format(ltp_v2.Framework.ApplicationConf.CourierMySqlConnection, "Office", "LantaOff");
        private MySql.Data.MySqlClient.MySqlConnection mySqlConnection;

        private string sqlGetClients = "SELECT code FROM clients WHERE name = @name;";
        
        private string sqlGetZakaz = "SELECT DISTINCT zakaz.code, zakaz.date_beg, zakaz.time_beg " + 
                                     "FROM zakaz " + 
                                     "LEFT JOIN address ON address.zakaz = zakaz.code " + 
                                     "LEFT JOIN givn ON givn.address = address.code " +
                                     "WHERE zakaz.source = @source " +
                                     "and zakaz.date_beg = @date_beg " +
                                     "and zakaz.time_beg = @time_beg " +
                                     "and givn.State is null";
        private string sqlInsertZakaz = "INSERT INTO zakaz (source, date_beg, time_beg) VALUES (@source, @date_beg, @time_beg);";

        private string sqlGetLastSendZakaz = "SELECT  kurier.name as kuriername, tooktime, states.Name as statename, boxes.Name " +
                                             "FROM    givn " +
                                             "INNER JOIN states on givn.State = states.StateCode and states.StateType = 8 " +
                                             "INNER JOIN address on address.code = givn.address " +
                                             "INNER JOIN boxes on boxes.address = address.code " +
                                             "INNER JOIN kurier on kurier.code = givn.kurier " +
                                             "WHERE givn.State = 5 " +
                                               "and boxes.Name like '" + vlogText + "%' " +
                                               "and givn.ldtime > @ldtime";

        private string sqlGetAddressByZakaz = "SELECT code FROM address where zakaz = @zakaz";
        private string sqlInsertAddress = "INSERT INTO address (zakaz, number, target, client_id, address, time_put_min, time_put_max, date_putn, address.out, station, vlog) VALUES (@zakaz, @number, @target, @client_id, @address, @time_put_min, @time_put_max, @date_putn, 'T', 65535, @vlog)";

        private string sqlInsertBoxes = "INSERT INTO boxes (address,Name,kol_vo) VALUES(@address, @name,1)";

        private string sqlGetBoxes = "SELECT code FROM boxes where Name = @Name";

        private string sqlUpdateAddress = "UPDATE  address SET Kol_vo = (SELECT count(*) FROM boxes WHERE address = @code) WHERE code = @code";

        public bool CheckConnection()
        {
            if (ConnectionString == "")
                return false;
            mySqlConnection = new MySqlConnection(ConnectionString);
            try
            {
                mySqlConnection.Open();
            }
            catch
            {
                return false;
            }
            mySqlConnection.Close();
            return true;
        }

        public List<Boxes> GetSendingPacket(DateTime LastDateTime)
        {
            List<Boxes> result = null;

            if (mySqlConnection == null)
                CheckConnection();

            MySqlCommand cmd = new MySqlCommand(sqlGetLastSendZakaz, mySqlConnection);
            cmd.Parameters.Add(get_param("@ldtime", LastDateTime, DbType.DateTime, 0));

            mySqlConnection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string vlog = dr["name"].ToString();
                vlog = vlog.Replace(vlogText, "").Trim();
               
                int packetNumber = 0;
             
                if (Int32.TryParse(vlog, out packetNumber))
                {
                    if (result == null)
                        result = new List<Boxes>();

                    result.Add(new Boxes()
                    {
                        PacketNumber = packetNumber,
                        SendingDate = (DateTime)dr["tooktime"],
                        Kurier = dr["kuriername"].ToString(),
                        State = dr["statename"].ToString()
                    });
                }
            }
            mySqlConnection.Close();
            return result;
        }
        

        private MySqlParameter get_param(string par_name, object par_value, DbType par_type, int par_size)
        {
            MySqlParameter par = new MySqlParameter();
            par.ParameterName = par_name;
            par.Value = par_value;
            par.DbType = par_type;
            if (par_type == DbType.String)
            {
                par.Size = par_size;
            }
            return par;
        }

        /// <summary>
        /// Получение ID Клиента
        /// </summary>
        public ushort CheckClients(string name)
        {
            if (mySqlConnection == null)
                CheckConnection();

            MySqlCommand cmd = new MySqlCommand(sqlGetClients, mySqlConnection);
            cmd.Parameters.Add(get_param("@name", name, DbType.String, 100));
            mySqlConnection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            ushort result = 0;
            while (dr.Read())
            {
                result = (ushort)dr["code"];
                break;
            }
            mySqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Получение заказа на текущий день
        /// </summary>
        private Zakaz GetZakazToday(int ClientId)
        {
            if (mySqlConnection == null)
                CheckConnection();

            MySqlCommand cmd = new MySqlCommand(sqlGetZakaz, mySqlConnection);
            cmd.Parameters.Add(get_param("@date_beg", DateTime.Now.Date, DbType.Date, 0));
            cmd.Parameters.Add(get_param("@time_beg", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0, 0, 0).TimeOfDay, DbType.Time, 0));
            cmd.Parameters.Add(get_param("@source", ClientId, DbType.Int32, 0));

            mySqlConnection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            Zakaz result = null;
            while(dr.Read())
            {
                result = new Zakaz()
                {
                    ID = (uint)dr["code"],
                    Date = (DateTime)dr["date_beg"],
                    Time = (TimeSpan)dr["time_beg"]
                };
                break;
            }
            mySqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Создание / получение заказа на сегодняшний день
        /// </summary>
        public Zakaz CreateNewZakaz(int ClientId)
        {
            if (DateTime.Now.Hour > 19 && DateTime.Now.Minute > 0 && DateTime.Now.Second > 0)
                return null;

            Zakaz result = GetZakazToday(ClientId);

            if (result != null)
                return result;

            MySqlCommand cmd = new MySqlCommand(sqlInsertZakaz, mySqlConnection);
            cmd.Parameters.Add(get_param("@source", ClientId, DbType.UInt16, 0));
            cmd.Parameters.Add(get_param("@date_beg", DateTime.Now.Date, DbType.Date, 0));
            cmd.Parameters.Add(get_param("@time_beg", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0, 0, 0).TimeOfDay, DbType.Time, 0));
            mySqlConnection.Open();
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            result = GetZakazToday(ClientId);
            return result;
        }

        /// <summary>
        /// олучение адреса для заказа
        /// </summary>
        private Address GetAddressByZakaz(Zakaz zakaz)
        {
            if (mySqlConnection == null)
                CheckConnection();

            MySqlCommand cmd = new MySqlCommand(sqlGetAddressByZakaz, mySqlConnection);
            cmd.Parameters.Add(get_param("@zakaz", zakaz.ID, DbType.Int32, 0));

            mySqlConnection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            Address result = null;
            while (dr.Read())
            {
                result = new Address()
                {
                    ID = (uint)dr["code"]
                };
                break;
            }
            mySqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Создание / получение адреса для заказа
        /// </summary>
        public Address CreateNewAddressByZakaz(int ClientId)
        {
            Zakaz zakaz = CreateNewZakaz(ClientId);
            if (zakaz == null)
                return null;

            Address address = GetAddressByZakaz(zakaz);
            if (address != null)
                return address;

            MySqlCommand cmd = new MySqlCommand(sqlInsertAddress, mySqlConnection);
            cmd.Parameters.Add(get_param("@zakaz", zakaz.ID, DbType.UInt32, 0));
            cmd.Parameters.Add(get_param("@number", 0, DbType.UInt32, 0));
            cmd.Parameters.Add(get_param("@target", "ПОЧТА", DbType.String, 255));
            cmd.Parameters.Add(get_param("@client_id", string.Format("TD{0}", DateTime.Today.ToString("yyMMdd")), DbType.String, 255));
            cmd.Parameters.Add(get_param("@address", "Крылатская ул.", DbType.String, 255));
            cmd.Parameters.Add(get_param("@time_put_min", zakaz.Time, DbType.Time, 0));
            cmd.Parameters.Add(get_param("@time_put_max", zakaz.Time, DbType.Time, 0));
            cmd.Parameters.Add(get_param("@date_putn", zakaz.Date, DbType.Date, 0));
            cmd.Parameters.Add(get_param("@vlog", "Конверты с договорами, см. Вложения, запись не Удалять!", DbType.String, 255));
            mySqlConnection.Open();
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();

            address = GetAddressByZakaz(zakaz);
            if (address != null)
                return address;
            else
                return null;
        }

        public void InsertItemsToAddress(Address address, string PacketNumber)
        {
            if (address == null)
                return;

            MySqlCommand cmd = new MySqlCommand(sqlInsertBoxes, mySqlConnection);
            cmd.Parameters.Add(get_param("@address", address.ID, DbType.UInt32, 0));
            cmd.Parameters.Add(get_param("@name", vlogText + PacketNumber, DbType.String, 255));

            mySqlConnection.Open();
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();

            cmd = null;
            cmd = new MySqlCommand(sqlUpdateAddress, mySqlConnection);
            cmd.Parameters.Add(get_param("@code", address.ID, DbType.UInt32, 0));
            mySqlConnection.Open();
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        public bool CheckPacketSend(string PacketNumber)
        {
            if (mySqlConnection == null)
                CheckConnection();

            MySqlCommand cmd = new MySqlCommand(sqlGetBoxes, mySqlConnection);
            cmd.Parameters.Add(get_param("@name", vlogText + PacketNumber, DbType.String, 100));
            mySqlConnection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            bool result = false;
            while (dr.Read())
            {
                result = true;
                break;
            }
            mySqlConnection.Close();
            return result;
        }
    }
}
