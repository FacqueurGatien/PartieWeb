import {Root} from "../Root.js"
class Header{
    constructor(){
        this.page="Accueil";
        this.GenerateHeader();
        this.root = new Root(this.page);
    }
    GenerateHeader(){
        let header1 = document.getElementById("pageLink");
        let nav = document.getElementById("navBar");
    
        let img = document.createElement("img");
        img.id="logoImg";
        img.src="./Image/logo.png"
        img.alt=""
    
        let ul = document.getElementById("pageLink");
        header1.appendChild(this.liGenerate("Equipe"));
        header1.appendChild(this.separateur());
        header1.appendChild(this.liGenerate("Faite un don"));
        header1.appendChild(this.separateur());
        header1.appendChild(this.liGenerate("Handicaps"));
        header1.appendChild(this.separateur());
        header1.appendChild(this.liGenerate("A11y"));
        header1.appendChild(this.separateur());
        header1.appendChild(this.liGenerate("Accueil"));
    
    
        let divRecherche = document.createElement("div");
    
        let input = document.createElement("input");
        input.id="rechercherInput";
        input.ariaLabel="rechercher";
        input.type="search";
        input.placeholder="rechercher";
    
        let buttonR = document.createElement("button");
        buttonR.id="rechercherButton";
        buttonR.onclick="";
        buttonR.textContent="Rechercher";
        divRecherche.id="rechercher";
    
        divRecherche.appendChild(input);
        divRecherche.appendChild(buttonR);
    
        nav.appendChild(img);
        nav.append(ul);
        nav.appendChild(divRecherche);
        
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

