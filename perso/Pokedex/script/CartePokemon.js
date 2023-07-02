import {Pokemon} from "./Pokemon.js"
class CartePokemon{
    constructor(pkmn){
        this.ConstruireCarte(pkmn);
    }
    ConstruireCarte(pkmn){
        console.log(pkmn)
        document.getElementById("cartetColor").setAttribute("style","background:linear-gradient(235deg, "+pkmn.Couleur[0]+","+ pkmn.Couleur[1]+");")
        document.getElementById("nom").textContent=pkmn.Nom

        let imageType = document.getElementById("typeImg");
        imageType.innerHTML=""
        for(let type of pkmn.Types){
            let img = document.createElement("img");
            img.src=type["image"]
            img.classList.add("logoType")
            imageType.appendChild(img)
        }

        let imgpkmn = document.getElementById("imagepkmn");
        imgpkmn.src=pkmn.Image;

        document.getElementById("categorie").textContent=pkmn.Categorie
        document.getElementById("taille").textContent=pkmn.Taille
        document.getElementById("poids").textContent=pkmn.Poid

        document.getElementById("descriptionText").textContent=pkmn.Description

        document.getElementById("atk").textContent=pkmn.Stat["atk"];
        document.getElementById("def").textContent=pkmn.Stat["def"];
        document.getElementById("atkSpe").textContent=pkmn.Stat["spe_atk"];
        document.getElementById("defSpe").textContent=pkmn.Stat["spe_def"];
        document.getElementById("vit").textContent=pkmn.Stat["vit"];
        document.getElementById("hp").textContent=pkmn.Stat["hp"];

        let talent = document.getElementById("talent");
        talent.innerHTML="";
        if(pkmn.Talent.length>0){
            for(let tal of pkmn.Talent){
                let p = document.createElement("p");
                p.textContent=tal;
                p.classList.add("talent")
                talent.appendChild(p)
            }
        }
        document.getElementById("evolution").textContent=pkmn.Evolution;
        document.getElementById("prevolution").textContent=pkmn.Prevolution;
        document.getElementById("id").textContent=pkmn.Id;
        document.getElementById("gen").textContent=pkmn.Generation;
    //     <div id="Carte">
    //     <section id="carteHeader">
    //         <h2 id="nom"></h2>
    //         <div id="header">
    //             <p><span>Type</span></p>
    //             <img src="" class="logoType">
    //         </div> 
    //     </section>
    //     <section id="carteBody">
    //         <article id="imageCarte">
    //             <img id="imagepkmn" src="" alt="">
    //             <figcaption id="details" >Categorie : <span id="categorie"></span> Taille : <span id="taille"></span> Poids : <span id="poids"></span></figcaption>
    //         </article>
    //         <article id="talent">
    //             <h2 id=>Description</h2>
    //             <p id="description"></p>
    //         </article>
    //         <article id="statistique">
    //             <div class="stat"><p>atk</p> <p id="atk"></p></div>
    //             <div class="stat"><p>def</p><p id="def"></p></div>
    //             <div class="stat"><p>hp</p> <p id="hp"></p></div>
    //             <div class="stat"><p>atak spe</p> <p id="atkSpe"></p></div>
    //             <div class="stat"><p>def spe</p> <p id="defSpe"></p></div>
    //             <div class="stat"><p>vit</p> <p id="vit"></p></div>
    //             <div class="stat"><p>talent : Charge bizarre</p></div>
    //             <div class="stat"><p>Evolution</p><p>Raichu</p></div>
    //             <div class="stat"><p>Prevolution</p><p>Aucune</p></div>
    //         </article>
    //     </section>
    //     <section id="carteFooter">
    //         <p>id : 25</p>
    //         <p>Generation : 1</p>
    //     </section>
    // </div>
    }
}
export {CartePokemon}