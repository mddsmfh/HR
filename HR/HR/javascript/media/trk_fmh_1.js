var qufmh = '' + this.location; 
qufmh = qufmh.substring((qufmh.indexOf('?cif')) + 4);
var keyfmh = qufmh.substring(0,qufmh.indexOf('=')); 
var cifmh = qufmh.substring((qufmh.indexOf('=')) + 1);
if (keyfmh == 'mh') {
var today = new Date();
var expiry = new Date(today.getTime() + 2592000000);
document.cookie="cifmh=" + cifmh + "; expires=" + expiry.toGMTString() + "; domain=mediatemple.net; path=/";
}