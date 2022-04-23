"use strict";
(function _personGameList() {
    const url = "api/persongameapi/playthroughs";
    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('There was an error');
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

function populateTable(result) {
    const tableBody = document.getElementById("tableBody");
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
        tableBody.appendChild(tr);
    });
}