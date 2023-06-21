function checkCase(r,c){
    if(r==0){
        if(board[r+1][c]==board[r][c]){
            return true;
        }
    }
    else if(r==3){
        if(board[r-1][c]==board[r][c]){
            return true;
        }
    }
    else{
        if(board[r-1][c]==board[r][c] ||board[r+1][c]==board[r][c]){
            return true;
        }
    }
    if(c==0){
        if(board[r][c+1]==board[r][c]){
            return true;
        }
    }
    else if(c==3){
        if(board[r][c-1]==board[r][c]){
            return true;
        }
    }
    else{
        if(board[r][c-1]==board[r][c] ||board[r][c+1]==board[r][c]){
            return true;
        }
    }
    return false;
}

function checkGameOver(){
    for(let r=0;r<rows;r++){
        for(let c=0;c<columns;c++){
            if(checkCase(r,c)){
                return false;
            }
        }
    }
    return true;
}

function hasEmptyTile(){
    for(let r=0;r<rows;r++){
        for(let c=0;c<columns;c++){
            if(board[r][c]==0){
                return true;
            }
        }
    }
    return false;
}