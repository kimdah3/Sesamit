// Write your Javascript code.
// DOM LOADED
$(function () {
    $('#kontakt-button')
        .click(function () {
            $('#kontaktModal').on('shown.bs.modal', function () {
                google.maps.event.trigger(map, "resize");
            });
        });
});

// Google maps
var map;
function initMap() {
    var myLatlng = new google.maps.LatLng(59.258944, 15.2320114);
    var myOptions = {
        zoom: 15,
        center: myLatlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('kontakt-map'), myOptions);
}

//Facebook
function GetFacebook() {
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s);
        js.id = id;
        js.src = "//connect.facebook.net/sv_SE/sdk.js#xfbml=1&version=v2.7&appId=107579145685";
        fjs.parentNode.insertBefore(js, fjs);

    }(document, 'script', 'facebook-jssdk'));

    FB.Canvas.setSize({ width: 800, height: 480 });
}


//Bryggan
function FillMenu() {
    alert("https://barappen.se:9310/api/v020/menu/1e");
}

//Utstkott
function ApplyUtskottSlide() {
    $('a.page-scroll')
                .bind('click',
                    function (event) {
                        var $anchor = $(this);
                        $('html, body')
                            .stop()
                            .animate({
                                scrollTop: $($anchor.attr('href')).offset().top
                            },
                                1500,
                                'easeInOutExpo');
                        event.preventDefault();
                    });

    $('#nav')
        .affix({
            offset: {
                top: $('#nav').offset().top
            }
        });
}
