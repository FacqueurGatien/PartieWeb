class Employee{
    constructor(_employee){
        this.id = _employee.id;
        this.fullName = _employee.employee_name;
        this.salary = _employee.employee_salary;
        this.year = _employee.employee_age;
    }
    GetValues(){
        return [this.id,this.fullName,this.GetEmail(),this.GetSalaryMonth(),this.GetYearBirth()];
    }

    GetKeys(){

        return ["Id","FullName","Email","Salary Month","Year of Birth"];
    }

    GetNameArray(){
        return [this.fullName.split(' ')[0],this.fullName.split(' ')[1]]
    }

    GetEmail(){
        let name = this.GetNameArray();
        return name[0][0].toLowerCase()+"."+name[1].toLowerCase()+"@email.com";
    }

    GetSalaryMonth(){
        return (this.salary/12).toFixed(2);
    }

    GetYearBirth(){
        let date = new Date();
        return date.getFullYear()-this.year;
    }

    GetEmployeeFormat(){
        return [this.id,this.fullName,this.GetEmail(),this.GetSalaryMonth(),this.GetYearBirth()];
    }
}
export {Employee};