// addInventoryController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-sims")
      .controller("addInventoryController", addInventoryController);

    function addInventoryController($http) {

        var vm = this;
        
        vm.newItem = {};

        vm.errorMessage = "";
        vm.isBusy = false;
        vm.successMessage = "";
        

        vm.addItem = function () {

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/items", vm.newItem)
              .then(function (response) {
                  // success
                  
                  vm.newItem = {};
                  vm.successMessage = "Saved Item";
              }, function () {
                  // failure
                  vm.errorMessage = "Failed to save new item";
              })
              .finally(function () {
                  vm.isBusy = false;
              });

        };



    }

})();