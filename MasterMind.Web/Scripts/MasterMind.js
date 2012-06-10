/// <reference path="jquery-1.6.4.js" />

//temporary
var selected = new Array();

$(function () {

    var hub = $.connection.masterMind;

    $('#ColorColumn .colorBox').click(function () {
        selected.push($(this).index());

        if (selected.length == 4) {
            
            var win = hub.clientGuess(selected).done(function (result) {
                if (result)
                    alert('you win!');
            });
            console.log(win);
            selected = new Array();
        }
    });

    hub.showGuess = function (guess, connectionId) {

        if ($.connection.hub.id != connectionId) {
            alert('Another player guessed: ' + guess[0] + guess[1] + guess[2] + guess[3]);
        }
    }

    $.connection.hub.start();
});