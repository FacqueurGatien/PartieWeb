import { ZipCodes } from "./ZipCodes.js";
import { SearchZipCodes } from "./SearchZipCodes.js";
import { SearchCities } from "./SearchCities.js";
import { ZipCode } from "./ZipCode.js";

const lien="https://arfp.github.io/tp/web/frontend/zipcodes/zipcodes.json";
const zipCodes = new ZipCodes(lien);
const tab = await zipCodes.CreateArray();
const keys = await new ZipCode(zipCodes.GetFirst()).GetKeys();

const saisie =document.getElementById("saisie");
const table = document.getElementById("tableResult");


if(saisie!=null){

    saisie.addEventListener('input',async (event)=>{              
        let test = await GetSaisie();
        if(saisie.value=="" || saisie.value.length<3 || test.length==0){
            while (table.firstChild) {
                table.removeChild(table.firstChild);
              }

        }
        else{
            while (table.firstChild) {
                table.removeChild(table.firstChild);
            }
            let array = await GetSaisie(); 
            if(array!=null){
                let row = document.createElement('tr');
                for(let key of keys){
                    let colTitre = document.createElement("th");
                    colTitre.textContent=key;
                    row.appendChild(colTitre);
                }
                table.appendChild(row);
                for(let city of array){

                    let row = document.createElement('tr');
                    for(let data of await new ZipCode(city).GetValues()){
  
                        let colData = document.createElement("td");
                        colData.textContent=data;
                        row.appendChild(colData);
                    }
                    table.appendChild(row);
                }
            }
        } 
    })
}

async function GetSaisie(){
    let cityList= await new SearchCities(tab).GetCities(saisie.value);
    return cityList;
}



