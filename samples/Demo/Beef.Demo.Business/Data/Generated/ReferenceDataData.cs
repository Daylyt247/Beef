/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef.Business;
using Beef.Mapper.Converters;
using RefDataNamespace = Beef.Demo.Common.Entities;
using Beef.Data.Database;
using Beef.Data.EntityFrameworkCore;
using Beef.Data.Cosmos;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the <b>ReferenceData</b> database access.
    /// </summary>
    public partial class ReferenceDataData : IReferenceDataData
    {
        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.Gender"/> objects.
        /// </summary>
        /// <returns>A <see cref="RefDataNamespace.GenderCollection"/>.</returns>
        public async Task<RefDataNamespace.GenderCollection> GenderGetAllAsync()
        {
            var __coll = new RefDataNamespace.GenderCollection();
            await DataInvoker.Default.InvokeAsync(this, async () => 
            {
                await Database.Default.GetRefDataAsync<RefDataNamespace.GenderCollection, RefDataNamespace.Gender>(__coll, "[Ref].[spGenderGetAll]", "GenderId", additionalProperties: (dr, item, fields) =>
                {
                    item.AlternateName = dr.GetValue<string>("AlternateName");
                });
            }, BusinessInvokerArgs.RequiresNewAndTransactionSuppress);

            return __coll;
        }

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.EyeColor"/> objects.
        /// </summary>
        /// <returns>A <see cref="RefDataNamespace.EyeColorCollection"/>.</returns>
        public async Task<RefDataNamespace.EyeColorCollection> EyeColorGetAllAsync()
        {
            var __coll = new RefDataNamespace.EyeColorCollection();
            await DataInvoker.Default.InvokeAsync(this, async () => { EfDb.Default.Query(EyeColorMapper.CreateArgs()).SelectQuery(__coll); await Task.CompletedTask; }, BusinessInvokerArgs.RequiresNewAndTransactionSuppress);
            return __coll;
        }

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.PowerSource"/> objects.
        /// </summary>
        /// <returns>A <see cref="RefDataNamespace.PowerSourceCollection"/>.</returns>
        public async Task<RefDataNamespace.PowerSourceCollection> PowerSourceGetAllAsync()
        {
            var __coll = new RefDataNamespace.PowerSourceCollection();
            await DataInvoker.Default.InvokeAsync(this, async () => { CosmosDb.Default.ValueQuery(PowerSourceMapper.CreateArgs("RefData")).SelectQuery(__coll); await Task.CompletedTask; }, BusinessInvokerArgs.RequiresNewAndTransactionSuppress);
            return __coll;
        }

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.Company"/> objects.
        /// </summary>
        /// <returns>A <see cref="RefDataNamespace.CompanyCollection"/>.</returns>
        public async Task<RefDataNamespace.CompanyCollection> CompanyGetAllAsync()
        {
            var __coll = new RefDataNamespace.CompanyCollection();
            await DataInvoker.Default.InvokeAsync(this, async () => await this.CompanyGetAll_OnImplementation(__coll).ConfigureAwait(false), BusinessInvokerArgs.RequiresNewAndTransactionSuppress);
            return __coll;
        }

        /// <summary>
        /// Provides the <see cref="RefDataNamespace.EyeColor"/> entity and Entity Framework <see cref="EfModel.EyeColor"/> property mapping.
        /// </summary>
        public static EfDbMapper<RefDataNamespace.EyeColor, EfModel.EyeColor> EyeColorMapper = EfDbMapper.CreateAuto<RefDataNamespace.EyeColor, EfModel.EyeColor>()
            .HasProperty(s => s.Id, d => d.EyeColorId)
            .AddStandardProperties();

        /// <summary>
        /// Provides the <see cref="RefDataNamespace.PowerSource"/> entity and Cosmos <see cref="RefDataNamespace.PowerSource"/> property mapping.
        /// </summary>
        public static CosmosDbMapper<RefDataNamespace.PowerSource, RefDataNamespace.PowerSource> PowerSourceMapper = CosmosDbMapper.CreateAuto<RefDataNamespace.PowerSource, RefDataNamespace.PowerSource>()
            .AddStandardProperties();
    }
}

#nullable restore