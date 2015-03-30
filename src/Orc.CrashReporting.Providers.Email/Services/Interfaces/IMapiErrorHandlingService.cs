namespace Orc.CrashReporting
{
    public interface IMapiErrorHandlingService
    {
        void HandleError(int errorCode);
    }
}