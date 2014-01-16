
var ajaxCall = function ajaxData(methodname, aThing) {

    $.ajax({
        type: "POST",
        url: "default.aspx/" + methodname,
        data: JSON.stringify(aThing),
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json"
    })
        .done(function (msg) {
            if (msg.d.TransactionResult === 1) {
                //document.location = "http://www.google.com"; 
                window.location = msg.d.TargetUrl; 
                //window.open("http://www.google.com");
                return false;
            }
            else {
                alert(msg.d.Message);
            }
        })
        .fail(function (msg, jqXHR, textStatus) {
            alert("Request failed: " + textStatus + msg.d.TransactionResult);
        })
};

//Method and click event for user logon 

var logonuser = function () {
    var message = "";
    var aUser = {};
    aUser.UsrID = d3.select("input#username").node().value;
    aUser.UsrPassword = d3.select("input#password").node().value;
    var User = { 'aUser': aUser };
    var status = ajaxCall("userLogon", User);
    return false; 
}

//Method and click event for registering 

var register = function () {

    var aFan = {};
    aFan.FanID = d3.select("input#emailsignup").node().value;
    aFan.FanEmail = d3.select("input#emailsignup").node().value;
    aFan.FanPassword = d3.select("input#passwordsignup").node().value;
    var Fan = { 'aFan': aFan };
    ajaxCall('fanRegister', Fan);
}

var registerClick = d3.select("input#btnRegister")
                .on("click", register);

var exposeLogin = function () {
    d3.select("div#registerform").style("display", "none");
    d3.select("div#loginform").style("display", "block");
};

var exposeRegister = function () {
    d3.select("div#loginform").style("display", "none");
    d3.select("div#registerform").style("display", "block");
};

var logonuserClick = d3.select("input#btnUsrLogon")
                .on("click", logonuser);

var toregister = d3.select("a#toregister")
                .on("click", exposeRegister);
var tologin = d3.select("a#tologin")
                .on("click", exposeLogin);