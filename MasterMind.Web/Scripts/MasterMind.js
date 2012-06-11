/// <reference path="jquery-1.6.4.js" />

//temporary arrays, will be moved to a js class
var selected = new Array();
var colors = new Array('white', 'yellow', 'orange', 'red', 'purple', 'teal', 'green', 'black');


$(function () {

    var hub = $.connection.masterMind;

    $('#ColorColumn .colorBox').click(function () {

        var indexClicked = $(this).index();
        //store selection
        selected.push(indexClicked);
        
        var lastEmptyRow = $('.none').last().parent();

        //add selection visually
        //will be changed to drag and drop
        lastEmptyRow.find('.none').first().addClass(colors[indexClicked]).removeClass('none');

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

            var lastEmptyRow = $('.none').last().parent();
            //add the guess visually
            lastEmptyRow.find('.none').first().addClass(colors[guess[0]]).removeClass('none');
            lastEmptyRow.find('.none').first().addClass(colors[guess[1]]).removeClass('none');
            lastEmptyRow.find('.none').first().addClass(colors[guess[2]]).removeClass('none');
            lastEmptyRow.find('.none').first().addClass(colors[guess[3]]).removeClass('none');
        }
    }

    $.connection.hub.start();
});