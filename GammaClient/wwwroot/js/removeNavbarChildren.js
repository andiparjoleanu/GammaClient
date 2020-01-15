var navbarNav = document.getElementsByClassName("navbar-nav");

var child = navbarNav[0].lastElementChild;
while (child) {
    navbarNav[0].removeChild(child);
    child = navbarNav[0].lastElementChild;
}