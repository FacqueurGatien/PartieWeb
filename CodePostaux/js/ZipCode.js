class ZipCode{
    constructor(_zipCode){
        Object.assign(this,_zipCode)
    }

    async GetKeys(){
        return Object.keys(this);
    }
    async GetValues(){
        return Object.values(this);
    }
}
export {ZipCode}