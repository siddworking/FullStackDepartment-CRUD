namespace DAL.Connected;
using BOL;
using MySql.Data.MySqlClient;

public class DBManager{
    public static string constring = @"server=localhost;port=3306;user=root;password=123456789;database=transflower";
    public static List<Department> GetAllDepartments(){
          List<Department> allDepartments = new List<Department>();
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=constring;
          try{
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection=con;
            string query = "select * from departments";
            cmd.CommandText=query;
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                int id = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
               string location = reader["location"].ToString();
               Department dept = new Department{
                ID = id,
                Name = name,
                Location = location
               };
               allDepartments.Add(dept);

            }
          }
          catch(Exception ee){
                Console.WriteLine(ee.Message);
          }
          finally{
                    con.Close();
          }
          return allDepartments;


    }

   public static List<Employee> GetAllEmployees(int id){

      List<Employee> allemps = new List<Employee>();
       MySqlConnection con = new MySqlConnection();
          con.ConnectionString=constring;
          try{
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection=con;
            string query = "select * from employees where deptid = "+id;
            cmd.CommandText=query;
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                int id1 = int.Parse(reader["id"].ToString());
                string fname = reader["firstName"].ToString();
               string lname = reader["lastName"].ToString();
               Employee emp = new Employee(id1,fname,lname);
                allemps.Add(emp);
               };
              

            }
          
          catch(Exception ee){
                Console.WriteLine(ee.Message);
          }
          finally{
                    con.Close();
          }
          return allemps;
          
         
   }

      public static Employee GetEmp(int id){

           Employee e = new Employee ();
       MySqlConnection con = new MySqlConnection();
          con.ConnectionString=constring;
          try{
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection=con;
            string query = "select * from employees where id = "+id;
            cmd.CommandText=query;
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()){
                int id1 = int.Parse(reader["id"].ToString());
                string fname = reader["firstName"].ToString();
               string lname = reader["lastName"].ToString();
               string email = reader["email"].ToString();
               int dept = int.Parse(reader["deptid"].ToString());
               int manager = int.Parse(reader["managerid"].ToString());
               Employee emp = new Employee{
                  Id = id1,
                  FirstName = fname,
                  LastName = lname,
                  Email = email,
                  DeptId = dept,
                  ManagerId = manager
               };
               e =  emp;
               
               };
              

            }
          
          catch(Exception ee){
                Console.WriteLine(ee.Message);
          }
          finally{
                    con.Close();
          }
          
          
          return e;
      }
   
}