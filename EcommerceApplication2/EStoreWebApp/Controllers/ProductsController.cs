using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EStoreWebApp.Models;
using BOL;
using BLL;

namespace EStoreWebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // get all products from BLL
        // Bind all products to ViewData
        // Send view Data to View
        List<Product> allProducts = new List<Product>();
        CatlogManager manager = new CatlogManager();
        allProducts = manager.GetProductsFromFile(@"D:\CDAC All subjects\.Net\practice\EcommerceApplication2\product.json");
        this.ViewData["products"] = allProducts;
        return View();
    }

    public IActionResult Details(int id)
    {
        CatlogManager manager = new CatlogManager();
        Product product = manager.GetProductById(id);
        this.ViewData["product"] = product;
        return View();
    }

    public IActionResult Insert()
    {
        return View();
    }

    public IActionResult Add(int pid, string title, string categ, float pri, int bal, string desc)
    {
        Product newProduct = new Product(pid, title,categ, pri, bal, desc);
        CatlogManager manager = new CatlogManager();
        manager.AddProduct(newProduct);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        // writting this will take it to Index view of Product;
         CatlogManager manager = new CatlogManager();
        manager.DeleteProduct(id);
        return RedirectToAction("Index");
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
