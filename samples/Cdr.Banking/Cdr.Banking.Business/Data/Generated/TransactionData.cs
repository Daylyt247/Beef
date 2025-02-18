/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Data.Cosmos;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Cdr.Banking.Common.Entities;
using Mac = Microsoft.Azure.Cosmos;
using RefDataNamespace = Cdr.Banking.Common.Entities;

namespace Cdr.Banking.Business.Data
{
    /// <summary>
    /// Provides the <see cref="Transaction"/> data access.
    /// </summary>
    public partial class TransactionData : ITransactionData
    {
        private readonly ICosmosDb _cosmos;
        private readonly AutoMapper.IMapper _mapper;

        private Action<CosmosDbArgs>? _onDataArgsCreate;
        private Func<IQueryable<Model.Transaction>, string?, TransactionArgs?, CosmosDbArgs, IQueryable<Model.Transaction>>? _getTransactionsOnQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionData"/> class.
        /// </summary>
        /// <param name="cosmos">The <see cref="ICosmosDb"/>.</param>
        /// <param name="mapper">The <see cref="AutoMapper.IMapper"/>.</param>
        public TransactionData(ICosmosDb cosmos, AutoMapper.IMapper mapper)
            { _cosmos = Check.NotNull(cosmos, nameof(cosmos)); _mapper = Check.NotNull(mapper, nameof(mapper)); TransactionDataCtor(); }

        partial void TransactionDataCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Get transaction for account.
        /// </summary>
        /// <param name="accountId">The Account Id.</param>
        /// <param name="args">The Args (see <see cref="Entities.TransactionArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="TransactionCollectionResult"/>.</returns>
        public Task<TransactionCollectionResult> GetTransactionsAsync(string? accountId, TransactionArgs? args, PagingArgs? paging) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            TransactionCollectionResult __result = new TransactionCollectionResult(paging);
            var __dataArgs = CosmosDbArgs.Create(_mapper, "Transaction", __result.Paging!, new Mac.PartitionKey(accountId), onCreate: _onDataArgsCreate);
            __result.Result = _cosmos.Container<Transaction, Model.Transaction>(__dataArgs).Query(q => _getTransactionsOnQuery?.Invoke(q, accountId, args, __dataArgs) ?? q).SelectQuery<TransactionCollection>();
            return await Task.FromResult(__result).ConfigureAwait(false);
        });

        /// <summary>
        /// Provides the <see cref="Transaction"/> and Entity Framework <see cref="Model.Transaction"/> <i>AutoMapper</i> mapping.
        /// </summary>
        public partial class CosmosMapperProfile : AutoMapper.Profile
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CosmosMapperProfile"/> class.
            /// </summary>
            public CosmosMapperProfile()
            {
                var s2d = CreateMap<Transaction, Model.Transaction>();
                s2d.ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
                s2d.ForMember(d => d.AccountId, o => o.MapFrom(s => s.AccountId));
                s2d.ForMember(d => d.IsDetailAvailable, o => o.MapFrom(s => s.IsDetailAvailable));
                s2d.ForMember(d => d.Type, o => o.MapFrom(s => s.TypeSid));
                s2d.ForMember(d => d.Status, o => o.MapFrom(s => s.StatusSid));
                s2d.ForMember(d => d.Description, o => o.MapFrom(s => s.Description));
                s2d.ForMember(d => d.PostingDateTime, o => o.MapFrom(s => s.PostingDateTime));
                s2d.ForMember(d => d.ExecutionDateTime, o => o.MapFrom(s => s.ExecutionDateTime));
                s2d.ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount));
                s2d.ForMember(d => d.Currency, o => o.MapFrom(s => s.Currency));
                s2d.ForMember(d => d.Reference, o => o.MapFrom(s => s.Reference));
                s2d.ForMember(d => d.MerchantName, o => o.MapFrom(s => s.MerchantName));
                s2d.ForMember(d => d.MerchantCategoryCode, o => o.MapFrom(s => s.MerchantCategoryCode));
                s2d.ForMember(d => d.BillerCode, o => o.MapFrom(s => s.BillerCode));
                s2d.ForMember(d => d.BillerName, o => o.MapFrom(s => s.BillerName));
                s2d.ForMember(d => d.ApcaNumber, o => o.MapFrom(s => s.ApcaNumber));

                var d2s = CreateMap<Model.Transaction, Transaction>();
                d2s.ForMember(s => s.Id, o => o.MapFrom(d => d.Id));
                d2s.ForMember(s => s.AccountId, o => o.MapFrom(d => d.AccountId));
                d2s.ForMember(s => s.IsDetailAvailable, o => o.MapFrom(d => d.IsDetailAvailable));
                d2s.ForMember(s => s.TypeSid, o => o.MapFrom(d => d.Type));
                d2s.ForMember(s => s.StatusSid, o => o.MapFrom(d => d.Status));
                d2s.ForMember(s => s.Description, o => o.MapFrom(d => d.Description));
                d2s.ForMember(s => s.PostingDateTime, o => o.MapFrom(d => d.PostingDateTime));
                d2s.ForMember(s => s.ExecutionDateTime, o => o.MapFrom(d => d.ExecutionDateTime));
                d2s.ForMember(s => s.Amount, o => o.MapFrom(d => d.Amount));
                d2s.ForMember(s => s.Currency, o => o.MapFrom(d => d.Currency));
                d2s.ForMember(s => s.Reference, o => o.MapFrom(d => d.Reference));
                d2s.ForMember(s => s.MerchantName, o => o.MapFrom(d => d.MerchantName));
                d2s.ForMember(s => s.MerchantCategoryCode, o => o.MapFrom(d => d.MerchantCategoryCode));
                d2s.ForMember(s => s.BillerCode, o => o.MapFrom(d => d.BillerCode));
                d2s.ForMember(s => s.BillerName, o => o.MapFrom(d => d.BillerName));
                d2s.ForMember(s => s.ApcaNumber, o => o.MapFrom(d => d.ApcaNumber));

                CosmosMapperProfileCtor(s2d, d2s);
            }

            partial void CosmosMapperProfileCtor(AutoMapper.IMappingExpression<Transaction, Model.Transaction> s2d, AutoMapper.IMappingExpression<Model.Transaction, Transaction> d2s); // Enables the constructor to be extended.
        }
    }
}

#pragma warning restore
#nullable restore