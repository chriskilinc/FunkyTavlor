angular.module('artstoneApp')
app.controller('editController', ['$scope', '$http', function ($scope, $http) {

    $scope.send = function (key) {
        console.log("ID: " + key);
        $http.post('../GetArtworkByKey/', key)
                .then(function(response) {
                    $scope.artwork = response.data;
                    console.log(response);
                });
        };

        $scope.artwork = {
            Title: '',
            Artist: '',
            Room: '',
            Description: '',
            ImgUrl: '',
        };


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

