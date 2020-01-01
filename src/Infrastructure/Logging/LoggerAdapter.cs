using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void Information(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void Warning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }
    }
}
