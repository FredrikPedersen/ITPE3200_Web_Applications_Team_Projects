using System;
using System.IO;

namespace Utilities.ErrorLogging
{
    public class Logger
    {
        private string _filePath = @".\Files\Errors\Error.txt";

        public void LoggError(string error)
        {
            if (File.Exists(_filePath))
            {
                using (StreamWriter writer = new StreamWriter(_filePath, append: true))
                {
                    writer.WriteLine("------------------- START ERROR LOG -------------------");
                    writer.WriteLine("Date and Time of occurence: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                    writer.WriteLine("Error Message: " + error.ToString());
                    writer.WriteLine("------------------- END ERROR LOG -------------------");
                    writer.Close();

                }
            }
        }
    }
}