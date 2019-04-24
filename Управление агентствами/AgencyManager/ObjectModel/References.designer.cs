﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgencyManager.ObjectModel
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="lanta")]
	public partial class ReferencesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public ReferencesDataContext() : 
				base(global::AgencyManager.Properties.Settings.Default.lantaConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ReferencesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReferencesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReferencesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReferencesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<MinimumDate> MinimumDates
		{
			get
			{
				return this.GetTable<MinimumDate>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class MinimumDate
	{
		
		private System.Nullable<System.DateTime> _NewDate;
		
		private System.Nullable<System.DateTime> _MaxTempDog;
		
		private System.Nullable<System.DateTime> _MaxLastDog;
		
		private System.Nullable<System.DateTime> _MinDateCreate;
		
		private System.Nullable<System.DateTime> _LastDogovor;
		
		public MinimumDate()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NewDate")]
		public System.Nullable<System.DateTime> NewDate
		{
			get
			{
				return this._NewDate;
			}
			set
			{
				if ((this._NewDate != value))
				{
					this._NewDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaxTempDog")]
		public System.Nullable<System.DateTime> MaxTempDog
		{
			get
			{
				return this._MaxTempDog;
			}
			set
			{
				if ((this._MaxTempDog != value))
				{
					this._MaxTempDog = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaxLastDog")]
		public System.Nullable<System.DateTime> MaxLastDog
		{
			get
			{
				return this._MaxLastDog;
			}
			set
			{
				if ((this._MaxLastDog != value))
				{
					this._MaxLastDog = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MinDateCreate")]
		public System.Nullable<System.DateTime> MinDateCreate
		{
			get
			{
				return this._MinDateCreate;
			}
			set
			{
				if ((this._MinDateCreate != value))
				{
					this._MinDateCreate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastDogovor")]
		public System.Nullable<System.DateTime> LastDogovor
		{
			get
			{
				return this._LastDogovor;
			}
			set
			{
				if ((this._LastDogovor != value))
				{
					this._LastDogovor = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
