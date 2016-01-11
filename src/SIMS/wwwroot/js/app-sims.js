// app-sims.js
(function () {

    "use strict";

    // Creating the Module
    angular.module("app-sims", ["simpleControls", "ngRoute"])
      .config(function ($routeProvider) {

          $routeProvider.when("/Add", {
              controller: "addInventoryController",
              controllerAs: "vm",
              templateUrl: "/views/addInventoryView.html"
          });

          $routeProvider.when("/Delete", {
              controller: "deleteInventoryController",
              controllerAs: "vm",
              templateUrl: "/views/deleteInventoryView.html"
          });

          $routeProvider.when("/Update", {
              controller: "updateInventoryController",
              controllerAs: "vm",
              templateUrl: "/views/updateInventoryView.html"
          });

          $routeProvider.when("/Forecast", {
              controller: "readInventoryController",
              controllerAs: "vm",
              templateUrl: "/views/readInventoryView.html"
          });

          $routeProvider.otherwise({ redirectTo: "/Forecast" });

      });

})();