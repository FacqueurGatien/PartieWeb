import { Employee } from "./Employee.js";
import { Employees } from "./Employees.js";

const link = "https://arfp.github.io/tp/web/frontend/employees/employees.json";
const employees=new Employees(link);
await employees.CreateArray();

if(employees.employeesList.length!=0){
    for(){
        
    }
}

