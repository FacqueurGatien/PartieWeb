class GenerationMain{
    constructor(_cereals){
        this.cereals=_cereals;
        this.main = document.getElementById("main");
        this.header = document.getElementById("header");
    }
    Generer(_array=this.cereals.cerealsCollection){
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
        
        for(let key of this.cereals.GetKeys()){
            let cell = document.createElement("th");
            cell.classList.add("mainTableHeaderCell");
            cell.classList.add("Cell"+key);
            cell.textContent = key;
            row.appendChild(cell);
        }

        thead.appendChild(row);

        return thead;
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
        let button = document.createElement("button");
        button.textContent = "X"
        button.className="DELButton";
        button.dataset.id=_id;
        button.addEventListener("click",(e)=>{
            this.cereals.DeleteCereal(e.target.dataset.id);
            this.Generer(this.cereals.SortCereals(e.target.dataset.id));
        });
        cellDEL.className="DEL";
        cellDEL.appendChild(button);
        return cellDEL
    }
}
export {GenerationMain}