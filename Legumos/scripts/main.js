import {LegumesCollection} from "./Legumes/LegumesCollection.js";
import {VentesCollection} from "./Ventes/VentesCollection.js";
import {LegumeTable} from "./Legumes/GenerateTableLegume/LegumeTable.js"
import {EventClass} from "./EventClass/EventClass.js"
import {Root} from "./Root.js"




let legumes = new LegumesCollection();
await legumes.getData();

let ventes = new VentesCollection();
await ventes.getData();
console.log(ventes)


EventClass.legumes=legumes;
EventClass.ventes=ventes;


let lien = document.querySelectorAll(".navPart a");
lien.forEach(l=>l.addEventListener("click",()=>{
    Root.rooter(l.id,legumes,ventes);
}));

