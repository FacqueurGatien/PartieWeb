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
    let array = cartesList.getCarteMaxStatArray(stat);
    let count=0;
    for(let carte of array){
        let row = document.createElement("tr");
        let rowTitre = document.createElement("tr");
        t_foot.appendChild(rowTitre);
        let cellTitre = document.createElement("th");
        cellTitre.colSpan=carte.getKeys().length-1;
        cellTitre.textContent="Carte avec la plus grande stat "+"\""+stat[count]+"\"";
        rowTitre.appendChild(cellTitre);
        for(let c of cartesList.getCarteId(carte['id']).getValues()){
            let cell = document.createElement("td");
            cell.textContent=c;
            row.appendChild(cell);
        }
        t_foot.appendChild(row);
        count++;
    }
}

function createFooter(){
//     for(let i of cartesList.getFirst().getKeys()){
//     createTable2(i);
//     }
    let cartes = ['attack','armor','played','victory'];
    createTable2(cartes);

}




createTitre();
createTable();
createFooter()