// addInventoryController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-sims")
      .controller("readInventoryController", readInventoryController);

    function readInventoryController($http) {

        var vm = this;

        vm.items = [];



        vm.errorMessage = "";
        vm.isBusy = true;
        vm.successMessage = "";


        $http.get("/api/items")
          .then(function (response) {
              // Success
              angular.copy(response.data, vm.items);
          }, function (error) {
              // Failure
              vm.errorMessage = "Failed to load data: " + error;
          })
          .finally(function () {
              vm.isBusy = false;
          });



        vm.addItem = function () {

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/items", vm.newItem)
              .then(function (response) {
                  // success

                  vm.newItem = {};
                  vm.successMessage = "Received Items";
              }, function () {
                  // failure
                  vm.errorMessage = "Failed to receive items";
              })
              .finally(function () {
                  vm.isBusy = false;
              });

        };



    }

})();