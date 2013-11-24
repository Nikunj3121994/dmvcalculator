/// dmvDataFactory

//TODO factories.dmvDataFactory = ['$http', '$q', function ($http, $q) {

app.factory('dmvDataFactory', ['$http', '$q', 'logger',
    function ($http, $q, logger) {

    // Init
    var dataFactory = {};

    // Data definition

    // GET
    get();

    function get() {
        dataFactory.getVehicleTypeCodeTable = function () {
            var deferred = $q.defer();
            $http.get("api/ApiCodeTable?codeTableType=VehicleType").success(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        };

        dataFactory.getEngineTypeCodeTable = function () {
            var deferred = $q.defer();
            $http.get("api/ApiCodeTable?codeTableType=EngineType").success(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        };

        dataFactory.getFuelTypeCodeTable = function () {
            var deferred = $q.defer();
            $http.get("api/ApiCodeTable?codeTableType=FuelType").success(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        };

        dataFactory.getEuroExhaustTypeCodeTable = function () {
            var deferred = $q.defer();
            $http.get("api/ApiCodeTable?codeTableType=EuroExhaustType").success(function (data) {
                deferred.resolve(data);
            });
            return deferred.promise;
        };
    }

    // POST
    post();

    function post() {
        dataFactory.postDmvData = function (dvmData) {
            
            var deferred = $q.defer();
            var result = {};

            //var dataW = JSON.stringify(dvmData);

            //$.ajax({
            //    type: "POST",
            //    url: "api/ApiDmvCalculation",
            //    data: dataW,
            //    success: function (data, textStatus, jqXHR) {
            //        console.log("DMV calulation succes: " + textStatus);

            //        result.data = data;
            //        result.status = textStatus;

            //        deferred.resolve(result);
            //    }
            //});

            $http.post("api/ApiDmvCalculation", dvmData)
                .success(function (data, status, headers, config) {
                    console.log("DMV calulation succes: " + status);
                    
                    result.data = data;
                    result.status = status;

                    deferred.resolve(result);
                })
                .error(function (data, status, headers, config) {
                    console.log("DMV calculation failed: " + data.exceptionMessage);

                    result.status = status;
                    result.data = data;

                    deferred.resolve(result);
                });
            
            return deferred.promise;
        };
    }

    return dataFactory;
}
]);
