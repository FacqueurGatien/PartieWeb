import {Root} from "../Root.js"
import { Tools } from "../Tools/tools.js";
class Header{
    constructor(){
        this.page="Accueil";
        this.navBar = document.getElementById("navBar")
        this.ul = document.getElementById("pageLink");
        this.root = new Root(this.page);
        this.GenerateHeader();
    }
    GenerateHeader(){

        this.navBar.prepend(Tools.Balise("img","","","logoImg","src","./Image/logo.png","alt","Logo du site"));
        this.ul.appendChild(Tools.Balise("p","-"));
        this.ul.appendChild(this.liGenerate("Accueil"));
        this.ul.appendChild(Tools.Balise("p","-"));
        this.ul.appendChild(this.liGenerate("A11y"));
        this.ul.appendChild(Tools.Balise("p","-"));
        this.ul.appendChild(this.liGenerate("Handicaps"));
        this.ul.appendChild(Tools.Balise("p","-"));
        this.ul.appendChild(this.liGenerate("Faite un don"));
        this.ul.appendChild(Tools.Balise("p","-"));
        this.ul.appendChild(this.liGenerate("Equipe"));
        this.ul.appendChild(Tools.Balise("p","-"));
        this.ul.appendChild(this.liGenerate("Plan du site"));
    
        let divRecherche = Tools.Balise("div","","","rechercher");
        divRecherche.appendChild(Tools.BaliseA("input","","","rechercherInput",["ariaLabel","type","placeholder"],["rechercher","search","Rechercher"]));
        divRecherche.appendChild(Tools.Balise("button","Rechercher","","rechercherButton"));
        this.navBar.appendChild(divRecherche);
        
    }
    liGenerate(text,lien=""){
        let li = document.createElement("li");

        li.classList.add("puceNavBar");
        li.classList.add("lienNav");
        li.textContent=text;

        li.dataset.page=text;
        li.addEventListener("click",(e)=>this.liFunction(e));
        return li
    }

    separateur(){
        let p=document.createElement("p");
        p.textContent="-";
        return p;
    }
    liFunction(e){
        this.page=(e.target.dataset.page);
        this.root.rooter(this.page);
    }
}
export {Header}

