namespace Testing;
using HR;

using MySql.Data.MySqlClient;
using System.Data;

public class DBTestManager{
    public static string connectionString = @"server=localhost;port=3306;user=root;password=123456789;database=transflower";
    public static List<Department> GetAllDepartments(){
        List<Department> allDepartments = new List<Department>();
        // Connected dataacess mode
        // using inbuild external object model
        //classes in MySql 
        //MySqlConnection : eastablishing connection
        //MySqlCommand   : query execution  
        //MySqlDataReader  : result of query to be captured after processing
        
         
         MySqlConnection con =  new MySqlConnection();
         con.ConnectionString = connectionString;
         try{
             con.Open();
             //fire query to databse
             MySqlCommand cmd = new MySqlCommand();
             cmd.Connection=con;
             string query="select * from departments";
             cmd.CommandText=query;
             MySqlDataReader reader = cmd.ExecuteReader();
             while(reader.Read())
            { 
                int id = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string location = reader["location"].ToString();
                Department dept = new Department{
                     Id = id,
                     Name = name,
                     Location=location


             };
             allDepartments.Add(dept);
             }
             
         }
         catch(Exception e){
            Console.WriteLine(e.Message);
         }
         finally{
              con.Close();
         }

         return allDepartments;

        //Disconnected Data acess Mode
        //Musql connection// MysqlDataAdapter//DataSet//DataTable,DataRow,DataColumn,DataRelation
    }
}