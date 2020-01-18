document.body.classList.add("bg-danger");

var navbar = document.getElementsByTagName("nav");
navbar[0].classList.remove("bg-primary");
navbar[0].classList.add("bg-danger");

var footer = document.getElementsByTagName("footer");
footer[0].classList.remove("bg-primary");
footer[0].classList.add("bg-danger");

var navbarNav = document.getElementsByClassName("navbar-nav");

var child = navbarNav[0].lastElementChild;
while (child) {
    navbarNav[0].removeChild(child);
    child = navbarNav[0].lastElementChild;
}

var listElement = document.createElement("li");
var detail = document.createElement("a");
detail.id = "popi-admin";
detail.innerHTML = "Admin";
detail.style.display = "inline";
detail.href = "#";
detail.classList.add("nav-link");
detail.classList.add("text-light");
detail.setAttribute("data-toggle", "popover");
detail.setAttribute("data-placement", "bottom");
detail.style.color = "white";
listElement.appendChild(detail);
var settingsIcon = document.createElement("i");
settingsIcon.style.fontSize = "30px";
settingsIcon.style.color = "white";
settingsIcon.style.marginLeft = "10px";
settingsIcon.classList.add("fa");
settingsIcon.classList.add("fa-cog");
settingsIcon.classList.add("icon-settings");
settingsIcon.classList.add("lnr");
settingsIcon.classList.add("lnr-cog");
settingsIcon.classList.add("ion-ios-settings-outline");
listElement.appendChild(settingsIcon);
navbarNav[0].appendChild(listElement);


var toggle = document.getElementsByClassName("navbar-toggler");
var navContent = document.getElementById("navbar-content");
navContent.removeChild(toggle[0]);

var navbarCollapse = document.getElementsByClassName("navbar-collapse");
navbarCollapse[0].classList.remove("collapse");
navbarCollapse[0].classList.remove("d-sm-inline-flex");
navbarCollapse[0].classList.remove("flex-sm-row-reverse");
navbarCollapse[0].classList.remove("navbar-collapse");

var navbarBrand = document.getElementsByClassName("navbar-brand");
navbarBrand[0].setAttribute("asp-controller", "Administration");
navbarBrand[0].setAttribute("asp-action", "ShowAllRoles");