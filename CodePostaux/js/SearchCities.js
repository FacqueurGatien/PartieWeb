class SearchCities{
    constructor(_array,_zipCode){
        this.array=_array;
        this.citiesArray=[];
    }

    GetCities(_city){
        this.citiesArray=[];
        let reg = new RegExp("[0-9]{3}");
        for(let z of this.array){
            if(reg.test(_city) && z.codePostal.includes(_city) && _city[0]==z.codePostal[0] && _city[1]==z.codePostal[1] && _city[2]==z.codePostal[2]){
                this.citiesArray.push(z);
            }
            else if(z.nomCommune.toLowerCase()==_city.toLowerCase()){
                this.citiesArray.push(z);
                return this.citiesArray;
            }
            else if(z.nomCommune.toLowerCase().includes(_city.toLowerCase())){
                this.citiesArray.push(z);
            }
        }
        return this.citiesArray;
    }
}
export{SearchCities}

