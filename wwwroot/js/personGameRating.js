﻿//java script to interact with the api and the rest of the project
"use strict";
(function _personGameRating() {
    const formRating =
        document.querySelector("#formRating");
    formRating.addEventListener('submit', x => {
        x.preventDefault();
        const url = "/api/persongameapi/assignrating";//url to direct to the controller methods
        const method = "put";
        const formData = new FormData(formRating);
        console.log(`${url} ${method}`);
        const personID = formData.get("personID");

        fetch(url, {
            method: method,
            body: formData
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('There was an error'); //404 error for if something happens
                }
                return response.status;
            })
            .then(result => {
                console.log(result);
                console.log("Success");
                window.location.replace(`/person/details/${personID}`); // redirect to person details view
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });

})();