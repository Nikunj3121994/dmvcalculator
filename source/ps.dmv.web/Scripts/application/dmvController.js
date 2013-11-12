/// dmvController

app.controller('dmvController', function ($scope, $http) {

    $scope.first = "First 123";

    $http.get("api/ApiCodeTable?codeTableType=VehicleType").success(function (data) {
        $scope.vehicleTypeCodeTable = data;
    });
    
    $http.get("api/ApiCodeTable?codeTableType=EngineType").success(function (data) {
        $scope.engineTypeCodeTable = data;
    });
    
    $http.get("api/ApiCodeTable?codeTableType=FuelType").success(function (data) {
        $scope.fuelTypeCodeTable = data;
    });
    
    $http.get("api/ApiCodeTable?codeTableType=EuroExhaustType").success(function (data) {
        $scope.euroExhaustTypeCodeTable = data;
    });

});



