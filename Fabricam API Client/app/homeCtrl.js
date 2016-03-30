(function(){
	'use strict';
	homeCtrl.$inject = ['$scope', 'adalAuthenticationService', '$http', '$window'];
	
	//var endpoint = 'https://fabricam-api.azurewebsites.net/api';
	var endpoint = 'https://fabricam-api-custom-auth.azurewebsites.net/api';
	
	function homeCtrl($scope, adal, $http, $window) {
		var that = this;
		this.$http = $http;
		this.$window = $window;
		this.$scope = $scope;
		
		if(this.isIframe()) return;
		
		if (!adal.userInfo.isAuthenticated) {
			$scope.$on('adal:loginSuccess', function () {
				that.onInit();
			});
		} else {
			that.onInit();
		}
		
		this.$scope.createTask = function(){
			if(!that.$scope.newTaskText) return;
		
			that.$http.post(endpoint + '/tasks', JSON.stringify({ text: that.$scope.newTaskText }), {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
			.then(function(){
				that.$scope.newTaskText = '';
				that.getTasks();
			});
		}
		
		this.$scope.deleteTask = function(index){
			that.$http.delete(endpoint + '/tasks/' + index)
			.then(function(){
				that.$scope.newTaskText = '';
				that.getTasks();
			});
		}
	}
	
	homeCtrl.prototype.onInit = function () {
		console.log("Init");
		this.getTasks();
	}
	
	homeCtrl.prototype.getTasks = function () {
		var that = this;
		this.$http.get(endpoint + '/tasks')
		.then(function(result){
			console.log(result);
			that.$scope.tasks = result.data;
		});
	}
	
	homeCtrl.prototype.isIframe = function () {
		try {
			return this.$window.self !== this.$window.top;
		} catch (e) {
			return true;
		}
	}
	
	angular.module('fabricam.api.client')
		.controller('homeCtrl', homeCtrl);
})();