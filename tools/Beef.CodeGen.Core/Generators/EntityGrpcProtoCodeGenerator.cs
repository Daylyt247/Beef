﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Beef.CodeGen.Config.Entity;
using OnRamp.Generators;
using System.Collections.Generic;

namespace Beef.CodeGen.Generators
{
    /// <summary>
    /// Represents the primary <b>gRPC Proto</b> code generator.
    /// </summary>
    public class EntityGrpcProtoCodeGenerator : CodeGeneratorBase<CodeGenConfig, CodeGenConfig>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="config"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        protected override IEnumerable<Config.Entity.CodeGenConfig> SelectGenConfig(CodeGenConfig config)
            => Check.NotNull(config, nameof(config)).Grpc.HasValue && Check.NotNull(config, nameof(config)).Grpc!.Value ? new Config.Entity.CodeGenConfig[] { config } : System.Array.Empty<Config.Entity.CodeGenConfig>();
    }
}