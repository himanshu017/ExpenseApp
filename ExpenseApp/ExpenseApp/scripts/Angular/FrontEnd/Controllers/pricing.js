(function () {
    'use strict';

    angular
        .module('appFrontEnd')
        .controller('pricing', pricing);

    pricing.$inject = ['$scope']; 

    function pricing($scope) {
        $scope.title = 'pricing';

        activate();

        function activate() { }
    }
})();
