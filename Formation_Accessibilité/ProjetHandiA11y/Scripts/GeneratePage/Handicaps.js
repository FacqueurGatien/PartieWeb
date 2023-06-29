import {Tools} from "../Tools/tools.js"
class Handicaps{
    constructor(){
        this.link = document.getElementById("cssPage");
        this.link.href="./Styles/Handicaps.css";
        this.main = document.getElementById("main");
        this.Generate();
    }
    Generate(){
        this.main.appendChild(Tools.Balise("h1","Symboles et types de handicaps","h1Titre"));
        this.main.appendChild(this.Section("./Image/HandicapsImage/vue.jpg","logo du handicap viseul","Handicap visuel","Le handicap visuel désigne les limitations fonctionnelles liées à la vision, que ce soit une cécité totale ou partielle. Les personnes atteintes de handicap visuel peuvent utiliser des aides techniques telles que les plages brailles, les synthèses vocales, ou les dispositifs d'agrandissement de texte pour accéder à l'information."));
        this.main.appendChild(this.Section("./Image/HandicapsImage/audition.jpg","logo du handicap auditif","Handicap auditif","Le handicap auditif concerne les limitations fonctionnelles liées à l'ouïe, que ce soit une surdité totale ou partielle. Les personnes atteintes de handicap auditif peuvent utiliser des appareils auditifs, des boucles magnétiques ou des sous-titres pour accéder à l'information sonore."));
        this.main.appendChild(this.Section("./Image/HandicapsImage/moteur.jpg","logo du handicap moteur","Handicap moteur","Le handicap moteur concerne les limitations physiques comme l'incapacité à utiliser une souris ou la nécessité d'avoir une temps de réponse plus lent."));
        this.main.appendChild(this.Section("./Image/HandicapsImage/psy.jpg","logo du handicap cognitif","Handicap cognitif","Le handicap cognitif concerne les problèmes de troubles de l'apprentissage, l'incapacité à se souvenir ou à se concentrer sur de grandes quantités d'informations, difficultés de lecture et de compréhension, difficultés à prendre des décisions."));
        let section = document.createElement("section");
        section.id="materiels";
        section.appendChild(Tools.Balise("h2","Quelques matériels d'accessibilité","h2Titre titreMateriels"));
        section.appendChild(this.DivMateriel("./Image/HandicapsImage/canneBlanche.jpg","Canne pour personnes aveugles"));
        section.appendChild(this.DivMateriel("./Image/HandicapsImage/braille.png","Plage braille"));
        section.appendChild(this.DivMateriel("./Image/HandicapsImage/micro.png","Synthèse vocale"));
        section.appendChild(this.DivMateriel("./Image/HandicapsImage/trackball.jpg","Trackball (remplace la souris)"));
        this.main.appendChild(section);
        
    }
    Section(lienImage,alt,titre,paragraphe){
        let section = Tools.Balise("section","","sectionHandicaps");
        section.appendChild(Tools.Balise("img","","imageSectionHandicaps","","src",lienImage,"alt",alt));
        let div = Tools.Balise("div","","divHandicaps");
        div.appendChild(Tools.Balise("h2",titre,"h2Titre h2TitreHandicaps"));
        div.appendChild(Tools.Balise("p",paragraphe));
        section.appendChild(div);

        return section;
    }
    DivMateriel(lienImage,texte){
        let div = Tools.Balise("div","","materiel");
        div.appendChild(Tools.Balise("img","","materielImage","","src",lienImage));
        div.appendChild(Tools.Balise("p",texte));
         return div;
    }
}
export {Handicaps}