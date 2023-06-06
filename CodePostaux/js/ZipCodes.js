import {ZipCode} from "./ZipCode.js";
class ZipCodes{

    constructor(_link){
        this.link=_link;
        this.zipCodesCollection=[]
    }

    async JsonConverter(){
        let reponse = await fetch(this.link);
        let jsonConverted = await reponse.json();
        return jsonConverted;
    }

    async CreateArray(){
        let response = await this.JsonConverter();
        for(let zip of response){
            this.zipCodesCollection.push(new ZipCode(zip));
        }
        return this.zipCodesCollection;
    }
}

export {ZipCodes}