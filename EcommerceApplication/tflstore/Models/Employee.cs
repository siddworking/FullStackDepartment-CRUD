namespace HR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

[Serializable]
    public class Employee{
   
public string FirstName {get;set;}
public string LastName {get;set;}
public string Email {get;set;}

public string Password {get;set;}

public int Number {get;set;}

       public Employee(){
        FirstName="Sidd";
        LastName="Nand";
        Email="hii";
        Password="bye";
        Number=8978;
        
       }

       public Employee(string fn,string ln,string em,string pass,int no){
            FirstName=fn;
            LastName=ln;
            Email=em;
            Password=pass;
            Number=no;
            
       }



       public static void SerializeAllEmployees(List<Employee> emps ){
               try    {
                    var opt = new JsonSerializerOptions {IncludeFields=true};
                    var empJson=JsonSerializer.Serialize<List<Employee>>(emps,opt);
                    string filename = @"d:\varity.json";
                    //serialize all blogs in json file
                    File.WriteAllText(filename,empJson);
                    }
                    catch(Exception e){ }
                     finally{}
      }
    
             
    
             
 }

    
     // public Empl


