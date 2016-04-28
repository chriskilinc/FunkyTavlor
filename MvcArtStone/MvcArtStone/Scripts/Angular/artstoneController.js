var app = angular.module("artstoneApp")
.controller("artstoneController", ["$http", "$scope","$state", function ($http, $scope, $state) {

        $scope.artwork =
        [
            artwork.Title =
            "A"
            //Artist: "b",
            //Room: "c",
            //Description: "d",
            //InStorage: "e",
            //CreationDate: "f",
            //AddedDate: "g",
        ];

        //$scope.open = function() {
        //    $state.go("_LoginPartial.cshtml");
        //};
        $scope.test = function() {
            console.log("Dick Bum - Test");
            $http.post("/Home/Test").then(function() {
                console.log("posted!");
            });

        }

    $scope.saveArtwork = function (artwork) {
        console.log("DickButt");
        $http.post("/Home/Submit", artwork).then(function (response) {
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