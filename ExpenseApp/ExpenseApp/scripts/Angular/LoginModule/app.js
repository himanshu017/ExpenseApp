(function () {
    'use strict';

    angular.module('ExpenseAppLogin', [
        // Angular modules
        //'ngAnimate',
        'ngRoute',
        'LocalStorageModule',
        'toastr',
        'ngValidate'

        // Custom modules
    ])

    .constant("appConfig", {
        "localUrl": "http://localhost:62160/",
        //"liveUrl": "http://localhost:62160/"
    })
    
    .config(['$httpProvider', 'toastrConfig', '$validatorProvider', function ($httpProvider, toastrConfig, $validatorProvider) {

        //Defaults for tostr notifications
        angular.extend(toastrConfig, {
            autoDismiss: true,
            closeButton: true,
            containerId: 'toast-container',
            maxOpened: 0,
            newestOnTop: true,
            positionClass: 'toast-top-right',
            preventDuplicates: false,
            preventOpenDuplicates: false,
            target: 'body'
        });

        //Defaults for valiation
        $validatorProvider.setDefaults({
            errorElement: 'span',
            errorClass: 'help-block help-block-error',
            focusInvalid: true,
            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },
            unhighlight: function (element) { // revert the change done by hightlight
                $(element)
                    .closest('.form-group').removeClass('has-error'); // set error class to the control group
            }
        });

        //Http intercepters for Authentication
        $httpProvider.interceptors.push(function ($q, $rootScope, $window, $location) {
             return {
                 request: function (config) {
                     return config;
                 },
                 requestError: function (rejection) {
                     return $q.reject(rejection);
                 },
                 response: function (response) {
                     if (response.status == "401") {
                         $location.path('/Login');
                     }
                     //the same response/modified/or a new one need to be returned.
                     return response;
                 },
                 responseError: function (rejection) {
                     if (rejection.status == "401") {
                         $location.path('/Login');
                     }
                     return $q.reject(rejection);
                 }
             };
        });

     }]);
})();
