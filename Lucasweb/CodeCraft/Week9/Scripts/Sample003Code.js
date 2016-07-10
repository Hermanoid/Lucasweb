function doDatMath() {
    var item1 = document.getElementById("number1").value;
    var item2 = document.getElementById("number2").value;
    var item3 = document.getElementById("number3").value;

    console.log(item1);
    console.log(item2);
    console.log(item3);

    var result = parseInt(item1) + parseInt(item2) + parseInt(item3);

    console.log(result);
    document.write(result);
    alert(result);
}