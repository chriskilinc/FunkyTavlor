angular.module('artstoneApp')
app.controller('artstoneController', ['$scope', '$http', function ($scope, $http) {
    //$scope.open = function() {
    //    $state.go("_LoginPartial.cshtml");
    //};
    $scope.test = function() {
        console.log("Dick Bum - Test");
        $http.post("/home/Submit")
            .then(function(response) {
                console.log(response);
            });

    };

    $scope.artwork = {
        ArtworkTitle: ''
    }
    $scope.insertArtwork = function() {
        console.log("Inserting Artwork");
        $http.post('/home/Submit/')
            .then(function() {
                console.log(response);
            });
    };

    //$scope.saveArtwork = function (artwork) {
    //    console.log("DickButt");
    //    $http.post("/Home/Submit", artwork).then(function (response) {
    //        console.log(response);
    //    });
    //}

    //$scope.company = {
    //    CorporateIdentityNumber: '',
    //    ContactPersonName: '',
    //    CurrencyCode: '',
    //    InvoiceAddress1: '',
    //    InvoiceCity: '',
    //    InvoiceCountryCode: '',
    //    InvoicePostalCode: '',
    //    Name: '',
    //    TermsOfPaymentId: '',
    //}

    //$scope.saveCompany = function (company) {

    //    $http.post('/home/submit', company).then(function (response) {
    //        console.log(response)
    //    });
    //}

}]);