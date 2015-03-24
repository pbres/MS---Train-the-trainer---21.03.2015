angular.module('umbraco').controller('PluginsTeamController',
    function ($scope, $routeParams, teamResource, dialogService, notificationsService, navigationService) {
        $scope.loaded = false;
        $scope.tabs = [{ id: "Info", label: "Info" }];
        $scope.players = [];
        $scope.player = null;


        if ($routeParams.id == "squad") {
            teamResource.getSquad().then(function (response) {
                $scope.players = response.data;
                console.log($scope.players);
                $scope.loaded = true;
            });
           
        } else {
            teamResource.getPlayerInfo($routeParams.id).then(function (response) {
                $scope.player = response.data;
                console.log($scope.player);
                $scope.loaded = true;
            });
        }
        
    });