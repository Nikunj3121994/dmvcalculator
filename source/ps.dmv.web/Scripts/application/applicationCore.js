/// applicationCore

// Global init
var app = angular.module('dmvApp', ['helperModule', 'ngRoute']);

// Core controllers
var controllers = {};
app.controller(controllers);

// Core factories
var factories = {};
app.factory(factories);

// Configuration DmvFormLite
app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider
        .when('/Calculator',
            {
                controller: 'dmvCalculationController',
                templateUrl: 'dmv/DmvForm'
            }
        )
        .when('/CalculatorLite',
            {
                controller: 'dmvCalculationController',
                templateUrl: 'dmv/DmvFormLite'
            }
        )
        .when('/DmvCalculationResult',
            {
                controller: 'dmvCalculationController',
                templateUrl: 'dmv/DmvCalculationResult'
            }
        )
        .otherwise({
            redirectTo: '/CalculatorLite'
        });
  }]);






