/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Newtonsoft.Json;

namespace Beef.Demo.Common.Entities
{
    /// <summary>
    /// Represents the other <see cref="Person"/> without <see cref="EntityBase"/> capabilities entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class PersonOther : IGuidIdentifier, IETag, IChangeLog
    {
        /// <summary>
        /// Gets or sets the <see cref="Person"/> identifier.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        [JsonProperty("firstName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        [JsonProperty("lastName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the ETag.
        /// </summary>
        [JsonProperty("etag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ETag { get; set; }

        /// <summary>
        /// Gets or sets the Change Log.
        /// </summary>
        [JsonProperty("changeLog", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ChangeLog? ChangeLog { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="PersonOther"/> collection.
    /// </summary>
    public partial class PersonOtherCollection : List<PersonOther> { }
}

#pragma warning restore
#nullable restore