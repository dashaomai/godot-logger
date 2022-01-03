using System;
using Godot;

namespace GodotLogger
{
    /// <summary> 自定义 Godot 日志工具
    public class Logger
    {
        private readonly string catalog;

        internal Logger(string catalog)
        {
            this.catalog = catalog;
        }

        private void Log(string level, string message)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string content = $"[{now}] [{level}] <{this.catalog}> - {message}";
            GD.Print(content);

            switch (level)
            {
                case "WARN":
                    GD.PushWarning($"<{this.catalog}> - {message}");
                    break;

                case "ERROR":
                    GD.PushError($"<{this.catalog}> - {message}");
                    break;
            }
        }

        public void Debug(string message)
        {
            this.Log("DEBUG", message);
        }

        public void Info(string message)
        {
            this.Log("INFO", message);
        }

        public void Warn(string message)
        {
            this.Log("WARN", message);
        }

        public void Error(string message)
        {
            this.Log("ERROR", message);
        }
    }

    public static class LoggerHelper
    {
        public static Logger GetLogger(Type type)
        {
            return new Logger(type.FullName);
        }
    }
}