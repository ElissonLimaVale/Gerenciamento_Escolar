using KissLog;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.Extensions.Configuration;

namespace SGIEscolar.Data.Config
{
    public class LogConfig
    {
        public static void RegisterKissLogListeners(IConfiguration configuration)
        {
            KissLogConfiguration.Listeners.Add(new RequestLogsApiListener(new Application(
                configuration["KissLog.OrganizationId"],
                configuration["KissLog.ApplicationId"])     
            )
            {
                ApiUrl = configuration["KissLog.ApiUrl"]   
            });
        }
    }
}
