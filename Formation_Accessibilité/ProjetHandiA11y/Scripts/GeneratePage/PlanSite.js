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
        let ul = Tools.Balise("ul","","","ulPlanSite")
        ul.appendChild(this.LiGenegateur("Accueil","","Accueil","lienPlan"));
        ul.appendChild(this.Accueil());
        this.main.appendChild(ul);
    }
    Accueil(){
        let ul =Tools.Balise("ul","","","ulPlanSiteTab")
        ul.appendChild(this.LiGenegateur("Accueil","introduction","Introduction sur HandiA11y","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Accueil","wcagPrincipes","Les 4 principes","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Accueil","wcagTablePrincipe","Tableau des critères WCAG 2.1","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Accueil","wcagTableNiveaux","Tableau des niveaux de conformité WCAG 2.1","lienPlanTab"));
        ul.appendChild(this.LiGenegateur("Accueil","graphic","Graphique et tableau des échecs les plus courants par WebAIM","lienPlanTab"));
        return ul;
    }
    LiGenegateur(page,id,text,classe){
        let li = Tools.Balise("li",text,classe);
        li.dataset.tag=id;
        li.addEventListener("click",(e)=>{
            console.log(e.target.dataset.tag)
            new Root(page,e.target.dataset.tag);
        });
        return li;
    }
}
export {PlanSite}