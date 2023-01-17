namespace BLL;
using BOL;
using DAL.Connected;

public class HRManager{
    public List<Department> GetAllDepartments(){
        List<Department> allDeratements = DBManager.GetAllDepartments();
        return allDeratements;
    }
   public List<Employee> GetAllEmployees(int id){
        List<Employee> allEmps = DBManager.GetAllEmployees(id);
        return allEmps;
   }

    public Employee GetEmployee (int id){
        Employee emp = DBManager.GetEmp(id);
        return emp;
    }

}