using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebApi.Boilderplate.Helpers.Logging
{
    public class Log4NetExceptionLogger : IExceptionLogger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Log4NetExceptionLogger));

        public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            var message = new StringBuilder();

            if (context.Request != null)
            {
                if (context.Request.Method != null)
                    message.Append(" ").Append(context.Request.Method.Method);

                if (context.Request.RequestUri != null)
                    message.Append(" ").Append(context.Request.RequestUri.AbsoluteUri);
            }

            if (context.Exception != null && !string.IsNullOrEmpty(context.Exception.GetBaseException().Message))
                message.Append(" ").AppendLine(context.Exception.GetBaseException().Message);

            log.Error(message.ToString());
            
            return null;
        }
    }
}
