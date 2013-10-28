/// dmvController

app.controller('dmvController', function ($scope, $http) {

    $scope.first = "First 123";

    $http.get("api/DmvApi").success(function(data) {
        $scope.items = data;
    });

});



