import React from 'react';
import Link from 'next/link.js';
import Image from 'next/image.js';
const pokemon = require('pokemon');

let id = 0;
export default function PokemonList(){
    return (
        <div>
        {
            pokemon.all('fr').map((pkn)=><p key={++id} ><Link href={{pathname:'https://www.pokepedia.fr/'+pkn}}>{pkn}</Link></p>)
        }
        {
            pokemon.all('fr').map((pkn)=><Image src={{pathname:'https://eternia.fr/public/media/pokedex/artworks/001.png'}} width={50} height={50} alt="Logo" ></Image>)
        }
        </div>
    );
}