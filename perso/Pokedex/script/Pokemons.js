import { db } from "./db.js";
import {Pokemon} from "./Pokemon.js"
class Pokemons{
    constructor(){
        this.pokemonListe = [];
    }
    async RecupererListe(){
        let array = await db.RecupererTableau("https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0");
        for(let pkmn of array["results"]){
            this.pokemonListe.push(pkmn);
        }
        // for(let pkm of array["results"]){
        //     let num = pkm["url"].split("/")[6];
        //     if(num>0 && num<=1010){
        //         this.pokemonListe.push(await db.RecupererTableau("https://pokeapi.co/api/v2/pokemon-species/"+num))
        //     }
        // }
        // console.log(this.pokemonListe)
    }
    async RecupererListFR(){
        let array = await db.RecupererTableau("https://api-pokemon-fr.vercel.app/api/v1/pokemon");
        let count = 0;
        for(let pkmn of array){
            if(pkmn["pokedexId"]>0 && pkmn["pokedexId"]<=1010){
                this.pokemonListe.push(pkmn);
            }
        }
    }
}
export {Pokemons}