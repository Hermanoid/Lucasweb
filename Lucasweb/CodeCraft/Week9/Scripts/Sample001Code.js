function testFunc() {
    document.getElementById("testFuncDemo").innerHTML = "ROBBER!!!";
    setTimeout(document.getElementById("testFuncDemo").innerHTML = "nothing to see here", 5000);
}
function whatDaWord(length) {
    coolString = "";
    console.log(String(length));
    for (i = 0; i < length; i++) {
        number = Math.round(Math.random() * 256);
        console.log(number);
        console.log(String.fromCharCode(number))
        coolString += String.fromCharCode(number);;
    }
    console.log(coolString);
    document.getElementById('RandomBox').innerHtml = coolString;
    return coolString;
}