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
            this.employeesList.push(new Employee(item));
        }
    }
    GetArray(){
        return this.employeesList;
    }
}
export {Employees};