"use strict";

(function () {

    var app = angular.module("claimsApp", []);

    app.controller('ClaimsController', ['$http', function ($http) {
        var allClaims = [];

        $http.get('/api/claimsApi').then(function (response) {
            allClaims = angular.fromJson(response.data);
        });

        this.getAllClaims = function () {
            return allClaims;
        };

        this.markClaimAsPaid = function (claim) {
            claim.paid = Date.now();
        };

        this.isPaidToHolder = function (claim) {
            return claim.paid !== null;
        };
    }]);

    app.controller('ClaimController', ['$http', function ($http) {
        this.claim = {};

        this.addClaim = function () {
            this.claim.paid = null;
            var self = this;

            var serialized = angular.toJson(this.claim);
            
            $http.post('/api/claimsApi', serialized).then(function (response) {

                // TODO: Handle invalid response in here
                self.claim = {};
            });

            this.claim = {};
        };
    }]);

    app.controller('PoliciesController', ['$http', function ($http) {

        var allPolicies = [];

        $http.get('/api/policiesApi').then(function (response) {
            allPolicies = angular.fromJson(response.data);
        });

        this.getPolicies = function () {
            return allPolicies;
        };
    }]);
})();

