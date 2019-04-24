using System;
using System.Collections;
using System.ComponentModel;

namespace rep25991
{
    public static class exPropertiesToHashtable
    {
        public static Hashtable PropertyToHashTable(this Type value)
        {
            Hashtable result = new Hashtable();
            foreach (PropertyDescriptor y in TypeDescriptor.GetProperties(value))
            {
                if (!string.IsNullOrEmpty(y.DisplayName) && y.DisplayName != y.Name)
                    result.Add(y.DisplayName, y.Name);
            }
            return result;
        }
    }
}
