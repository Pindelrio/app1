using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;

namespace Company.Function
{
    public static class HttpTrigger1
    {
        private static readonly HttpClient httpClient = new HttpClient();
        [FunctionName("HttpTrigger1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

           string requestBody = await new StreamReader(req.Body).ReadLineAsync();

           StringContent content = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);

           var response = await httpClient.PostAsync("https://ddt11f1.azurewebsites.net/api/HttpTrigger1?code=v3OohZqW5_GQb7ObYGQUU26wYcVitbRsrwt1SAHjIIEaAzFuFy3s2Q==", content);
           
           var responseMessage = await response.Content.ReadAsStringAsync();

           Console.WriteLine($"--> Response: {responseMessage}");

           return new OkObjectResult("Payload Recieved");

        }
    }
}
