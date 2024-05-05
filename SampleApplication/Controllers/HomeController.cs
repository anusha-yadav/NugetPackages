﻿using Aspose.Words;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleApplication.Controllers
{
    /// <summary>
    /// HomeController
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// DownloadPdf
        /// </summary>
        /// <returns></returns>
        public ActionResult DownloadPdf()
        {
            PdfGenerator.PdfGenerator converter = new PdfGenerator.PdfGenerator();
            string data = GetHtmlContent();
            byte[] pdfBytes = converter.HtmlToPdf(data);
            return File(pdfBytes, "application/pdf", "final.pdf");
        }

        /// <summary>
        /// GetHtmlContent
        /// </summary>
        /// <returns></returns>
        public string GetHtmlContent()
        {
            string filePath = "~/Views/Shared/_Content.cshtml";
            string result = Razor.Templating.Core.RazorTemplateEngine.RenderPartialAsync(filePath,"Hello !!!").Result;
            return result;
        }
    }
}