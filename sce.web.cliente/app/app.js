var EmpApp = angular.module('myapp', ['ngRoute', 'PedControllers']);
EmpApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/lista',
        {
            templateUrl: 'Pedido/Lista.html',
            controller: 'ListController'
        }).
        when('/novo',
        {
            templateUrl: 'Pedido/Editar.html',
            controller: 'EditController'
        }).
        when('/edit/:id',
        {
            templateUrl: 'Pedido/edit.html',
            controller: 'EditController'
        }).
        when('/delete/:id',
        {
            templateUrl: 'Pedido/delete.html',
            controller: 'DeleteController'
        }).
        otherwise(
        {
            redirectTo: '/lista'
        });
}]);  