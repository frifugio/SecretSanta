# A Secret (Static) Santa :santa:

A template repository you can use to create (entirely free!) an Azure Static Web App, with Blazor WebAssembly front-end, and Azure Functions + CosmosDB backend; in order to develop a webpage to organize your Secret Santa!

## Template content

This solution is based on 3 projects, as the Azure Static Web App service expects:

* **SecretSanta.API** - Azure Function that will serve as the backend for our webpage, which will connect to CosmosDB to retrieve and update data.
* **SecretSanta.Client** - Blazor WebAssembly project used for our Static Web App front-end.
* **SecretSanta.Shared** - Class library in .NET Standard that contains the model definition used by both the API and the Client project.

## How to use it

To start using it you just need to press the green button _"Use this template"_ on top of the file list and create your repository.

Then, after cloning the project locally you will need just a simple step to be able to develop and debug easily on your PC, and to rebuild the connection to your personal Azure Resources.

So, add a file named **local.settings.json** into **SecretSantaTest.API/**, containing the following code:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "MyDatabase": "REPLACE-WITH-DATABASE-NAME",
    "MyContainer": "REPLACE-WITH-CONTAINER-NAME",
    "CosmosDBConnectionString": "REPLACE-WITH-COSMOSDB-CONNECTION-STRING"
  },
  "Host": {
    "LocalHttpPort": 7071,
    "CORS": "*",
    "CORSCredentials": false
  }

}
```

Replace the values of _MyDatabase_, _MyContainer_ and _CosmosDBConnectionString_ to the respective values of your personal Azure resources that tou will create on the next step.

> At the moment in the web app there is not a way to create new _friends_, so for each one you will need to manually add them to CosmosDB as a json element with just a _name_ property.

### Azure resources

As anticipated, you can provision everything with the Azure trial account ([how to create one](https://azure.microsoft.com/it-it/free/)).  
Then just follow these documentation links to create the Azure resources:

* [CosmosDB](https://docs.microsoft.com/en-us/azure/cosmos-db/sql/create-cosmosdb-resources-portal)
  * > You can use the free tier, but remember that you can have only one free tier database, in the case you already have one, just create a new container in it
* [Azure Static Web App](https://docs.microsoft.com/en-us/azure/static-web-apps/deploy-blazor#create-a-static-web-app)
  * > Use the entire name _SecretSanta.Client_ for the App location property, and _SecretSanta.API_ for the API property during the initial setup
* [Configure settings of the Web App](https://docs.microsoft.com/en-us/azure/static-web-apps/application-settings#configure-application-settings)
  * > Where you will insert the same key and values you'll replace on the JSON file described before.

## Thanks

I would like to thank **[@Guenda_S](https://twitter.com/Guenda_S)** for the original idea she developed in python (you can find it [here](https://github.com/guendas/secretsanta)), which I translated into these Microsoft technologies.  
P.S. Now you know to who is referred the easter egg image you will find in the repo :roll_eyes: :grin:

## Contacts

If you have any question or idea to improve this repository please feel free to write it in the [Discussion tab](https://github.com/frifugio/secretSanta-AzureStaticWebApp/discussions) :speech_balloon:, reach me on Twitter **[@Dragonriffi92](https://twitter.com/Dragonriffi92)** :dragon_face:, or even directly contribute to the repo! :man_technologist:
