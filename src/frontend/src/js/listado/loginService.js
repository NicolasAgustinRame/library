$(document).ready(function(){
    var modal = new bootstrap.Modal(document.getElementById('exampleModal'), {
        backdrop: 'static', // Makes background non-clickable
        keyboard: false // Disables closing modal with keyboard
    });

    const token = localStorage.getItem("token")

    if (!token) {
        modal.show();
    }


    $('#formLogin').validate({
        rules: {
            email: {
                required: true
            },
            password: {
                required: true
            }
        },
        messages: {
            email: {
                required: "Ingrese email"
            },
            password: {
                required: "Ingresar password"
            }
        },
        errorClass: "text-danger mt-2"
    })


    $('#btnIngresar').click(function(){
        if($('#formLogin').valid()){
            modal.hide();
            login()
        }
    });
    $('#idLoginOut').click(function(){
        loginOut()
        location.reload()
        modal.show();
    });
});


function login() {
    const url = 'https://localhost:44320/login/post'
    const email = $('#idEmail').val()
    const password = $('#idPassword').val()

    fetch(url, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            email: email,
            password: password
        })
    })
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            console.log(response.errorMessage)
        } else {
            const token = response.data.token
            localStorage.setItem("token", token)
            window.location.href = window.location.pathname + "?token=" + token;
        }
    })
    .catch(error => {
        console.log(error)
    })
}

function loginOut() {
    localStorage.removeItem("token")
    location.reload()
}