import {Db} from "../Db.js"
import {Legume} from "./Legume.js"
class LegumesCollection{
    constructor(){
        this.data =[];
        this.sortDirection=true;
    }
    async getData(){
        this.data= await Db.getDb("https://arfp.github.io/tp/web/frontend/grocery/legumos.json");
        this.data = this.data.map(l=>l=new Legume(l));
    }
    async deleteLegume(id){
        this.data = this.data.filter(d=>d.Id!=id);
        return this.data;
    }
    async editLegume(id){
        console.log(id)
    }
    async sortTable(column){
        let array = [];
        if(typeof(this.data[0][column])!="string"){
            array = this.data.sort((a,b)=>a[column]-b[column]);
        }
        else{
            array = this.data.sort((a,b)=>a[column].toString().localeCompare(b[column]).toString());
        }
        this.sortDirection=!this.sortDirection;
        if(!this.sortDirection){
            return array.reverse();
        }
        return array     
    }
}
export {LegumesCollection}