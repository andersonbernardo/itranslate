using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FuseDeskApi.Helper
{
    public class ExportCsvHelper
    {
        public static FileStreamResult GetCsv<T>(IEnumerable<T> data, string fileName)
        {
            var ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms, Encoding.UTF8);

            var properties = typeof(T).GetProperties();            

            var header = properties.Where(x => !string.IsNullOrEmpty(x.GetCustomAttribute<HeaderCsvFileAttribute>()?.HeaderName)).Select(x => x.GetCustomAttributes<HeaderCsvFileAttribute>().FirstOrDefault().HeaderName).Aggregate((c, n) => $"{c};{n}");

            writer.WriteLine(header);

            foreach (var item in data)
            {
                var linha = properties.Where(x => !string.IsNullOrEmpty(x.GetCustomAttribute<HeaderCsvFileAttribute>()?.HeaderName)).Select(x => x.GetValue(item, null)).Aggregate((c, n) => $"{c};{n}");
                writer.WriteLine(linha);
            }

            writer.Flush();
            ms.Position = 0;

            return new FileStreamResult(ms, "text/csv") { FileDownloadName = $"{fileName}.csv" };
        }

        public static MemoryStream GetStreamCsv<T>(IEnumerable<T> data)
        {
            var ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms, Encoding.UTF8);

            var properties = typeof(T).GetProperties();

            var header = properties.Where(x => !string.IsNullOrEmpty(x.GetCustomAttribute<HeaderCsvFileAttribute>()?.HeaderName)).Select(x => x.GetCustomAttributes<HeaderCsvFileAttribute>().FirstOrDefault().HeaderName).Aggregate((c, n) => $"{c};{n}");

            writer.WriteLine(header);

            foreach (var item in data)
            {
                var linha = properties.Where(x => !string.IsNullOrEmpty(x.GetCustomAttribute<HeaderCsvFileAttribute>()?.HeaderName)).Select(x => x.GetValue(item, null)).Aggregate((c, n) => $"{c};{n}");
                writer.WriteLine(linha);
            }

            writer.Flush();
            ms.Position = 0;

            return ms;
        }
    }
}
