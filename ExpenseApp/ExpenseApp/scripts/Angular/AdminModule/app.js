(function () {
    'use strict';

    angular.module('AdminApp', [
        // Angular modules
        'ngAnimate',
        'ngRoute'

        // Custom modules

        // 3rd Party Modules
        
    ])
    .config(function ($routeProvider) {

        $routeProvider.when("/Admin.Dashboard", {
            controller: "Dashboard",
            templateUrl: "/Views/Admin/sub/Dashboard.html"
        });

        $routeProvider.otherwise({ redirectTo: "/Dashboard" });
    })
    .controller('mainController', ['$scope', '$location', function ($scope, $location) {

        $scope.isActive = function (route) {
            return route === $location.path();
        }

        init();

        function init() {

        }
    }])
})();
