class GenerationTableau{
    constructor(_volCollection){
        this.volCollection=_volCollection;
        this.tbody = document.getElementById("volTbody");
    }
    generationTableau(){
        console.log(this.volCollection)
        this.tbody.innerHTML="";
        for(let vol of this.volCollection.actualData){
            this.tbody.appendChild(this.generateRow(vol));
        }
        this.generateCell()
    }
    generateRow(vol){
        let tr = document.createElement("tr");
        for(let val of vol.getValues()){
            tr.appendChild(this.generateCell(val));
        }
        return tr;
    }
    generateCell(value){
        let td = document.createElement("td");
        td.textContent=value;
        td.classList.add("valueVolTd");
        td.classList.add("cellData");
        return td;
    }
}
export {GenerationTableau}