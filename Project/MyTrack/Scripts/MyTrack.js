$(document).ready(PageLoad);
function PageLoad() {
    var varBtnBuyClicked=false;
    var varCountPassengers = 0;
    $("#btnAddPassenger").val("Add Passenger");
    $('#btnPrintTicket').hide();
    $('#fdsShowTrains').hide();
    $('#fdsAddPassengers').hide();
    $('#logOut').on("click", function () {
        $(location).attr('href', "Home.aspx");
    });
    $(function () {
        $("#Usertabs").tabs();
    });
    $(".chosen").data("placeholder", "Select Station...").chosen({ width: 210 });
    $(function () {
        $("#datepicker").datepicker();
    });
    //GetAllTrains();
    //CreateTrain();
    
     $('#TrainsGrid').jqxGrid({
        width: '70%',
        height: '300px',
        columns: [
        { text: 'Train Number', datafield: 'TrainNumber', width: 80, hidden: true },
        { text: 'Train', datafield: 'TrainName', width: 100 },
        { text: 'From', datafield: 'Source', width: 100 },
        { text: 'To', datafield: 'Destination', width: 100 },
        { text: 'Distance', datafield: 'Distance', width: 60 },
        { text: 'Arrival Time', datafield: 'ArrivalTime', width: 100, hidden: true },
        { text: 'Departure Time', datafield: 'DepartureTime', width: 100, hidden: true },
        {
            text: 'Select Train', datafield: 'Edit', columntype: 'button', width: 100, cellsrenderer: function () {
                return "Select";
            }, buttonclick: function (row) {
                editrowindex = row;
                var varTrainName = $("#TrainsGrid").jqxGrid('getcellvalue', row, "TrainName");
                var varSource = $("#TrainsGrid").jqxGrid('getcellvalue', row, "Source");
                var varDestination = $("#TrainsGrid").jqxGrid('getcellvalue', row, "Destination");
                var varDistance = $("#TrainsGrid").jqxGrid('getcellvalue', row, "Distance");
                $('#txtAvailableTrain').val(varTrainName);
                $('#txtDistance').val(varDistance);
                $('#txtTicketFrom').val(varSource);
                $('#txtTicketTo').val(varDestination);
                $('#txtFare').val("1000");
                $('#fdsAddPassengers').show();
                $('#fdsAddPassengers').focus();
                //window.location = '/Customers/Edit/?id=' + id;
            }
        }
        ],
        theme: 'metro',
        sortable: true,
        pageable: true,
        source: null
     });

     $('#PnrGrid').jqxGrid({
         width: '70%',
         height: '300px',
         columns: [
         { text: 'PNR Number', datafield: 'PNRNumber', width: 80, hidden: true },
         { text: 'Name', datafield: 'Name', width: 150 },
         { text: 'Age', datafield: 'Age', width: 150 },
         { text: 'Gender', datafield: 'Gender', width: 100, hidden: true },
         { text: 'Berth Preference', datafield: 'BerthPreference', width: 60, hidden: true },
         { text: 'Seat Number', datafield: 'SeatNumber', width: 150 }
        ],
         theme: 'metro',
         sortable: true,
         pageable: true,
         source: null
     });

     BindTrains();
        $("#btnSearchTrains").click(function () {
        $('#fdsShowTrains').show();
        $('#fdsShowTrains').focus();
    });
    $("#btnChangePlan").click(function () {
        $('#fdsShowTrains').hide();
        $('#fdsAddPassengers').hide();
    });
    
    $("#btnAddPassenger").click(function () {
 	var ddllNoOfPassengersVal = $('#ddllNoOfPassengers').find('option:selected');
        var ddllNoOfPassengersText = ddllNoOfPassengersVal.text();
        CreatePassenger();
        varCountPassengers = varCountPassengers + 1;
        if(varCountPassengers == ddllNoOfPassengersText) {
            $("#btnAddPassenger").val("Buy Ticket");
            $('#btnPrintTicket').show();
            varBtnBuyClicked=true;
          }
    });
    if (varBtnBuyClicked == true) {
        CreateTicket();
    }
    $('#btnPrintTicket').click(function () {
        PrintTicket();
    });
    AjaxCallForDDL('UsersHome.aspx?GetTrains=true', 'POST', BindTrains, FailureCallOnBindTrainDrop);
}

function BindTrains(data) {
    var TrainDetails = JSON.parse(data);
    BindDropDown("#ddlFrom", TrainDetails, "Source", "TrainNumber");
}

function FailureCallOnBindTrainDrop(xhr, msg, exception) {
    alert(msg);
}
function AjaxCallForDDL(url, callType, successCall, FailureCallBack) {
    $.ajax({
        url: url,
        type: callType,
        async: true,
        success: successCall,
        error: FailureCallBack
    });
}

    function BindDropDown(selector, data, dataMember, valueMember) {
        $(selector).empty();
        for (var obj in data) {
            $(selector).append("<option value = " + data[obj][valueMember] + ">" + data[obj][dataMember] + "</option>")
        }
        $(selector).trigger("chosen:updated");
    }

    function PrintTicket() {
        var url = "PrintTicket.aspx";
        $(location).attr('href', url);
    }




    //function GetAllTrains() {
    //    ajaxCaller("UsersTrainDetailsService.asmx/GetSpecificTrainsbyFromToService", "{}", SuccessCallOnSpecificTrain, FailureCallOnSpecificTrain);
    //      }

    //function CreateTrain() {
    //    ajaxCaller("UsersTrainDetailsService.asmx/CreateTrainService", "{}", SuccessCallOnCreateTrain, FailureCallOnCreateTrain);
    //}

    function CreateTicket() {
        debugger
        //var varPnr = (Math.floor(Math.random() * 90000) + 10000).toString();
        var varTrainName = $('#txtAvailableTrain').val();
        var varPnr = $('#hdnPnr').val();
        var ddlFromVal = $('#ddlFrom').find('option:selected');
        var ddlFromText = ddlFromVal.text();
        var ddlToVal = $('#ddlTo').find('option:selected');
        var ddlToText = ddlToVal.text();
        var dateJourneyDate = $('#datepicker').val();
        var date = new Date(dateJourneyDate);
        var dateFormattedJourneyDate = date.getFullYear() + "-" + date.getMonth() + "-" + date.getDate();
        var currDate = new Date();
        var dateFormattedCurrDate = currDate.getFullYear() + "-" + currDate.getMonth() + "-" + currDate.getDate();
        var ddllNoOfPassengersVal = $('#ddllNoOfPassengers').find('option:selected');
        var ddllNoOfPassengersText = ddllNoOfPassengersVal.text();
        var varClass = "2A";
        var varDistance = 200;
        var varEmailId = $('#txtEmail').val();
        var varArrivalTime = "12:00";
        var varDepartureTime = "16:00";
        var varFare = "1000";
        var varTransactionId = 1;
        var objTicket = JSON.stringify({
            "obj": [varTrainName,varPnr, ddlFromText, ddlToText, dateFormattedJourneyDate, dateFormattedCurrDate, varClass, varDistance, ddllNoOfPassengersText, varEmailId,
                varArrivalTime, varDepartureTime,varTransactionId, varFare]
        });
        ajaxCaller("UsersTrainDetailsService.asmx/CreateTicketService", objTicket, SuccessCallOnCreateTicket, FailureCallOnCreateTicket);
    };
    function CreatePassenger() {
        var varPnr = $('#hdnPnr').val();
        var varName = $('#txtPassengerName').val();
        var varAge = $('#txtAge').val();
        var varGender = $("input[name='gender']:checked").val();
        var ddlBerthVal = $('#ddlBerth').find('option:selected');
        var ddlBerthText = ddlBerthVal.text();
        var count = 110;
        var varSeatNo = count + 1;
        var objPassenger = JSON.stringify({
            "objPs": [varPnr, varName, varAge, varGender, ddlBerthText, varSeatNo]
        });
        ajaxCaller("UsersTrainDetailsService.asmx/CreatePassengerService", objPassenger, SuccessCallOnCreatePassenger, FailureCallOnCreatePassenger);
        ClearAllFields();
    };

    function ClearAllFields() {
        $('#txtPassengerName').val("");
        $('#txtAge').val("");
        $("#ddlBerth").attr('selectedIndex', '-1').find("option:selected").removeAttr("selected");
        //$('#ddlBerth').text("Select Berth");
    }

    function BindTrains() {
        var objData = JSON.stringify({});
        ajaxCaller("UsersTrainDetailsService.asmx/GetAllTrainsService", objData, SuccessCallOnBindTrains, FailureCallOnBindTrains);
    } 

    function SuccessCallOnBindTrains(data) {
        var Trains = data.d;
        var source = {
            datatype: 'json',
            datafields: [
                { name: 'TrainNumber', type: 'int' },
                { name: 'TrainName', type: 'string' },
                { name: 'Source', type: 'string' },
                { name: 'Destination', type: 'string' },
                { name: 'Distance', type: 'int' },
                 { name: 'ArrivalTime', type: 'string' },
                { name: 'DepartureTime', type: 'string' }
            ],
            id: 'TrainNumber',
            localData: Trains
        };
        var dataAdapter = new $.jqx.dataAdapter(source);
        $('#TrainsGrid').jqxGrid('source', dataAdapter);
    }

    function FailureCallOnBindTrains(xhr, msg, exception) {
        alert(msg);
    }
    function BindPnrs() {
        var objData = JSON.stringify({});
        ajaxCaller("UsersTrainDetailsService.asmx/GetAllTrainsService", objData, SuccessCallOnBindPnrs, FailureCallOnBindPnrs);
    }
    function SuccessCallOnBindPnrs(data) {
        var Pnrs = data.d;
        var source = {
            datatype: 'json',
            datafields: [
                { name: 'PNRNumber', type: 'string' },
                { name: 'Name', type: 'string' },
                { name: 'Age', type: 'int' },
                { name: 'Gender', type: 'string' },
                { name: 'BerthPreference', type: 'string' },
                 { name: 'SeatNumber', type: 'int' }
               ],
            id: 'PNRNumber',
            localData: Pnrs
        };
        var dataAdapter = new $.jqx.dataAdapter(source);
        $('#PnrGrid').jqxGrid('source', dataAdapter);
    }
    function FailureCallOnBindPnrs(xhr, msg, exception) {
        alert(msg);
    }
   function SuccessCallOnCreateTicket(Response) {
        alert(Response.d.Message);
   }
   function SuccessCallOnCreatePassenger(Response) {
       alert(Response.d.Message);
   }
   function FailureCallOnCreateTicket(Response) {
       alert(Response.d.Message);
   }
   
   function FailureCallOnCreatePassenger(Response) {
        alert(Response.d.Message);
    }

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
        });
    }




