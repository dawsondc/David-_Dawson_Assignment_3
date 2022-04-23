"use strict";
(function _personGameCreate() {
    const formCreatePersonGame =
        document.querySelector("#formCreatePersonGame");
    formCreatePersonGame.addEventListener('submit', e => {
        e.preventDefault();
        const url = "/api/persongameapi/create";
        const method = "post";
        const formData = new FormData(formCreatePersonGame);
        console.log(`${url} ${method}`);

        fetch(url, {
            method: method,
            body: formData
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('There was an error');
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