
namespace MiddlewareMVC.Loggers
{
    public class LoggerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //log request
            logReq(context.Request);

            await next.Invoke(context); //Continue to next middleware/code

            //log responce
            logResp(context.Response);
        }

        private string LogFile = @$"{Environment.CurrentDirectory}/ServerLogs.txt";

        private void logReq(HttpRequest req)
        {
            File.AppendAllLines(LogFile, [$"{DateTime.UtcNow} | {req.Path} | {req.Method}"]);
        }

        private void logResp(HttpResponse resp)
        {
            File.AppendAllLines(LogFile, [$"{resp.StatusCode}"]);
        }
    }
}
