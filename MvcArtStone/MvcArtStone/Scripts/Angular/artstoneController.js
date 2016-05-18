angular.module('artstoneApp')
app.controller('artstoneController',
[
    '$scope', '$http', function($scope, $http) {
        //$scope.open = function() {
        //    $state.go("_LoginPartial.cshtml");
        //};
        $scope.test = function() {
            console.log("Dick Bum - Test");
            $http.post("/home/Submit")
                .then(function(response) {
                    console.log(response);
                });

        }

        $scope.uploadFile = function(files) {
            var fd = new FormData();
            //Take the first selected file
            fd.append("file", files[0]);

            $http.post(uploadUrl,
                    fd,
                    {
                        withCredentials: true,
                        headers: { 'Content-Type': undefined },
                        transformRequest: angular.identity
                    })
                .success("yay")
                .error("damn");

        };

        $scope.artwork = {
            Title: '',
            Artist: '',
            Room: '',
            Description: '',
            InStorage: true,
            ImgUrl: '',
            File: []
        };


        $scope.artworkdata = {
            artworks: null,
            availableArtworks: []
        }

        function getArtworks() {
            console.log("Fetching all available visable artworks artworks..");
            $http.get('/home/GetArtworks')
                .then(function(response) {
                    $scope.artworkdata.availableArtworks = response.data;
                    console.log(response);
                });
        }
        getArtworks();

        $scope.insertArtwork = function(artwork) {
            console.log("Inserting Artwork");

            $http.post('/home/InsertArtwork', artwork)
                .then(function(response) {
                        console.log("SUCCESS");
                        console.log(response);
                    },
                    function(response) {
                        console.log("Failed");
                    });
        };

        $scope.fetchArtworkId = function(artwork) {
            $http.post('/home/editartwork', artwork)
                .then(function(response) {
                    console.log("Artwork ip in the air!");
                });
        }
    }

]);


