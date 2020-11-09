nilexTicket.controller("nilexTicketController", function ($scope, nilexTicketService) {
    $scope.attendance = {
        value: true       
    };

    //UPDATE SETTINGS
    $scope.UpdateSettings = function () {
        var stObject = {
            Username: $scope.Username,
            FullName: $scope.FullName,
            Password: $scope.Password,           
            Mail: $scope.Mail,
            ID: $scope.id
        };
        var stObj = nilexTicketService.updateSettings(stObject);
        stObj.then(function (response) {
           // $('#studentModal').modal('hide');
        }, function (error) {

        })
    }
});