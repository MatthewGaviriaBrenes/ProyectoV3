﻿using System.Diagnostics;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ProyectoV3.Models;

namespace ProyectoV3.Controllers;

public class HomeController : Controller
{
    /*private readonly IConverter _converter;

    public HomeController(IConverter converter)
    {
        _converter = converter;
    }*/

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

