class GenerationMain{
    constructor(_cereals){
        this.cereals=_cereals;
        this.main = document.getElementById("main");
        this.header = document.getElementById("header");
        this.arrayTrie=_cereals.cerealsCollection;
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
        
        for(let key of this.cereals.GetKeys()){
            let cell = document.createElement("th");
            cell.classList.add("mainTableHeaderCell");
            cell.id="Cell"+key;
            cell.dataset.key=key;
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
        switch(cell.dataset.key){
            case "ID":
                cell.addEventListener("click",()=>{
                    if(array[0].id != Math.min(...array.map(d => d.id ))){
                        array = array.sort((cerA,cerB)=>cerA.id - cerB.id);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.id - cerB.id).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "NOM":
                cell.addEventListener("click",()=>{
                    if(array[0].name > array[array.length-1].name){
                        array = array.sort((cerA,cerB)=>cerA.name.localeCompare(cerB.name));
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.name.localeCompare(cerB.name)).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "CALORIES":
                cell.addEventListener("click",()=>{
                    if(array[0].calories != Math.min(...array.map(d => d.calories ))){

                        array = array.sort((cerA,cerB)=>cerA.calories - cerB.calories);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.calories - cerB.calories).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "PROTEÏNES":
                cell.addEventListener("click",()=>{
                    if(array[0].protein != Math.min(...array.map(d => d.protein ))){

                        array = array.sort((cerA,cerB)=>cerA.protein - cerB.protein);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.protein - cerB.protein).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "SEL":
                cell.addEventListener("click",()=>{
                    if(array[0].sodium != Math.min(...array.map(d => d.sodium ))){

                        array = array.sort((cerA,cerB)=>cerA.sodium - cerB.sodium);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.sodium - cerB.sodium).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "FIBRES":
                cell.addEventListener("click",()=>{
                    if(array[0].fiber != Math.min(...array.map(d => d.fiber ))){

                        array = array.sort((cerA,cerB)=>cerA.fiber - cerB.fiber);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.fiber - cerB.fiber).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "GLUCIDES":
                cell.addEventListener("click",()=>{
                    if(array[0].carbo != Math.min(...array.map(d => d.carbo ))){

                        array = array.sort((cerA,cerB)=>cerA.carbo - cerB.carbo);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.carbo - cerB.carbo).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "SUCRE":
                cell.addEventListener("click",()=>{
                    if(array[0].sugars != Math.min(...array.map(d => d.sugars ))){

                        array = array.sort((cerA,cerB)=>cerA.sugars - cerB.sugars);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.sugars - cerB.sugars).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "POTASSIUM":
                cell.addEventListener("click",()=>{
                    if(array[0].potass != Math.min(...array.map(d => d.potass ))){

                        array = array.sort((cerA,cerB)=>cerA.potass - cerB.potass);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.potass - cerB.potass).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "VITAMINES":
                cell.addEventListener("click",()=>{
                    if(array[0].vitamins > array[array.length-1].vitamins){

                        array = array.sort((cerA,cerB)=>cerA.vitamins - cerB.vitamins);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.vitamins - cerB.vitamins).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "EVALUATION":
                cell.addEventListener("click",()=>{
                    if(array[0].rating > array[array.length-1].rating){

                        array = array.sort((cerA,cerB)=>cerA.rating - cerB.rating);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.rating - cerB.rating).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
            case "NS":
                cell.addEventListener("click",()=>{
                    if(array[0].rating > array[array.length-1].rating){

                        array = array.sort((cerA,cerB)=>cerA.rating - cerB.rating);
                    }
                    else{
                        array = array.sort((cerA,cerB)=>cerA.rating - cerB.rating).reverse();
                    }
                    this.Generer(array)
                });
                return cell;
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