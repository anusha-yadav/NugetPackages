using Aspose.Words;
using System.IO;

namespace PdfGenerator
{
    /// <summary>
    /// PdfGenerator
    /// </summary>
    public class PdfGenerator
    {
        /// <summary>
        /// HtmlToPdf
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public byte[] HtmlToPdf(string strFileName)
        {
            byte[] pdfByteArray;

            using (System.IO.MemoryStream htmlStream = new System.IO.MemoryStream())
            {
                string htmlString = strFileName;
                byte[] htmlByteArray = System.Text.Encoding.UTF8.GetBytes(htmlString);
                htmlStream.Write(htmlByteArray, 0, htmlByteArray.Length);
                htmlStream.Position = 0; // Reset position to the beginning of the stream

                // Create and configure HtmlLoadOptions
                Aspose.Words.Loading.HtmlLoadOptions htmlLoadOptions = new Aspose.Words.Loading.HtmlLoadOptions();

                // Load HTML content into Aspose.Words Document
                Aspose.Words.Document htmlDocument = new Aspose.Words.Document(htmlStream, htmlLoadOptions);

                // Convert Aspose.Words Document to PDF
                using (System.IO.MemoryStream pdfStream = new System.IO.MemoryStream())
                {
                    Aspose.Words.Saving.PdfSaveOptions pdfSaveOptions = new Aspose.Words.Saving.PdfSaveOptions();
                    htmlDocument.Save(pdfStream, pdfSaveOptions);

                    pdfByteArray = pdfStream.ToArray();
                }
            }
            return pdfByteArray;
        }

        /// <summary>
        /// ConvertImageToPdf
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public byte[] ConvertImageToPdf(string imagePath)
        {
            // Create a new document
            Document pdfDocument = new Document();
            DocumentBuilder document = new DocumentBuilder(pdfDocument);
            document.InsertImage(imagePath);
            MemoryStream outputStream = new MemoryStream();
            pdfDocument.Save(outputStream, Aspose.Words.SaveFormat.Pdf);
            byte[] pdfBytes = outputStream.ToArray();
            return pdfBytes;
        }

    }
}
