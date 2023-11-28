namespace PersonalSite.Tools {
    internal static class StringExtensions {

        /// <summary>
        /// Indicates whether the specified string is not null or not an empty string ("").
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is not null or not an empty string (""); otherwise, false.</returns>
        internal static bool IsNtEmptyNull(this string value) { 
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether the specified string is null or an empty string ("").
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        internal static bool IsEmptyNull(this string value) {
            return string.IsNullOrEmpty(value);
        }
    }
}
