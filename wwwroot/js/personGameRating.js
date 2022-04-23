"use strict";
(function _personGameRating() {
    const formRating =
        document.querySelector("#formRating");
    formRating.addEventListener('submit', e => {
        e.preventDefault();
        const url = "/api/persongameapi/assignrating";
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
                    throw new Error('There was an error');
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