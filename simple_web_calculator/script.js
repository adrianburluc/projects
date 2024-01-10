function test(){
      var icon = document.getElementById('icon');

      if(icon.style.width!="100%")
      {
        icon.style.width="100%";
        icon.style.height="100%";
        icon.style.marginTop="-25px";
        icon.style.marginLeft="0";
        document.getElementById('text-icon').style.visibility = "hidden";
        document.getElementById('calc-icon').style.color = "rgba(0, 0, 0, 0)";
        document.getElementById('icon').style.background="rgba(46, 48, 52, 1)";
        setTimeout(
        function() {
          document.getElementById('app-window').style.display="block";
        }, 740);
      }
      else{
        icon.style.width="50px";
        icon.style.height="50px";
        icon.style.marginTop="50px";
        icon.style.marginLeft="20px";
        document.getElementById('text-icon').style.visibility = "visible";
        document.getElementById('calc-icon').style.color = "rgba(0, 0, 0, 1)";
        document.getElementById('changecolor').style.color = "white";
      }
    }
    function phoneView(){
      var smartphone = document.getElementById('smartphone');
      smartphone.style.width="350px";
      smartphone.style.height="700px";
      var btns = document.getElementsByClassName('buttont-text');
      for(var i = 0, length = btns.length; i < length; i++) {
        if(btns[i].style.fontSize != '200%'){
          btns[i].style.fontSize = '200%';
        }
      }
      document.getElementById('history').style.fontSize = '150%';
      document.getElementById('input-text').style.fontSize = '300%';
      document.getElementById('display-text-area').style.paddingBottom = '15px';
    }
    function tabletView(){
      var smartphone = document.getElementById('smartphone');
      smartphone.style.width="700px";
      smartphone.style.height="700px";
      var btns = document.getElementsByClassName('buttont-text');
      for(var i = 0, length = btns.length; i < length; i++) {
        if(btns[i].style.fontSize != '200%'){
          btns[i].style.fontSize = '200%';
        }
      }
      document.getElementById('history').style.fontSize = '150%';
      document.getElementById('input-text').style.fontSize = '300%';
      document.getElementById('display-text-area').style.paddingBottom = '15px';
    }
    function watchView(){
      var smartphone = document.getElementById('smartphone');
      smartphone.style.width="350px";
      smartphone.style.height="350px";
      var btns = document.getElementsByClassName('buttont-text');
      for(var i = 0, length = btns.length; i < length; i++) {
        if(btns[i].style.fontSize != '125%'){
          btns[i].style.fontSize = '125%';
        }
      }
      document.getElementById('history').style.fontSize = '100%';
      document.getElementById('input-text').style.fontSize = '200%';
      document.getElementById('display-text-area').style.paddingBottom = '0';
    }
    function changeBg(){
      document.getElementById('bgscreen').style.backgroundImage = "url('https://i.imgur.com/hTOyUzz.png')";
    }
    function changeBg2(){
      document.getElementById('bgscreen').style.backgroundImage = "url('https://i.imgur.com/IGzYOpD.png')";
    }
    function changeBg3(){
      document.getElementById('bgscreen').style.backgroundImage = "url('https://i.imgur.com/bbi116b.png')";
    }
	
	

  function checkIfInputEquals0(){
  var number = document.getElementById("input").textContent;
  if(number.substr(number.length - 1)=='0' && parseFloat(number)==0){
      document.getElementById("input").innerHTML = "";
  }
}

function btn0(){
  if(parseFloat(document.getElementById("input").textContent)!=0){
    if(isSymbolUsed==true)
    {
      document.getElementById("input").innerHTML = "";
      isSymbolUsed=false;
    }
    if(isEqualUsed==true)
    {
      document.getElementById("input").innerHTML = "";
      document.getElementById("equation").innerHTML = "";
      equation=0;
      isEqualUsed=false;
    }
    document.getElementById("input").innerHTML += "0";
  }


}
function btn1(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "1";
}

function btn2(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "2";
}

function btn3(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "3";
}

function btn4(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "4";
}

function btn5(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "5";
}

function btn6(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "6";
}

function btn7(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "7";
}

function btn8(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "8";
}

function btn9(){
  checkIfInputEquals0();
  if(isSymbolUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    isSymbolUsed=false;
  }
  if(isEqualUsed==true)
  {
    document.getElementById("input").innerHTML = "";
    document.getElementById("equation").innerHTML = "";
    equation=0;
    isEqualUsed=false;
  }
  document.getElementById("input").innerHTML += "9";
}

function btnDot(){
  var number = document.getElementById("input").textContent;
  if(number.includes(".")==false)
  {
    document.getElementById("input").innerHTML += ".";
  }
}

function clearC(){
  var numberString = document.getElementById("input").textContent;
  var number = parseFloat(numberString);
  if(number!=0 || numberString.substr(numberString.length - 1)=='.')
  {
    document.getElementById("input").innerHTML = numberString.slice(0, -1);
  }
  if(document.getElementById("input").innerHTML == "")
  {
    document.getElementById("input").innerHTML = "0";
  }
}

function clearCE(){
  document.getElementById("input").innerHTML = "0";
  document.getElementById("equation").innerHTML = "";
  equation=0;
}

function getNumber(){
  var number = parseFloat(document.getElementById("input").textContent);
  return number;
}

function aFolositSimbol(){
  if(operation!=""){
    return true;
  }
  return false;
}

var operation="+";
var equation=0;
var isSymbolUsed=false;
var isEqualUsed=false;
function btnPlus(){
  checkOperation();
  document.getElementById("equation").innerHTML+=" + ";
  operation="+";
}

function btnMinus(){
  checkOperation();
  document.getElementById("equation").innerHTML+=" - ";
  operation="-";
}

function btnMultiplication(){
  checkOperation();
  document.getElementById("equation").innerHTML+=" * ";
  operation="*";
}

function btnDivide(){
  checkOperation();
  document.getElementById("equation").innerHTML+=" / ";
  operation="/";
}

function checkOperation(){
  if(isEqualUsed==false)
  {
    if(operation=="+"){
      equation=equation+getNumber();
    }
    else if(operation=="-"){
      equation=equation-getNumber();
    }
    else if(operation=="*"){
      equation=equation*getNumber();
    }
    else if(operation=="/"){
      equation=equation/getNumber();
    }
  }
  else {
      isEqualUsed=false;
  }
  document.getElementById("equation").innerHTML+=getNumber();
  document.getElementById("input").innerHTML=equation;
  isSymbolUsed=true;
}

function btnEqual(){
  var lastNumber=getNumber();
  isEqualUsed=true;
  document.getElementById("equation").innerHTML=equation;
  if(operation=="+")
  {
    equation=equation+lastNumber;
    document.getElementById("equation").innerHTML+=" + "+lastNumber+" = ";
  }
  if(operation=="-")
  {
    equation=equation-lastNumber;
    document.getElementById("equation").innerHTML+=" - "+lastNumber+" = ";
  }
  if(operation=="*")
  {
    equation=equation*lastNumber;
    document.getElementById("equation").innerHTML+=" * "+lastNumber+" = ";
  }
  if(operation=="/")
  {
    equation=equation/lastNumber;
    document.getElementById("equation").innerHTML+=" / "+lastNumber+" = ";
  }
  document.getElementById("input").innerHTML = equation;
}