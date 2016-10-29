(function () {
    'use strict';

    angular.module('appFrontEnd', [
        // Angular modules
        'ngAnimate',
        'ngRoute'

        // Custom modules

        // 3rd Party Modules

    ])
    .config(function ($routeProvider) {

        $routeProvider.when("/Home", {
            controller: "home",
            templateUrl: "/Views/FrontEnd/home.html"
        });

        $routeProvider.when("/About", {
            controller: "about",
            templateUrl: "/Views/FrontEnd/AboutUs.html"
        });

        $routeProvider.when("/Contact", {
            controller: "contact",
            templateUrl: "/views/FrontEnd/Contact.html"
        });

        $routeProvider.when("/Pricing", {
            controller: "pricing",
            templateUrl: "/views/FrontEnd/Pricing.html"
        });

        $routeProvider.otherwise({ redirectTo: "/Home" });
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
