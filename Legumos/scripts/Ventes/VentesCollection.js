import {Db} from "../Db.js"
import { Vente } from "./Vente.js";
class VentesCollection{
    constructor(){
        this.data =[];
    }
    async getData(){
        this.data= await Db.getDb("https://arfp.github.io/tp/web/frontend/grocery/legumos-sales.json")
        this.data = this.data.map(v=>v=new Vente(v));
    }
    
}
export {VentesCollection}