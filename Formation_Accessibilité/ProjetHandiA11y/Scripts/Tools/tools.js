 class Tools{
    static Balise(NomBalise,Contenu="",Class="",Id="",attributeN="",attributeV="",attributeN2="",attributeV2=""){
        let Balise = document.createElement(NomBalise);
        if(Contenu!="")
        {
            Balise.innerHTML=Contenu;
        }
        if(Class!="")
        {
            Balise.classList=Class;
        }
        if(Id!="")
        {
            Balise.id=Id;
        }
        if(attributeN!="")
        {
            Balise.setAttribute(attributeN,attributeV);
        }
        if(attributeN2!="")
        {
            Balise.setAttribute(attributeN2,attributeV2);
        }
        return Balise
    }
    static BaliseA(NomBalise,Contenu="",Class="",Id="",arrayN=[],arrayV=[]){
        let Balise = document.createElement(NomBalise);
        if(Contenu!="")
        {
            Balise.innerHTML=Contenu;
        }
        if(Class!="")
        {
            Balise.classList=Class;
        }
        if(Id!="")
        {
            Balise.id=Id;
        }
        if(arrayN.length!=0)
        {
            let count=0;
            for(let att of arrayN){
                Balise.setAttribute(att,arrayV[count++]);
            }
        }
        return Balise
    }
    static BaliseT(NomBalise,Contenu="",Class="",Id="",attributeN="",attributeV="",attributeN2="",attributeV2=""){
        let Balise = document.createElement(NomBalise);
        if(Contenu!="")
        {
            Balise.textContent=Contenu;
        }
        if(Class!="")
        {
            Balise.classList=Class;
        }
        if(Id!="")
        {
            Balise.id=Id;
        }
        if(attributeN!="")
        {
            Balise.setAttribute(attributeN,attributeV);
        }
        if(attributeN2!="")
        {
            Balise.setAttribute(attributeN2,attributeV2);
        }
        return Balise
    }
}
export {Tools}