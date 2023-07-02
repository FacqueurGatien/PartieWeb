import{db}from "./db.js"
class Pokemon{
    constructor(){
        this.Id=0;
        this.Generation=0;
        this.Nom = "";
        this.Taille = "";
        this.Poid= "";
        this.Types= []
        this.Image="";
        this.Description="Description Inconnue";
        this.Stat=[]
        this.Prevolution="//";
        this.Evolution="//";
        this.Talent=[];
        this.Categorie="";
        this.Couleur=[];
    }
    async RecupererPokemon(num){
        let pkmn = await db.RecupererTableau("https://pokeapi.co/api/v2/pokemon-species/"+num);
        let pkmnstat = await db.RecupererTableau("https://api-pokemon-fr.vercel.app/api/v1/pokemon/"+num);
        this.Id=pkmn["id"];
        this.Nom=pkmn["names"][4]["name"];
        this.RecupererDescription(pkmn["flavor_text_entries"]);
        this.Taille=pkmnstat["height"];
        this.Poid=pkmnstat["weight"];
        this.RecupererTypes(pkmnstat["types"]);
        this.Image=pkmnstat["sprites"]["regular"]
        this.Stat=pkmnstat["stats"]
        this.RecupererEvolution(pkmnstat["evolution"]);
        this.Generation=pkmnstat["generation"];
        this.RecupererTalent(pkmnstat["talents"])
        this.Categorie=pkmnstat["category"];
        this.RecupererColor(pkmnstat["types"]);
    }
    RecupererColor(types){
        let array = {
            "Normal":"rgba(160,162,160,0.5)",
            "Feu":"rgba(231,35,36,0.5)",
            "Eau":"rgba(36,129,239,0.5)",
            "Plante":"rgba(61,162,36,0.5)",
            "Électrik":"rgba(250,193,0,0.5)",
            "Glace":"rgba(61,217,255,0.5)",
            "Combat":"rgba(255,129,0,0.5)",
            "Poison":"rgba(146,63,204,0.5)",
            "Sol":"rgba(146,80,27,0.5)",
            "Vol":"rgba(130,186,239,0.5)",
            "Psy":"rgba(239,63,122,0.5)",
            "Insecte":"rgba(146,162,18,0.5)",
            "Roche":"rgba(176,170,130,0.5)",
            "Spectre":"rgba(112,63,112,0.5)",
            "Dragon":"rgba(79,96,226,0.5)",
            "Ténèbres":"rgba(78,63,60,0.5)",
            "Acier":"rgba(96,162,185,0.5)",
            "Fée":"rgba(239,112,239,0.5)",
            "Obscur":"rgba(69,69,74,0.5)"
        }
        if(this.Types.length>1){
            this.Couleur.push(array[types[0]["name"]]);
            this.Couleur.push(array[types[1]["name"]]);
        }
        else{
            this.Couleur.push(array[types[0]["name"]]);
            this.Couleur.push(array[types[0]["name"]]);
        }
        console.log(this)
    }
    RecupererTalent(talents){
        if(talents!=null){
            for(let talent of talents){
                this.Talent.push(talent["name"]);
            }
        }
    }
    RecupererDescription(descriptions){
        if(descriptions.length!=0){
            let descs=[];
            for(let desc of descriptions){
                if(desc["language"]["name"]=="fr"){
                    descs.push(desc["flavor_text"]);
                }
            }
            if(descs.length>0){
                this.Description=descs[0];
            }
            else{
                this.Description=descriptions[0]["flavor_text"]
            }
        }
    }
    RecupererTypes(types)
    {
        if(types.length>0){
            for(let type of types){
                this.Types.push(type)
            }
        }   
    }
    RecupererEvolution(evolution){
        if(evolution!=null)
        {
            if(evolution["next"]!=null){
                this.Evolution=evolution["next"][0]["name"];
            }
            if(evolution["pre"]!=null){
                this.Prevolution=evolution["pre"][evolution["pre"].length-1]["name"];
            }
        }

    }
}
export {Pokemon}
