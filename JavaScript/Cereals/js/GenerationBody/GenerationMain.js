class GenerationMain{
    constructor(_cereals){
        this.cereals=_cereals;
        this.main = document.getElementById("main");
        this.header = document.getElementById("header");
        this.arrayTrie=_cereals.cerealsCollection;
        this.bool=true;
    }
    Generer(_array=this.cereals.cerealsCollection){
        this.arrayTrie=_array
        this.main.innerHTML="";

        let table = document.createElement("table");
        table.id="mainTable"

        table.appendChild(this.TableHeader());
        table.appendChild(this.TableBody(_array));
        this.main.appendChild(table);
    }
    TableHeader(){
        let thead = document.createElement("thead");
        thead.id="mainTableHeader";

        let row = document.createElement("tr");
        row.className="mainTableHeaderRow";
        let cursor=0;
        let keys = this.cereals.GetKeysO()
        for(let key of this.cereals.GetKeys()){
            
            let cell = document.createElement("th");
            cell.classList.add("mainTableHeaderCell");
            cell.id=key;
            cell.dataset.key=keys[cursor++];
            cell=this.TrieColonne(cell,key);
            cell.textContent = key;
            row.appendChild(cell);
        }
        thead.appendChild(row);
        return thead;
    }
    TrieColonne(_cell){
        let cell = _cell;
        let array=[];
        array=this.arrayTrie;

        if(_cell.dataset.key!="name" && _cell.dataset.key!="del"){
            cell.addEventListener("click",(e)=>{
                this.bool=!this.bool;
                if(this.bool){
                    array = array.sort((cerA,cerB)=>cerA[e.target.dataset.key] - cerB[e.target.dataset.key]);
                }
                else{
                    array = array.sort((cerA,cerB)=>cerA[e.target.dataset.key] - cerB[e.target.dataset.key]).reverse();
                }
                this.Generer(array)
            });
        }
        else if(_cell.dataset.key!="del"){
            cell.addEventListener("click",(e)=>{
                this.bool=!this.bool;
                if(this.bool){
                    array = array.sort((cerA,cerB)=>cerA[e.target.dataset.key].localeCompare(cerB[e.target.dataset.key]));
                }
                else{
                    array = array.sort((cerA,cerB)=>cerA[e.target.dataset.key].localeCompare(cerB[e.target.dataset.key])).reverse();
                }
                this.Generer(array)
            });
        }
        return cell;
    }
    TableBody(_array){
        let tbody = document.createElement("tbody");
        tbody.className="mainTableBody"
        
        for(let cereal of _array){
            let row = document.createElement("tr");
            for(let value of cereal.GetValues()){
                let cell = document.createElement("td");
                cell.classList.add("cellData");
                cell.textContent=value;
                row.appendChild(cell);
            }

            row.appendChild(this.Nutriscore(cereal.rating));
            row.appendChild(this.DellButton(cereal.id));
            tbody.appendChild(row)
        }
        return tbody;

    }
    Nutriscore (_rating){
        let cellNS = document.createElement("td")

        cellNS.textContent=this.cereals.CalculeNutriscore(_rating);
        cellNS.classList.add("NS");
        cellNS.classList.add("NS"+cellNS.textContent);
        return cellNS;
    }
    DellButton(_id){
        let cellDEL = document.createElement("td");
        cellDEL.textContent = "X"
        cellDEL.className="DEL";
        cellDEL.dataset.id=_id;
        cellDEL.addEventListener("click",(e)=>{
            this.cereals.DeleteCereal(e.target.dataset.id);
            this.Generer(this.cereals.SortCereals(e.target.dataset.id));
        });

        return cellDEL
    }
}
export {GenerationMain}