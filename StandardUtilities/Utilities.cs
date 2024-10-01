namespace StandardUtilities
{
    public class Utilities :IDisposable
    {
        /// <summary>
        /// CleanString - to remove any characters that will cause issues when submitting to  SQL.
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public static string? CleanString(string fieldValue)
        {
            return fieldValue.Replace("'", "").Replace("\"", "") ?? null;
        }

        /// <summary>
        /// Format the date
        /// </summary>
        /// <param name="utcNow"></param>
        /// <returns></returns>
        public static DateTime? FormatCurrentDate() 
        { 
            return DateTime.UtcNow; 
        }
        
        //Part of utilities

        /// <summary>
        /// Clean Guid to get the GUID
        /// </summary>
        /// <returns></returns>
        public static string GetGUID() { return Guid.NewGuid().ToString(); } // #11

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
