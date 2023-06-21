import {carte} from "./carte.js";

class cartes{
    constructor(_lien){
        this.cartes=[];
        this.lien = _lien;
    }
    async fetchJson(){
        let reponse = await fetch(this.lien);
        let temp = await reponse.json();
        for(let c of temp){
            this.cartes.push(new carte(c));
        }
    }
    getFirst(){
        try{
            return this.cartes[0]
        }catch(error){
            alert("La collection est vide");
        }
    }
    getCarteId(id){
        for(let carte of this.cartes){
            if(carte["id"]==id){
                return carte;
            }
        }
    }
    getCarteMaxStat(stat){
        
        let maximum=0;
        let idCarte=0;
        let testStat = this.getFirst()

        if(testStat[stat]-testStat[stat]==0){    
            for(let carte of this.cartes){
                if(carte[stat]>maximum){
                    maximum=carte[stat]
                    idCarte=carte["id"];
                }  
            }
        }
        return this.getCarteId(idCarte);
    }
    getCarteMaxStatArray(stat){
        let array = stat;
        let arrayToReturn=[];
        for(let a of array){
            arrayToReturn.push(this.getCarteMaxStat(a));
        }
        return arrayToReturn;
    }
}
export {cartes};