using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using SecretSantaTest.Shared;

namespace SecretSantaTest.API
{
    public static class SecretSantaFunctions
    {
        [FunctionName("GetAllFriends")]
        public static IActionResult GetAllFriends(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            HttpRequest req,
            [CosmosDB(
                databaseName: "%MyDatabase%",
                collectionName: "%MyContainer%",
                ConnectionStringSetting = "CosmosDBConnectionString",
                SqlQuery = "SELECT * FROM c")]
                IEnumerable<FriendPresent> friendList, ILogger log)
        {
            return new OkObjectResult(friendList);
        }

        [FunctionName("UpdateFriend")]
        public async static Task<IActionResult> UpdateFriend(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "UpdateFriend/{id}")]
            HttpRequest req,
            [CosmosDB(
                databaseName: "%MyDatabase%",
                collectionName: "%MyContainer%",
                ConnectionStringSetting = "CosmosDBConnectionString",
                Id = "{id}")]IAsyncCollector<FriendPresent> friendOut, ILogger log)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            try
            {
                FriendPresent data = JsonConvert.DeserializeObject<FriendPresent>(requestBody);
                await friendOut.AddAsync(data);

                return new OkObjectResult(data);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

    }
}
