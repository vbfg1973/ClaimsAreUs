using ClaimsAreUs.Data.Config;

namespace ClaimsAreUs.Api.Config
{
    /// <summary>
    ///     Holds general configuration for app and services
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        ///     Database config
        /// </summary>
        public SqlDatabaseConfiguration Database { get; set; } = null!;
    }
}