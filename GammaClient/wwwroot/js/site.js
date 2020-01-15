// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let logoSymbol = document.getElementById("logoSymbol");
let logoGamma = document.getElementById("logoGamma");

function changeLogoOnMouseEnter() {
    logoSymbol.style.display = "none";
    logoGamma.style.display = "block";
}

function changeLogoOnMouseOut() {
    logoGamma.style.display = "none";
    logoSymbol.style.display = "block";
}