function CallService(url, type, contentType, data) {
    var resultVal = null;

    $.ajax({
        url: url,
        type: type,
        contentType: contentType,
        data: data,
        async: false,
        success: function (result) {
            resultVal = result.d;
        },
        error: function (error) {
            alert("Error: " + error);
        }
    });

    return resultVal;
}