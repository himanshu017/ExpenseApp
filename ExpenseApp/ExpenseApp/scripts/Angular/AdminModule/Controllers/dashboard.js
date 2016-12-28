(function () {
    'use strict';

    angular
        .module('AdminApp')
        .controller('dashboard', dashboard);

    dashboard.$inject = ['$scope'];

    function dashboard($scope) {
        var dc = this;


        activate();
        function activate() { }
    }
})();
