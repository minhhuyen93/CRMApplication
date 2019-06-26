namespace Application.Common.Helper
{
    using Application.Repository;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class AssemblyHelper
    {
        public static TAttribute GetClassAttribute<TAttribute>(Type type) where TAttribute : Attribute
        {
            return type.GetCustomAttribute<TAttribute>(true);
        }

        internal static Type GetFileType<IDbContext>()
        {
            string dll = AssemblyHelper.GetApplicationDlls();

            Type fileType = Assembly.Load(dll).GetTypes()
                .Where(item => !item.IsAbstract && item.IsClass && typeof(IDbContext).IsAssignableFrom(item))
                .FirstOrDefault();

            return fileType;
        }

        private static string GetApplicationDlls(string filePattern = "*.dll")
        {
            string binPath = AssemblyHelper.GetBinDirectoryPath();
            string dll = Directory.GetFiles(binPath, filePattern)
                                .Where(item => Path.GetFileName(item).Contains("Application.dll"))
                                .Select(fileItem => Path.GetFileNameWithoutExtension(fileItem))
                                .First();
            return dll;
        }

        private static string GetBinDirectoryPath()
        {
            string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", string.Empty);
            return binPath;
        }

        internal static IDbContext Create(Type type)
        {
            object result = Activator.CreateInstance(type, new object[] { });
            return (IDbContext)result;
        }
    }
}