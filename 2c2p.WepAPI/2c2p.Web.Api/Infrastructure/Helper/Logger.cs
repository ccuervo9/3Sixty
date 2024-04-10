using System;
using Infrastructure.Helper;
using log4net;

namespace WebApi2c2p.Helper
{
    public static class Loggers
    {
        private static log4net.ILog Log { get; set; }

        static Loggers()
        {
            Log = log4net.LogManager.GetLogger(typeof(Loggers));
        }

        public static void Error(object msg)
        {
            Log.Error(msg);
        }

        public static void Error(object msg, Exception ex)
        {
            Log.Error(msg, ex);
        }

        public static void Error(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public static void Info(object msg)
        {
            Log.Info(msg);
        }
    }
}
