using System;
using System.Text;

namespace AudiosearchNet
{
    /// <summary>
    /// Extends String class adding some util methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts an input string to its equivalent string representation that is encoded with base-64 digits.
        /// </summary>
        /// <param name="input">An input string</param>
        /// <returns>A base-64 string.</returns>
        public static string ToBase64String(this string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        /// <summary>
        /// Converts an input string to a byte array;
        /// </summary>
        /// <param name="input">An input string.</param>
        /// <returns>A byte array.</returns>
        public static byte[] ToByteArray(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        /// <summary>
        /// Creates an Audiosear.ch API endpoind by some path.
        /// </summary>
        /// <param name="path">A valid path.</param>
        /// <returns>An Audiosear.ch API endpoind.</returns>
        public static string ToAudiosearchApiEndpoing(this string path)
        {
            if (path.StartsWith("/"))
            {
                return string.Concat(Config.API_URL, path);
            }

            throw new OperationCanceledException(
                    string.Format("\"{0}\" is not a valid endpoint path", path)
                );
        }
    }
}
