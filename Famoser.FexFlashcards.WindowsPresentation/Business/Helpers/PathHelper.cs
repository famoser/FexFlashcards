using System.IO;
using System.Reflection;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Helpers
{
    class PathHelper
    {
        public static string GetAssemblyPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
