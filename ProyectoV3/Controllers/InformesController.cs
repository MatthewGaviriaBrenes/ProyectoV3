using System.Diagnostics;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ProyectoV3.Models;

namespace ProyectoV3.Controllers;

public class InformesController : Controller 
{
    private readonly IConverter _converter;

    public InformesController(IConverter converter)
    {
        _converter = converter;
    }

    [HttpGet]
    public IActionResult DescargarInformes()
    {
        InformesModel infmod = new InformesModel();
        return View(infmod);
    }
    
    [HttpPost]
    public IActionResult DescargarInformes(InformesModel infmod)
    {
        string pagina_actual = HttpContext.Request.Path;
        string url_pagina = HttpContext.Request.GetEncodedUrl();
        url_pagina = url_pagina.Replace(pagina_actual, "");
        url_pagina = $"{url_pagina}/Informes/VistaParaPDF";

        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = new GlobalSettings()
            {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait
            },
            Objects = {
                new ObjectSettings(){
                    Page = url_pagina,
                    PagesCount = true,
                    HtmlContent = infmod.ejtxt,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
        };

        var archivoPDF = _converter.Convert(pdf);
        string nombrePDF = "Informe_" + infmod.numinform + ".pdf";

        return File(archivoPDF, "application/pdf", nombrePDF);
    }

    public IActionResult VistaParaPDF()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}