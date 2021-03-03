"use strict";

function ShowCustomerForm() {
  document.getElementById("customerSearch").style.display = 'block';
  document.getElementById("dateSearch").style.display = 'none';
  ShowSearchButton();
}

function ShowDateForm() {
  document.getElementById("dateSearch").style.display = 'block';
  document.getElementById("customerSearch").style.display = 'none';
  ShowSearchButton();
}

function ShowSearchButton() {
  document.getElementById("search-btn").style.display = 'block';
}

document.getElementById("radioDate").onclick = ShowDateForm;
document.getElementById("radioCustomer").onclick = ShowCustomerForm;
var response = fetch('https://localhost:44325/Orders');