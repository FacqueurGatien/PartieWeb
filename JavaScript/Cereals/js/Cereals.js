import {Db} from "./db.js";
import {Cereal} from "./Cereal.js";
class Cereals{
    constructor(){
        this.cerealsCollection=[];
    }

    async GetCereals(){
        let reponse = await Db.fetchData("https://arfp.github.io/tp/web/frontend/cereals/cereals.json");

        for(let cereal of reponse.data){
            this.cerealsCollection.push(new Cereal(cereal));
        }
    
        return this.cerealsCollection;
    }
    GetFirst(){
        try{
            return this.cerealsCollection[0];
        }catch{}
    }
    DeleteCereal(_id){
        this.cerealsCollection=this.cerealsCollection.filter(cer=>cer.id!=_id);
    }

    SortCereals(){
        let array=[]
        let nb=0;
        for(let c of ["A","B","C","D","E"]){
            if(document.getElementById(c).checked){
                nb++;
                for(let cereal of this.cerealsCollection){
                    if(this.CalculeNutriscore(cereal.rating)==c){
                        array.push(cereal);
                    }
                }
            }
        }
        let sel = document.getElementById("categorieSelect")
        if(sel.value!="Tous"){
            if(nb==0){
                nb++;
                array=this.AjoutCategorie(this.cerealsCollection,sel);
            }
            else{
                array=this.AjoutCategorie(array,sel);
            }
        }
        let search=document.getElementById("rechercherInput");
        if(nb==0){
            return this.SearchCerealNom(search.value,this.cerealsCollection);
        }
        else{
            return this.SearchCerealNom(search.value,array);
        }
    }
    AjoutCategorie(_array,_sel){
        let array=[];
        for(let t of _array){
            array.push(t)
        }
        if(_sel.value=="Sans sucre"){
            return array.filter(ss=>ss.sugars < 1);
        }
        else if(_sel.value=="Pauvre en Sel"){
            return array.filter(ss=>ss.sodium < 50);
        }
        else if(_sel.value=="Boost"){
            return array.filter(ss=>ss.vitamins >= 25 && ss.fiber >= 10);
        }
        else{
            return _array;
        }
    }
    GetKeys(){
        return ["ID","NOM","CALORIES","PROTEÏNES","SEL","FIBRES","GLUCIDES","SUCRE","POTASSIUM","VITAMINES","EVALUATION","NS","DEL"];
    }
    CalculeNutriscore(_evaluation){
        if(parseFloat(_evaluation)>=80){
            return "A"
        }
        else if(parseFloat(_evaluation)>=70){
            return "B";
        }
        else if(parseFloat(_evaluation)>=55){
            return "C";
        }
        else if(parseFloat(_evaluation)>=35){
            return "D";
        }
        else{
            return "E";
        }
    }
    SearchCerealNom(_text,_array=this.cerealsCollection){
        if(_text!=""){
            return _array.filter(sn=>(sn.name.toLowerCase()).includes(_text.toLowerCase()));
        }
        else{
            return _array;
        }
    }
}
export {Cereals};