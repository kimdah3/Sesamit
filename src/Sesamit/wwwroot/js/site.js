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
function ApplySlide() {
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


function ImperaAnnons() {
    $('body').append('<div class="impera-widget"> <style>.impera-widget{position: fixed; z-index: 1000; bottom:0; width:100%;}.impera-widget .circle-container{-webkit-border-radius:50%; border-radius:50%; left:50%; -webkit-transform:translate(-50%); transform:translate(-50%); background:#dd519a; color:white; height:250px; width:250px; text-align: center; position: absolute; bottom:-125px; transition: 0.5s ease-in-out;}.impera-widget .circle-container .ds-logo img{height:150px; width:150px; filter:grayscale(100%);}.impera-widget .circle-container:hover{bottom:-50px;}.impera-widget .circle-container .cta{font-size:24px; color:black; text-decoration: none;}@media (max-width:420px){.impera-widget .circle-container .ds-logo img{height:90px; width:90px; filter:grayscale(100%);}.impera-widget .circle-container{height:200px; width:200px;}}</style> <div class="circle-container"> <a href="http://www.digitalsummit.se/student/"> <div class="ds-logo"> <img src="http://www.digitalsummit.se/media/1035/logga.svg"> </div><div class="cta"> Anmäl dig här! </div></a> </div></div>')
}