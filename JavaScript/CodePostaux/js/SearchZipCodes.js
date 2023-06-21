class SearchZipCodes{
    constructor(_array,_city){
        this.array=_array;
        this.city=_city;
        this.zipCodesArray=[];
    }

    GetZipCodes(){

        for(let c of this.array){
            if(c.zipCode.nomCommune.includes(this.city)){
                this.zipCodesArray.push(c.zipCode.codePostal);
            }
        }
        return this.zipCodesArray;
    }
}
export {SearchZipCodes};