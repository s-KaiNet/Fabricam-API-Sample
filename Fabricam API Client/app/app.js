(function(){
	'use strict';
	
	angular.module('fabricam.api.client', ['AdalAngular', 'ngRoute', 'officeuifabric.components'])
	.config(config);

	config.$inject = [
		'$httpProvider',
		'adalAuthenticationServiceProvider',
		'$routeProvider'];
	function config($httpProvider, adalProvider, $routeProvider) {

		$routeProvider
				.when('/', {
					controller: 'homeCtrl',
					templateUrl: 'main.html',
					requireADLogin: true
				})
				.otherwise({
					redirectTo: '/'
				});

		adalProvider.init(
			{
				clientId: '1a9d8dfd-787a-49b1-86a3-b813afd14b11',
				extraQueryParameter: 'nux=1',
				endpoints: {
					'https://graph.microsoft.com': 'https://graph.microsoft.com',
					'https://fabricam-api.azurewebsites.net/api': '4125f3f1-410d-41f0-9f5e-18d9ff21560d',
					'https://fabricam-api-custom-auth.azurewebsites.net/api': '50896c9f-242c-42de-a114-448130c3b481'
				}
			},
			$httpProvider
		);
	}
})();