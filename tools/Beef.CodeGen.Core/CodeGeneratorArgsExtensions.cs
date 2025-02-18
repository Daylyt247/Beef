﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using OnRamp;
using System;
using System.Collections.Generic;

namespace Beef.CodeGen
{
    /// <summary>
    /// Provides extenstion methods to <see cref="CodeGeneratorArgs"/>.
    /// </summary>
    public static class CodeGeneratorArgsExtensions
    {
        /// <summary>
        /// Gets the <see cref="CodeGeneratorArgsBase.Parameters"/> value with a key of <see cref="CodeGenConsole.CompanyParamName"/>.
        /// </summary>
        /// <param name="args">The <see cref="ICodeGeneratorArgs"/>.</param>
        /// <param name="throwWhereNotFound">Indicates to throw a <see cref="KeyNotFoundException"/> when the specified key is not found.</param>
        public static string GetCompany(this ICodeGeneratorArgs args, bool throwWhereNotFound = false) => (args ?? throw new ArgumentNullException(nameof(args))).GetParameter<string>(CodeGenConsole.CompanyParamName, throwWhereNotFound)!;

        /// <summary>
        /// Gets the <see cref="CodeGeneratorArgsBase.Parameters"/> value with a key of <see cref="CodeGenConsole.AppNameParamName"/>.
        /// </summary>
        /// <param name="args">The <see cref="ICodeGeneratorArgs"/>.</param>
        /// <param name="throwWhereNotFound">Indicates to throw a <see cref="KeyNotFoundException"/> when the specified key is not found.</param>
        public static string GetAppName(this ICodeGeneratorArgs args, bool throwWhereNotFound = false) => (args ?? throw new ArgumentNullException(nameof(args))).GetParameter<string>(CodeGenConsole.AppNameParamName, throwWhereNotFound)!;

        /// <summary>
        /// Validate that <see cref="CodeGeneratorArgsBase.Parameters"/> with a key of <see cref="CodeGenConsole.CompanyParamName"/> and <see cref="CodeGenConsole.AppNameParamName"/> have been specified and throw a
        /// <see cref="CodeGenException"/> where invalid.
        /// </summary>
        /// <param name="args">The <see cref="ICodeGeneratorArgs"/>.</param>
        /// <exception cref="CodeGenException">A <see cref="CodeGenException"/> is thrown where not specified.</exception>
        public static void ValidateCompanyAndAppName(this ICodeGeneratorArgs args)
        {
            if (string.IsNullOrEmpty((args ?? throw new ArgumentNullException(nameof(args))).GetCompany()) || string.IsNullOrEmpty(args.GetAppName()))
                throw new CodeGenException($"Parameters '{CodeGen.CodeGenConsole.CompanyParamName}' and {CodeGen.CodeGenConsole.AppNameParamName} must be specified.");
        }
    }
}