$(function () {
    var button = document.getElementById("scrollTopButton");
    console.log(button);
    button.addEventListener("click", function (event) {
        event.preventDefault;
        console.log("inButton");
        var body = $("html, body");
        body.stop().animate({ scrollTop: 0 }, 2500, 'swing', function () {
        });
    });

});

$(window).bind("load", function () {

    var footerHeight = 0,
        footerTop = 0,
        $footer = $("#footer");

    positionFooter();

    function positionFooter() {

        footerHeight = $footer.height();
        footerTop = ($(window).scrollTop() + $(window).height() - footerHeight) + "px";

        if (($(document.body).height() + footerHeight) < $(window).height()) {
            $footer.css({
                position: "absolute"
            }).animate({
                top: footerTop
            }, 1, "swing")
        } else {
            $footer.css({
                position: "static"
            })
        }

    }

    $(window)
            .scroll(positionFooter)
            .resize(positionFooter)

});
