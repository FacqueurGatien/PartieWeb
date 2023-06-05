import {carte} from "./carte.js";
import {cartes} from "./cartes.js";

var lien= "https://arfp.github.io/tp/web/frontend/cardgame/cardgame.json";

const cartesList = new cartes(lien);
await cartesList.fetchJson();

const t_thead=document.getElementById("tableau_h");
const t_body=document.getElementById("tableau_b");
const t_foot=document.getElementById("tableau_f");

function createTitre(){
    let row = document.createElement("tr");


    for(let content of cartesList.getFirst().getKeys()){
            let cell = document.createElement("th");
            cell.textContent=content;
            row.appendChild(cell);
    }
    t_thead.appendChild(row);
}

function createTable(){

    for(let carte of cartesList.cartes){

        let row = document.createElement("tr");

        for(let content of carte.getValues()){
            let cell = document.createElement("td");
            cell.textContent=content;
            row.appendChild(cell);
        }
        
        t_body.appendChild(row);
    }
}

function createTable2(stat){
    let maximum=0;
    let idCarte=0;

    let test = cartesList.getFirst()

    if(test[stat]-test[stat]==0){
        let row = document.createElement("tr");
        let rowTitre = document.createElement("tr");
    
        for(let carte of cartesList.cartes){
            if(carte[stat]>maximum){
                maximum=carte[stat]
                idCarte=carte["id"];
            }  
        }
        t_foot.appendChild(rowTitre);
        let cellTitre = document.createElement("th");
        cellTitre.colSpan=cartesList.getFirst().getKeys().length;
    

        cellTitre.textContent="Carte avec la plus grande stat "+"\""+stat+"\"";
        rowTitre.appendChild(cellTitre);
        for(let c of cartesList.getCarteId(idCarte).getValues()){
    
            let cell = document.createElement("td");
            cell.textContent=c;
            row.appendChild(cell);
        }
    
        t_foot.appendChild(row);
    }

}

function createFooter(){
    for(let i of cartesList.getFirst().getKeys()){
    createTable2(i);
    }


}




createTitre();
createTable();
createFooter()