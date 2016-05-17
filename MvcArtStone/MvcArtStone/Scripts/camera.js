function hasGetUserMedia() {
    return !!(navigator.getUserMedia || navigator.webkitGetUserMedia ||
              navigator.mozGetUserMedia || navigator.msGetUserMedia);
}

if (hasGetUserMedia()) {
    // Good to go!
} else {
    alert('getUserMedia() is not supported in your browser');
}

if (Modernizr.getusermedia){
    var gUM = Modernizr.prefixed('getUserMedia', navigator);
    gUM({video: true}, function( //...
    //...
    });