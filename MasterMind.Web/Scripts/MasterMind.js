/// <reference path="jquery-1.6.4.js" />


$(function () {




    var msgHub = $.connection.masterMind;

    msgHub.showMessage = function (message, connectionId) {
        if (connectionId != $.connection.hub.id)
            $('#MessageList').append('<li>' + message + '</li>');
    }

    $('#MessageButton').click(function () {

        var message = $('#InputMessage').val();
        var connectionId = $.connection.hub.id;
        msgHub.broadcastMessage(message);
    });

    $.connection.hub.start();
});