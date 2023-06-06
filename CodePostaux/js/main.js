import { ZipCodes } from "./ZipCodes.js";
import { SearchZipCodes } from "./SearchZipCodes.js";
import { SearchCities } from "./SearchCities.js";

const a = new ZipCodes("https://arfp.github.io/tp/web/frontend/zipcodes/zipcodes.json");

const tab = await a.CreateArray();

let ZipCodeList=new SearchZipCodes(tab,"Uckange").GetZipCodes();
let CityList=new SearchCities(tab,ZipCodeList).getCities();
var saisie =document.getElementById("saisie");

console.log(saisie);
function GetSaisie(){
    let pattern = new RegExp("[\d]{5}");
    if(pattern.test(saisie)){

    }
}

for(let z of ZipCodeList){
    console.log(z)
}
console.log("______")
for(let c of CityList){
    console.log(c)
}


