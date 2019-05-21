// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="SimpleLogger.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Riskified.SDK.Logging;

namespace Riskified.SDK.Sample
{
    public class SimpleExampleLogger : ILogger
    {
        public void Debug(string message)
        {
            Log(message, "DEBUG");
        }

        public void Debug(string message, Exception exception)
        {
            Debug($"{message}. Exception was: {exception.Message}. StackTrace: {exception.StackTrace}");
        }

        public void Info(string message)
        {
            Log(message, "INFO");
        }

        public void Info(string message, Exception exception)
        {
            Info($"{message}. Exception was: {exception.Message}. StackTrace: {exception.StackTrace}");
        }

        public void Error(string message)
        {
            Log(message, "ERROR");
        }

        public void Error(string message, Exception exception)
        {
            Error($"{message}. Exception was: {exception.Message}. StackTrace: {exception.StackTrace}");
        }

        public void Fatal(string message)
        {
            Log(message, "FATAL");
        }

        public void Fatal(string message, Exception exception)
        {
            Fatal($"{message}. Exception was: {exception.Message} StackTrace: {exception.StackTrace}");
        }

        private static void Log(string message, string level)
        {
            Console.WriteLine("\nLOG:: {0}  {1}  {2}", DateTime.Now, level, message);
        }
    }
}
