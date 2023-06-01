var size = 3;
var board;

window.onload = function(){
    setGame();
}

function setGame(){
    board=
    [
        [
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ],
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ],
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ]
        ],
        [
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ],
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ],
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ]
        ],
        [
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ],
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ],
            [
                [[],[],[]],
                [[],[],[]],
                [[],[],[]]
            ]
        ]
    ]
        
    for(let rb=0; rb < size;rb++){
        for(let cb=0;cb < size;cb++){
            let tileBlock=document.createElement("div");
            tileBlock.id=rb.toString()+ "-" + cb.toString();
            document.getElementById("board").append(tileBlock);
            updateTile(tileBlock,"tileBlock");

            for(let r=0;r<size;r++){
                for(let c=0;c<size;c++){
                    let tile=document.createElement("div");
                    tile.id=rb.toString()+"-"+cb.toString()+"-"+r.toString()+"-"+c.toString();
                    document.getElementById(tileBlock.id).append(tile);
                    updateTile(tile,"tile");

                    // let inputNum = document.createElement("input");
                    // inputNum.id = "case"+rb.toString()+"-"+cb.toString()+"-"+r.toString()+"-"+c.toString();
                    // inputNum.type="number";
                    // inputNum.min="1";
                    // inputNum.max="9";
                    // updateInput(inputNum,"inputNum");
                    // document.getElementById(tile.id).append(inputNum);

                    let selectNum = document.createElement("select");
                    selectNum.name="case";
                    selectNum.id = "case"+rb.toString()+"-"+cb.toString()+"-"+r.toString()+"-"+c.toString();
                    updateInput(selectNum,"inputNum");
                    document.getElementById(tile.id).append(selectNum);


                    for(let i=0;i<10;i++){
                        let option = document.createElement("option");
                        if(i==0){
                            option.value="0";
                            option.innerText=" ";
                        }
                        else{
                            option.value=i.toString();
                            option.innerText=i.toString();
                        }
                        document.getElementById(selectNum.id).append(option);
                    }



                    console.log(rb+" "+cb+" "+r+" "+c);
                }
            }
        }
    }
    
    function updateTile(tile,className){
        tile.classList="";
        tile.classList.add(className);

    }
    function updateInput(input,className){
        input.classList="";
        input.classList.add(className);

    }
}