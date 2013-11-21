/// customDirectives

// Date picker
app.directive('jqdatepicker', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            element.datepicker({
                dateFormat: 'm-d-yy',
                onSelect: function (date) {
                    scope.dmvCalculation.DateOfCalculation = date; //TODO: do it in generic way!
                    scope.$apply();
                }
            });
        }
    };
});