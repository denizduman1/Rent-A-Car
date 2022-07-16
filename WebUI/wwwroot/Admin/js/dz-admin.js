$(document).ready(function () {
    setTimeout(stopLoadingGif, 2000);
    function stopLoadingGif() {
        $("body").removeClass("loading-gif");
    }
});