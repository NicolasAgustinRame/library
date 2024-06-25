$(document).ready(function() {
    listarLibros()
})

function listarLibros() {
    const url = 'https://localhost:44320/libros/GetAll'
    fetch(url)
    .then(response => response.json())
    .then((response) => {
        if(!response.success){
            alert('Error al consumir la api')
        }
        else {
            const cuerpoTabla = document.querySelector("tbody")
            response.data.forEach(libro => {
                const fila = document.createElement("tr")
                fila.innerHTML += `<td>${libro.titulo}</td>`
                fila.innerHTML += `<td>${libro.autor.nombre}</td>`
                fila.innerHTML += `<td>${libro.genero.nombre}</td>`
                fila.innerHTML += `<td><button type="button" class="btn btn-danger" id="btnEliminar">Eliminar</button></td>`
                cuerpoTabla.append(fila)
            });
        }
    }).catch(err => {
        alert("Algo salio mal " + err)
    })
}

