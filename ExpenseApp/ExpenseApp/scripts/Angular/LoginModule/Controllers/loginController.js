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
        };

        // determines which control panel is shown
        lc.Type = 'L';

        lc.terms = false;

        lc.login = function (form) {
            if (form.validate()) {
                $('#btnLogin').html('<i class="fa fa-cog fa-spin fa-2x"></i>');
                loginService.login(lc.loginData.userName, lc.loginData.password).then(function (response) {

                    if (response === 500) {
                        toastr.error('Authentication failed. Invalid username or password.', 'Error!');

                    }
                    else if (response.UserID > 0) {
                        toastr.success('User Authenticated.', 'Success!');
                    }
                    lc.loginData = {
                        userName: "",
                        password: ""
                    };
                    $('#btnLogin').html('Sign In');
                });
            }
        }

        lc.registerUser = function (form) {
            if (form.validate()) {
                $('#btnresgiter').html('<i class="fa fa-cog fa-spin fa-2x"></i>');
                alert(JSON.stringify(lc.registrationData));
                loginService.register(lc.registrationData).then(
                    function (res) {
                        if (res) {
                            toastr.success('Registration Successful. Please log in to continue.', 'Success!');
                            lc.registrationData = null;
                            lc.Type = 'L';
                            $('#btnresgiter').html('Create account');
                        } else {
                            alert(JSON.stringify(res));
                        }
                    },
                    function (err) {
                        alert(err)
                    });
            }
        }

        lc.forgotPassword = function (form) {
            if (form.validate()) {
                $('#btnForgotPass').html('<i class="fa fa-cog fa-spin fa-2x"></i>');
                loginService.forgotPassword(lc.forgotEmail).then(function (res) {

                    if (res === 1) {
                        toastr.success("We have sent a link to your email with further instrustions.", "Success!")
                    } else if (res === 2) {
                        toastr.warning("The email you provided doesn't exist.")
                    } else {
                        alert(res);
                    }
                    $('#btnForgotPass').html('Recover password');

                    lc.forgotEmail = '';
                    lc.Type = 'L';
                });
            }
        }

        function init() {
            $window.sessionStorage["TokenInfo"] = null;
        }

        lc.change = function (t) {
            lc.Type = t;
        }

        init();
    };

})();