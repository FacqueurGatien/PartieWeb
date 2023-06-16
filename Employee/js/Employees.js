import {Employee} from "./Employee.js";
class Employees{
    constructor(_link){
        this.employeesList=[];
        this.link=_link;
    }
    async CreateArray(){
        let response = await fetch(this.link);
        let jsonConverted = await response.json();

        for(let item of jsonConverted.data){
            console.log(item)
            this.employeesList.push(new Employee(item));
        }
    }
    GetArraySort(){
        return this.employeesList.sort((a, b) => a.salary > b.salary ? 1:-1);
    }
    GetArraySortReverse(){
        return this.employeesList.sort((a, b) => a.salary < b.salary ? 1:-1)
    }
    GetFirst(){
        try{
            if(this.employeesList.concat.length>0)
            {
                return this.employeesList[0];
            }         
        }catch{
            console.log("La liste est vide.");
        }
    }
    async GetById(id){
        try{
        for(let e of this.employeesList){
            if(e.id == id){
                return await e;
            }
        }}catch{}
    }
    async CopieEmp(id,newId=0){
        let copie = await  this.GetById(id);
        return new Employee(copie,newId)
    }

}
export {Employees};