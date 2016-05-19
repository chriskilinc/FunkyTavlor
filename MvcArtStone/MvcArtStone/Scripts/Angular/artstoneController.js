angular.module('artstoneApp')
app.controller('artstoneController', ['$scope', '$http', function ($scope, $http) {
        $scope.artwork = {
            Title: '',
            Artist: '',
            Room: '',
            Description: '',
            InStorage: true,
            ImgUrl: '',
            Files: {}
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
                    console.log(response);
                },
                    function (response) {
                        console.log("Failed");
                    });
        };

        $scope.fetchArtworkId = function (artwork) {
            $http.post('/home/editartwork', artwork)
                .then(function (response) {
                    console.log("Artwork ip in the air!");
                });
        }
    }

]);

