class Acceuil{
    constructor(){
        this.link=document.getElementById("cssPage");
        this.link.href="./Styles/Accueil.css";
        this.main = document.getElementById("main");
        this.Accueil();
        //window.location.href="./index.html#graphicImg"
    }
    rectangle(classDiv,classH3,textH3,textP){
        let div = this.Balise("div","",classDiv);
        div.appendChild(this.Balise("h3",textH3,classH3));
        div.appendChild(this.Balise("p",textP));
        return div;
    }
    Balise(NomBalise,Contenu="",Class="",Id="",attributeN="",attributeV="",attributeN2="",attributeV2=""){
        let Balise = document.createElement(NomBalise);
        if(Contenu!="")
        {
            Balise.innerHTML=Contenu;
        }
        if(Class!="")
        {
            Balise.classList=Class;
        }
        if(Id!="")
        {
            Balise.id=Id;
        }
        if(attributeN!="")
        {
            Balise.setAttribute(attributeN,attributeV);
        }
        if(attributeN2!="")
        {
            Balise.setAttribute(attributeN2,attributeV2);
        }
        return Balise
    }
    AddRow(_ContenuRow){
        let ContenuRow=[];
        ContenuRow=_ContenuRow;
        let tr = this.Balise("tr");
        for(let c of ContenuRow){
            tr.appendChild(c);
        }
        return tr;
    }
    Introduction(){
        let section = document.createElement("section");
        section.id="introduction";
        section.appendChild(this.Balise("h1","Bienvenue sur HandiA11y","h1Titre"));
        section.appendChild(this.Balise("p","HandiAl1y est un site spécialisé pour découvrir les bases de l'accessibilité web et les différents handicaps à prendre en compte."))
        section.appendChild(this.Balise("h2","Pourquoi 11y et pas A11é?","h2Titre"));
        section.appendChild(this.Balise("p","AT1É est une abréviation pour accessibilité où 11 représente le nombre de lettres entre le à et le é du mot accessibilité. Cette même abréviation dans sa version anglaise est plus jolie à l'oreille : A11Y"));
        section.appendChild(this.Balise("h2","Quelle est l'origine du mot HANDICAP ?","h2Titre"))
        section.appendChild(this.Balise("p","Le mot handicap trouve son origine dans l'anglais médiéval. Il estdérivé de l'expression <span class=\"bold\" lang=\"en\">hand in cap</span>, qui signifie main dans le chapeau.À l'époque, cette expression était utilisée dans les jeux de hasard pourindiquer qu'un joueur était désavantagé ou handicapé par rapport auxautres joueurs. Au fil du temps, le terme a été adopté dans d'autrescontextes pour décrire une situation où une personne estdésavantagée ou limitée dans ses capacités physiques, mentales ousociales."));
        return section;
    }
    WcagPrincipes(){
        let section = document.createElement("section");
        section.id="wcagPrincipes";
        section.appendChild(this.Balise("h2","Le WCAG et les 4 principes A11y","h2Titre","wcagPrincipesTitre"));
        section.appendChild(this.rectangle("conteneurRectangle","h3Titre h3Conteneur","Perceptible","Les informations et les composants de l'interface utilisateur doivent être perceptibles pour tous les utilisateurs, y compris ceux ayant des limitations sensorielles."));
        section.appendChild(this.rectangle("conteneurRectangle","h3Titre h3Conteneur","Utilisable","Les composants de l'interface utilisateur doivent être utilisables par tous les utilisateurs, y compris ceux ayant des limitations physiques ou cognitives."));
        section.appendChild(this.rectangle("conteneurRectangle","h3Titre h3Conteneur","Compréhensible","Les informations et les opérations doivent être compréhensibles pour tousles utilisateurs, y compris ceux ayant des limitations cognitives."));
        section.appendChild(this.rectangle("conteneurRectangle","h3Titre h3Conteneur","Robuste","Le contenu doit être robuste et fonctionnel sur différentes plateformes, ycompris les technologies d'assistance, pour tous les utilisateurs."));

        return section;
    }
    WcagTablePrincipe(){
        let section = document.createElement("section");
        section.id="wcagTablePrincipe";
        section.appendChild(this.Balise("legend","Les critères WCAG 2.1 sous forme de tableau","legend"));
        let table = this.Balise("table","","table");
        let thead = this.Balise("thead","","thead");
        thead.appendChild(this.AddRow([this.Balise("th","Principes","th"),this.Balise("th","Critères","th"),this.Balise("th","Correspondances","th"),this.Balise("th","Objectifs","th")]));
        let tbody = this.Balise("tbody","","tbody");
        tbody.appendChild(this.AddRow([this.Balise("th","Perceptible","th","","rowspan","4"),this.Balise("td","1.1","td"),this.Balise("td","Alternatives textuelles","td"),this.Balise("td","Fournir des alternatives textuelles pour tout contenu non textuel afin qu'il puisse être modifié dans d'autres formes comme les gros caractères, le braille, la parole, les symboles où unlangage plus simple.","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","1.2","td"),this.Balise("td","Médias temporels","td"),this.Balise("td","Fournir des alternatives aux médias temporels.","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","1.3","td"),this.Balise("td","Adaptable","td"),this.Balise("td","Créez du contenu qui peut être présenté de différentes manières (par exemple une mise en page plus simple) sans perdre d'informations ou de structure.","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","1.4","td"),this.Balise("td","Distinguable","td"),this.Balise("td","Faciltez la visualisation et l'écoute du contenu par les utilisateurs, notamment en séparant le premier plan de l'arrière-plan","td")]));
        tbody.appendChild(this.AddRow([this.Balise("th","Utilisable","th","","rowspan","5"),this.Balise("td","2.1","td"),this.Balise("td","Accessible au clavier","td"),this.Balise("td","Rendre toutes les fonctionnalités disponibles à partir dun clavier.","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","2.2","td"),this.Balise("td","Suffisament de temps","td"),this.Balise("td","Donnez aux utilisateurs suffisamment de temps pour lire et utiliser le contenu","td")]));            
        tbody.appendChild(this.AddRow([this.Balise("td","2.3","td"),this.Balise("td","Convulsions et réactions physiques","td"),this.Balise("td","Concevoir des contenus qui ne provoquent pas de convulsions ou des réactions physiques comme des crises épileptiques (zones clignotantes et flashs)","td")]));            
        tbody.appendChild(this.AddRow([this.Balise("td","2.4","td"),this.Balise("td","Navigable","td"),this.Balise("td","Fournir des moyens d'aider les utilisateurs à naviguer, à trouver du contenu et à déterminer où ils se trouvent","td")]));            
        tbody.appendChild(this.AddRow([this.Balise("td","2.5","td"),this.Balise("td","Entrées ciblables","td"),this.Balise("td","Faciliter utilisation des fonctionnalités par les utilisateurs grâce à diverses entrées au-delà du clavier","td")]));            
        tbody.appendChild(this.AddRow([this.Balise("th","Compréhensible","th","","rowspan","3"),this.Balise("td","3.1","td"),this.Balise("td","Lisibilité du texte et de l'interface","td"),this.Balise("td","Rendre le contenu du texte lisible et compréhensible.","td")]));            
        tbody.appendChild(this.AddRow([this.Balise("td","3.2","td"),this.Balise("td","Prévisible","td"),this.Balise("td","Faites en sorte que les pages Web s'affichent et fonctionnent de manière prévisible.","td")]));            
        tbody.appendChild(this.AddRow([this.Balise("td","3.3","td"),this.Balise("td","Assistance à la saisie","td"),this.Balise("td","Faites en sorte que les pages Web s'affichent et fonctionnent de manière prévisible.","td")]));            
        tbody.appendChild(this.AddRow([this.Balise("th","Robuste","th"),this.Balise("td","4.1","td"),this.Balise("td","Compatible","td"),this.Balise("td","Optimiser la compatibilité avec les agents utilisateurs actuels et futurs, y compris les technologies d'assistance.","td")]));             
        table.appendChild(thead);
        table.appendChild(tbody);
        section.appendChild(table);
        return section;
    }
    XcagTableNiveaux(){
        let section = document.createElement("section");
        section.id="wcagTableNiveaux";
        section.appendChild(this.Balise("legend","Les 3 niveaux de conformité WCAG 2.1","lgend"));
        let table = this.Balise("table","","table");
        let thead = this.Balise("thead","","thead");
        let tbody = this.Balise("tbody","","tbody");
        thead.appendChild(this.AddRow([this.Balise("th","Niveaux","th"),this.Balise("th","Description","th")]));
        tbody.appendChild(this.AddRow([this.Balise("th","A","th"),this.Balise("td","Accessibilité de base, répondant aux besoins essentiels des utilisateurs handicapés ou en situation de handicap","td")]));
        tbody.appendChild(this.AddRow([this.Balise("th","AA","th"),this.Balise("td","Accessibilité avancée, garantissant une meilleure expérience pour la majorité des utilisateurs handicapés ou en situation de handicap","td")]));
        tbody.appendChild(this.AddRow([this.Balise("th","AAA","th"),this.Balise("td","Accessibilité maximale, offrant une expérience optimale pour tous les utilisateurs, y compris les utilisateurs handicapés","td")]));
        table.appendChild(thead);
        table.appendChild(tbody);
        section.appendChild(table);
        section.appendChild(this.Balise("p","Vous pouvez tester la lecture des 2 tableaux avec JAWS ou NVDA pour voir s'ils sont accessibles !","legend"));

        return section;
    }
    Graphic(){
        let section = document.createElement("section");
        section.id="graphic";
        section.appendChild(this.Balise("a","WCAG 2.1 en VO","legend","lienGraphic","href","https://www.w3.org/WAI/standards-guidelines/wcag/glance/fr"));
        section.appendChild(this.Balise("h2","Most common WCAG failures by WebAIM","h2Titre"));
        section.appendChild(this.Balise("p","Graphique et tableaux des échecs les plus courants par WebAIM","legend"));
        section.appendChild(this.Balise("img","","","graphicImg","src","./Image/Graphique.png","alt","Graphique demonstratif des echecs les plus courants par WebAIM"));
        let table = this.Balise("table","","table graphicTable");
        let thead = this.Balise("thead","","thead");
        let tbody = this.Balise("tbody","","tbody");

        thead.appendChild(this.AddRow([this.Balise("th","WCAG Failure Type","th"),this.Balise("th","# of home pages","th"),this.Balise("th","% of home pages","th")]));
        tbody.appendChild(this.AddRow([this.Balise("td","Low contrast text","td"),this.Balise("td","852,868","td"),this.Balise("td","85.3%","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","Missing alternative text for images","td"),this.Balise("td","679,964","td"),this.Balise("td","68%","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","Empty links","td"),this.Balise("td","581,408","td"),this.Balise("td","58.1%","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","Missing form input labels","td"),this.Balise("td","528,482","td"),this.Balise("td","52.8%","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","Missing document language","td"),this.Balise("td","329,612","td"),this.Balise("td","33.1%","td")]));
        tbody.appendChild(this.AddRow([this.Balise("td","Empty buttons","td"),this.Balise("td","250,367","td"),this.Balise("td","25%","td")]));

        table.appendChild(thead);
        table.appendChild(tbody);

        section.appendChild(table);

        return section;
    }
    Accueil(){
        this.main.appendChild(this.Introduction());
        this.main.appendChild(this.WcagPrincipes());
        this.main.appendChild(this.WcagTablePrincipe());
        this.main.appendChild(this.XcagTableNiveaux());
        this.main.appendChild(this.Graphic());
    }
}
export {Acceuil};