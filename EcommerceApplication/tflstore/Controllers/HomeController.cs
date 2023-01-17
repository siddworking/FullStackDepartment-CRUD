using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tflstore.Models;
using HR;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tflstore.Controllers;

public class HomeController : Controller
{

     
   
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


   
    public IActionResult Index()
    {
        
        return View();
    }
    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

     public IActionResult Aboutus()
    {
        return View();
    }

     public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
