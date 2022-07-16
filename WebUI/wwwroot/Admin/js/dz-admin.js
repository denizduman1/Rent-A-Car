$(document).ready(function () {
    setTimeout(stopLoadingGif, 1000);
    function stopLoadingGif() {
        $("body").removeClass("loading-gif");
    }
});