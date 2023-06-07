import { ZipCodes } from "./ZipCodes.js";
import { SearchZipCodes } from "./SearchZipCodes.js";
import { SearchCities } from "./SearchCities.js";
import { ZipCode } from "./ZipCode.js";

const lien="https://arfp.github.io/tp/web/frontend/zipcodes/zipcodes.json";
const zipCodes = new ZipCodes(lien);
const tab = await zipCodes.CreateArray();
const keys = await new ZipCode(zipCodes.GetFirst()).GetKeys();

const saisie =document.getElementById("saisie");
const datalist = document.getElementById("datalistResult");

let array = await GetSaisie(); 

//Pour charger la liste des le chargement de la page
/**if(array!=null){

    for(let city of array){
        let row = document.createElement('option');
        row.value=city.nomCommune;
        row.textContent=city.codePostal;
        datalist.appendChild(row);                     
    }
}*/

if(saisie!=null){

    saisie.addEventListener('input',async (event)=>{              
        let test = await GetSaisie();
        if(saisie.value=="" || saisie.value.length<3 || test.length==0){
            while (datalist.firstChild) {
                datalist.removeChild(datalist.firstChild);
              }

        }
        else{
            while (datalist.firstChild) {
                datalist.removeChild(datalist.firstChild);
            }
            let array = await GetSaisie(); 
            if(array!=null){
                for(let city of array){
                        let row = document.createElement('option');
                        row.value=city.nomCommune;
                        row.textContent=city.codePostal;
                        datalist.appendChild(row);               
                }
            }
        } 
    })
}

async function GetSaisie(){
    let cityList= await new SearchCities(tab).GetCities(saisie.value);
    return cityList;
}



