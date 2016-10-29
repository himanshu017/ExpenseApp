(function () {
    'use strict';

    angular
        .module('appFrontEnd')
        .controller('home', home);

    home.$inject = ['$scope']; 

    function home($scope) {
        $scope.title = 'home';

        activate();

        function activate() { }
    }
})();
