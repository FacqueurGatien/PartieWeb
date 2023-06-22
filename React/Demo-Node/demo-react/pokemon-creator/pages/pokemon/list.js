const pokemon = require('pokemon');
let id = 0;
export default function PokemonList(){
    return (
        pokemon.all('fr').map((pkn)=><p key={++id}>{pkn}</p>)
    );
}