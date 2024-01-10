var intervalFishMove = setInterval(fishMoving, 1400);
var intervalCheckTime = setInterval(check,1000);
var intervalCheckScore = setInterval(check2,500);
var scor=0;
var old_x_pos=0;
var old_y_pos=0;
function fishMoving(){
    var fishMove = document.getElementById('fishMove');
    var fish = document.getElementById('fish');
    var x_pos = Math.floor(Math.random() * (239 - 0)) + 0;
    var y_pos = Math.floor(Math.random() * (189 - 0)) + 0;
    fishMove.style.left = (x_pos) + "px";
    fishMove.style.top = (y_pos) + "px";
    fishMove.style.transitionDuration = "2s";
    fish.style.webkitTransform = 'rotate('+getAngle(old_x_pos, old_y_pos, x_pos, y_pos)+'deg)';
    old_x_pos=x_pos;
    old_y_pos=y_pos;
}

function getAngle(x1, y1, x2, y2){
	var	dx = x1 - x2;
	var dy = y1 - y2;
	return Math.atan2(dy,dx) * 180 / Math.PI;
}

function test(){
  if(scor<3 || gameover==false)
  {
    var hit = document.getElementById('hit');
    hit.style.left = (event.clientX-20) + "px";
    hit.style.top = (event.clientY-20) + "px";
    hit.style.display = "block";
    setTimeout(checkDisplayHit, 600);
  }
}

function checkDisplayHit(){
    var hit = document.getElementById('hit');
    if(hit.style.display == "block")
    {
      hit.style.display = "none";
    }
    scor=scor+1;
    document.getElementById('scor').innerHTML = scor;
}

function check(){
  var bar = document.getElementById('timer');
  //bar.style.transitionDuration = "5s";
  bar.value-=1;
}

var gameover=false;
function check2(){
  var bar = document.getElementById('timer');
  if(bar.value==0 || scor==3)
  {
    clearInterval(intervalCheckScore);
    clearInterval(intervalCheckTime);
    clearInterval(intervalFishMove);
    gameover=true;
  }
}

function printMousePos(event) {
  document.getElementById('coord').textContent ="";
  document.getElementById('coord').textContent +=
    "clientX: " + event.clientX +
    " - clientY: " + event.clientY;
}
//document.addEventListener("click", printMousePos);