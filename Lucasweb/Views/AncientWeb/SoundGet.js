
function FileHelper(path)
{
    console.log(path);
    var brain = new FileReader(path);
    console.log(brain.readAsText());
    var oReq = new XMLHttpRequest()
    something = oReq.open("GET", path);
    console.log(oReq);
    console.log(oReq.response())
}





function getSounds(){
	$("#soundwebGetSoundA").attr("href","");
	$("#soundwebGetSoundImg").attr("onclick","getPath()");
	$("#soundwebGetSoundDirections").html("Please wait until the file completes downloading and then push the button again.");
	setTimeout(function(){/* Look mah! No code!*/},500);
	
}

function getPath(){
	$("#soundwebGetSoundDirections").html("Now, find the file in the file browser. Then, copy the path at the top of the browser-box.  Paste the <u>path</u> alone into the text-enter-box without changing it at all. Then, click the button again.");
	$("#soundwebGetSoundImg").attr("onclick","readPath()");
	$("#soundwebGetSoundPathInput").css("opacity", 1);
	$("#soundwebGetSoundPathText").css("opacity", 1);
	setTimeout(function(){/* Look mah! No code!*/},500);
}

function readPath(){
	$("#soundwebGetSoundDirections").html("loading...");
	$("#soundwebGetSoundImg").attr("onclick","");
	setTimeout(function(){/* Look mah! No code!*/},500);
	console.log($("#soundwebGetSoundPathInput").val());
	console.log($("#soundwebGetSoundPathText").val());
	
	var text = FileHelper("file:\\\\\\"+ $("#soundwebGetSoundPathText").val() + "\\" + $("#soundwebGetSoundPathInput").val());
	
	console.log(text);
	
	
}
