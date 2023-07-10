import { LegumesCollection } from "../Legumes/LegumesCollection.js";

class EventClass{

    static legumes;
    static ventes

    static async getLegumes(){
        if(EventClass.legumes.length!=0){
            return await EventClass.legumes;
        }
        else{
            EventClass.legumes=new LegumesCollection();
            return await EventClass.legumes;
        }
    }
    static async getVentes(){
        if(EventClass.legumes.length!=0){
            return await EventClass.legumes;
        }
        else{
            EventClass.legumes=new LegumesCollection();
            return await EventClass.legumes;
        }
    }

    static async deleteLegume(id){
        let leg = await EventClass.getLegumes();
        return await leg.deleteLegume(id);
    }
    static async editLegume(id){
        let leg = await EventClass.getLegumes();
        return await leg.editLegume(id);
    }
    static async sortTable(column){
        let leg = await EventClass.getLegumes();
        return await leg.sortTable(column);
    }
}
export {EventClass}