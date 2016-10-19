(function () {
    'use strict';

    angular.module('ExpenseAppLogin').controller('loginController', loginController);

    loginController.$inject = ['$scope', 'LoginService', '$location', 'AuthenticationService', '$window', 'appConfig', 'toastr'];

    function loginController($scope, loginService, $location, AuthenticationService, $window, appConfig, toastr) {
        var lc = this;

        lc.loginData = {
            userName: "",
            password: ""
        };

        lc.user = '';

        lc.forgotEmail = '';

        lc.registrationData = {
            userName: "",
            password: "",
            Email: "",
            Confirmpassword:''
        };

        // determines which control panel is shown
        lc.Type = 'L';

        lc.login = function (form) {
            if (form.validate()) {
                $('#btnLogin').html('<i class="fa fa-cog fa-spin fa-2x"></i>');
                loginService.login(lc.loginData.userName, lc.loginData.password).then(function (response) {

                    if (response == 500) {
                        toastr.error('Authentication failed. Invalid username or password.', 'Error!');

                    }
                    else if (response.UserID > 0) {
                        toastr.success('User Authenticated.', 'Success!');
                    }

                    $('#btnLogin').html('Sign In');
                });
            }
        }

        lc.registrationData = function (form) {
            if (form.validate()) {
                //$('#btnLogin').html('<i class="fa fa-cog fa-spin fa-2x"></i>');
                //loginService.login(lc.loginData.userName, lc.loginData.password).then(function (response) {

                //    if (response == 500) {
                //        toastr.error('Authentication failed. Invalid username or password.', 'Error!');

                //    }
                //    else if (response.UserID > 0) {
                //        toastr.success('User Authenticated.', 'Success!');
                //    }

                //    $('#btnLogin').html('Sign In');
                //});
            }
        }
        lc.login = function (form) {
            if (form.validate()) {
                $('#btnLogin').html('<i class="fa fa-cog fa-spin fa-2x"></i>');
                loginService.login(lc.loginData.userName, lc.loginData.password).then(function (response) {

                    if (response == 500) {
                        toastr.error('Authentication failed. Invalid username or password.', 'Error!');

                    }
                    else if (response.UserID > 0) {
                        toastr.success('User Authenticated.', 'Success!');
                    }

                    $('#btnLogin').html('Sign In');
                });
            }
        }
        function init() {
            $window.sessionStorage["TokenInfo"] = null;
            //alert(JSON.stringify($window.sessionStorage["TokenInfo"]));
        }


        lc.change = function (t) {
            lc.Type = t;
        }

     

        
        init();
    };

})();