using System.Reflection;

namespace ClaimsAreUs.Data.Support
{
    public sealed class DataAssemblyReference
    {
        public static readonly Assembly Assembly = typeof(DataAssemblyReference).Assembly;
    }
}