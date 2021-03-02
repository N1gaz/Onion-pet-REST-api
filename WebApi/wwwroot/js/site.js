function ShowCustomerform() {
    document.getElementById("customer-search").style.display = 'block'
    document.getElementById("date-search").style.display = 'none'
    ShowSearchButton();
}

function ShowDateForm() {
    document.getElementById("date-search").style.display = 'block'
    document.getElementById("customer-search").style.display = 'none'
    ShowSearchButton();
}

function ShowSearchButton() {
    document.getElementById("search-btn").style.display = 'block'
}

function CreateOrdersList(XHR) {
    var response = XHR.responseText;

}

var XHR = new XMLHttpRequest();
XHR.open('GET', "https://localhost:44325/Orders", false);
XHR.send();
var respStr = XHR.responseText;
var list = respStr.match(/{.*?}/g);

console.log(list);