// Write your Javascript code.
// Google maps
var map;

function initMap() {
    var myLatlng = new google.maps.LatLng(59.2555144,15.2420114);
    var myOptions = {
        zoom: 17,
        center: myLatlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('kontakt-map'), myOptions);
}

$(function () {
    $('#kontaktModal').on('shown.bs.modal', function () {
        google.maps.event.trigger(map, "resize");
    });

    $('a.page-scroll').bind('click', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });

    $('#nav').affix({
        offset: {
            top: $('#nav').offset().top
        }
    });

});