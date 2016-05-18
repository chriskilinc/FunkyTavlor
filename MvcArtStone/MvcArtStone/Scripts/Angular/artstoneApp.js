var app = angular.module('artstoneApp', []);

//function artstoneController($scope) {
//    artstoneController.prototype.$scope = $scope;
//}

//artstoneController.prototype.setFile = function (element) {
//    var $scope = this.$scope;
//    $scope.$apply(function () {
//        $scope.artwork.Files = element.files[0];
//    });
//};
//app.directive("fileread",
//[
//    function () {
//        return {
//            scope: {
//                fileread: "="
//            },
//            link: function (scope, element, attributes) {
//                element.bind("change",
//                    function (changeEvent) {
//                        var reader = new FileReader();
//                        reader.onload = function (loadEvent) {
//                            scope.$apply(function () {
//                                scope.fileread = loadEvent.target.result;
//                            });
//                        }
//                        reader.readAsDataURL(changeEvent.target.files[0]);
//                    });
//            }
//        }
//    }
//]);