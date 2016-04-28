function playSound(id,loc){
	document.getElementById(id).style.opacity = 0.8;
	var audio = new Audio(loc);
	audio.play();
	document.getElementById(id).style.opacity = "1";
}