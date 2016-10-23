(function () {
    'use strict';
    angular.module('ExpenseAppLogin').service('LoginService', ['$http', '$q', 'AuthenticationService', 'authData', 'appConfig',
    function ($http, $q, authenticationService, authData, appConfig) {
        var userInfo;
        var loginServiceURL = appConfig.localUrl;
        var deviceInfo = [];
        var deferred;

        this.login = function (userName, password) {
            deferred = $q.defer();
            var data = "grant_type=password&username=" + userName + "&password=" + password;
            $http.post(loginServiceURL + 'token', data, {
                headers:
                   {
                       'Content-Type': 'application/x-www-form-urlencoded'
                   }
            }).success(function (response) {
                var o = response;
                userInfo = {
                    accessToken: response.access_token,
                    userName: response.userName,
                    role: response.role,
                    userID: response.UserID,
                    userTypeID: response.UserTypeID
                };
                authenticationService.setTokenInfo(userInfo);
                authData.authenticationData.IsAuthenticated = true;
                authData.authenticationData.userName = response.userName;
                deferred.resolve(response);
            })
            .error(function (err, status, headers, config) {
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
                deferred.resolve(status);
            });
            return deferred.promise;
        }

        this.logOut = function () {
            authenticationService.removeToken();
            authData.authenticationData.IsAuthenticated = false;
            authData.authenticationData.userName = "";
        }

        this.register = function (data) {
            deferred = $q.defer();
            $http.post(loginServiceURL + 'Account/RegisterUser', JSON.stringify({ objUser: data })).success(function (response) {
                deferred.resolve(response);
            })
            .error(function (err, status, headers, config) {
                deferred.resolve(status);
            });
            return deferred.promise;
        }

        this.forgotPassword = function (email) {
            deferred = $q.defer();
            $http.post(loginServiceURL + 'Account/ForgotPassword', JSON.stringify({ email: email })).success(function (response) {
                deferred.resolve(response);
            })
            .error(function (err, status, headers, config) {
                deferred.resolve(status);
            });
            return deferred.promise;
        }
    }
    ]);
})();