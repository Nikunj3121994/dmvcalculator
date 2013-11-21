/// dmvCalculationController

controllers.dmvCalculationController = ['$scope', '$http', 'logger', 'dmvDataFactory', 'date', '$location',
        function ($scope, $http, logger, dmvDataFactory, date, $location) {
            
            // Init
            $scope.dmvCalculation = {};
            $scope.dataLoaded = false;
            $scope.onlyNumbers = /^\d+$/;

            function init() {

                $scope.dmvCalculation.init = logger.log('DMV form initialized.');

                $scope.dmvCalculation.DateOfCalculation = date.getDateNow();
            }

            // Data fetch
            dataFetch();

            function dataFetch() {

                dmvDataFactory.getVehicleTypeCodeTable().then(function (result) {
                    init();

                    $scope.dmvCalculation.vehicleTypeCodeTable = result;

                    $scope.dmvCalculation.VehicleTypeId = $scope.dmvCalculation.vehicleTypeCodeTable[0];
                    
                    $scope.dataLoaded = true; //TODO: hack make it for all calls
                });

                dmvDataFactory.getEngineTypeCodeTable().then(function (result) {
                    $scope.dmvCalculation.engineTypeCodeTable = result;

                    $scope.dmvCalculation.EngineTypeId = $scope.dmvCalculation.engineTypeCodeTable[0];
                });

                dmvDataFactory.getFuelTypeCodeTable().then(function (result) {
                    $scope.dmvCalculation.fuelTypeCodeTable = result;
                });

                dmvDataFactory.getEuroExhaustTypeCodeTable().then(function (result) {
                    $scope.dmvCalculation.euroExhaustTypeCodeTable = result;
                });
            }

            // Actions
            actions();

            function actions() {
                $scope.processDmvCalculation = function (dmvCalculationData) {

                    if (dmvCalculationData.$valid) {

                        //Data Process
                        dmvCalculationData.VehicleTypeId = dmvCalculationData.VehicleTypeId.id;
                        dmvCalculationData.EuroExhaustTypeId = dmvCalculationData.EuroExhaustTypeId.id;
                        dmvCalculationData.EngineTypeId = dmvCalculationData.EngineTypeId.id;
                        dmvCalculationData.FuelTypeId = dmvCalculationData.FuelTypeId.id;

                        //POST data
                        dmvDataFactory.postDmvData(dmvCalculationData).then(function (result) {

                            if (result.status === 200)
                            {
                                $scope.processDmvCalculationResult = result.status;

                                $scope.returnData = result.data;

                                $scope.reset();

                                window.location = '/Dmv/DmvCalculationResult/' + result.data.DmvCalculation.Id;
                                
                            } else {
                                $scope.processDmvCalculationResult = result.status + " " + result.data.message;
                            }
                            
                        });

                    } else {
                        $scope.processDmvCalculationResult = "Not valid form.";
                    }
                };
            }

            // Cleanup
            cleanup();

            function cleanup() {
                $scope.reset = function () {
                    
                    var newDmvCalculation = {};

                    $scope.dmvCalculation = angular.copy(newDmvCalculation);

                    dataFetch();
                };
            }
        }
];



