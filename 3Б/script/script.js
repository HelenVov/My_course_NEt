
let button=document.getElementById('run');
button.addEventListener("click", run);
let selectedTd;

function color(td) {

    if(td.style.backgroundColor == "blue")
    	td.style.backgroundColor = "white";
    else
    	td.style.backgroundColor = "blue";  
}

function remove_table() {

	var table=document.getElementById('table');
	if (table) {
		table.parentNode.removeChild(table);
	}
}

function run(){	

	remove_table();
	let row=document.getElementById("row");
	let column=document.getElementById("column");
	let cols = parseInt(column.value);
	let rows = parseInt(row.value);
    let myBut= document.getElementsByTagName("button");
    let div=document.createElement('div');

    let table = document.createElement('table');
	table.id='table';

    let tableBody = document.createElement('tbody');
    table.appendChild(tableBody);

    for (let i = 0; i < cols; i++) {

        let tr = document.createElement('tr');
        tableBody.appendChild(tr);

        for (let j = 0; j < rows; j++) {

            let td = document.createElement('td');
        	td.innerText=i.toString()+j.toString();
            tr.appendChild(td);
        }
    }
    div.appendChild(table);
    myBut[0].after(div);

    table.onclick = function(event) {
    let target = event.target; 

    if (target.tagName != 'TD') return;

    color(target); 
    };
}