(function () {
    'use strict';

    angular
        .module('appFrontEnd')
        .controller('contact', contact);

    contact.$inject = ['$scope']; 

    function contact($scope) {
        $scope.title = 'contact';

        activate();

        function activate() { }
    }
})();
