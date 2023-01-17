// Database operations unit Testing
using Testing;
using System.Collections.Generic;
using HR;

List<Department> allDept = DBTestManager.GetAllDepartments();
foreach ( Department dept in allDept){
    Console.WriteLine(dept.Name + "  " + dept.Location);
}