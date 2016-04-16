angular.module('artstoneApp')
.controller('artstoneController', ['$http', '$scope', function ($http, $scope) {

    $scope.artwork = {
        Title: '',
        Artist: '',
        Room: '',
        Description: '',
        InStorage: '',
        CreationDate: '',
        AddedDate: '',
    }

    $scope.saveArtwork = function (artwork) {
        $http.post('/home/submit', artwork).then(function (response) {
            console.log(response);
        });
    }

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