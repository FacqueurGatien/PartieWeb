import { Db } from "./db.js";
import { Employee } from "./Employee.js";

class Employees 
{
    constructor()
    {
        this.employeesCollection = [];
        this.sortOrder=true;
    }

    async GetEmployees()
    {
        let reponse = await Db.fetchData('https://arfp.github.io/tp/web/frontend/employees/employees.json');

        for(let employee of reponse.data){
            this.employeesCollection.push(new Employee(employee));
        }

        return this.employeesCollection;
    }

    deleteEmployee(id){
        this.employeesCollection=this.employeesCollection.filter(emp=>emp.id!=id);
    }

    
    duplicateEmployee(id){
        let employee = this.employeesCollection.find(emp=>emp.id==id);
        let maxId = Math.max.apply(Math, this.employeesCollection.map(function(emp){return emp.id}));
        if(employee instanceof Employee){
            let newEmployee = new Employee(employee);
            newEmployee.id = ++maxId;
            this.employeesCollection.push(newEmployee);
        }
    }

    sortBySalary(){
        console.log(this.employeesCollection);
        this.employeesCollection.sort((a,b)=>a.employee_salary - b.employee_salary);
        console.log("bbbb");
        if(!this.sortOrder){
            this.employeesCollection.reverse();
        }
        this.sortOrder=!this.sortOrder;
    }

    /* Ajouter les méthodes pour rechercher, supprimer et dupliquer un employé dans employeesCollection */
}
export { Employees }