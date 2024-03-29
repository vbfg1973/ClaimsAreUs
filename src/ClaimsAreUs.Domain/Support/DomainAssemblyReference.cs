﻿using System.Reflection;

namespace ClaimsAreUs.Domain.Support
{
    /// <summary>
    ///     A reference to the domain assembly
    /// </summary>
    public sealed class DomainAssemblyReference
    {
        /// <summary>
        ///     The assembly reference
        /// </summary>
        public static readonly Assembly Assembly = typeof(DomainAssemblyReference).Assembly;
    }
}