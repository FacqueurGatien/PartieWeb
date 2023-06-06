class SearchCities{
    constructor(_array,_zipCode){
        this.array=_array;
        this.zipCode=_zipCode;
        this.citiesArray=[];
    }

    getCities(){

        for(let z of this.array){
            if(z.zipCode.codePostal.includes(this.zipCode)){
                this.citiesArray.push(z.zipCode.nomCommune);
            }
        }
        return this.citiesArray;
    }
}
export{SearchCities}