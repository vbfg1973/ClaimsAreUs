using System.Reflection;

namespace ClaimsAreUs.Common.Extensions
{
    public static class AssemblyExtensions
    {
        public static string XmlCommentsFilePath(this Assembly assembly)
        {
            var baseDirectory = AppContext.BaseDirectory;
            var fileName = assembly.GetName().Name + ".xml";
            return Path.Combine(baseDirectory, fileName);
        }
    }
}