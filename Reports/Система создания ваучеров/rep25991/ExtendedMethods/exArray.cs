using System;

namespace rep25991
{
    public static class ArrayExM
    {
        public static string[] RemoveBlankLines(this string[] value)
        {
            while (value.Length > 0 && value[value.Length - 1].RemoveSpace() == "")
            {
                Array.Resize(ref value, value.Length - 1);
            }
            return value;
        }
    }
}
