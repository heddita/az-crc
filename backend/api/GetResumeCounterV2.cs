using System;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
namespace Company.Function
{
    public class GetResumeCounterV2
    {
        private readonly ILogger<GetResumeCounterV2> _logger;
        private readonly CosmosClient _cosmosClient;
        // Constructor where CosmosClient and ILogger are injected
        public GetResumeCounterV2(ILogger<GetResumeCounterV2> logger, CosmosClient cosmosClient)
        {
            _logger = logger;
            _cosmosClient = cosmosClient;
        }
        // Function to get and update the counter from Cosmos DB
        [Function("GetResumeCounterV2")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var container = _cosmosClient.GetContainer("AzureResume", "Counter");
           
            try
            {
                // Read the current counter from Cosmos DB
                var response = await container.ReadItemAsync<Counter>("1", new PartitionKey("1"));
                var counter = response.Resource;
               
                // Update the counter
                counter.Count += 1;
                await container.ReplaceItemAsync(counter, counter.Id, new PartitionKey(counter.Id));
                // Create the HTTP response
                var httpResponse = req.CreateResponse(HttpStatusCode.OK);
                httpResponse.Headers.Add("Content-Type", "application/json; charset=utf-8");
                await httpResponse.WriteStringAsync(JsonConvert.SerializeObject(counter));
                return httpResponse;
            }
            catch (Exception ex)
            {
                // Log the error and send an internal server error response
                _logger.LogError($"Error processing request: {ex.Message}");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("An error occurred processing your request.");
                return errorResponse;
            }
        }
    }
}