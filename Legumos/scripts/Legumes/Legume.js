class Legume{
    constructor(legume){
        Object.assign(this,legume);
    }
    getValues(){
        return Object.values(this);
    }
    getValuesP(){
        return [this.Name, this.Variety, this.PrimaryColor, this.LifeTime ,this.Fresh];
    }
}
export {Legume}