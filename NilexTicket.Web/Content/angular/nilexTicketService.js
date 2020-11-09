nilexTicket.service("nilexTicketService", function ($http) {
    //UPDATE SETTINGS
    this.updateSettings = function (stObject) {        
        var response = $http({
            method: 'POST',
            url: 'User/Settings',
            data: JSON.stringify(stObject),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });
        return response;
    } 
});