using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EStoreWebApp.Models;

using BOL;
using BLL;

namespace EStoreWebApp.Controllers;

public class DepartmentsController : Controller
{
    private readonly ILogger<DepartmentsController> _logger;

    public DepartmentsController(ILogger<DepartmentsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HRManager mgr=new HRManager();
        List<Department> departments=mgr.GetAllDepartments();
        this.ViewData["departments"]=departments;
        return View();
    }

     public IActionResult GetEmployee(int ID)
    {
        HRManager mgr=new HRManager();
        List<Employee> employees=mgr.GetAllEmployees(ID);
        this.ViewData["emp"]=employees;
        return View();
    }
    public IActionResult Getemmp(int Id){
         HRManager mgr=new HRManager();
        Employee employee =mgr.GetEmployee(Id);
        this.ViewData["employ"]=employee;
        return View();
    }

     
}
