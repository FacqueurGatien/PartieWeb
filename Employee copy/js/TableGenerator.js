class TableGenerator{
    
    constructor(employeeTable){
        this.employees = employeeTable;
        this.tBody=document.getElementById("tableBody");
    }

    GenerateBody(){
        this.tBody.innerHTML="";
        for(let employee of this.employees.employeesCollection){
            let row = document.createElement("tr");
            this.tBody.appendChild(row);
            this.GenerateCell(row,employee.id);
            this.GenerateCell(row,employee.employee_name);
            this.GenerateCell(row,employee.email);
            this.GenerateCell(row,employee.salary);
            this.GenerateCell(row,employee.year);
            this.GenerateCellButton(row,employee);
        }
    } 

    GenerateCell(row,data){
        let cell = document.createElement("td");
        cell.textContent=data;
        row.appendChild(cell);
    }

    GenerateCellButton(row,emp){
        let cell = document.createElement("td");
        cell.classList.add("button")

        let buttonDuplicate = document.createElement("button");
        buttonDuplicate.addEventListener("click",(e)=>this.employeeDupclicate(e));
        buttonDuplicate.textContent="Duplicate";
        buttonDuplicate.dataset.id=emp.id;

        let buttonDelete = document.createElement("button");
        buttonDelete.addEventListener("click",(e)=>this.employeeDelete(e));
        buttonDelete.textContent="Delete";
        buttonDelete.dataset.id=emp.id;

        cell.appendChild(buttonDuplicate);
        cell.appendChild(buttonDelete);

        row.appendChild(cell);
    }

    employeeDupclicate(e){
        this.employees.duplicateEmployee(e.target.dataset.id);
        this.GenerateBody();
    }

    employeeDelete(e){
        this.employees.deleteEmployee(e.target.dataset.id);
        this.GenerateBody();
    }
}
export {TableGenerator}