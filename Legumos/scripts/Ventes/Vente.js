class Vente{
    constructor(vente){
        Object.assign(this,vente);
    }
    getValues(){
        return Object.values(this);
    }
}
export {Vente}