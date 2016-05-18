angular.module('editApp')
app.controller('editController', ['$scope', '$http', '$sce', function ($scope, $http, $sce) {

    $scope.artwork = {
        Title: '',
        Artist: '',
        Room: '',
        Description: '',
        InStorage: true,
        ImgUrl: '',
    };



    //$scope.key = $sce.trustAsHtml(key);

    $scope.fetchArtworkId = function(key) {
        //$scope.key = $sce.trustAsHtml(key);
        
        console.log(key);
        $http.get('/home/GetSingleArtworkByKey', key)
            .then(function (response) {
                //$scope.artwork = response.data;
                console.log(response);
            });
    }

}
]);

