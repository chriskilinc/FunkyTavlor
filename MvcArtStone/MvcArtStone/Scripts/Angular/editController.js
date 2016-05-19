angular.module('artstoneApp');
app.controller('editController', ['$scope', '$http', function ($scope, $http) {

    //$scope.send = function () {
    //    $http.post('../EditArtwork/' )
    //            .then(function(response) {
    //                $scope.artwork = response.data;
    //                console.log(response);
    //            });
    //    };
   

    $scope.newArtwork = {
        Title: '',
        Artist: '',
        Room: '',
        Description:'',
        ImgurUrl: '',
        InStorage: false,
        Signed: false,
        Id: '' 
        };
    
        $scope.EditArtwork = function (newArtwork) {
            console.log("Editing Artwork");
            
            var fullUrl = window.location.href;
            var split = fullUrl.slice(-36)

            $scope.newArtwork.Id = split;
            $http.post('/home/EditArtworkByModel', newArtwork)
                .then(function (response) {
                    window.location.replace("/home/")
                    console.log("SUCCESS");
                    console.log(response);
                },
                    function (response) {
                        console.log("Failed");
                    });
                });
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

