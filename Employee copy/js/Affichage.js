// if(employees.employeesList.length!=0){
//     let rowTitle = document.createElement("tr");
//     let keys = employees.GetFirst();
//     document.getElementById("label").appendChild(rowTitle);
//     for(let k of keys.GetKeys()){
//         let titleRow = document.createElement("th");
//         titleRow.textContent=k;
//         titleRow.classList="titleTable";
//         rowTitle.appendChild(titleRow);
//     }

//     let arrayEmp = employees.GetArraySortReverse();
//     let somme = 0;
//     for(let emp of arrayEmp){
//         let rowData = document.createElement("tr");
//         document.getElementById("data").appendChild(rowData);
//         let dup = document.createElement("button");
//         let del = document.createElement("button");
//         dup.textContent="Duplicate";
//         dup.classList="buttonDup";
//         del.textContent="Delete";
//         del.classList="buttonDel";    
//         for(let e of emp.GetValues()){
//             let data = document.createElement("td");
//             data.textContent=e;
//             data.classList="dataTable";
//             rowData.appendChild(data);
//         }
//         somme+=parseFloat(emp.GetSalaryMonth());
//         let actions = document.createElement("td");
//         actions.classList="dataTable";
//         actions.appendChild(dup);
//         actions.appendChild(del);
//         rowData.appendChild(actions);
//     }   
//     console.log(somme.toFixed(2))
// }