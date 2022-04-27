// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification

function makeScheduleTitleEditable(editButton) {
    makeInput(editButton
        .parentNode
        .parentNode
        .parentNode
        .getElementsByClassName("item-title")[0])
};

function makeInput(e) {
    e.innerHTML = '<input id="text-input" value="' + e.innerText + '">';
    var textBox = document.getElementById("text-input");

    textBox.focus();
    textBox.addEventListener('focusout', cancelScheduleTitleEditable(textBox));
}

function cancelScheduleTitleEditable(textBox) {
    return function () {
        textBox.parentNode.innerHTML = textBox.value;
        window.location.href = 'schedules/edit?studentId=228&scheduleId=331&scheduleTitle=' + textBox.value;
    };
}

// Delete PopUp
$(function () {
    var placeholderElement = $('#placeholderElement');

    // Add/Delete button press
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');

        });
    });

     //Proceed with add/delete
    placeholderElement.on('click', '#deleteSchedule',
        function(event) {
            var url = $(this).data('url');
            $.post(url).done(function(response) {
                placeholderElement.find('.modal').modal('hide');
                location.reload(true);
            });
        });

    placeholderElement.on('click', '#addSchedule',
        function (event) {
            var form = $(this).parents('.modal').find('form');
            var action_url = form.attr('action');
            var send_data = form.serialize();
            $.post(action_url, send_data).done(function (response) {
                placeholderElement.find('.modal').modal('hide');
                location.reload(true);
            });
        });
    // Proceed with edit
    placeholderElement.on('click', '#editSchedule',
        function (event) {
            var form = $(this).parents('.modal').find('form');
            var action_url = form.attr('action');
            var send_data = form.serialize();
            $.post(action_url, send_data).done(function (response) {
                placeholderElement.find('.modal').modal('hide');
                location.reload(true);
            });
        });
});