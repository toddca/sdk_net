// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="LoggingServices.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;

namespace Riskified.SDK.Logging
{
    public static class LoggingServices
    {
        private static ILogger s_loggerProxy;
        //private static LoggingServices _sdkLogger;
        /*
        public static LoggingServices GetInstance()
        {
            return _sdkLogger ?? (_sdkLogger = new LoggingServices());
        }
        */

        public static void InitializeLogger(ILogger logger)
        {
            if (logger != null)
            {
                s_loggerProxy = logger;
            }
        }

        public static void Debug(string message)
        {
            s_loggerProxy?.Debug(message);
        }

        public static void Debug(string message, Exception exception)
        {
            s_loggerProxy?.Debug(message, exception);
        }

        public static void Info(string message)
        {
            s_loggerProxy?.Info(message);
        }

        public static void Info(string message, Exception exception)
        {
            s_loggerProxy?.Info(message, exception);
        }

        public static void Error(string message)
        {
            s_loggerProxy?.Error(message);
        }

        public static void Error(string message, Exception exception)
        {
            s_loggerProxy?.Error(message, exception);
        }

        public static void Fatal(string message)
        {
            s_loggerProxy?.Fatal(message);
        }

        public static void Fatal(string message, Exception exception)
        {
            s_loggerProxy?.Fatal(message, exception);
        }
    }
}
