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
}
export {cartes};