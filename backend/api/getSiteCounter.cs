using System.Configuration;
using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Azure.Functions;



namespace Company.Function
{
    public class getSiteCounter
    {
        private readonly ILogger<getSiteCounter> _logger;

        public getSiteCounter(ILogger<getSiteCounter> logger)
        {
            _logger = logger;
        }

        [Function("getSiteCounter")]
        public HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req,
            [CosmosDBInput(databaseName:"websitecounter", containerName:"c1", Connection = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter count)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");


            var jsonToReturn = JsonConvert.SerializeObject(count);
            jsonToReturn = "15";

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK){
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
