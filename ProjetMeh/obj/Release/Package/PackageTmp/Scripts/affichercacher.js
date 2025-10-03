function bascule(elem) {
    etat = document.getElementById(elem).style.display;
    if (etat == "none") {
        document.getElementById(elem).style.display = "block";
    } else {
        document.getElementById(elem).style.display = "none";
    }
}

function expandcollapse(name) {
    
    var div = document.getElementById(name);
    var img = document.getElementById('img' + name);
    var img1 = document.getElementById('img1' + name);
    if (div.style.display == 'none') {
        div.style.display = "inline";
        img.src = "/Images/moins.png";
        img1.src = "/Images/moins.png";
    }
    else {
        div.style.display = "none";
        img.src = "/Images/plus.png";
        img1.src = "/Images/plus.png";
    }
}

function expandcollapse1(name,numero) {
    
    var div = document.getElementById(name);
    var bt = document.getElementById('bt_' + name);
    if (div.style.display == 'none') {
        div.style.display = "inline";
        bt.innerHTML = numero;
        }
    else {
        div.style.display = "none";
        bt.innerHTML = numero;
    }
}


function expandcollapse2(name) {
    
    var div = document.getElementById(name);
    var bt = document.getElementById('bt_' + name);
    div.style.display = 'none';
    if (div.style.display == 'none') {
        div.style.display = "inline";
        bt.innerHTML = "Rechercher";
    }
    else {
        div.style.display = "none";
        bt.innerHTML = "Rechercher";
    }
}
