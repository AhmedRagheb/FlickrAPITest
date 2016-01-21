
var tags = null;
$("#tags").keyup(function () {
    

    clearTimeout(tags);
    tags = setTimeout(function () {
        if ($("#tags").val().length < 3) {
            $("#status").text("");
            return false;
        }

        var tags = {tags: $("#tags").val() };
        var container = $("#pictures");
        
        $.ajax({
            url: "/Home/GetImages",
            type: "POST",
            async: true,
            dataType: "html",
            data: tags,
            success: function (data) {
                $("#status").text("Success.");
                container.html(data);

                $("img").fadeTo(1000, 1);
            },
            beforeSend: function() {
                $("#status").text("Retrieving ...");
            },
            complete: function() {
                $("#status").text("");
            },
            error: function() {
                $("#status").text("Error.");
            }
        });
        

    }, 250);
})

$(document).ajaxStart(function () {
    $("#status").text("Requesting ...");
});