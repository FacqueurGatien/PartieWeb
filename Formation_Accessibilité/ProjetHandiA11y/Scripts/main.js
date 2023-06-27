import {Accessibility} from "./Popup/Accessibility.js"

let access = new Accessibility();

let buttonAccess=document.getElementById("ButtonParam").addEventListener("click",(e)=>{
    if(!access.open){
        access.open=true;
        window.open("index.html", "hello", "width=200,height=200");
    }
})
;
