$(function () {

    $(".edit-button").click(function (event) {
        var url = $(this).data('url');
        location.href = url;
    });
});