/// helperModule

var helperModule = angular.module('helperModule', [])
    .value('logger', {
        log: function (data) {
            console.log(data);
            return data;
        }
    })
    .value('date', {
        getDateNow: function () {
            var now = new Date();
            var yy = now.getFullYear().toString();
            var m = (now.getMonth() + 1).toString(); // getMonth() is zero-based
            var d = now.getDate().toString();
            var todayDate = m + "-" + d + "-" + yy;
            return todayDate;
        }
    });