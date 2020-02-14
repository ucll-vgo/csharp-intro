using System;
using System.IO;
using System.Collections.Generic;
using Xunit;

namespace LoggerExercise
{
    public class UnitTests
    {
        [Fact]
        public void StreamLoggerTest()
        {
            const string message = "Test";
            var memoryStream = new MemoryStream();
            var reader = new StreamReader(memoryStream);
            var writer = new StreamWriter(memoryStream);
            var logger = new StreamLogger(writer);

            logger.Log(message);
            logger.Close();

            memoryStream.Seek(0, SeekOrigin.Begin);
            Assert.Equal(message, reader.ReadLine());
            Assert.Null(reader.ReadLine());
        }

        [Fact]
        public void NullLoggerTest()
        {
            const string message = "Test";
            var logger = new NullLogger();

            logger.Log(message);
            logger.Close();
            // Just checking that it compiles
        }

        [Fact]
        public void BroadcasterTest()
        {
            const string message = "Testestest";
            var memoryStream1 = new MemoryStream();
            var reader1 = new StreamReader(memoryStream1);
            var writer1 = new StreamWriter(memoryStream1);
            var logger1 = new StreamLogger(writer1);

            var memoryStream2 = new MemoryStream();
            var reader2 = new StreamReader(memoryStream2);
            var writer2 = new StreamWriter(memoryStream2);
            var logger2 = new StreamLogger(writer2);

            var logger = new LogBroadcaster(new List<Logger>() { logger1, logger2 });

            logger.Log(message);
            logger.Close();

            memoryStream1.Seek(0, SeekOrigin.Begin);
            Assert.Equal(message, reader1.ReadLine());
            Assert.Null(reader1.ReadLine());

            memoryStream2.Seek(0, SeekOrigin.Begin);
            Assert.Equal(message, reader2.ReadLine());
            Assert.Null(reader2.ReadLine());
        }

        [Fact]
        public void FileLoggerTest()
        {
            const string message = "Testerydoo";
            var filename = Path.GetTempFileName();
            var logger = FileLogger.Create(filename);

            logger.Log(message);
            logger.Close();

            var contents = File.ReadAllText(filename);
            Assert.Equal(message, contents.Trim());
        }
    }

    /*
        TestLogger checks that Close() has a default implementation.
     */
    class TestLogger : Logger
    {
        public override void Log(string message) { }
    }
}
