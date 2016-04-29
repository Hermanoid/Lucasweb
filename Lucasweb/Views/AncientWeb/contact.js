function sendMail(address) {
    var link = "MAILTO:"+ address
             + "?subject=" + escape("Email from the Lucasweb by " + escape(document.getElementById("contactinternalname").value))
             + "&body=" + escape(document.getElementById('contactinternalmeassage').value);

    window.location.href = link;
}