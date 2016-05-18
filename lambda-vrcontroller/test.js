//var socket = require('socket.io-client')('https://alexa-vrcontroller.azurewebsites.net', { forceNew: true });
var socket = require('socket.io-client')('wss://alexa-vrcontroller.azurewebsites.net');

socket.on('connect', function(){
	console.log('connected ');
	socket.emit('add user', 'alexa');
});
socket.on('login', function(data){
	console.log('login');
	socket.emit('new message', 'gym2');
	socket.emit('disconnect');
	socket.disconnect();
});
socket.on('open', function(data){
	console.log(data);
});
socket.on('new message', function(data){
	console.log(data);
});

socket.on('user joined', function(data){
	console.log(data);
	socket.emit('new message', 'hi ' + data.username + ' from alexa');
});
socket.on('disconnect', function(){});
