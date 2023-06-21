const counter = document.getElementById("counter");
const reset = document.getElementById("empty");
const field = document.getElementById("field");

let interval =undefined;

const maFunction = ()=>{
    if(counter.value > 0){

            let img = document.createElement("img");
            img.src="img/flower.png";
            img.classList="imgFlower";
            field.appendChild(img);
    }
    else if(counter.value==0){
        clearInterval(interval);
    }
}

counter.addEventListener('change',function(){
    if(interval != undefined){
        clearInterval(interval);
    }
        interval = setInterval(maFunction,1000/counter.value);
});
