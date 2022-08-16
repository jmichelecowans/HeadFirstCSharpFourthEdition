using System;
using System.IO;

namespace ExceptionFiltersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = "No first line was read";
            try
            {
                var lines = File.ReadAllLines(args[0]);
                firstLine = (lines.Length > 0) ? lines[0] : "The file was empty";
            }
            catch (IndexOutOfRangeException) when (firstLine != null)
            {
                Console.Error.WriteLine("Please specify a filename.");
            }
            catch (FileNotFoundException) when (firstLine != null)
            {
                Console.Error.WriteLine("Unable to find file: {0}", args[0]);
            }
            catch (UnauthorizedAccessException ex) when (firstLine != null)
            {
                Console.Error.WriteLine("File {0} could not be accessed: {1}"
                    , args[0], ex.Message);
            }
            catch (IOException ex) when (firstLine != null)
            {
                Console.Error.WriteLine("I/O Error while reading the file: {0}", ex.Message);
            }
            catch (Exception ex) when (firstLine != null)
            {
                Console.Error.WriteLine("Error while reading the file: {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine(firstLine);
            }
        }
    }
}
