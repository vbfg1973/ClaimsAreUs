namespace ClaimsAreUs.Api.Extensions
{
    /// <summary>
    ///     Environment helpers
    /// </summary>
    public static class EnvironmentUtility
    {
        /// <summary>
        ///     Figure out environment from env variables. Mostly defaults to "Development"
        /// </summary>
        /// <returns></returns>
        public static string GetEnvironmentName()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            environmentName = environmentName.ToLower().Trim();

            return environmentName switch
            {
                "prod" => "Production",
                "production" => "Production",
                _ => "Development" // default return
            };
        }
    }
}