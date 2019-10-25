using System;
using System.IO;

namespace Utilities.Logging
{
    public class ErrorLogger
    {
        private const string FilePath = @".\Files\Logs\errors.txt";

        public static void LogError(Exception exception)
        {
            
            if (!File.Exists(FilePath))
            {
                using (var stream = File.Create(FilePath)) { }
            }

            using (var writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine("------------------- START ERROR LOG -------------------");
                writer.WriteLine("Time of occurence: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

                while (exception != null) 
                {
                    writer.WriteLine( exception.GetType().FullName);
                    writer.WriteLine( "Message: " + exception.Message);
                    writer.WriteLine( "StackTrace: " + exception.StackTrace);

                    exception = exception.InnerException;
                }
                writer.WriteLine("------------------- END ERROR LOG -------------------");
                writer.WriteLine();
                writer.Close();
            }
        }
    }
}