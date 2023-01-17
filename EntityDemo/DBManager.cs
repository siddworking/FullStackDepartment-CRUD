namespace DAL;
using BOL;

public class DBMager:IDBManager{

    public void Delete(int id)
    {
        using(var context = new CollectionContext())
        {
            context.Departments.Remove(context.Departments.Find(id));
            context.SaveChanges();
        }


    }

    public List<Department> GetAll()
    {
      using(var context = new CollectionContext())
      {
        Console.WriteLine("inside ");
        var departments = from dept in context.Departments select dept;
        return departments.ToList<Department>();
      }

    }

    public Department GetById(int id)
    {
      using(var context = new CollectionContext())
      {
        var dept = context.Departments.Find(id);
        return dept;
      }
    }

    public void Insert(Department dept)
    {
        using(var context = new CollectionContext())
      {
        context.Departments.Add(dept);
        context.SaveChanges();
      }
    }

    public void Update(Department dept)
    {
      using(var context = new CollectionContext())
      {
        var department = context.Departments.Find(dept.Id);
        department.Id = dept.Id;
        department.Name = dept.Name;
        department.Location = dept.Location;
        context.SaveChanges();
      }

    }

}