import { A11y } from "./GeneratePage/A11y.js";
import { Acceuil } from "./GeneratePage/Acceuil.js";
import { Handicaps } from "./GeneratePage/Handicaps.js";
import { FaireDon } from "./GeneratePage/FaireDon.js";
import { Equipe } from "./GeneratePage/Equipe.js";
import {PlanSite} from "./GeneratePage/PlanSite.js"
class Root{
    constructor(page,tag=""){
        this.rooter(page,tag);
    }   
    rooter(page,tag){
        document.getElementById("main").innerHTML=""
        switch(page){
            case "Accueil":
                new Acceuil();
                break;
            case "A11y":
                new A11y();
                break;
            case "Handicaps":
                new Handicaps();
                break;
            case "Faite un don":
                new FaireDon();
                break;
            case "Equipe":
                new Equipe();
                break;
            case "Plan du site":
                new PlanSite();
                break;
        }
        if(tag!=""){
            setTimeout(()=>{document.location.href="#"+tag;},10);
        }
    }
}
export {Root}