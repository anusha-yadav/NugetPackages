using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfGenerator
{
    /// <summary>
    /// PdfGeneratorV1_2
    /// </summary>
    public class PdfGeneratorV1_2
    {
        /// <summary>
        /// HtmlToPdf
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <returns></returns>
        public byte[] HtmlToPdf(string htmlContent)
        {
            byte[] pdfByteArray;

            // Load HTML content into Aspose.Words Document
            using (var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(htmlContent)))
            {
                // Create and configure HtmlLoadOptions
                var htmlLoadOptions = new Aspose.Words.Loading.HtmlLoadOptions();

                // Load HTML content into Aspose.Words Document
                var htmlDocument = new Aspose.Words.Document(htmlStream, htmlLoadOptions);

                var pdfSaveOptions = new Aspose.Words.Saving.PdfSaveOptions
                {
                    // Set PDF compliance to PDF/A-1a
                    Compliance = Aspose.Words.Saving.PdfCompliance.PdfA1a,

                    // Set rendering options for headers and footers
                    OutlineOptions = { HeadingsOutlineLevels = 3 },
                    DisplayDocTitle = true,
                };

                foreach (Section section in htmlDocument.Sections)
                {
                    // Add header
                    var header = new HeaderFooter(section.Document, HeaderFooterType.HeaderPrimary);
                    header.AppendChild(new Paragraph(section.Document));
                    section.HeadersFooters.Add(header);

                    // Add footer
                    var footer = new HeaderFooter(section.Document, HeaderFooterType.FooterPrimary);
                    footer.AppendChild(new Paragraph(section.Document));
                    section.HeadersFooters.Add(footer);
                }

                // Set PDF save options
                

                // Convert Aspose.Words Document to PDF
                using (var pdfStream = new MemoryStream())
                {
                    htmlDocument.Save(pdfStream, pdfSaveOptions);
                    pdfByteArray = pdfStream.ToArray();
                }
            }

            return pdfByteArray;
        }
    }
}
