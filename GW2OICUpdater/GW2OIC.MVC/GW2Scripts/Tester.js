$(document).ready(function(){

    $("#GetGW2Item").click(function () {

        var id = $("#GW2SearchBox").val();

        $.get("../JSON/GetItem", { id: id }).success(function (data) {
            console.log(data);
            $("#item_id").html("<br />" + data.item_id);
            $("#name").html("<br />" + data.name);
            $("#description").html("<br />" + data.description);
            $("#type").html("<br />" + data.type);
            $("#level").html("<br />" + data.level);
            $("#rarity").html("<br />" + data.rarity);
            $("#vendor_value").html("<br />" + data.vendor_value);
            $("#icon_file_id").html("<br />" + data.icon_file_id);
            $("#icon_file_signature").html("<br />" + data.icon_file_signature);
            $("#default_skin").html("<br />" + data.default_skin);
        });

    });

});

