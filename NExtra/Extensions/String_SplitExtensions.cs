using System;
using System.Collections.Generic;
using System.Linq;

namespace NExtra.Extensions
{
	/// <summary>
	/// Split extension methods for System.String.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class String_SplitExtensions
    {
	    /// <summary>
		/// Split a string by a string rather than by a char.
		/// </summary>
		public static IEnumerable<string> Split(this string str, string separator)
        {
		    int offset;
		    var offsets = Split_CalculateOffsets(str, separator, out offset);
		    var result = Split_CalculateResult(str, separator, offset, offsets);

		    return new List<String>(result.AsEnumerable());
		}

	    /// <summary>
		/// Split a string by a string rather than by a char,
		/// then convert each list element to a certain type.
		/// </summary>
		public static IEnumerable<T> Split<T>(this string str, string separator, bool throwExceptionOnError = false)
		{
			var result = new List<T>();
			
			foreach (var element in str.Split(separator))
			{
                try { result.Add((T)Convert.ChangeType(element, typeof(T))); }
                catch (Exception) { if (throwExceptionOnError) throw; }
			}

			return result.AsEnumerable();
		}



	    /// <summary>
	    /// Calculate split offset data.
	    /// </summary>
	    private static int[] Split_CalculateOffsets(string str, string separator, out int offset)
	    {
	        offset = 0;

	        var index = 0;
	        var offsets = new int[str.Length + 1];

	        while (index < str.Length)
	        {
	            var indexOf = str.IndexOf(separator, index);
	            if (indexOf != -1)
	            {
	                offsets[offset++] = indexOf;
	                index = (indexOf + separator.Length);
	            }
	            else
	            {
	                index = str.Length;
	            }
	        }

	        return offsets;
	    }

	    /// <summary>
	    /// Calculate split result, using previously calculated offset data.
	    /// </summary>
	    private static IEnumerable<string> Split_CalculateResult(string str, string separator, int offset, IList<int> offsets)
	    {
	        //Init default result for zero offset
	        var result = new string[offset + 1];
	        result[0] = str;

	        //Calculate result for non-zero offset
	        if (offset != 0)
	        {
	            offset--;
	            result[0] = str.Substring(0, offsets[0]);
	            for (var i = 0; i < offset; i++)
	                result[i + 1] = str.Substring(offsets[i] + separator.Length, offsets[i + 1] - offsets[i] - separator.Length);
	            result[offset + 1] = str.Substring(offsets[offset] + separator.Length);
	        }

	        return result;
	    }
    }
}
