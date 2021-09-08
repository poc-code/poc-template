using System.IO;
using System.Text;

namespace Poc_Template_Api.Extensions
{
    public static class JsonExtension
    {
        public static MemoryStream ToMemoryStream(this string jsonString)
        {
            byte[] bytess = Encoding.ASCII.GetBytes(jsonString);
            var data = new MemoryStream(bytess);
            data.Position = 0;

            var responseBody = new StreamReader(data).ReadToEnd();

            var memoryStreamModified = new MemoryStream();
            using var sw = new StreamWriter(memoryStreamModified);
            sw.Write(responseBody);
            sw.Flush();
            memoryStreamModified.Position = 0;

            return memoryStreamModified;
        }
    }
}
