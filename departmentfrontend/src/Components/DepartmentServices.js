import axios from "axios";
const base_url = 'http://localhost:5279/';

class DepartmentServices{
   getDepartments(){
    return axios.get(base_url+"Departments");
   }

   addDepartment(dept){
      return axios.post(base_url+"Departments",dept,{
         headers:{
            'Content-Type' : 'application/json'
         }
      });
   }
   getDepartmentbyid(id){
      return axios.get(base_url+"Departments/"+id);
   }

   deletedept(deptid){
      return axios.delete(base_url+"Departments/"+deptid)
   }
   updatedept(dept){
      return axios.put(base_url+"Departments/"+dept.id,dept,{
         headers:{
            'Content-Type':'application/json' 
         }
      })
   }
}
export default new DepartmentServices();