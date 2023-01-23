using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AuthencationDemo.Model.common;

namespace AuthencationDemo.Model
{
    public class AppLogger
    {
        public static void AuditRequest(string _Controller, string _Action, List<String> lstParam)
        {
            var _logger = Log.ForContext<AppLogger>();
            _logger.Information("----------------------- (User:" + AuthUser.UserId + ") -------------------------");
            _logger.Information("1. Controller: " + _Controller);
            _logger.Information("2. Action: " + _Action);
            _logger.Information("3. Request with Parameter");
            foreach (string item in lstParam)
            {
                _logger.Information(item);
            }
        }
        public static void AuditMessage(string _Message)
        {
            var _logger = Log.ForContext<AppLogger>();
            _logger.Information(_Message);
        }
        public static void ResponseAudit(BaseResponse objBaseResponse)
        {
            var _logger = Log.ForContext<AppLogger>();
            _logger.Information("4. Response/Exception");
            _logger.Information("Response Status:" + objBaseResponse.status);
            _logger.Information("Response Status Code:" + objBaseResponse.statusCode);
            if (objBaseResponse.responseContent != null)
                _logger.Information("Response Content:" + JsonConvert.SerializeObject(objBaseResponse.responseContent));
            _logger.Information("-----------------------       End          -------------------------");
        }
        public static void ExceptionLog(Exception ex)
        {
            var _logger = Log.ForContext<AppLogger>();
            _logger.Error("----------------------- (User:" + AuthUser.UserId + ") Start-------------------------");
            _logger.Error("Message: " + ex.Message);
            _logger.Error("InnerException: " + ex.InnerException);
            _logger.Error("StackTrace: " + ex.StackTrace);
            _logger.Error("Type: " + ex.GetType().ToString());
            _logger.Error("-----------------------End-------------------------");
        }
        public static void ExceptionLogWithString(Exception ex, string stringex)
        {
            var _logger = Log.ForContext<AppLogger>();
            _logger.Error("----------------------- (User:" + AuthUser.UserId + ") Start-------------------------");
            _logger.Error("Message: " + ex.Message);
            _logger.Error("Email: " + stringex);
            _logger.Error("InnerException: " + ex.InnerException);
            _logger.Error("StackTrace: " + ex.StackTrace);
            _logger.Error("Type: " + ex.GetType().ToString());
            _logger.Error("-----------------------End-------------------------");
        }
    }
}
