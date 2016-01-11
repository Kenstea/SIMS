// addInventoryController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-sims")
      .controller("deleteInventoryController", deleteInventoryController);

    function deleteInventoryController($http) {

        var vm = this;

        vm.deleteItem = {};

        vm.errorMessage = "";
        vm.isBusy = false;
        vm.successMessage = "";


        vm.destroyItem = function () {

            vm.isBusy = true;
            vm.errorMessage = "";
            
            $http.put("/api/items/delete", vm.deleteItem)
              .then(function (response) {
                  // success

                  vm.newItem = {};
                  vm.successMessage = "Deleted Item";
              }, function (error) {
                  // failure
                  vm.errorMessage = "Failed to delete item";
                  console.log(error);
              })
              .finally(function () {
                  vm.isBusy = false;
              });
        };



    }

})();