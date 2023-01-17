using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BOL;
using DAL;
namespace EntityDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
   

    private readonly ILogger<DepartmentsController> _logger;

    public DepartmentsController(ILogger<DepartmentsController> logger)
    {
        _logger = logger;
    }

   [HttpGet(Name = "GetDepartments")]
    public IEnumerable<Department> Get()
    {
        DBMager db = new DBMager();

    List<Department> alldept = db.GetAll();
    return alldept;
    }

[EnableCors()]
[HttpGet]
[Route("{id:}")]
    public Department Getbyid([FromRoute] int id)
    {
        DBMager db = new DBMager();
        Department dept = db.GetById(id);
        return dept;
    }

 [EnableCors()]
 [HttpPost]

 public  void Insert(Department dept)
 {
        DBMager db = new DBMager();
         db.Insert(dept);
             
 }  

[EnableCors()]
 [HttpDelete]
 [Route("{id:}")]
 public void Delete([FromRoute] int id)
 {
    DBMager db = new DBMager();
    db.Delete(id);
 }

[EnableCors()]
 [HttpPut]
 [Route("{id:}")]
 public void Put([FromRoute] int id ,Department dept)
 {
    DBMager db = new DBMager();
    db.Update(dept);
 }



}
