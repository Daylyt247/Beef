# 'CodeGeneration' object (database-driven)

The `CodeGeneration` object defines global properties that are used to drive the underlying database-driven code generation.

<br/>

## Property categories
The `CodeGeneration` object supports a number of properties that control the generated code output. These properties are separated into a series of logical categories.

Category | Description
-|-
[`Infer`](#Infer) | Provides the _special Column Name inference_ configuration.
[`CDC`](#CDC) | Provides the _Change Data Capture (CDC)_ configuration.
[`Path`](#Path) | Provides the _Path (Directory)_ configuration for the generated artefacts.
[`DotNet`](#DotNet) | Provides the _.NET_ configuration.
[`Event`](#Event) | Provides the _Event_ configuration.
[`Outbox`](#Outbox) | Provides the _Event Outbox_ configuration.
[`Auth`](#Auth) | Provides the _Authorization_ configuration.
[`Namespace`](#Namespace) | Provides the _.NET Namespace_ configuration for the generated artefacts.
[`Collections`](#Collections) | Provides related child (hierarchical) configuration.

The properties with a bold name are those that are more typically used (considered more important).

<br/>

## Infer
Provides the _special Column Name inference_ configuration.

Property | Description
-|-
`columnNameIsDeleted` | The column name for the `IsDeleted` capability.<br/>&dagger; Defaults to `IsDeleted`.
`columnNameTenantId` | The column name for the `TenantId` capability.<br/>&dagger; Defaults to `TenantId`.
`columnNameOrgUnitId` | The column name for the `OrgUnitId` capability.<br/>&dagger; Defaults to `OrgUnitId`.
`columnNameRowVersion` | The column name for the `RowVersion` capability.<br/>&dagger; Defaults to `RowVersion`.
`columnNameCreatedBy` | The column name for the `CreatedBy` capability.<br/>&dagger; Defaults to `CreatedBy`.
`columnNameCreatedDate` | The column name for the `CreatedDate` capability.<br/>&dagger; Defaults to `CreatedDate`.
`columnNameUpdatedBy` | The column name for the `UpdatedBy` capability.<br/>&dagger; Defaults to `UpdatedBy`.
`columnNameUpdatedDate` | The column name for the `UpdatedDate` capability.<br/>&dagger; Defaults to `UpdatedDate`.
`columnNameDeletedBy` | The column name for the `DeletedBy` capability.<br/>&dagger; Defaults to `UpdatedBy`.
`columnNameDeletedDate` | The column name for the `DeletedDate` capability.<br/>&dagger; Defaults to `UpdatedDate`.
`orgUnitJoinSql` | The SQL table or function that is to be used to join against for security-based `OrgUnitId` verification.<br/>&dagger; Defaults to `[Sec].[fnGetUserOrgUnits]()`.
`checkUserPermissionSql` | The SQL stored procedure that is to be used for `Permission` verification.<br/>&dagger; Defaults to `[Sec].[spCheckUserHasPermission]`.
`getUserPermissionSql` | The SQL function that is to be used for `Permission` verification.<br/>&dagger; Defaults to `[Sec].[fnGetUserHasPermission]`.

<br/>

## CDC
Provides the _Change Data Capture (CDC)_ configuration.

Property | Description
-|-
`cdcSchema` | The schema name for the generated `CDC`-related database artefacts.<br/>&dagger; Defaults to `XCdc` (literal).
`cdcAuditTableName` | The table name for the `Cdc`-Tracking.<br/>&dagger; Defaults to `CdcTracking` (literal).
`cdcIdentifierMapping` | Indicates whether to include the generation of the generic `Cdc`-IdentifierMapping database capabilities.
`cdcIdentifierMappingTableName` | The table name for the `Cdc`-IdentifierMapping.<br/>&dagger; Defaults to `CdcIdentifierMapping` (literal).
`cdcIdentifierMappingStoredProcedureName` | The table name for the `Cdc`-IdentifierMapping.<br/>&dagger; Defaults to `spCreateCdcIdentifierMapping` (literal).
`jsonSerializer` | The JSON Serializer to use for JSON property attribution. Valid options are: `None`, `Newtonsoft`.<br/>&dagger; Defaults to `Newtonsoft`. This can be overridden within the `Entity`(s).
`pluralizeCollectionProperties` | Indicates whether the .NET collection properties should be pluralized.
`hasBeefDbo` | Indicates whether the database has (contains) the standard _Beef_ `dbo` schema objects.<br/>&dagger; Defaults to `true`.

<br/>

## Path
Provides the _Path (Directory)_ configuration for the generated artefacts.

Property | Description
-|-
`pathBase` | The base path (directory) prefix for the Database-related artefacts; other `Path*` properties append to this value when they are not specifically overridden.<br/>&dagger; Defaults to `Company` (runtime parameter) + `.` + `AppName` (runtime parameter). For example `Beef.Demo`.
`pathDatabaseSchema` | The path (directory) for the Schema Database-related artefacts.<br/>&dagger; Defaults to `PathBase` + `.Database/Schema` (literal). For example `Beef.Demo.Database/Schema`.
`pathDatabaseMigrations` | The path (directory) for the Schema Database-related artefacts.<br/>&dagger; Defaults to `PathBase` + `.Database/Migrations` (literal). For example `Beef.Demo.Database/Migrations`.
`pathBusiness` | The path (directory) for the Business-related (.NET) artefacts.<br/>&dagger; Defaults to `PathBase` + `.Business` (literal). For example `Beef.Demo.Business`.
`PathCdcPublisher` | The path (directory) for the CDC-related (.NET) artefacts.<br/>&dagger; Defaults to `PathBase` + `.Cdc` (literal). For example `Beef.Demo.Cdc`.

<br/>

## DotNet
Provides the _.NET_ configuration.

Property | Description
-|-
`cdcExcludeColumnsFromETag` | The default list of `Column` names that should be excluded from the generated ETag (used for the likes of duplicate send tracking)
`autoDotNetRename` | The option to automatically rename the SQL Tables and Columns for use in .NET. Valid options are: `None`, `PascalCase`, `SnakeKebabToPascalCase`.<br/>&dagger; Defaults `SnakeKebabToPascalCase` that will remove any underscores or hyphens separating each word and capitalize the first character of each; e.g. `internal-customer_id` would be renamed as `InternalCustomerId`. The `PascalCase` option will capatilize the first character only.
`entityScope` | The entity scope option. Valid options are: `Common`, `Business`, `Autonomous`.<br/>&dagger; Defaults to `Common` for backwards compatibility; `Autonomous` is recommended. Determines where the entity is scoped/defined, being `Common` or `Business` (i.e. not externally visible).

<br/>

## Event
Provides the _Event_ configuration.

Property | Description
-|-
**`eventSubjectRoot`** | The root for the event name by prepending to all event subject names via CDC.<br/>&dagger; Used to enable the sending of messages to the likes of EventHub, Service Broker, SignalR, etc. This can be extended within the `Entity`(s).
`eventSubjectFormat` | The default formatting for the Subject when an Event is published via CDC. Valid options are: `NameOnly`, `NameAndKey`.<br/>&dagger; Defaults to `NameAndKey` (being the event subject name appended with the corresponding unique key.)`.
**`eventActionFormat`** | The formatting for the Action when an Event is published via CDC. Valid options are: `None`, `PastTense`.<br/>&dagger; Defaults to `None` (no formatting required, i.e. as-is).
`eventSourceRoot` | The URI root for the event source by prepending to all event source URIs for CDC.<br/>&dagger; The event source is only updated where an `EventSourceKind` is not `None`. This can be extended within the `Entity`(s).
`eventSourceKind` | The URI kind for the event source URIs for CDC. Valid options are: `None`, `Absolute`, `Relative`, `RelativeOrAbsolute`.<br/>&dagger; Defaults to `None` (being the event source is not updated).
`eventSourceFormat` | The default formatting for the Source when an Event is published via CDC. Valid options are: `NameOnly`, `NameAndKey`, `NameAndGlobalId`.<br/>&dagger; Defaults to `NameAndKey` (being the event subject name appended with the corresponding unique key.)`.

<br/>

## Outbox
Provides the _Event Outbox_ configuration.

Property | Description
-|-
`eventOutbox` | Indicates whether events will publish using the outbox pattern and therefore the event outbox artefacts are required.
`eventOutboxTableName` | The table name for the `EventOutbox`.<br/>&dagger; Defaults to `EventOutbox` (literal).

<br/>

## Auth
Provides the _Authorization_ configuration.

Property | Description
-|-
**`orgUnitImmutable`** | Indicates whether the `OrgUnitId` column is considered immutable, in that it can not be changed once set.<br/>&dagger; This is only applicable for stored procedures.

<br/>

## Namespace
Provides the _.NET Namespace_ configuration for the generated artefacts.

Property | Description
-|-
`namespaceBase` | The base Namespace (root) for the .NET artefacts.<br/>&dagger; Defaults to `Company` (runtime parameter) + `.` + `AppName` (runtime parameter). For example `Beef.Demo`.
`namespaceCommon` | The Namespace (root) for the Common-related .NET artefacts.<br/>&dagger; Defaults to `NamespaceBase` + `.Common` (literal). For example `Beef.Demo.Common`.
`namespaceBusiness` | The Namespace (root) for the Business-related .NET artefacts.<br/>&dagger; Defaults to `NamespaceBase` + `.Business` (literal). For example `Beef.Demo.Business`.
`NamespaceCdcPublisher` | The Namespace (root) for the CDC-related publisher .NET artefacts.<br/>&dagger; Defaults to `NamespaceBase` + `.CdcPublisher` (literal). For example `Beef.Demo.CdcPublisher`.

<br/>

## Collections
Provides related child (hierarchical) configuration.

Property | Description
-|-
**`tables`** | The corresponding [`Table`](Database-Table-Config.md) collection.<br/><br/>A `Table` object provides the relationship to an existing table within the database.
**`queries`** | The corresponding [`Query`](Database-Query-Config.md) collection.<br/><br/>A `Query` object provides the primary configuration for a query, including multiple table joins.

