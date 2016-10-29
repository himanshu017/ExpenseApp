(function () {
    'use strict';

    angular
        .module('appFrontEnd')
        .controller('about', about);

    about.$inject = ['$scope']; 

    function about($scope) {
        $scope.title = 'about';

        activate();

        function activate() { }
    }
})();
