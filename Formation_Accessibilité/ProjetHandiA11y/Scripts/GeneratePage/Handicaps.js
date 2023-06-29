import {Tools} from "../Tools/tools.js"
class Handicaps{
    constructor()
    {
        this.link = document.getElementById("cssPage");
        this.link.href="./Styles/Handicaps.css";
        this.main = document.getElementById("main");
        this.Generate();
    }
    Generate(){
        this.main.appendChild(Tools.Balise("h1","Symboles et types de handicaps","h1Titre"));
        this.main.appendChild(Tools.Balise("h2"));
    }
    Section(lienImage,alt,titre,paragraphe){
        let section = Tools.Balise("section","","","sectionHandicpas");
        section.appendChild(Tools.Balise("img","","","imageSectionHandicaps","src",lienImage,"alt",alt));
        let div = Tools.Balise("div","","divHandicaps");
        div.appendChild(Tools.Balise("h2",titre,"h2Titre h2TitreHandicaps"));
        div.appendChild(Tools.Balise("p",paragraphe));
        section.appendChild(div);

        return section;
    }
}
export {Handicaps}