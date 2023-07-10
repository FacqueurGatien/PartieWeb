class VenteTable{
    constructor(array){
        this.ventesCollectionData=array;
        this.main = document.getElementById("main");
        this.page=1;
    }
    generateTable(array=this.ventesCollectionData.data){
        this.main.innerHTML="";
        let pagniationControl = document.createElement("div");
        let buttonG = document.createElement("button");
        buttonG.textContent="<";
        let num = document.createElement("p");
        num.textContent=this.page;
        let buttonD = document.createElement("button");
        buttonD.textContent=">";

        pagniationControl.appendChild(buttonG);
        pagniationControl.appendChild(num);
        pagniationControl.appendChild(buttonD);

        this.main.appendChild(pagniationControl);

        let div = document.createElement("div");
        div.id="ventMain"
        array.forEach(v => {
            div.appendChild(this.generateCard(v))
        });
        this.main.appendChild(div);

    }
    generateCard(vente){
        let div = document.createElement("div");
        div.classList.add("cardVente");

        let h2 = document.createElement("h2");
        h2.textContent = vente["Name"].toUpperCase();
        let h3 = document.createElement("h3");
        h3.textContent = "("+vente["SaleWeight"]+"KGS)";
        let h4 = document.createElement("h4");
        h4.textContent = vente["SaleDate"];

        div.appendChild(h2);
        div.appendChild(h3);
        div.appendChild(h4);
        
        return div;
    }
    generateCardPage(page){
        let div = document.createElement("div");
        div.classList.add("pagination")

    }
}
export {VenteTable}