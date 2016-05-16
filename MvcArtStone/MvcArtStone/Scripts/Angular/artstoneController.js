angular.module('artstoneApp')
app.controller('artstoneController', ['$scope', '$http', function ($scope, $http) {
    //$scope.open = function() {
    //    $state.go("_LoginPartial.cshtml");
    //};
    $scope.test = function () {
        console.log("Dick Bum - Test");
        $http.post("/home/Submit")
            .then(function (response) {
                console.log(response);
            });

    }

    $scope.artwork = {
        Title: '',
        Artist: '',
        File: []
    }
    
    $scope.file_changed = function (element) {

        $scope.$apply(function (scope) {
            var photofile = element.files[0];
            var reader = new FileReader();
            reader.onload = function (e) {
                // handle onload
               
                $scope.artwork.File.push(photofile);
                

                ////Sets the Old Image to new New Image
                //$('#photo-id').attr('src', e.target.result);

                ////Create a canvas and draw image on Client Side to get the byte[] equivalent
                //var canvas = document.createElement("canvas");
                //var imageElement = document.createElement("img");

                //imageElement.setAttribute('src', e.target.result);
                //canvas.width = imageElement.width;
                //canvas.height = imageElement.height;
                //var context = canvas.getContext("2d");
                //context.drawImage(imageElement, 0, 0);
                //var base64Image = canvas.toDataURL("image/jpeg");

                ////Removes the Data Type Prefix 
                ////And set the view model to the new value
                //$scope.data.photo = base64Image.replace(/data:image\/jpeg;base64,/g, '');
            };
            console.log(photofile);
            reader.readAsDataURL(photofile);
        });
    };

    $scope.insertArtwork = function (artwork) {
        console.log("Inserting Artwork");
        var x = $scope.artwork.File;
        console.log(x);
       
        $http.post('/home/InsertArtwork', $scope.artwork, function(response) {
            console.log("SUCCESS");
            console.log(response);
        }, function(response) {
            console.log("Failed");
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