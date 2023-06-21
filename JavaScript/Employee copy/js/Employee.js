class Employee{
    constructor(employee){
        Object.assign(this,employee);
        this.email = this.GetEmail();
        this.year = this.GetYearOfBirth();
        this.salary = this.GetSalary();
    }

    GetKeys(){
        return Object.keys(this);
    }

    GetValues(){
        return Object.values(this);
    }

    GetEmail(){
        return this.employee_name[0].toLowerCase()+"."+this.employee_name.split(" ")[1].toLowerCase()+"@email.com"
    }

    GetSalary(){
        return (this.employee_salary/12).toFixed(2);
    }

    GetYearOfBirth(){
        return new Date().getFullYear()-this.employee_age;
    }
}
export {Employee};