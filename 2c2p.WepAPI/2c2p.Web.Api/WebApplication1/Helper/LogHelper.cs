using BussinesLogic.Entities.Helpers;

using Infrastructure.Helper;
using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace WebApi2c2p.Helper
{
    public class LogHelper
    {
        private static ILog logger = LogManager.GetLogger("RollingLogFileAppender");
        private static ILog logger2 = LogManager.GetLogger("ErrorsFileAppender");



        /// <summary>
        /// Log info method to record every log 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public static void LogInfo(HttpContext httpContext, string request, string response, LogTypeEnum logType)
        {
            string logTypeR = string.Empty;
            string message = string.Empty;
            if (logType.Equals(LogTypeEnum.info))
            {
                logTypeR = logType.ToString();
                message = "Success request";
            }
            else if (logType.Equals(LogTypeEnum.error))
            {
                logTypeR = logType.ToString();
                message = "Error";
            }

            Log(httpContext, request, logTypeR, message, null, response);
        }



        private static void Log(HttpContext httpContext, string request, string logTypeKey, string message, string exceptionType, string response)
        {
            string userName = httpContext.User?.Identity?.Name;
            string ip = httpContext.Request.PathBase;
            string url = httpContext.Request.Path;

       

            LogsDTO entity = new LogsDTO
            {
                LogTypeKey = logTypeKey,
                EventDate = DateTime.Now,
                Message = (message != "Success request") ? "Error" : message,
                Url = url,
                UserName = userName,
                IP = ip,
                request = request,
                ExceptionType = exceptionType,
                Response = response
            };

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var textLog = JsonConvert.SerializeObject(entity, settings);

            //_auditLogRepository.AddAsync(entityModel);

            LogWrite(textLog);

            Logs log = new Logs
            {
                Message = (message != "Success request") ? "Error" : message,
                ExceptionType = exceptionType,
                Response = response,
                Url = url
            };
            string resultLog = JsonOperations.ToJson(log);
            logger2.Info(resultLog);

            entity.DataContext = request;
            entity.Message = message;
            string result = JsonOperations.ToJson(entity);
            logger.Info(result);


        }

        private static string SizeResponse(string response)
        {
            int maxLength = 200;
            string resultResponse = string.Empty;
            if (response.Length > maxLength)
            {
                resultResponse = response.Substring(0, maxLength);
            }

            return resultResponse;
        }




        public static void LogWrite(string logMessage)
        {
            AppSettings configValue = new AppSettings();
            string m_exePath = new string(configValue.ReadConfig("Logger", "path").ToString());


            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log_" + DateTime.Now.ToString("MM-dd-yyyy") + ".txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}