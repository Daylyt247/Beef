﻿#if (implement_database || implement_entityframework)
using Beef.Database.Core;
#endif
#if (implement_cosmos)
using Beef.Data.Cosmos;
#endif
using Beef.Test.NUnit;
#if (implement_cosmos)
using Microsoft.Extensions.Configuration;
using Cosmos = Microsoft.Azure.Cosmos;
#endif
using NUnit.Framework;
#if (implement_database || implement_entityframework)
using System.Reflection;
#endif
#if (!implement_httpagent)
using System.Threading.Tasks;
using Company.AppName.Api;
#endif
using Company.AppName.Common.Agents;
#if (implement_cosmos)
using Company.AppName.Business.Data;
using Company.AppName.Business.Entities;
#endif

namespace Company.AppName.Test.Apis
{
    [SetUpFixture]
    public class FixtureSetUp
    {
#if (implement_database || implement_entityframework)
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestSetUp.DefaultEnvironmentVariablePrefix = "AppName";
            TestSetUp.AddWebApiAgentArgsType<IAppNameWebApiAgentArgs, AppNameWebApiAgentArgs>();
            TestSetUp.DefaultExpectNoEvents = false;

            var config = AgentTester.BuildConfiguration<Startup>("AppName");

            TestSetUp.RegisterSetUp(async (count, _) =>
            {
                var args = new DatabaseExecutorArgs(
                    count == 0 ? DatabaseExecutorCommand.ResetAndDatabase : DatabaseExecutorCommand.ResetAndData,
                    config["ConnectionStrings:Database"],
                    typeof(Database.Program).Assembly, Assembly.GetExecutingAssembly()) 
                { UseBeefDbo = true };

                return await DatabaseExecutor.RunAsync(args).ConfigureAwait(false) == 0;
            });
        }
#endif
#if (implement_cosmos)
        private bool _removeAfterUse;
        private AppNameCosmosDb? _cosmosDb;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestSetUp.DefaultEnvironmentVariablePrefix = "AppName";
            TestSetUp.AddWebApiAgentArgsType<IAppNameWebApiAgentArgs, AppNameWebApiAgentArgs>();
            TestSetUp.DefaultExpectNoEvents = false;

            var config = AgentTester.BuildConfiguration<Startup>("AppName");

            TestSetUp.RegisterSetUp(async (count, _) =>
            {
                var cc = config.GetSection("CosmosDb");
                _removeAfterUse = config.GetValue<bool>("RemoveAfterUse");
                _cosmosDb = new AppNameCosmosDb(new Cosmos.CosmosClient(cc.GetValue<string>("EndPoint"), cc.GetValue<string>("AuthKey")), cc.GetValue<string>("Database"), createDatabaseIfNotExists: true);

                var rc = await _cosmosDb.ReplaceOrCreateContainerAsync(
                    new Cosmos.ContainerProperties
                    {
                        Id = "Person",
                        PartitionKeyPath = "/_partitionKey"
                    }, 400).ConfigureAwait(false);

                await rc.ImportBatchAsync<PersonTest, Person>("Person.yaml", "Person").ConfigureAwait(false);

                var rdc = await _cosmosDb.ReplaceOrCreateContainerAsync(
                    new Cosmos.ContainerProperties
                    {
                        Id = "RefData",
                        PartitionKeyPath = "/_partitionKey",
                        UniqueKeyPolicy = new Cosmos.UniqueKeyPolicy { UniqueKeys = { new Cosmos.UniqueKey { Paths = { "/type", "/value/code" } } } }
                    }, 400).ConfigureAwait(false);

                await rdc.ImportValueRefDataBatchAsync<PersonTest, ReferenceData>("RefData.yaml").ConfigureAwait(false);

                return true;
            });
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            if (_cosmosDb != null && _removeAfterUse)
                await _cosmosDb.Database.DeleteAsync().ConfigureAwait(false);
        }
#endif
#if (implement_httpagent || implement_none)
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestSetUp.DefaultEnvironmentVariablePrefix = "AppName";
            TestSetUp.AddWebApiAgentArgsType<IAppNameWebApiAgentArgs, AppNameWebApiAgentArgs>();
            TestSetUp.DefaultExpectNoEvents = false;
        }
#endif
    }
}