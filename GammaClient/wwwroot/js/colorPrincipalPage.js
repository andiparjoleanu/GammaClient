﻿//let bodyColor = "#083358";
document.body.style.backgroundColor = "white";

var navbar = document.getElementsByTagName("nav");
//navbar[0].classList.remove("bg-primary");
//navbar[0].classList.add("bg-white");

var footer = document.getElementsByTagName("footer");
footer[0].classList.remove("bg-primary");
footer[0].classList.add("bg-white");
footer[0].classList.add("text-dark");
//footer[0].style.color = bodyColor;

var logoS = document.getElementById("logoSymbol");
logoS.style.color = "white";

var logoG = document.getElementById("logoGamma");
logoG.style.color = "white";

var popi = document.getElementById("popi");
popi.classList.remove("text-light");
popi.style.color = "white";