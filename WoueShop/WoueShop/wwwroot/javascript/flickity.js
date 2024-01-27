function startFlickity() {
    var elem = document.querySelector('.carousel');
    var flkty = new Flickity(elem, {
        // options
        cellAlign: 'left',
        contain: true,
        autoPlay: true
    });

    // element argument can be a selector string
    //   for an individual element
    var flkty = new Flickity('.carousel', {
        // options
        autoPlay: true
    });
}