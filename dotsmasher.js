var score = 0;
var aWidth;
var aHeight;
var timer;
var speed=2400;

function detectHit(){
    score += 1;
    scoreLabel.innerHTML = "Score: " + score;
    speed=speed-200;
    if (speed<=200) 
    	speed=2400;
}
function resetScore(){
    score = 0;
    scoreLabel.innerHTML = "Score: " + score;
}
function resetSpeed(){
    speed=2400;
}

function setGameAreaBounds(){
if(document.all){
    aWidth = document.body.clientWidth;
    aHeight = document.body.clientHeight;
}else{
    aWidth = innerWidth;
    aHeight = innerHeight;
}

aWidth -= 30;
aHeight -= 95;

document.getElementById("gameArea").style.width = aWidth;
document.getElementById("gameArea").style.height = aHeight;

aWidth -= 74;
aHeight -= 74;

moveDot();
}

function moveDot(){
    var x = Math.floor(Math.random()*aWidth);
    var y = Math.floor(Math.random()*aHeight);
    
    if(x<10)
        x = 10;
    if(y<10)
        y = 10;
    
    document.getElementById("dot").style.left = x;
    document.getElementById("dot").style.top = y;
    clearTimeout(timer);
    timer = setTimeout("moveDot()",speed);
    
}