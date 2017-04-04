using System.Collections.Generic;
using System.Linq;

namespace AudiosearchNet
{
    /// <summary>
    /// Extends Dictionary class adding some util methods.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Converts a dictionary to a post data Key/Value pair style.
        /// </summary>
        /// <typeparam name="K">Type of keys.</typeparam>
        /// <typeparam name="V">Type of values.</typeparam>
        /// <param name="dictionary">a dictionary</param>
        /// <returns>A post data Key/Value pair style</returns>
        public static string ToPostData<K,V>(this Dictionary<K,V> dictionary)
        {
            if (dictionary.Count > 0)
            {
                return dictionary
                    .Select(
                        p => string.Concat(p.Key, "=", p.Value)
                    ).
                    Aggregate(
                        (current, next) => string.Concat(current, "&", next)
                    );
            }

            return null;
        }
    }
}
