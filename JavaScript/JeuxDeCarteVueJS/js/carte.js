class carte{
    constructor(_carte){
        //for(let content in _carte){
        //    this[content]=_carte[content]
        //}
        Object.assign(this,_carte);
    }

    getValues(){
        return Object.values(this);
    }

    getKeys(){

        return Object.keys(this);
    }
}
export {carte};