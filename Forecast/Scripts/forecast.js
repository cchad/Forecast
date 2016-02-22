$(function() {
    $("[data-color]").each(function(index, element) {
        var color = getColor(index);
        $(element).css("background-color", color);
        $(element).children("div").each(function(childindex, child) {
            $(child).css("background-color", color);
        });
    });
});

var fibonacci = new Array(1, 2, 3, 5, 8, 13);

function getColor(index) {
    index++;
    if (fibonacci.indexOf(index) > -1) {
        return "#cff";
    }
    if (index % 3 === 0 && index % 5 === 0) {
        return "#cfc";
    }
    if (index % 3 === 0) {
        return "#fcc";
    }
    return index % 5 === 0 ? "#ccf" : "#fff";
}