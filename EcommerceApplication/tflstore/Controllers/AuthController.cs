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

public class AuthController : Controller
{

     
   
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }


   
    
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Welcome()
    {
        return View();
    }

     public IActionResult Registration()
    {
        return View();
    }

     public IActionResult ShowAll()
    {
        return View();
    }

     public IActionResult validate(string email,string password)
    {
         string filename = @"d:\varity.json";
        string jsonString = System.IO.File.ReadAllText(filename);
        List<Employee> emps = JsonSerializer.Deserialize<List<Employee>>(jsonString);
        foreach(Employee e in emps){
            if(email == e.Email && password == e.Password){
               return Redirect("/auth/Welcome");
            }
        }
        // if(email == "siddhant@gmail.com" && password=="sidd"){
        //     return Redirect("/auth/Welcome");
        // }
         return Redirect("/home/Privacy");
    }
    
    public IActionResult confirm(string fname,string lname,string email,string pass,int cno)
    {
         try
        {
        // var opt1 = new JsonSerializerOptions {IncludeFields=true};
        string filename = @"d:\varity.json";
        string jsonString = System.IO.File.ReadAllText(filename);
        List<Employee> emps = JsonSerializer.Deserialize<List<Employee>>(jsonString);
        Employee e = new Employee(fname,lname,email,pass,cno);
        emps.Add(e);
        Employee.SerializeAllEmployees(emps);
        Console.WriteLine(e.Email);
        return Redirect("/auth/Login");
        } 
         catch (JsonException ex)
        {
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
        }
        catch(Exception e){}
                     finally{}
       
        
        return Redirect("/auth/Welcome");
    }

     public IActionResult getit()
    {
        try
        {
        // var opt1 = new JsonSerializerOptions {IncludeFields=true};
        string filename = @"d:\varity.json";
        string jsonString = System.IO.File.ReadAllText(filename);
        List<Employee> emps = JsonSerializer.Deserialize<List<Employee>>(jsonString);
        ViewData["members"] = emps;
        } 
         catch (JsonException ex)
        {
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
        }
        catch(Exception e){}
                     finally{}
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
