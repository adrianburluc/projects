function showLang() {
  document.getElementById("language").classList.toggle("show");
}
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}

function openNav() {
  var sidenav = document.getElementById("mySidenav");
  sidenav.innerHTML="<ul class='align'><li><a href='javascript:void(0)' class='closebtn' onclick='closeNav()'>&times;</a></li><li><a href='#'>Acasa</a></li><li><a href='#'>Camere</a></li><li><a href='#'>Servicii</a></li><li><a href='#'>Restaurant</a></li><li><a href='#'>Galerie</a></li><li><a href='#'>Rezerva camera</a></li></ul>";
  sidenav.style.width = "100%";
  sidenav.style.display="block";
}

function closeNav() {
  var sidenav = document.getElementById("mySidenav");
  document.getElementById("mySidenav").style.width = "0";
}
