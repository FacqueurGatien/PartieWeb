class Cereal{
    constructor(_cereal){
        Object.assign(this,_cereal);
    }

    GetKeys(){
        return Object.keys(this);    
    }

    GetValues(){
        return Object.values(this);
    }
}
export {Cereal};