/// dmvController

app.controller('dmvController', function ($scope) {

    $scope.first = "First 123";

    $http.get("api/DmvApi").success(function(data) {
        $scope.items = data;
    });

});



