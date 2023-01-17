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

public class ProductsController : Controller
{

     
   
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }


   
  
    public IActionResult AllProducts()
    {
      List<Product> prod = new List<Product>();
      prod = ProductManager.GetAllProducts();
      ViewData["prods"] = prod;
        return View();
    }

     public IActionResult AddProducts()
    {
    //   List<Product> prod = new List<Product>();
    //   prod = ProductManager.GetAllProducts();
    //   ViewData["prods"] = prod;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
