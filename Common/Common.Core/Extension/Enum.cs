using System;
using System.Collections.Generic;

namespace Common.Core.Extension
{
    public class Enum<T> where T : struct, IConvertible
    {
        public static IEnumerable<KeyValuePair<T?, string>> ToKeyValuePairList()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            IList<KeyValuePair<T?, string>> keyValuePairList = new List<KeyValuePair<T?, string>>();

            foreach (T item in System.Enum.GetValues(typeof(T)))
            {
                KeyValuePair<T?, string> keyValuePair = new KeyValuePair<T?, string>(item, item.ToString());
                keyValuePairList.Add(keyValuePair);
            }

            return keyValuePairList;
        }

        public static IEnumerable<T> ToList()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            IList<T> list = new List<T>();

            foreach (T item in System.Enum.GetValues(typeof(T)))
            {
                list.Add(item);
            }

            return list;
        }
    }
}