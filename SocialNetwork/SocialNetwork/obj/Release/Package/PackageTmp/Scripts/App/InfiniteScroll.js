var InfiniteScrollApp = angular.module('InfiniteScrollApp', []);

function InfiniteScroll(scope)
{

}

InfiniteScrollApp.directive('InfiniteScroll', function () {
    return {
        restrict: 'A',
        templateUrl: '',
        scope: {
            dataUrl: '='
        },
        controller: InfiniteScroll(scope)
    }
})