﻿let bodyColor = "white";
document.body.style.backgroundColor = bodyColor;

var navbar = document.getElementsByTagName("nav");
navbar[0].classList.remove("bg-primary");
navbar[0].style.backgroundColor = "#18A7B5";

var footer = document.getElementsByTagName("footer");
footer[0].classList.remove("bg-primary");
footer[0].style.backgroundColor = bodyColor;
footer[0].classList.remove("text-white");
footer[0].classList.add("text-dark");

var logoS = document.getElementById("logoSymbol");
logoS.classList.add("text-white");

var logoG = document.getElementById("logoGamma");
logoG.classList.add("text-white");

var popi = document.getElementById("popi");
popi.classList.remove("text-light");
popi.classList.add("text-white");