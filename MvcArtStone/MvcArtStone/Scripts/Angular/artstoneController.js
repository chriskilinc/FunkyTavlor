angular.module('artstoneApp')
app.controller('artstoneController', ['$scope', '$timeout', '$http', function ($scope, $timeout, $http) {



    $scope.uploadme = {};
    $scope.uploadme.src = "";

    $scope.artwork = {
        Title: '',
        Artist: '',
        Room: '',
        Description: '',
        InStorage: true,
        ImgUrl: $scope.uploadme.src,
        Files: $scope.uploadme,
        Signed: false
    };




    $scope.artworkdata = {
        artworks: null,
        availableArtworks: []
    }

    function getArtworks() {
        console.log("Fetching all available visable artworks artworks..");
        $http.get('/home/GetArtworks')
            .then(function (response) {
                $scope.artworkdata.availableArtworks = response.data;
                console.log(response);
            });
    }
    getArtworks();



    $scope.insertArtwork = function (artwork) {
        console.log("Inserting Artwork");


        $http.post('/home/InsertArtwork', artwork)
            .then(function (response) {
                console.log("SUCCESS");
                window.location.reload();
                console.log(response);
            },
                function (response) {
                    console.log("Failed");
                });
    };

    $scope.deleteArtwork = function (artwork) {
        //id = artwork.id;
        
        $http.post('/home/DeleteArtworkById', artwork)
            .then(function (response) {
                //window.location.replace("/home/")
                console.log("SUCCESS");
                window.location.reload(); //TODO: Work around a 'reload()' to a real-time update instead of going to the server first
                console.log(response);
            })
    }

    $scope.fetchArtworkId = function (artwork) {
        $http.post('/home/editartwork', artwork)
            .then(function (response) {
                console.log("Artwork ip in the air!");
            });
    };

    // Instantiate these variables outside the watch
    var filterTextTimeout;
    //Kollar om någonting händer i search.artworks
    $scope.$watch('search.artworks',
        function (val) {
            //Kollar om värdet är tomt eller under 3 bokstäver och i sådannafall görs ingen databas-sökning
            if (val == null || val.length < 3) {
                $scope.artworks = null;
                return;
            }

            if (filterTextTimeout)
                $timeout.cancel(filterTextTimeout);


            filterTextTimeout = $timeout(function () {
                //Går till SearchArtworks 
                $http.post("/home/SearchArtworks", { id: val })
                    .then(function (response) {
                        $scope.artworks = response.data;
                        console.log(response);
                    })
                    .then(function (response) {
                        console.log(response);
                    });

            }, 250); //Wait 250 ms

        });

}

]).directive("fileread", [function () {
    return {
        scope: {
            fileread: "="
        },
        link: function (scope, element, attributes) {
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        scope.fileread = loadEvent.target.result;
                        //console.log(scope.fileread = loadEvent.target.result);
                    });
                }
                reader.readAsDataURL(changeEvent.target.files[0]);
            });
        }
    }
}]);

