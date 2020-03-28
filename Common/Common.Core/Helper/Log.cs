using NLog;
using System;

namespace Common.Core.Helper
{
    public class Log
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Error(System.Exception ex) => Logger.Error(ex);
    }
}
