angular.module('artstoneApp');
app.controller('editController', ['$scope', '$http', function ($scope, $http) {

    //$scope.send = function () {
    //    $http.post('../EditArtwork/' )
    //            .then(function(response) {
    //                $scope.artwork = response.data;
    //                console.log(response);
    //            });
    //    };

        $scope.artwork = {
            Title: val,
            Artist: val,
            Room: val,
            Description: val,
            ImgUrl: val,
        };

    

    $scope.update = function(artwork) {
        $scope.artwork = angular.copy(artwork);
        console.log(artwork);
    }


        ////$scope.key = $sce.trustAsHtml(key);

        //$scope.fetchArtworkId = function(key) {
        //    //$scope.key = $sce.trustAsHtml(key);

        //    console.log(key);
        //    $http.get('/home/GetSingleArtworkByKey', key)
        //        .then(function (response) {
        //            //$scope.artwork = response.data;
        //            console.log(response);
        //        });
        //}

    }
]);

