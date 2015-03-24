angular.module('umbraco.resources').factory('teamResource',
    function ($http) {
        return {
            getSquad: function () {
            	return $http.get("backoffice/Team/Team/GetSquad");
            },
            getPlayerInfo: function (id) {
            	return $http.get("backoffice/Team/Team/GetPlayerInfo?id=" + id);
            }
        }
    }
);