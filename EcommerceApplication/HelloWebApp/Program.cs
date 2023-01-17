//WebApplication is a class and CreateBuilder is a static method
using HR;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// var emp = new {Id=23,FirstNAme="Siddhant",LastNAme="Nand"};
var employees = new List<Employee>();
 employees.Add(new Employee(){ID=23,FirstName="Siddhant",LastName="Nand"});
 employees.Add(new Employee(){ID=24,FirstName="Shiv",LastName="Nand"});
 employees.Add(new Employee(){ID=25,FirstName="Kunal",LastName="Buwa"});
//  employees.Add(new Employee(){ID=23,FirstName="Siddhant",LastName="Nand"});
//  employees.Add(new Employee(){ID=23,FirstName="Siddhant",LastName="Nand"});

// Mapping with the get request 
app.MapGet("/", () => "Hello World!");
// app.MapGet("/hello",() => "<h1>Asp.Net WEb Application </h1>");
app.MapGet("/api/employee",()=>employees);
app.Run();
