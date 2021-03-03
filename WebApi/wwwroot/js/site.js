function ShowCustomerForm() {
    document.getElementById("customerSearch").style.display = 'block'
    document.getElementById("dateSearch").style.display = 'none'
    ShowSearchButton();
}

function ShowDateForm() {
    document.getElementById("dateSearch").style.display = 'block'
    document.getElementById("customerSearch").style.display = 'none'
    ShowSearchButton();
}

function ShowSearchButton() {
    document.getElementById("search-btn").onclick = Search;
    document.getElementById("search-btn").style.display = 'block';
}

function Search() {
    if (document.forms["switchType"].elements["radioCustomer"].checked == true) {
        SearchByCustomer();
    }
    else if (document.forms["switchType"].elements["radioDate"].checked == true) {
        SearchByDate();
    }
    else {
        GetOrders();
    }
}

function SearchByDate() {
    var date = document.forms["dateSearchForm"].elements["date"].value;

    if (date == '') {
        alert('Введите дату');
    }
    else {
        GetOrdersByDate(date);
    }
    
}

function SearchByCustomer() {
    var name = document.forms["customerSearchForm"].elements["name"].value;
    var surname = document.forms["customerSearchForm"].elements["surname"].value;

    if (name == '' || surname == '') {
        alert('Заполните все поля');
    }
    else {
        GetOrdersByCustomer(name, surname);
    }
}

 async function GetOrders(){
    const responseOrders = await fetch("/Orders", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (responseOrders.ok === true) {
        const orders = await responseOrders.json();
        DrawOrders(orders.value);
    }
}

 async function GetOrdersByDate(date) {
    const responseOrders = await fetch("/Orders/" + date, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (responseOrders.ok === true) {
        const orders = await responseOrders.json();
        DrawOrders(orders);
    }
}

async function GetOrdersByCustomer(customerName, customerSurname) {

    const customers = await GetCustomerByNameAndSurname(customerName, customerSurname);
    for (var i of customers) {
        const responseOrders = await fetch("/Orders/" + i.id, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });

        if (responseOrders.ok === true) {
            const orders = await responseOrders.json();
            await DrawOrders(orders);
        }
    }
}

 async function DrawOrders(responseResult) {
     let rows = document.querySelector("tbody");

     rows.innerText = '';

     for (var i of responseResult) {
         var innerable = await row(i);
         rows.append(innerable);
     }
}

 async function row(order) {

    const customer = await GetCustomerByCustomerId(order.customerId);

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", order.id);

    const idTd = document.createElement("td");
    idTd.append(order.id);
    tr.append(idTd);

    const orderDateTd = document.createElement("td");
    orderDateTd.append(order.orderDate.substring(0, order.orderDate.indexOf('T')));
    tr.append(orderDateTd);

    const orderPriceTd = document.createElement("td");
    orderPriceTd.append(order.orderPrice);
    tr.append(orderPriceTd);

    const customerIdTd = document.createElement("td");
    customerIdTd.append(order.customerId);
    tr.append(customerIdTd);

    const customerNameTd = document.createElement("td");
    customerNameTd.append(customer.customerName)
    tr.append(customerNameTd);

    const customerSurnameTd = document.createElement("td");
    customerSurnameTd.append(customer.customerSurname)
    tr.append(customerSurnameTd);


    return tr;
}

async function GetCustomerByCustomerId(id) {

    const responseCustomers = await fetch("/Customers/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (responseCustomers.ok == true) {
        const customer =  responseCustomers.json();
        return  customer;
    }
    else {
         alert("Не удалось получить пользователя с id = " + id);
        return  null;
    }
    
}

async function GetCustomerByNameAndSurname(name, surname) {

    const responseCustomers = await fetch("/Customers/" + name + '-' + surname, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (responseCustomers.ok == true) {
        const customer = responseCustomers.json();
        return customer;
    }
    else {
        alert("Не удалось получить пользователя с id = " + id);
        return null;
    }

}

document.getElementById("radioDate").onclick = ShowDateForm;
document.getElementById("radioCustomer").onclick = ShowCustomerForm;
document.onkeyup = (e) => {
    if (e.keyCode == 13) {
        Search();
    }
}
GetOrders();
