var PedControllers = angular.module("PedControllers", []);

PedControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('http://localhost:53062/api/pedido/').then(function (response) {
            $scope.pedidos = response.data;
        });
    }
]);
 
PedControllers.controller("PedidoController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        
        $scope.delete = function () {
            $http.delete('/api/Pedido/' + $scope.id).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "Ocorreu um erro ao excluir pedido! " + data;
            });
        };
    }
]);
  
PedControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        
        $http.get("http://localhost:53062/api/produto/").then(function (response) {
            $scope.produtos = response.data;

            $scope.itens = [{}];
            $scope.adicionaItem = function () {
                $scope.itens.push({                    
                    codigo: $scope.selectedItem.ProdutoID,
                    descricao: $scope.selectedItem.Descricao,                    
                    quantidade: $scope.Quantidade,
                    preco: $scope.selectedItem.Preco
                });
                $scope.Quantidade = $scope.selectedItem.Preco = '';
            };

            $scope.deletaItem = function (codigo) {
                var index = -1;
                var comArr = eval($scope.itens);
                for (var i = 0; i < comArr.length; i++) {
                    if (comArr[i].codigo === codigo) {
                        index = i;
                        break;
                    }
                }
                if (index === -1) {
                    alert("Algo deu errado");
                }
                $scope.itens.splice(index, 1);
            };

        });
        
        $scope.save = function () {
            var obj = {
                PedidoID: $scope.PedidoID,
                DataPedido: $scope.DataPedido,
                CPF: $scope.CPF,
                Nome: $scope.Nome,
                CEP: $scope.CEP,
                Endereco: $scope.Endereco,
                ListaItens: $scope.itens
            };
            if (!$routeParams.id) {
                $http.post('http://localhost:53062/api/pedido/', obj).success(function (data) {
                    $location.path('/lista');
                }).error(function (data) {
                    $scope.error = "Ocorreu um erro ao adicionar um pedido! " + data.ExceptionMessage;
                });
            }
            else {
                $http.put('http://localhost:53062/api/pedido/', obj).success(function (data) {
                    $location.path('/lista');
                }).error(function (data) {
                    console.log(data);
                    $scope.error = "Ocorreu um erro ao salvar o pedido! " + data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.PedidoID = $routeParams.id;
            $scope.title = "Editar Pedido";
            $http.get('http://localhost:53062/api/pedido/' + $routeParams.id).success(function (data) {
                $scope.PedidoID = data.PedidoID;
                $scope.DataPedido = new Date(data.DataPedido);
                $scope.CPF = data.CPF;
                $scope.Nome = data.Nome;
                $scope.CEP = data.CEP;
                $scope.Endereco = data.Endereco;
                $scope.ListaItens = data.ListaItens;
            });
        }
        else {
            $scope.title = "Novo Pedido";
        }
    }
]);  