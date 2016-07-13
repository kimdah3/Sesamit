// Write your Javascript code.


// Google maps
var map;

function initMap() {
    map = new google.maps.Map(document.getElementById('kontakt-map'), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 8
    });
}

$(function () {
    $('#kontaktModal').on('shown.bs.modal', function () {
        google.maps.event.trigger(map, "resize");
    });
});