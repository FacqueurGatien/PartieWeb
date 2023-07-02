import { Tools } from "../Tools/tools.js";
class Equipe{
    constructor(){
        this.link = document.getElementById("cssPage");
        this.link.href = "./Styles/Equipe.css";
        this.main = document.getElementById("main");
        this.Generer();
    }
    Generer(){
        let section1=Tools.Balise("section","","","section1Equipe");
        section1.appendChild(Tools.Balise("h1","Notre présence dans le monde !","h1Titre h1TitreEquipe"));
        section1.appendChild(Tools.Balise("p","HandiA11y est un site fictif en cours de création permettant d'effectuer des tests d'accessibilité avec un un lecteur d'écran comme NVDA ou JAWS."));

        let section1b=Tools.Balise("section","","","section1bEquipe");
        section1b.appendChild(Tools.Balise("h2","Une équipe dirigeante à la pointe de la technologie (Paris)","h2Titre h2TitreEquipe"));
        section1b.append(this.Block("./Image/Equipe/directrice.png","Photo de Raymonde Muche","Directrice et experte en développement web","Raymonde Muche","DirectriceEquipe"));
        let divEquipe = Tools.Balise("div","","","divEquipe");
        divEquipe.appendChild(this.Block("./Image/Equipe/communication.png","Photo de Barbara Coiffure","Communication","Barbara Coiffure"));
        divEquipe.appendChild(this.Block("./Image/Equipe/rh.png","Photo de Johnny PasDepp","Relations clients","Johnny PasDepp"));
        divEquipe.appendChild(this.Block("./Image/Equipe/webmaster.png","Photo de Ariana PasGrandé","Accessibilité","Ariana PasGrandé"));
        divEquipe.appendChild(this.Block("./Image/Equipe/noixdecoco.png","Photo de la mascotte de l'equipe","Mascotte","Noix de Coco"));
        section1b.appendChild(divEquipe);

        let section2=Tools.Balise("section","","","section2Equipe");
        section2.appendChild(Tools.Balise("h2","Notre implantation est pourtant réelle ( enfin, presque ;) )","h2Titre h2TitreEquipe","h2Section2Equipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Paris\" target=\"blank\">Paris</a> le siège (France) - 4 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/New_York\" target=\"blank\">New York</a> (Etats-Unis) - 12 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Londres\" target=\"blank\">Londres</a> (Royaume-Unis) - 18 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Tokyo\" target=\"blank\">Tokyo</a> (Japon) - 10 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Berlin\" target=\"blank\">Berlin</a> (Allemagne) - 8 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Moscou\" target=\"blank\">Moscou</a> (Russie) - 1 bénévole","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Pekin\" target=\"blank\">Pekin</a> (Chine) - 200 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Sydney\" target=\"blank\">Sydney</a> (Australie) - 9 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Sao_Paulo\" target=\"blank\">São Paulo</a> (Bresil) - 7 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Dubai\" target=\"blank\">Dubai</a> (Emirats arabes unis) - 13 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Rome\" target=\"blank\">Rome</a> (Italie) - 11 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Mexico\" target=\"blank\">Mexico</a> (Mexique) - 16 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Singapour\" target=\"blank\">Singapour</a> (Singapour) - 19 bénévoles","lieuxEquipe"));
        section2.appendChild(Tools.Balise("p","<a class=\"lienWiki\" href=\"https://fr.wikipedia.org/wiki/Mumbai\" target=\"blank\">Mumbai</a> (Inde) - 6 bénévoles","lieuxEquipe"));
        
        this.main.appendChild(section1);
        this.main.appendChild(section1b);
        this.main.appendChild(section2);
    }

    Block(lienImage,alt,role,nom,directrice=""){
        if(directrice!=""){
            let section = Tools.Balise("section","","sectionEquipe",directrice);
            section.appendChild(Tools.Balise("img","","imgBlockEquipe",directrice+"Image","src",lienImage,"alt",alt));
        }
        else{
            let section = Tools.Balise("section","","sectionEquipe");
            section.appendChild(Tools.Balise("img","","imgBlockEquipe","equipeImage","src",lienImage,"alt",alt));
        }
        let section = Tools.Balise("section","","sectionEquipe",directrice);
        section.appendChild(Tools.Balise("img","","imgBlockEquipe",directrice+"Image","src",lienImage,"alt",alt));

        section.appendChild(Tools.Balise("h2",role,"h2Titre h2TitreBlockEquipe"));
        section.appendChild(Tools.Balise("p",nom));
        return section;
    }
}
export { Equipe }