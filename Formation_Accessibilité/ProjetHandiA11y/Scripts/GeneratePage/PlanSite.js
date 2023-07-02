import {Tools} from "../Tools/tools.js";
import {Root} from "../Root.js";
class PlanSite{
    constructor(){
        this.link=document.getElementById("cssPage");
        this.link.href="./Styles/PlanSite.css";
        this. main = document.getElementById("main");
        this.GenerateTest();
    }
    GenerateTest(){
        let ulAccueil = Tools.Balise("ul","","ulPlanSite");
        ulAccueil.appendChild(this.LiGenegateur("Accueil","","Accueil","lienPlan"));
        ulAccueil.appendChild(this.Accueil());

        let ulA11y = Tools.Balise("ul","","ulPlanSite");
        ulA11y.appendChild(this.LiGenegateur("A11y","header","A11y","lienPlan"));
        ulA11y.appendChild(this.A11y());

        let ulHandicaps = Tools.Balise("ul","","ulPlanSite");
        ulA11y.appendChild(this.LiGenegateur("Handicaps","header","Les handicaps et quelques matériels","lienPlan"));
        ulA11y.appendChild(this.Handicaps());

        let ulFaireDon = Tools.Balise("ul","","ulPlanSite");
        ulFaireDon.appendChild(this.LiGenegateur("Faite un don","header","Faites un don (formulaire)","lienPlan"));

        let ulEquipe = Tools.Balise("ul","","ulPlanSite");
        ulEquipe.appendChild(this.LiGenegateur("Equipe","header","Equipe","lienPlan"));
        ulEquipe.appendChild(this.Equipe());

        let ulPlan = Tools.Balise("ul","","ulPlanSite");
        ulPlan.appendChild(this.LiGenegateur("Plan du site","header","Plan du site"));

        this.main.appendChild(ulAccueil);
        this.main.appendChild(ulA11y);
        this.main.appendChild(ulHandicaps);
        this.main.appendChild(ulFaireDon);
        this.main.appendChild(ulEquipe);
        this.main.appendChild(ulPlanSite);
    }
    Accueil(){
        let ul =Tools.Balise("ul","","","ulPlanSiteTab")
        ul.appendChild(this.LiGenegateur("Accueil","main","Introduction sur HandiA11y","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Accueil","wcagPrincipes","Les 4 principes","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Accueil","wcagTablePrincipe","Tableau des critères WCAG 2.1","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Accueil","wcagTableNiveaux","Tableau des niveaux de conformité WCAG 2.1","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Accueil","graphic","Graphique et tableau des échecs les plus courants par WebAIM","lienPlanTab"));
        return ul;
    }
    A11y(){
        let ul =Tools.Balise("ul","","","ulPlanSiteTab")
        ul.appendChild(this.LiGenegateur("A11y","main","Quelques bonnes pratiques","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("A11y","audit","Comment faire un audit ?","lienPlanTab"));
        return ul;
    }
    Handicaps(){
        let ul =Tools.Balise("ul","","","ulPlanSiteTab")
        ul.appendChild(this.LiGenegateur("Handicaps","main","Handicaps et les symboles","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Handicaps","materiels","Quelques exemples de matériels","lienPlanTab"));
        return ul; 
    }
    Equipe(){
        let ul =Tools.Balise("ul","","","ulPlanSiteTab")
        ul.appendChild(this.LiGenegateur("Equipe","main","Pourquoi ce site ?","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Equipe","section1bEquipe","Organigramme de la société","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Equipe","section2Equipe","Liste des implantations dans le monde","lienPlanTab"));
        return ul;
    }
    LiGenegateur(page,id,text,classe){
        let li = Tools.Balise("li",text,classe);
        li.dataset.tag=id;
        li.addEventListener("click",(e)=>{
            new Root(page,e.target.dataset.tag);
        });
        return li;
    }
}
export {PlanSite}