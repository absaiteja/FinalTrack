$(document).ready(function () {
    $('input[type = button]').button();
    $('.tabs').tabs();
    $("#forgot").dialog({
        autoOpen: false,
        title:'Forgot Password',
        draggable: false,
        resizable: false,
        modal: true,
        width: 400,
        dialogClass: 'no-close',
        buttons: {
            "Clear": ClearAll
        }
    })
    function ClearAll() {
        $('#txtFmail').val("");
    }
    $(".Password a").click(function () {
        $("#forgot").dialog("open");
        $('#txtFmail').val($('#txtEmail').val());
    });
    $('#btnFSubmit').click(function () {
        var object = JSON.stringify({ "EmailID": [$('#txtFmail').val()] });
        ajaxCaller("TrainDetailsService.asmx/GetPassword", object, SuccessMail, FailureCallBack);
    });
    function SuccessMail(data) {
        if (data.d == true) 
        {
            alert("Password Has Been Sent To your Email");
            $("#forgot").dialog("close");
        }
    }
    function SuccessCallBack(data) {
        if (data.d == true) {
            $(location).attr('href', 'UsersHome.aspx');
        }
        else
            alert("Please Enter Correct Password");
    }
    function FailureCallBack(XHR, msg, exception) {
        debugger;
        alert(msg);
    }
    $('#txtEmail').blur(function(){
       
        if ($('#txtEmail').val() == '') {
            alert("Please Enter EmailId");
            return false;
        }
    })
    $('#txtPassword').blur(function () {

        if ($('#txtPassword').val() == '') {
            alert("Please Enter Password");
            return false;
        }
    })
    $('#btnSubmit').click(function () {
        if ($('#txtEmail').val() == '') {
            alert("Please Enter EmailId");
            return false;
        }
        if ($('#txtPassword').val() == '') {
            alert("Please Enter Password");
            return false;
        }
        if (($('#txtEmail').val() == "admin") && ($('#txtPassword').val() == "admin")) {
            $(location).attr('href', 'AdminHome.aspx');
        }
        else {
            var object = JSON.stringify({ "objGetTrainDetails": [$('#txtEmail').val(), $('#txtPassword').val()] });
            ajaxCaller("UsersService.asmx/GetUserSDetails", object, SuccessLogin, FailureCallBack);
        }
    })
    function ajaxCaller(url, dataToSend, SuccessCallBack, FailureCallBack) {
        $.ajax({
            url: url,
            async: true,
            type: 'POST',
            data: dataToSend,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: SuccessCallBack,
            error: FailureCallBack
        })
    }
    function SuccessLogin(data) {
        if (data.d == true) {
            $(location).attr('href', 'UsersHome.aspx');
        }
    }
    $('#btnRsubmit').click(function () {
        var x = 0;
        var UserName = $('#txtFirstName').val();
        var Numbers = /^[789]\d{9}$/;
        var CharactersOnly = /^[A-Za-z]+$/;
        var ContactNumber = $('#txtContactNumber').val();
        var EmailId = $('#txtUserName').val();
        var Password = $('#txtRPassword').val();
        var ConfirmPassword = $('#txtConfirmPassword').val();
        var EmailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;
        if (UserName == '' && ContactNumber == '' && EmailId == '' && Password == '' && ConfirmPassword == '') {
            alert('All fields are mandatory');
            return false;
        } 
        if (UserName == '') {
            alert("Please Enter UserName");
            $('#txtFirstName').focus();
            return false;
        }
        if (UserName != '') {
            if (!UserName.match(CharactersOnly)) {
                alert("Enter Characters Only");
                return false;
            }
        }
        if ($('#rdoMale').checked && $('#rdoFemale').checked) {
            alert("Please Select Gender");
            return false;
        }
      
        if (ContactNumber == '') {
            alert("Please Enter ContactNumber");
            $('#txtContactNumber').focus();
            return false;
        }
        if (ContactNumber != '') {
            if (!ContactNumber.match(Numbers) && ContactNumber.length != 10) {
                alert("Please Give valid Contact Number");
                return false;
            }
        }
        if(EmailId==''){
            alert("Please Enter EmailId");
            $('#txtUserName').focus();
            return false;
        }
        if (EmailId != '')
        {
            if (!EmailId.match(EmailExp))
            {
                alert("Invalid Email Id");
                return false;
            }
        }
        if (Password == '')
        {
            alert("Please Enter Password");
            $('#txtRPassword').focus();
            return false;
        }
        if (Password != '' && ConfirmPassword == '')
        {
            alert("Please enter Confirm Password");
            $('#txtConfirmPassword').focus();
            return false;
        }
        if (Password != ConfirmPassword) {
            alert("Password not match");
            return false;
        }
        else {
           
            var object = JSON.stringify({ "obj": [$('#txtFirstName').val(), $('#txtContactNumber').val(), $('#txtUserName').val(), $('#txtRPassword').val(), "Male"] });
            ajaxCaller("UsersService.asmx/CreateService", object, SuccessRegistration, FailureCallBack);
            return true;
        }
        function SuccessRegistration(data) {
            if (data.d == true) {
                alert("Successfully Added");
            }
        }
    })
    $('#ddlSelector').change(function () {
        var trainname = JSON.stringify({ strEmailId: $('#ddlSelector').val() });
        ajaxCallerFare("FaresService.asmx/GetFareService", trainname, SuccessFare, FailureCallBack);
    })
    function ajaxCallerFare(url, dataToSend, SuccessFare, FailureCallBack) {
        debugger;
        $.ajax({
            url: url,
            async: true,
            type: 'POST',
            data: dataToSend,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: SuccessCallBack,
            error: FailureCallBack
        })
    }
    function SuccessFare(data) {
        $('#txtFare').val(data.d.Fare);
    }
});
