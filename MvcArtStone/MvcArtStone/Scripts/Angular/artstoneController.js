﻿angular.module('artstoneApp')
app.controller('artstoneController', ['$scope', '$timeout', '$http', function ($scope, $timeout, $http) {
    $scope.artwork = {
        Title: '',
        Artist: '',
        Room: '',
        Description: '',
        InStorage: true,
        ImgUrl: '',
        Files: []
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

            },
                250); //Wait 250 ms

        });

}

]);

