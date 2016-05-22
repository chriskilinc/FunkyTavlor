angular.module('artstoneApp');
app.controller('editController', ['$scope', '$http', function ($scope, $http) {

    //$scope.send = function () {
    //    $http.post('../EditArtwork/' )
    //            .then(function(response) {
    //                $scope.artwork = response.data;
    //                console.log(response);
    //            });
    //    };


    $scope.uploadme = {};
    $scope.uploadme.src = "";

    $scope.artwork = {
        Title: '',
        Artist: '',
        Room: '',
        Description:'',
        InStorage: false,        
        Id: '',
        ImgUrl: $scope.uploadme.src,
        Files: $scope.uploadme,
        Signed: false,
    };

    $scope.deleteArtwork = function (artwork) {
        var fullUrl = window.location.href;
        var id = fullUrl.slice(-36)
        console.log(id);
        $scope.artwork.Id = id;

        $http.post('/home/DeleteArtworkById', artwork)
            .then(function (response) {
                window.location.replace("/home/")
                console.log("SUCCESS");
                console.log(response);
            })
    }

    $scope.EditArtwork = function (artwork) {
        console.log("Editing Artwork");

        var fullUrl = window.location.href;
        var split = fullUrl.slice(-36)

        $scope.artwork.Id = split;
        $http.post('/home/EditArtworkByModel', artwork)
            .then(function (response) {
                window.location.replace("/home/")
                console.log("SUCCESS");
                console.log(response);
            },
                function (response) {
                    console.log("Failed");
                })
    }


}

]).directive("fileread", [function () {
    return {
        scope: {
            fileread: "="
        },
        link: function (scope, element, attributes) {
            console.log("im kinda doing it");
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        scope.fileread = loadEvent.target.result;
                        console.log(scope.fileread = loadEvent.target.result);
                    });
                }
                reader.readAsDataURL(changeEvent.target.files[0]);
            });
        }
    }
}]);

