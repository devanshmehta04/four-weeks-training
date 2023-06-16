namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
            string[] lines = { "1", "Se", "jikji" };
            // Set a variable to the Documents path.
            string docPath = "C:/Users/admin/Desktop/devansh/4 week/week-1/day-5/exercise-1/FileLoggerDisposableApp";
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "myfile.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
    }
}

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
        // Initialize StreamWriter instance
        _writer = new StreamWriter(filePath);
    }

        public void Dispose()
        {
        // Implement IDisposable pattern
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        {
            if (disposing)
            {
                _writer.Dispose();
                _writer = null;
            }
        }
    }

        public void Log(string message)
        {
    // Write message to the file
    _writer.WriteLine(message);
         }
   
}