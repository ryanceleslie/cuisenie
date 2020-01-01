using System;

namespace Core.Interfaces
{
    public interface IAppLogger<T>
    {
        void Information(string message, params object[] args);
        void Warning(string message, params object[] args);
        void Error(Exception exception, string message, params object[] args);
    }
}
