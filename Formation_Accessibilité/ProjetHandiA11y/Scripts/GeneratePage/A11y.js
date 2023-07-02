import {Tools} from "../Tools/tools.js"
class A11y{
    constructor(){
        this.link=document.getElementById("cssPage");
        this.link.href="./Styles/A11y.css";
        this. main = document.getElementById("main");
        this.GenerateTest();
    }
    GenerateTest(){
        let article = Tools.Balise("article","","","articleA11y");
        article.appendChild(Tools.Balise("h1","Quelques bonnes pratiques d'accessibilité...","h1Titre","bonnePratique"));

        article.appendChild(Tools.Balise("img","","imageA11y","","src","./Image/A11yImage/compoFloral.jpg","alt","Image d'une composition floral"))
        article.appendChild(Tools.Balise("h2","Que faire avec des images décorativces ?","h2TitreA11Y"));
        article.appendChild(Tools.Balise("p","Utiliser des attributs \"alt\" vides ou nuls afin d'éviter qu'elles soient lues par les technologies d'assistance."));

        article.appendChild(Tools.Balise("img","","imageA11y","","src","./Image/A11yImage/couverture.jpg","alt","Couverture du livre 'Accessibilité et handicap' de Joel Zaffran"))
        article.appendChild(Tools.Balise("h2","Quoi mettre dans les alternatives textuelles des images informatives ?","h2TitreA11Y"));
        article.appendChild(Tools.Balise("p","Des descriptions appropriées pour fournir des informations équivalentes pour les utilisateurs qui ne peuvent pas voir les images. Les attributs title et aria-describedby ne sont pas indispensables !"));
        
        article.appendChild(Tools.Balise("img","","imageA11y","","src","./Image/A11yImage/extraitCode.jpg","alt","Extrai de code HTML approprié"))
        article.appendChild(Tools.Balise("h2","Balises HTML sémantiques","h2TitreA11Y"));
        article.appendChild(Tools.BaliseT("p","Utiliser des balises HTML sémantiques appropriées (telles que <header>, <nav>, <main>, <section>, <article>, <aside>, <footer>) pour améliorer la structure et la compréhension du contenu par les technologies d'assistance."));
        // Rajouter le bouton qui montre un extrait de code
        
        article.appendChild(Tools.Balise("img","","imageA11y","","src","./Image/A11yImage/personQuiEcrit.png","alt","Personne sans bras qui ecrit avec son clavier"))
        article.appendChild(Tools.Balise("h2","Donner l'accès au clavier","h2TitreA11Y"));
        article.appendChild(Tools.Balise("p","S'assurer que toutes les fonctionnalités du site sont accessibles via le clavier par les personnes qui ne peuvent pas utiliser la souris."));
        
        article.appendChild(Tools.Balise("img","","imageA11y","","src","./Image/A11yImage/contraste.png","alt","image illustrant unexemple de choix de contraste rendant difficile la lecture du texte"))
        article.appendChild(Tools.Balise("h2","Régler les problèmes de contraste des couleurs","h2TitreA11Y"));
        article.appendChild(Tools.Balise("p","Utiliser des combinaisons de couleurs offrant un contraste suffisant pour rendre le contenu lisible pour les personnes atteintes de déficience visuelle."));
        
        article.appendChild(Tools.Balise("img","","imageA11y","","src","./Image/A11yImage/formulaire.png","alt","image d'un formulaire"))
        article.appendChild(Tools.Balise("h2","Comment rendre les formulaires accessibles ?","h2TitreA11Y"));
        article.appendChild(Tools.BaliseT("p","Il faut utiliser des balises HTML sémantiques telles que <form>, <input>, <label>, <select>, <textarea>, etc... pour améliorer la compréhension du contenu par les technologies d'assistance."));
        
        article.appendChild(Tools.Balise("h2","Comment réaliser un audit d'accessibilité de votre site web ?","h2TitreA11Y","audit"));
        article.appendChild(Tools.Balise("img","","imageA11y","","src","./Image/A11yImage/peroquet.png","alt","dessin d'un peroquet"))
        article.appendChild(Tools.Balise("h2","Comment rendre les formulaires accessibles ?","h2TitreA11Y"));
        
        article.appendChild(Tools.Balise("p","<span class=\"bold\">ARA</span>vous propose une méthodologie pour réaliser 3 types d'audit"));
        article.appendChild(Tools.Balise("p","<span class=\"bold\"> (25 critères du <span class=\"pointillet\" title=\"Referenciel generale de l'amelioration de l'accessibilité\">RGAA</span>)"));
        article.appendChild(Tools.Balise("p","<span class=\"bold\"> (50 critères du <span class=\"pointillet\" title=\"Referenciel generale de l'amelioration de l'accessibilité\">RGAA</span>)"));
        
        article.appendChild(Tools.Balise("p","<span class=\"bold\"> dit de conformité (106 critères du <span class=\"pointillet\" title=\"Referenciel generale de l'amelioration de l'accessibilité\">RGAA</span>)"));
        article.appendChild(Tools.Balise("a","Lien pour effectuer un audit d'un site web","lienA11y","","href","https://ara.numerique.gouv.fr/audits/nouveau","target","blank"));
        article.appendChild(Tools.Balise("a","Lien vers une liste d'outils pour tester l'accessibilité","lienA11y","","href","https://ara.numerique.gouv.fr/ressources/outils","target","blank"));
        
        this.main.appendChild(article);
    }
}
export {A11y}