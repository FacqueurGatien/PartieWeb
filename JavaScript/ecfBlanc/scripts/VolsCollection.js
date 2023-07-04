import { db } from "./db.js";
import {Vol} from "./Vol.js"
class VolCollection{
    constructor(){
        this.initialData=[];
        this.actualData=[];
    }
    async load(){
        let temp = await db.getDB("https://arfp.github.io/tp/web/frontend/flights/flights.json");
        this.initialData = temp;
        this.initialData = this.initialData.map(v=>new Vol(v));
        this.copieData();
    }

    copieData(){
        this.actualData = Array.from(this.initialData);
    }
    columnSortEvent(e){
        console.log(this.volCollection);
        if(typeof(this.actualData[0][e.target.dataset.name])!="string"){
            this.actualData.sort((x,y)=>x[e.target.dataset.name]-y[e.target.dataset.name]);
        }
        else{
            this.actualData.sort((x,y)=>x[e.target.dataset.name].toString().localeCompare(y[e.target.dataset.name].toString()));
        }
        if(this.sortDirection){
            this.actualData.reverse();
        }
        this.sortDirection=!this.sortDirection;
    }
}
export {VolCollection}