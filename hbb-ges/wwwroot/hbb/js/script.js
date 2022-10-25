$(document).ready(function() {
	
	var user_agent = navigator.userAgent.toLowerCase();
	var mobile = false;
	if ((/up.browser|up.link|mmp|symbian|smartphone|midp|wap|vodafone|o2|pocket|kindle|mobile|pda|psp|treo|blackberry|opera mini|android|iphone|ipod|ipad/.test(user_agent))) {	mobile = true;}
	
	if (mobile) {		
	}
	else{	
	  	$('#clouds1').pan({fps: 30, speed: 2.5, dir: 'left', depth: 10});	  	
	}


}); //
$(window).load(function() {
	//

}); //