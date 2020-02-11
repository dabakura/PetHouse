using log4net;
using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PetHouse.API.Models
{
    public class Log
    {
        private static readonly Log _instance = new Log();
        protected ILog monitoringLogger;
        protected static ILog debugLogger;

        private Log()
        {
            debugLogger = LogManager.GetLogger("DebugLogger");
        }

        private void SetMonitoring(Type type)
        {
            _instance.monitoringLogger = LogManager.GetLogger(type);
        }
        /// <summary>  
        /// Used to log Debug messages in an explicit Debug Logger  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Debug(string message)
        {
            debugLogger.Debug(message);
        }


        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Debug(string message, System.Exception exception)
        {
            debugLogger.Debug(message, exception);
        }

        private void CreateLog(Type type, EventLogEntryType entryType, string message, Exception exception = null)
        {
            _instance.SetMonitoring(type);
            ConsoleLog(entryType, type.Name, message, exception);
            switch (entryType)
            {
                case EventLogEntryType.Error:
                    ErrorLog(message, exception);
                    break;
                case EventLogEntryType.Warning:
                    WarnLog(message, exception);
                    break;
                case EventLogEntryType.Information:
                    InfoLog(message, exception);
                    break;
                case EventLogEntryType.FailureAudit:
                    FatalLog(message, exception);
                    break;
                default:
                    InfoLog(message, exception);
                    break;
            }
        }
        public void ConsoleLog(EventLogEntryType type, string name, string message, Exception exception)
        {
            if (exception != null)
                message += "\n" + exception.Message;
            System.Diagnostics.Debug.WriteLine(
                DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToShortTimeString() + " " +
                type.ToString() + " " +
                name + " - " +
                message);
        }

        public void InfoLog(string message, Exception exception)
        {
            if (exception == null)
                _instance.monitoringLogger.Info(message);
            else _instance.monitoringLogger.Info(message, exception);
        }

        public void WarnLog(string message, Exception exception)
        {
            if (exception == null)
                _instance.monitoringLogger.Warn(message);
            else _instance.monitoringLogger.Warn(message, exception);
        }

        public void ErrorLog(string message, Exception exception)
        {
            if (exception == null)
                _instance.monitoringLogger.Error(message);
            else _instance.monitoringLogger.Error(message, exception);
        }

        public void FatalLog(string message, Exception exception)
        {
            if (exception == null)
                _instance.monitoringLogger.Fatal(message);
            else _instance.monitoringLogger.Fatal(message, exception);
        }
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Info<T>(string message)
        {
            _instance.CreateLog(typeof(T), EventLogEntryType.Information, message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Info<T>(string message, Exception exception)
        {
            _instance.CreateLog(typeof(T), EventLogEntryType.Information, message, exception);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Warn<T>(string message)
        {
            _instance.CreateLog(typeof(T), EventLogEntryType.Warning, message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Warn<T>(string message, Exception exception)
        {
            _instance.CreateLog(typeof(T), EventLogEntryType.Warning, message, exception);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Error<T>(string message)
        {
            _instance.CreateLog(typeof(T), EventLogEntryType.Error, message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Error<T>(string message, Exception exception)
        {
            _instance.CreateLog(typeof(T), EventLogEntryType.Error, message, exception);
        }


        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Fatal<T>(string message)
        {
            _instance.CreateLog(typeof(T), EventLogEntryType.FailureAudit, message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Fatal<T>(string message, Exception exception)
        {
            _instance.CreateLog(typeof(T), EventLogEntryType.FailureAudit, message, exception);
        }

    }
}