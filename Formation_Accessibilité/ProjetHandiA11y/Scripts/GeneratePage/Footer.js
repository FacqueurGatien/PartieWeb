class Footer{
    constructor(){
        this.footer = document.getElementById("footer");
        this.GenerateFooter();
    }
    GenerateFooter(){
        let p = document.createElement("p");
        p.textContent="© 2023 HandiA11y. Tout droits réservés.";
        this.footer.appendChild(p);
    }
}
export {Footer}