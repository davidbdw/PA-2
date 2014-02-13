function getValues() {
    var userSearch = $("#userSearch").val();
    if (userSearch.length == 0) {
        $("#result").empty();
        $("#result").html = 'You didn\'t enter in a search value.';
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService1.asmx/getResults",
        data: "{userInput:" + userSearch + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#result").empty();
            for (var i = 0; i < msg.d.length; i++) {
                $("#result").append.(msg.d[i] + "<br/>");
            }
            $("#result").html(JSON.stringify(msg));
        },
        error: function (msg, status, error) {
            $("#result").html(JSON.stringify(msg));
        }
    });
};