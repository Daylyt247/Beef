/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Beef;
using Beef.Entities;
using Beef.WebApi;
using Newtonsoft.Json.Linq;
using Beef.Demo.Common.Entities;
using Beef.Demo.Common.Agents.ServiceAgents;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Agents
{
    /// <summary>
    /// Provides the Contact Web API agent.
    /// </summary>
    public partial class ContactAgent : WebApiAgentBase, IContactServiceAgent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAgent"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> (where overridding the default value).</param>
        /// <param name="beforeRequest">The <see cref="Action{HttpRequestMessage}"/> to invoke before the <see cref="HttpRequestMessage">Http Request</see> is made (see <see cref="WebApiServiceAgentBase.BeforeRequest"/>).</param>
        public ContactAgent(HttpClient? httpClient = null, Action<HttpRequestMessage>? beforeRequest = null)
        {
            ContactServiceAgent = Beef.Factory.Create<IContactServiceAgent>(httpClient, beforeRequest);
        }
        
        /// <summary>
        /// Gets the underlyng <see cref="IContactServiceAgent"/> instance.
        /// </summary>
        public IContactServiceAgent ContactServiceAgent { get; private set; }

        /// <summary>
        /// Gets the <see cref="Contact"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<ContactCollectionResult>> GetAllAsync(WebApiRequestOptions? requestOptions = null)
            => ContactServiceAgent.GetAllAsync(requestOptions);

        /// <summary>
        /// Gets the <see cref="Contact"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Contact"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<Contact>> GetAsync(Guid id, WebApiRequestOptions? requestOptions = null)
            => ContactServiceAgent.GetAsync(id, requestOptions);

        /// <summary>
        /// Creates the <see cref="Contact"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Contact"/> object.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<Contact>> CreateAsync(Contact value, WebApiRequestOptions? requestOptions = null)
            => ContactServiceAgent.CreateAsync(Check.NotNull(value, nameof(value)), requestOptions);

        /// <summary>
        /// Updates the <see cref="Contact"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Contact"/> object.</param>
        /// <param name="id">The <see cref="Contact"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<Contact>> UpdateAsync(Contact value, Guid id, WebApiRequestOptions? requestOptions = null)
            => ContactServiceAgent.UpdateAsync(Check.NotNull(value, nameof(value)), id, requestOptions);

        /// <summary>
        /// Deletes the <see cref="Contact"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Contact"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult> DeleteAsync(Guid id, WebApiRequestOptions? requestOptions = null)
            => ContactServiceAgent.DeleteAsync(id, requestOptions);
    }
}

#pragma warning restore IDE0005
#nullable restore