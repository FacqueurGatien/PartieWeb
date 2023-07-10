import { EventClass } from "../../EventClass/EventClass.js";

class LegumeTable{
    constructor(array){
        this.legumeCollectionData=array;
        this.main = document.getElementById("main");
    }
    generateTable(array=this.legumeCollectionData.data){
        this.main.innerHTML="";
        let table = document.createElement("table");
        table.id = "legumeTable";
        table.appendChild(this.generateThead());
        array.forEach(l=>{
            table.appendChild(this.generateTbody(l));
        })
        
        this.main.appendChild(table);
    }
    generateCell(content,_tx="td"){
        let tx = document.createElement(_tx);
        tx.textContent=content;
        return tx;
    }
    generateThead(){
        // let arrayHead = ["Nom","Variété","Couleur","Durée Conservation","Frais","Action"];
        let arrayHead = [{from: 'Name', to: 'Nom'},
        {from: 'Variety', to:  'Variete'},
        {from: 'PrimaryColor', to : 'Couleur'},
        {from: 'LifeTime', to: 'Durée Consevation'},
        {from: 'Fresh', to: 'Frais'},
        {from: 'Action', to: 'Action'}];
        let tr = document.createElement("tr");
        tr.classList.add("cellContent");
        for(let l of arrayHead){
            if(l["from"]!="Id" && l["from"]!="Price"){
                let th = this.generateCell(l["to"],"th");
                if(l["from"]!="Action"){
                    th.classList.add("sortHead");
                    th.addEventListener("click",async ()=>{
                        this.generateTable(await EventClass.sortTable(l["from"]));
                    });
                }
                tr.appendChild(th);
                
            }
        }
        return tr;
    }
    generateAction(id){
        let div = document.createElement("div");
        div.classList.add("actionCell");
        let td = document.createElement("td");


        let edit = document.createElement("a");
        edit.textContent="Editer";
        edit.classList.add("editButton");

        edit.addEventListener("click",async()=>{
            this.generateTable(await EventClass.editLegume(id));
        })

        let esp = document.createElement("p");
        esp.textContent=".";
        esp.classList.add("espAction");
        let del = document.createElement("a");
        del.textContent="Supprimer";
        del.classList.add("delButton");

        del.addEventListener("click",async (e)=>{
            this.generateTable(await EventClass.deleteLegume(id));
        });
        
        div.appendChild(edit);
        div.appendChild(esp);
        div.appendChild(del);
        td.appendChild(div);
        return td;
    }
    generateTbody(_legume){
        let tr = document.createElement("tr");
        let legume = _legume.getValuesP();
        tr.classList.add("cellContent");
        for(let l of legume){
            if(l!="Id" && l!="Price"){
                tr.appendChild(this.generateCell(l,"td"));
            }
        }
        tr.appendChild(this.generateAction(_legume["Id"]));
        return tr;
    }
}
export {LegumeTable}