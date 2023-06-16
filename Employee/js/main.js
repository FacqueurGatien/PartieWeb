import { Employee } from "./Employee.js";
import { Employees } from "./Employees.js";

const link = "https://arfp.github.io/tp/web/frontend/employees/employees.json";
const employees=new Employees(link);
await employees.CreateArray();

let arrayEmp = employees.GetArraySortReverse()
Show(arrayEmp);
function Show(array){
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
    
        let somme = 0;
        for(let emp of array){
            let rowData = document.createElement("tr");
            document.getElementById("data").appendChild(rowData);
            let dup = document.createElement("button");
            let del = document.createElement("button");
            dup.textContent="Duplicate";
            dup.classList="buttonDup";
            dup.name=emp.id;
            dup.addEventListener("click", async (e)=>{
                let newId=0;
                for(let emp of arrayEmp){
                    if(emp.id> newId){
                        newId=parseInt(emp.id)+1;
                    }
                }
                let copie = await employees.CopieEmp(dup.name,newId);
                arrayEmp.push(copie)
                document.getElementById("label").innerHTML="";
                document.getElementById("data").innerHTML="";
                document.getElementById("foot").innerHTML="";
                Show(arrayEmp);
            })

            del.textContent="Delete";
            del.name=emp.id;
            del.addEventListener("click", (e)=>{
                ////////////////////////////////////////
                arrayEmp = arrayEmp.filter((p) => del.name != p.id )
                document.getElementById("label").innerHTML="";
                document.getElementById("data").innerHTML="";
                document.getElementById("foot").innerHTML="";
                Show(arrayEmp)
                ///////////////////////////////////////
            })

            del.classList="buttonDel";    
            for(let e of emp.GetValues()){
                console.log();

                    let data = document.createElement("td");
                    data.textContent=e;
                    data.classList="dataTable";
                    rowData.appendChild(data);
            }
            somme+=parseFloat(emp.GetSalaryMonth());
            let actions = document.createElement("td");
            actions.classList="dataTable";
            actions.appendChild(dup);
            actions.appendChild(del);
            rowData.appendChild(actions);
        }               
        let rowFoot = document.createElement("tr");
        for(let i of keys.GetKeys()){
            let dataFoot = document.createElement("th");
            dataFoot.classList="dataFoot";
            if(i == "Id"){
                dataFoot.textContent=array.length;
            }
            else if(i == "Salary Month"){
                dataFoot.textContent=somme.toFixed(2);
            }
            rowFoot.appendChild(dataFoot);
        }
        let dataFoot=document.createElement("th");
        dataFoot.classList="datafoot"
        rowFoot.appendChild(dataFoot);
        document.getElementById("foot").appendChild(rowFoot);
    }
}