function checkMove(boardTemp){
    for(let r=0;r<rows;r++){
        for(let c=0;c<columns;c++){
            if(board[r][c]!=boardTemp[r][c])
            return true;
        }
    }
    return false;
}
function copyBoard(){
    let boardTemp=[
        [0,0,0,0],
        [0,0,0,0],
        [0,0,0,0],
        [0,0,0,0]
    ];
    for(let r=0;r<rows;r++){
        for(let c=0;c<columns;c++){
            boardTemp[r][c]=board[r][c];
        }
    }
    return boardTemp;
}

function setTwo(){
    if(!hasEmptyTile()){
        return;
    }
    let found=false;
    while(!found){
        let r = Math.floor(Math.random()*rows);
        let c = Math.floor(Math.random()*columns);
        if(board[r][c]==0){
            board[r][c]=2;
            let tile = document.getElementById(r.toString()+"-"+c.toString());
            tile.innerText="2";
            tile.classList.add("x2");
            found=true;
        }
    }
}