import { Tools } from "../Tools/tools.js";
class FaireDon{
    constructor(){
        this.link = document.getElementById("cssPage");
        this.link.href="./Styles/FaireDon.css";
        this.main = document.getElementById("main");
        this.Generer();
    }
    Generer(){
        let div = Tools.Balise("div","","","divMain");

        div.appendChild(Tools.Balise("h1","Nous sommes bénévoles, faites un don !","h1Titre h1TitreDon"));
        div.appendChild(Tools.Balise("img","","","imageDon","src","./Image/don.png"));
        let container = Tools.Balise("div","","","ContainerForm");
        let form = (Tools.Balise("form","","","formDon"));
        form.appendChild(this.InfoPerso());
        form.appendChild(this.Adresse());
        form.appendChild(this.Souhait());
        form.appendChild(this.Montant());
        form.appendChild(this.InfoPaiement());
        form.appendChild(Tools.Balise("button","Valider le don","","submitButtonForm","type","submit"))
        container.appendChild(form);
        this.main.appendChild(div);
        this.main.appendChild(container);
    }
    Block(label,baliseNom,type,pattern="",placeholder=""){
        let div = Tools.Balise("div","","divBlock");
        div.appendChild(Tools.Balise("label",label,"labelForm"))
        let input = Tools.Balise(baliseNom,"","inputForm","","type",type,"required",true);

        if(pattern!=""){
            input.pattern =pattern;
        }
        if(placeholder!=""){
            input.placeholder =placeholder;
        }
        div.appendChild(input);
        return div;
    }
    BlockC(label,baliseNom,type,pattern="",placeholder=""){
        let div = Tools.Balise("div","","divBlockC");
        div.appendChild(Tools.Balise("label",label,"labelForm"))
        let input = Tools.Balise(baliseNom,"","inputFormC","","type",type,"required",true);
        div.appendChild(input);
        return div;
    }
    BlockRadio(label,baliseNom,type,name,checked=false){
        let div = Tools.Balise("div","","divBlockR");
        div.appendChild(Tools.Balise("label",label,"labelForm"))
        if(checked){
            div.appendChild(Tools.BaliseA(baliseNom,"","radioForm","",["type","name","checked"],[type,name,""]));  
        }
        else{
            div.appendChild(Tools.BaliseA(baliseNom,"","radioForm","",["type","name"],[type,name]));
        }
        return div;
    }
    BlockSelect(label,array){
        let div = Tools.Balise("div","","divBlock");
        div.appendChild(Tools.Balise("label",label,"labelForm"))
        let select =Tools.Balise("select","","selctForm","","name",label);
        for(let option of array){
            select.appendChild(Tools.Balise("option",option,"","","value",option.toLowerCase()));
        }
        div.appendChild(select);
        return div;
    }
    InfoPerso(){
        let fieldset = Tools.Balise("fieldset","","fieldsetForm")
        fieldset.appendChild(Tools.Balise("legend","Information Personel","legendForm"))
        fieldset.appendChild(this.BlockSelect("Civilité",["Monsieur","Madame","Autre"]))
        fieldset.appendChild(this.Block("Prénom","input","text"));
        fieldset.appendChild(this.Block("Nom","input","text"));
        fieldset.appendChild(this.Block("Age","input","number"));
        fieldset.appendChild(this.Block("Couriel","input","email"));
        return fieldset;
    }
    Adresse(){
        let fieldset = Tools.Balise("fieldset","","fieldsetForm")
        fieldset.appendChild(Tools.Balise("legend","Adresse","legendForm"))
        fieldset.appendChild(this.Block("Numéro","input","text"));
        fieldset.appendChild(this.Block("Nom de la rue","input","text"));
        fieldset.appendChild(this.Block("Code postal","input","text"));
        fieldset.appendChild(this.Block("Ville","input","text"));
        return fieldset;
    }
    Souhait(){
        let fieldset = Tools.Balise("fieldset","","fieldsetForm");
        fieldset.appendChild(Tools.Balise("legend","Souhaits","legendForm"));
        fieldset.appendChild(this.BlockC("Recevoir la newsletter","input","checkbox"));
        fieldset.appendChild(this.BlockC("Devenir bénévole","input","checkbox"));
        return fieldset;
    }
    Montant(){
        let fieldset = Tools.Balise("fieldset","","fieldsetForm");
        fieldset.appendChild(Tools.Balise("legend","Montant du don","legendForm"));
        fieldset.appendChild(this.BlockSelect("Montant",["10","100","200","400","500","800","900","1000","2000"]));
        return fieldset;
    }
    InfoPaiement(){
        let fieldset = Tools.Balise("fieldset","","fieldsetForm");
        fieldset.appendChild(Tools.Balise("legend","Informations de paiement","legendForm"));
        fieldset.appendChild(this.Choixcarte());
        fieldset.appendChild(this.Block("Numéro de carte","input","text","[0-9]{16}"));
        fieldset.appendChild(this.Block("Date d'expiration","input","text","","MM/AA"));
        fieldset.appendChild(this.Block("Numéro de carte","input","text","[0-9]{3}"));
        return fieldset;
    }
    Choixcarte(){
        let fieldset = Tools.Balise("fieldset","","","fieldsetChoixCarte");
        fieldset.appendChild(Tools.Balise("legend","Choix de la carte","legendForm"));
        fieldset.appendChild(this.BlockRadio("Master Card","input","radio","carte",true));
        fieldset.appendChild(this.BlockRadio("CB","input","radio","carte"));
        fieldset.appendChild(this.BlockRadio("Visa","input","radio","carte"));
        return fieldset;
    }
    

}
export {FaireDon}