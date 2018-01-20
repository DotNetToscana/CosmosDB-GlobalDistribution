# Azure Cosmos DB - Global Distribution

Do you want to try a Global Distribution scenario with Azure Cosmos DB and Azure App Service?

This repo is perfect for you!


### CosmosDBGlobalDistribution project

We have create a simple Asp.Net Core Web Application with only one page.

![Image](./Files/Img01.png)

In this page you can find, starting from the top of the page to bottom:
- The base url of the Web App
- The "Enable Read preferences" Checkbox
- A Simple Graph. The Web App makes an Async call using jQuery to retreive an amount of data stored on Azure Cosmos DB. So in the X axis there is the timestamp of the call (`datetime`), on the Y axis there is the response time (`milliseconds`)
- The average time of responses 


### Azure Demo Environment

You can create a test scenario deploying **AzureDemoEnv** Azure Resource group project.

- **[Here](https://docs.microsoft.com/en-us/azure/azure-resource-manager/vs-azure-tools-resource-groups-deployment-projects-create-deploy#deploy-the-resource-group-project-to-azure)** you can find how to deploy. 

You have to choose 3 parameters:

![Image](./Files/Img02.png)

1. CosmosDBAccountName: The name of your Cosmos DB. The procedure will create 1 Cosmos DB Instance with Mongo DB.
2. AppServicePlanPrefix: the prefix of your App Service Plans. 
The deploy will create 4 App Service Plan, one for each region from `West Europe`, `West US`, `Brazil South`, `Australia Southeast` with the name, respectively `[AppServicePrefix]AppSPWestEurope`,`[AppServicePrefix]AppSPWestUS`,`[AppServicePrefix]AppSPBrasilSouth` and `[AppServicePrefix]AppSPAustraliaSoutheast`. Those 4 Service Plan will have the Free Plan selected.
At the same time, the procedure will create 4 App Service, one for each region. Their name will be `[AppServicePrefix]WebWestEurope`,`[AppServicePrefix]WebWestUS`,`[AppServicePrefix]WebBrasilSouth` and `[AppServicePrefix]WebAustraliaSoutheast`.
3. CosmosDBWriteRegion: The write region for the Cosmos DB

```markdown
# Warning! Publishing this Environment you may incur Cosmos DB charges
```

Once the deployment is finished, you have to:

1. Connect to Cosmos DB, create a new collation and load the data from `restaurants.json` inside it. To upload data inside Cosmos DB, please [use this guide](https://github.com/MicrosoftDocs/azure-docs/blob/master/articles/cosmos-db/mongodb-migrate.md).
 
```markdown
For Example:

mongoimport.exe --host <your_hostname>:10255 -u <your_username> -p <your_password> --db <your_database> --collection <your_collection>  --file restaurants.json --numInsertionWorkers 1 --batchSize 1
```

2. Change the ConnectionString in the `appconfig.json` with the right Connection String for the Cosmos DB just created and `Database` name and `Collation` name in the same way.
3. Deploy **CosmosDBGlobalDistribution** Web App to each App Service created before.
4. Change the Urls inside `CosmosDBGlobalDistribution.html` file and open it with a browser


The result will be an image like the following.

![Image](./Files/Img10.png)

You will see the four Web Apps loaded.
You will also se that the write region will have the fastest response time.

Now you can go to the Azure Cosmos DB Azure Portal page and select **Replicate Data Globally**
![Image](./Files/Img03.png)

Try to check all the regions inside the photo below and click Save.

![Image](./Files/Img04.png)

Without reloading the `CosmosDBGlobalDistribution.html`, once the Replication is finished, you will see that the response time will not change.
This becouse MongoDB will still get data from the write region.

Now click on "Enable Read Preferences": in this way you are telling to MongoDB to get data from the nearest read region and now the respone time will be faster!