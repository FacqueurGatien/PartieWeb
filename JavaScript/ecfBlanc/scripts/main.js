import { VolCollection } from "./volsCollection.js";
import {GenerationTableau} from "./GenerationTableau.js";
import {VolEvent} from "./VolEvent.js"

let volCollection = new VolCollection();
await volCollection.load();

let generationTableau = new GenerationTableau(volCollection);
generationTableau.generationTableau();

VolEvent.volCollection=volCollection;

let volEntete=document.querySelectorAll(".volEntete");

for(let ve of volEntete){
    ve.addEventListener("click",(e)=>{
        VolEvent.columnSortEvent(e);
        generationTableau.generationTableau();
    })
}