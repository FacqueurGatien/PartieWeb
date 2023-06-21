import {GenerationMain} from "./GenerationMain.js"
class GenerationHeader{
    constructor(_cereals){
        this.header=document.getElementById("header");
        this.cereals=_cereals;
        this.main = new GenerationMain(this.cereals);
    }
    Generer(){
        this.header.appendChild(this.Titre());
        this.header.appendChild(this.CadreRecherche());
        this.header.appendChild(this.CadreFiltre());
        this.main.Generer();
    }
    Titre(){
        let titre = document.createElement("h1");
        titre.textContent="Cereals";
        titre.setAttribute("id","headerTitre");

        return titre;
    }
    CadreRecherche(){
        let cadreRecherche = document.createElement("fieldset");
        cadreRecherche.setAttribute("id", "rechercher");

        let cadreTitre = document.createElement("legend"); 
        cadreTitre.textContent = "Rechercher";
        cadreTitre.className = "fieldsetTitre"

        let input = document.createElement("input");
        input.placeholder="Nom du Céréale";
        input.type ="search";
        input.setAttribute("id", "rechercherInput");
        input.addEventListener("input",(e)=>{
            this.main.Generer(this.cereals.SortCereals())
        });

        cadreRecherche.appendChild(cadreTitre);
        cadreRecherche.appendChild(input);

        return cadreRecherche;
    }
    CadreFiltre(_array){
        let cadreFiltre = document.createElement("fieldset");
        cadreFiltre.id="filtrer";

        let cadreTitre = document.createElement("legend"); 
        cadreTitre.textContent = "Filtrer";
        cadreTitre.className = "fieldsetTitre";

        cadreFiltre.appendChild(cadreTitre);

        cadreFiltre.appendChild(this.CadreNutriscore(["A","B","C","D","E"]));
        cadreFiltre.appendChild(this.CadreCategorie(_array));

        return cadreFiltre;
    }
    CadreNutriscore(){
        let cadreNutriscore = document.createElement("fieldset");
        cadreNutriscore.id = "nutriscore";
            
        let cadreTitre = document.createElement("legend");
        cadreTitre.textContent = "Nutriscore";
        cadreTitre.className = "fieldsetTitre";

        let div = document.createElement("div");
        div.id="nutriscoreDiv";

        for(let score of ["A","B","C","D","E"]){
            let checkbox = document.createElement("input");
            checkbox.type = "checkbox";
            checkbox.className = "nutriscoreCheckbox";
            checkbox.id=score;
            checkbox.addEventListener("click",(e)=>{
                this.main.Generer(this.cereals.SortCereals())
            });
            let label = document.createElement("label");
            label.for=score;
            label.className = "nutriscoreLabel";
            label.textContent = score;

            div.appendChild(checkbox);
            div.appendChild(label);
        }

        cadreNutriscore.appendChild(cadreTitre);
        cadreNutriscore.appendChild(div);

        return cadreNutriscore;
    }
    CadreCategorie(){
            let cadreCategorie = document.createElement("fieldset");
            cadreCategorie.id="categorie";

            let cadreTitre = document.createElement("legend");
            cadreTitre.textContent = "Categorie";
            cadreTitre.className = "fieldsetTitre"

            let select = document.createElement("select");
            select.id="categorieSelect";
            select.name="categorie";
            select.addEventListener("change",(e)=>{
                this.main.Generer(this.cereals.SortCereals())
            });

            for(let op of ["Tous","Sans sucre","Pauvre en Sel","Boost"]){
                let option = document.createElement("option");
                option.id=op
                option.textContent=op;
                option.value=op;
                select.appendChild(option);
            } 

            cadreCategorie.appendChild(cadreTitre);
            cadreCategorie.appendChild(select);

            return cadreCategorie;
    }
}
export{GenerationHeader}