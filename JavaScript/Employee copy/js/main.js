import { Employees } from "./Employees.js";
import { TableGenerator } from "./TableGenerator.js";

let employees = new Employees();
await employees.GetEmployees()

let employeeTable = new TableGenerator(employees);
employeeTable.GenerateBody();
document.getElementById("sort").addEventListener("click",()=>{employees.sortBySalary(); employeeTable.GenerateBody()});