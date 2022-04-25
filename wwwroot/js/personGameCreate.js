
//java script to interact with the api and the rest of the project
"use strict";
(function _personGameCreate() {
    const formCreatePersonGame =
        document.querySelector("#formCreatePersonGame");
    formCreatePersonGame.addEventListener('submit', x => {
        x.preventDefault();
        const url = "/api/persongameapi/create";//url to direct to the controller methods
        const method = "post";
        const formData = new FormData(formCreatePersonGame);
        console.log(`${url} ${method}`);

        fetch(url, {
            method: method,
            body: formData
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('There was an error'); //404 error for if something happens
                }
                return response.json();
            })
            .then(result => {
                console.log('Success!');
                window.location.replace(`/person/details/${result.personID}`); // redirect to details view
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });

})();