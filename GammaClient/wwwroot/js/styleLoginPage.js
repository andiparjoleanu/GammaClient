var navbarNav = document.getElementsByClassName("navbar-nav");

var child = navbarNav[0].lastElementChild;
while (child) {
    navbarNav[0].removeChild(child);
    child = navbarNav[0].lastElementChild;
}

var toggle = document.getElementsByClassName("navbar-toggler");
var navContent = document.getElementById("navbar-content");
navContent.removeChild(toggle[0]);

var navbarCollapse = document.getElementsByClassName("navbar-collapse");
navbarCollapse[0].classList.remove("collapse");
navbarCollapse[0].classList.remove("d-sm-inline-flex");
navbarCollapse[0].classList.remove("flex-sm-row-reverse");
navbarCollapse[0].classList.remove("navbar-collapse");