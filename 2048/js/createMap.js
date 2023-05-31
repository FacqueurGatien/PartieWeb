function setGame(){
    board=[
        [0,0,0,0],
        [0,0,0,0],
        [0,0,0,0],
        [0,0,0,0]
    ]


    for(let r=0; r < rows;r++){
        for(let c=0;c < columns;c++){
            let tile=document.createElement("div");
            tile.id=r.toString()+ "-" + c.toString();
            let num = board[r][c];
            updateTile(tile,num);
            document.getElementById("board").append(tile);
        }
    }
    setTwo();
}

function updateTile(tile,num){
    tile.innerText = "";
    tile.classList="";
    tile.classList.add("tile");
    if(num>0){
        tile.innerText=num;
        if(num<=4096){
            tile.classList.add("x"+num.toString());
        }
        else{
            tile.classList.add("x8192")
        }
    }
}