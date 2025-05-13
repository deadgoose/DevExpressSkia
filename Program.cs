using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using System.Diagnostics;

namespace DevExpressTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var x = Test("path/to/your/file");
            x.Wait();
            stopwatch.Stop();
            Console.WriteLine((x.Result as byte[]).Length);
            Console.WriteLine(stopwatch.Elapsed.ToString());
        }

        public static async Task<byte[]> Test(string filePath)
        {
            var document = await File.ReadAllBytesAsync(filePath);
            using (RichEditDocumentServer srv = new RichEditDocumentServer())
            {
                using (var inputStream = new MemoryStream(document))
                {
                    await srv.LoadDocumentAsync(inputStream, DocumentFormat.Mht);
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        var options = new PdfExportOptions();
                        options.DocumentOptions.Author = "Zenvoices";
                        options.Compressed = true;
                        options.ConvertImagesToJpeg = true;

                        await srv.ExportToPdfAsync(outputStream, options);
                        outputStream.Flush();
                        return outputStream.ToArray();
                    }
                }
            }
        }
    }
}
