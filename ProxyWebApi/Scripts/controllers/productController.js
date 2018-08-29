var prodApp = angular.module("prodApp");

prodApp.controller("productController", ['$scope', '$http', function ($scope, $http) {

    $scope.pageCount = 10;
    $scope.currentPage = 1;
    $scope.products = [];

    $scope.init = function() {
        $scope.getStatistic();
    };

    $scope.getNextPage = function() {
        $scope.currentPage++;
    };

    $scope.getPrevPage = function () {
        $scope.currentPage--;
    };

    $scope.$watch('currentPage', function (newValue) {
        $scope.getProductsPage(newValue);
    });

    $scope.getProductsPage = function (page) {
        $http({
                method: 'get', url: '/api/products/products',
                params: {
                    skip: (page - 1) * $scope.pageCount,
                    count: $scope.pageCount
                }
            })
            .then(function (response) {
                $scope.products = response.data;
                console.log("products:" + response.data);
            });
    };
    $scope.getStatistic = function () {
        $http({
            method: 'get', url: '/api/products/Statistic'
            })
            .then(function (response) {
                $scope.statistic = response.data;
                $scope.totalPages = Math.round($scope.statistic.Count / $scope.pageCount);

                console.log("products:" + response.data);
            });
    };

}]);