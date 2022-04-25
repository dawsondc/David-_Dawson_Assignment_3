//java script to interact with the api and the rest of the project
"use strict";
(function _personGameList() {
    const url = "api/persongameapi/playthroughs";
    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('There was an error'); //404 error for if something happens
            }
            return response.json();
        })
        .then(result => {
            populateTable(result);
        })
        .catch(error => {
            console.error('Error:', error);
        });
})();

//populating the view with the correct info about each entry
function populateTable(result) {
    const Table = document.getElementById("Table");
    result.forEach((item) => {
        const tr = document.createElement("tr");
        for (let key in item) {
            const td = document.createElement("td");
            let text = item[key];
            if (text === '' && key === 'Rating') {
                text = "No Rating Given";
            }
            let Node = document.createTextNode(text);
            td.appendChild(Node);
            tr.appendChild(td)
        }
        Table.appendChild(tr);
    });
}