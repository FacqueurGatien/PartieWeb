import { Employee } from "./Employee.js";
import { Employees } from "./Employees.js";

const link = "https://arfp.github.io/tp/web/frontend/employees/employees.json";
const employees=new Employees(link);
await employees.CreateArray();

if(employees.employeesList.length!=0){
    let rowTitle = document.createElement("tr");
    let keys = employees.GetFirst();
    document.getElementById("label").appendChild(rowTitle);
    for(let k of keys.GetKeys()){
        let titleRow = document.createElement("th");
        titleRow.textContent=k;
        titleRow.classList="titleTable";
        rowTitle.appendChild(titleRow);
    }
    for(let emp of employees.employeesList){
        let rowData = document.createElement("tr");
        document.getElementById("data").appendChild(rowData);
        for(let e of emp.GetValues()){
            let data = document.createElement("td");
            data.textContent=e;
            data.classList="dataTable";
            rowData.appendChild(data);
        }
    }
}

