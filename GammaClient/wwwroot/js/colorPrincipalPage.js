let bodyColor = "#083358";
document.body.style.backgroundColor = bodyColor;

var navbar = document.getElementsByTagName("nav");
navbar[0].classList.remove("bg-primary");
navbar[0].classList.add("bg-white");

var footer = document.getElementsByTagName("footer");
footer[0].classList.remove("bg-primary");
footer[0].classList.add("bg-white");
footer[0].classList.remove("text-white");
footer[0].style.color = bodyColor;

var logoS = document.getElementById("logoSymbol");
logoS.style.color = bodyColor;

var logoG = document.getElementById("logoGamma");
logoG.style.color = bodyColor;

var popi = document.getElementById("popi");
popi.classList.remove("text-light");
popi.style.color = bodyColor;