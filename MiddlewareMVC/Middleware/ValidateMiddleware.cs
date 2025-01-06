
using System.Buffers;
using System.Text.Json;

using Azure.Core;

namespace MiddlewareMVC.Loggers
{
    public class ValidateMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //Check on request
            //Check if safe
            if (ValidateName(context.Request))
            {
                //UNSAFE! RETRY!

                context.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                context.Response.ContentType = "text/string";
                await context.Response.Body.WriteAsync("Unaccepted name found! Try again!".Select(x=> Convert.ToByte(x)).ToArray());

                return;
            }


            await next.Invoke(context); //Continue to next middleware/code

        }

        public bool ValidateName(HttpRequest req)
        {
            if (req.Path == "/Adventurer" && req.Method == HttpMethods.Post)
            { 
                req.EnableBuffering(); //Allows body to be read multiple times

                var rawRequestBody = new StreamReader(req.Body).ReadToEndAsync().Result;
                //Get content to  validate

                //var a = JsonSerializer.Deserialize<Adventurer>(rawRequestBody);

                List<string> bannedWords = ["pomeranian",
                    "bruno",
                    "voldemort",
                    "rickroll"];

                req.Body.Position = 0; //Reset after reading
                return bannedWords.Any(w => rawRequestBody.ToLower().Contains(w));

            }

            return false;
        }
    }
}
