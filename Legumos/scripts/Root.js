import { LegumeTable } from "./Legumes/GenerateTableLegume/LegumeTable.js";
import { VenteTable } from "./Ventes/GenerateTableVente/VenteTable.js";

class Root{
    static rooter(page,l,v){
        document.getElementById("main").innerHTML=""
        let css = document.getElementById("css");
        let t;
        switch(page){
            case "Legumes":
                css.href="./styles/legumes.css";
                t = new LegumeTable(l);
                t.generateTable();
                break;
            case "Ventes":
                css.href="./styles/ventes.css";
                t = new VenteTable(v);
                t.generateTable();
                break
        }
    }
}
export {Root}