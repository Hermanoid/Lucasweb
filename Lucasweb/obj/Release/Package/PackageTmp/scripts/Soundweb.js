function PlayAudio(Location, ID) {
    $("#PlayButton-" + ID).removeClass("glyphicon-play-circle");
    $("#PlayButton-" + ID).addClass("glyphicon-time");
    var Sound = new Audio(Location);
    Sound.oncanplaythrough = function () {
        window.setTimeout(function () {
            $("#PlayButton-" + ID).removeClass("glyphicon-time");
            $("#PlayButton-" + ID).addClass("glyphicon-play-circle");
            Sound.play();
        }, 500)

    }

}