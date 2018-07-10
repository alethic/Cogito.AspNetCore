using System;

using Microsoft.AspNetCore.Http;

namespace Cogito.AspNetCore
{

    public static class PathStringExtensions
    {

        /// <summary>
        /// Determines whether the end of this <see cref="PathString"/> instance matches the specified <see cref="PathString"/>.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool EndsWithSegments(this PathString path, PathString other)
        {
            return EndsWithSegments(path, other, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines whether the end of this <see cref="PathString"/> instance matches the specified <see cref="PathString"/> when
        /// using the specified comparison option.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="other"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static bool EndsWithSegments(this PathString path, PathString other, StringComparison comparisonType)
        {
            var value1 = path.Value ?? string.Empty;
            var value2 = other.Value ?? string.Empty;

            if (value1.EndsWith(value2, comparisonType))
            {
                return value1.Length == value2.Length || value1[value2.Length] == '/';
            }

            return false;
        }

        /// <summary>
        /// Determines whether the end of this <see cref="PathString"/> instance matches the specified <see cref="PathString"/> when compared
        /// returns the remaining segments.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="other"></param>
        /// <param name="remaining"></param>
        /// <returns></returns>
        public static bool EndsWithSegments(this PathString path, PathString other, out PathString remaining)
        {
            return EndsWithSegments(path, other, StringComparison.OrdinalIgnoreCase, out remaining);
        }

        /// <summary>
        /// Determines whether the end of this <see cref="PathString"/> instance matches the specified <see cref="PathString"/> when compared
        /// using the specified comparison option and returns the remaining segments.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="other"></param>
        /// <param name="comparisonType"></param>
        /// <param name="remaining"></param>
        /// <returns></returns>
        public static bool EndsWithSegments(this PathString path, PathString other, StringComparison comparisonType, out PathString remaining)
        {
            var value1 = path.Value ?? string.Empty;
            var value2 = other.Value ?? string.Empty;

            if (value1.EndsWith(value2, comparisonType))
            {
                if (value1.Length == value2.Length)
                {
                    remaining = PathString.Empty;
                    return true;
                }
                else
                {
                    remaining = value1.Substring(0, value1.Length - value2.Length);
                    return true;
                }
            }

            return false;
        }

    }

}
