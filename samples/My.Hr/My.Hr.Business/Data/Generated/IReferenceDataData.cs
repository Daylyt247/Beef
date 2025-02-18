/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using RefDataNamespace = My.Hr.Business.Entities;

namespace My.Hr.Business.Data
{
    /// <summary>
    /// Provides the <b>ReferenceData</b> data access.
    /// </summary>
    public partial interface IReferenceDataData
    {
        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.Gender"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.GenderCollection"/>.</returns>
        Task<RefDataNamespace.GenderCollection> GenderGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.TerminationReason"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.TerminationReasonCollection"/>.</returns>
        Task<RefDataNamespace.TerminationReasonCollection> TerminationReasonGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.RelationshipType"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.RelationshipTypeCollection"/>.</returns>
        Task<RefDataNamespace.RelationshipTypeCollection> RelationshipTypeGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.USState"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.USStateCollection"/>.</returns>
        Task<RefDataNamespace.USStateCollection> USStateGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.PerformanceOutcome"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.PerformanceOutcomeCollection"/>.</returns>
        Task<RefDataNamespace.PerformanceOutcomeCollection> PerformanceOutcomeGetAllAsync();
    }
}

#pragma warning restore
#nullable restore