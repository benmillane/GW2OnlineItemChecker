$(document).ready(function(){

    $("#GetGW2Item").click(function () {

        var id = $("#GW2SearchBox").val();

        $.get("../JSON/GetItem", { id: id }).success(function (data) {
            console.log(data);
            $("#item_id").html(data.item_id);
        });

    });

});

