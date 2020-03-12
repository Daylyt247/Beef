/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Entities;
using Cdr.Banking.Business.Data;
using Cdr.Banking.Common.Entities;
using RefDataNamespace = Cdr.Banking.Common.Entities;

namespace Cdr.Banking.Business.DataSvc
{
    /// <summary>
    /// Provides the Account data repository services.
    /// </summary>
    public static partial class AccountDataSvc
    {
        #region Private
        #pragma warning disable CS0649 // Defaults to null by design; can be overridden in constructor.

        private static readonly Func<AccountCollectionResult, AccountArgs?, PagingArgs?, Task>? _getAccountsOnAfterAsync;
        private static readonly Func<AccountDetail?, string?, Task>? _getDetailOnAfterAsync;
        private static readonly Func<Balance?, string?, Task>? _getBalanceOnAfterAsync;

        #pragma warning restore CS0649
        #endregion

        /// <summary>
        /// Get all accounts.
        /// </summary>
        /// <param name="args">The Args (see <see cref="AccountArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="AccountCollectionResult"/>.</returns>
        public static Task<AccountCollectionResult> GetAccountsAsync(AccountArgs? args, PagingArgs? paging)
        {
            return DataSvcInvoker.Default.InvokeAsync(typeof(AccountDataSvc), async () => 
            {
                var __result = await Factory.Create<IAccountData>().GetAccountsAsync(args, paging).ConfigureAwait(false);
                if (_getAccountsOnAfterAsync != null) await _getAccountsOnAfterAsync(__result, args, paging).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Get <see cref="AccountDetail"/>.
        /// </summary>
        /// <param name="accountId">The <see cref="Account"/> identifier.</param>
        /// <returns>The selected <see cref="AccountDetail"/> object where found; otherwise, <c>null</c>.</returns>
        public static Task<AccountDetail?> GetDetailAsync(string? accountId)
        {
            return DataSvcInvoker.Default.InvokeAsync(typeof(AccountDataSvc), async () => 
            {
                var __key = new UniqueKey(accountId);
                if (ExecutionContext.Current.TryGetCacheValue<AccountDetail>(__key, out AccountDetail __val))
                    return __val;

                var __result = await Factory.Create<IAccountData>().GetDetailAsync(accountId).ConfigureAwait(false);
                ExecutionContext.Current.CacheSet(__key, __result!);
                if (_getDetailOnAfterAsync != null) await _getDetailOnAfterAsync(__result, accountId).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Get <see cref="Account"/> <see cref="Balance"/>.
        /// </summary>
        /// <param name="accountId">The <see cref="Account"/> identifier.</param>
        /// <returns>The selected <see cref="Balance"/> object where found; otherwise, <c>null</c>.</returns>
        public static Task<Balance?> GetBalanceAsync(string? accountId)
        {
            return DataSvcInvoker.Default.InvokeAsync(typeof(AccountDataSvc), async () => 
            {
                var __key = new UniqueKey(accountId);
                if (ExecutionContext.Current.TryGetCacheValue<Balance>(__key, out Balance __val))
                    return __val;

                var __result = await Factory.Create<IAccountData>().GetBalanceAsync(accountId).ConfigureAwait(false);
                ExecutionContext.Current.CacheSet(__key, __result!);
                if (_getBalanceOnAfterAsync != null) await _getBalanceOnAfterAsync(__result, accountId).ConfigureAwait(false);
                return __result;
            });
        }
    }
}

#nullable restore