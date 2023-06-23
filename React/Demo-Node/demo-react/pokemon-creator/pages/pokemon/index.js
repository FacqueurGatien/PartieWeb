import React from "react";
import Image from "next/image";

export default class PokemonListe extends React.Component{
    render(){
        return (
            <React.Fragment>
                <h1>Liste des Pokemons</h1>
                <a href="./pokemon/list">
                <Image src="/images/pikachu.png" width={500} height={500} alt="Logo Pikachu" ></Image>      
                </a>
            </React.Fragment>
        );
    }
}

/*export default function PokemonIndex(){

}*/