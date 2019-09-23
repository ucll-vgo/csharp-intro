using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public abstract class Logger
    {
        public abstract void Log(string message);

        public virtual void Close()
        {
            // NOP
        }
    }

    public class StreamLogger : Logger
    {
        private readonly StreamWriter writer;

        public StreamLogger(StreamWriter writer)
        {
            this.writer = writer;
        }

        public override void Log(string message)
        {
            this.writer.WriteLine(message);
            this.writer.Flush();
        }
    }

    public class FileLogger : StreamLogger
    {
        private readonly FileStream fileStream;

        public static Logger Create(string path)
        {
            var fileStream = File.OpenWrite(path);

            return new FileLogger(fileStream);
        }

        private FileLogger(FileStream fileStream)
            : base(new StreamWriter(fileStream))
        {
            this.fileStream = fileStream;
        }

        public override void Close()
        {
            this.fileStream.Close();
        }
    }

    public class NullLogger : Logger
    {
        public override void Log(string message)
        {
            // NOP
        }
    }

    public class LogBroadcaster : Logger
    {
        private readonly IList<Logger> loggers;

        public LogBroadcaster(IEnumerable<Logger> loggers)
        {
            this.loggers = loggers.ToList();
        }

        public override void Log(string message)
        {
            foreach ( var log in loggers )
            {
                log.Log(message);
            }
        }

        public override void Close()
        {
            foreach ( var log in loggers )
            {
                log.Close();
            }
        }
    }
}