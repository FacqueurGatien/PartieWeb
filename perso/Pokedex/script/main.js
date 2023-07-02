import { Pokemons } from "./Pokemons.js";
import {CartePokemon} from "./CartePokemon.js"
import { Pokemon } from "./Pokemon.js";
let main = document.getElementById("main");
let pkmns = new Pokemons();
await pkmns.RecupererListFR();

for(let pkmn of pkmns.pokemonListe){
    let a = document.createElement("a");
    a.href="#"
    a.textContent=pkmn["name"]["fr"]
    a.dataset.pokeId=pkmn["pokedexId"]
    a.addEventListener("click",async (e)=>{
        let carte = new Pokemon();
        await carte.RecupererPokemon(e.target.dataset.pokeId);
        new CartePokemon(carte);
    })
    document.getElementById("Liste").appendChild(a)
}