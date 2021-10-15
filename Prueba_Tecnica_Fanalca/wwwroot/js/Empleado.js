var token;
var tokenExpira;
$(document).ready(function () {

    

    llamadaAjaxPOST("https://localhost:44345/api/login", (data) => {

        token = 'Bearer ' + data["token"];
        tokenExpira =new Date( data["expireAt"]);


   llamadaAjax("https://localhost:44345/api/area",token, (data) => {

       llenarComboArea(data, optionArea);
   });


    }, {
            Username: "Roger",
            Password: "12345"
    });


 

    var optionArea = $('#listAreas');
    optionArea.on("change", () => {
        var fechaActual = new Date(); 
        

        if (fechaActual > tokenExpira ) {


            llamadaAjaxPOST("https://localhost:44345/api/login", (data) => {

                token = 'Bearer ' + data["token"];
                tokenExpira = data["expireAt"];


                llamadaAjax("https://localhost:44345/api/SubArea/GetSubareasxArea", token, (data) => {
                    var control = $('#listSubAreas');
                    llenarComboSubArea(data, control);
                }, { numAreaId: optionArea.val() });


            }, {
                Username: "Roger",
                Password: "12345"
            });


        } else {
            llamadaAjax("https://localhost:44345/api/SubArea/GetSubareasxArea", token, (data) => {
                var control = $('#listSubAreas');
                llenarComboSubArea(data, control);
            }, { numAreaId: optionArea.val() });

        }
            
    });

});


function llamadaAjax(url,token, Funtion_respuesta, parametros = "") {
    $.ajax({
        url: url,
        type: "GET",
        headers: { 'Authorization': token },
        data: parametros,
        success: (response) => {
            Funtion_respuesta(response);
        },
        error: (response) => {
            Funtion_respuesta(response);
        }
    });
}




function llamadaAjaxPOST(url, Funtion_respuesta, parametros = "") {
    $.ajax({

        url: url,
        type: "POST",
        data: JSON.stringify(parametros),
       // headers: { 'Authorization':'Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c3VhcmlvIiwianRpIjoiNGIzZGIyMWMtMWI3ZC00MDQzLWJkYjAtYzkzZGNlODYwNmE3IiwiaWF0IjoxNjM0Mjk3NDQ0LCJyb2xlcyI6WyJDbGllbnRlIiwiQWRtaW5pc3RyYWRvciJdLCJuYmYiOjE2MzQyOTc0NDQsImV4cCI6MTYzNDMxNTQ0NCwiaXNzIjoiUGV0aWNpb25hcmlvIiwiYXVkIjoiUHVibGljIn0.5-CWKoBVMYJcLWeo4egJqTjz1cJzAXBfJj_noFGEHjQ'} ,
        headers: { 'Content-Type': 'application/json' },
        success: (response) => {
            Funtion_respuesta(response);
        },
        error: (response) => {
            Funtion_respuesta(response);
        }
    });
}

function llenarComboSubArea(data, control) {
    control.empty();
    var option = document.createElement('option');
    option.value = "";
    option.text = "Seleccione";
    control.append(option);
    for (var dato in data) {
        let option = document.createElement('option');
        option.value = data[dato].numSubareaId;
        option.text = data[dato].nombre;
        control.append(option);
    }


}


function llenarComboArea(data, control) {
    control.empty();
    var option = document.createElement('option');
    option.value = "";
    option.text = "Seleccione";
    control.append(option);
    for (var dato in data) {
        let option = document.createElement('option');
        option.value = data[dato].numAreaId;
        option.text = data[dato].nombre;
        control.append(option);
    }
}

