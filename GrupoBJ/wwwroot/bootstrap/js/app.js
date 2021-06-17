var ajaxPeliculas = function (accion, url, formulario) {
    
    var datos = $('#'+formulario).serializeArray();
    datos.push({name:'accion',value:accion});
    
    $.ajax({
        url:url,
        data:datos,
        type:"POST",
        datatype:"JSON",
        success:function(response){
            
            if (response.peliculas !== null){
                $.each(response.peliculas, function(index,pelicula){
                    $('#tablaPeliculas tbody').append(
                        "<tr><td>"+pelicula.idp+"</td>"+
                        "<td>"+pelicula.titulo+"</td>"+
                        "<td>"+pelicula.genero+"</td>"+
                        "<td>"+pelicula.duracion+"</td>"+
                        "<td>"+pelicula.clasificacion+"</td>"+
                        "</tr>"
                    );
                });
            }
        }
    });
}