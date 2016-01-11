// addInventoryController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-sims")
      .controller("updateInventoryController", updateInventoryController);

    function updateInventoryController($http) {

        var vm = this;

       

        vm.editItem = {};

        vm.errorMessage = "";
        vm.isBusy = false;
        vm.successMessage = "";
       

        

        vm.updateItem = function () {

            vm.isBusy = true;
            vm.errorMessage = "";


            $http.put("/api/items", vm.editItem)
              .then(function (response) {
                  // success

                  vm.successMessage = "Edited Item";
              }, function () {
                  // failure
                  vm.errorMessage = "Failed to edit item";
              })
              .finally(function () {
                  vm.isBusy = false;
              });

        };



    }

})();