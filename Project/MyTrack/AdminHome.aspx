<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="MyTrack.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.11.1.js"></script>
    <script src="Scripts/jquery-ui.min.js"></script>
    <link href="Scripts/jquery-ui.min.css" rel="stylesheet" />
    <script src="Chosen/choosen/chosen.jquery.min.js"></script>
    <link href="Chosen/choosen/chosen.min.css" rel="stylesheet" />
    <script src="jqwidgets/jqx-all.js"></script>
    <link href="jqwidgets/styles/jqx.base.css" rel="stylesheet" />
    <link href="jqwidgets/styles/jqx.metro.css" rel="stylesheet" />
    <script src="Scripts/AdminScript.js"></script>
    <link href="CSS/AdminStyles.css" rel="stylesheet" />
    <link href="CSS/Styles.css" rel="stylesheet" />
</head>
<body oncontextmenu="return false">
    <form id="form1" runat="server">
        <div class="header">
            <h1><span class="left">
                <img src="Images/logo.jpg" height="80" width="200" />
            </span>
                <span class="right">Online Railway Reservation </span></h1>
        </div>
        <div>
            <div id="tabs">
                <ul>
                    <li><a href="#TrainDetails">Trains</a></li>
                    <li><a href="#FareDetails">Fares</a></li>
                    <li><a href="#TrainSchedule">Schedule</a></li>
                    <li id="list"><a href="#Logout">Logout</a></li>

                </ul>
                <div id="TrainDetails">
                    <span class="LeftSpan">
                        <label for="txtTrainNumber" hidden="hidden">
                            Train Number :<span class="Mandatory">*</span>
                        </label>
                    </span>
                    <span class="RightSpan">
                        <input id="txtTrainNumber" type="text" maxlength="5" placeholder="Train Number" hidden="hidden" />
                    </span>
                    <div class="LeftDiv">
                        <div class="FirstInner">
                            <span class="LeftSpan">
                                <label for="txtTrainName">
                                    Train Name :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="RightSpan">
                                <input id="txtTrainName" type="text" maxlength="30" placeholder="Train Name" />
                            </span>
                        </div>
                        <div class="SecondInner">
                            <span class="LeftSpan">
                                <label for="txtSource">
                                    Source :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="RightSpan">
                                <input id="txtSource" type="text" maxlength="30" placeholder="Source" />
                            </span>
                        </div>
                        <div class="ThirdInner">
                            <span class="LeftSpan">
                                <label for="txtArrivalTime">
                                    Arrival Time :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="RightSpan">
                                <input id="txtArrivalTime" type="text" maxlength="30" placeholder="ArrivalTime" />
                            </span>
                        </div>
                    </div>

                    <div class="RightDiv">
                        <div class="FirstInner">
                            <span class="LeftSpan">
                                <label for="txtDistance">
                                    Distance :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="RightSpan">
                                <input id="txtDistance" type="text" maxlength="30" placeholder="Distance" />
                            </span>
                        </div>
                        <div class="SecondInner">
                            <span class="LeftSpan">
                                <label for="txtDestiantion">
                                    Destination :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="RightSpan">
                                <input id="txtDestination" type="text" maxlength="30" placeholder="Destination" />
                            </span>
                        </div>
                        <div class="ThirdInner">
                            <span class="LeftSpan">
                                <label for="txtDepartureTime">
                                    Departure Time :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="RightSpan">
                                <input id="txtDepartureTime" type="text" maxlength="30" placeholder="ArrivalTime" />
                            </span>
                        </div>
                    </div>

                    <div class="Buttons">

                        <span>
                            <input id="btnSubmitTrain" type="button" value="Submit" />
                            <input id="btnClear" type="button" value="Clear" />
                        </span>
                    </div>
                        <div id="TrainsDetailsGrid">
                    </div>
                  
                </div>
                <div id="FareDetails">
                    <div id="Fare">
                        <div class="ControlDiv">
                            <span class="LeftSpan">
                                <label for="ddlFareDetails">
                                    Train Name :<span class="Mandatory">*</span>
                                </label>
                            </span>

                            <span class="rightSpan">
                                <select class="chosen" id="ddlFareDetails" style="width: 200px; height:30px;">

                                    <option value="-1">select Train</option>
                                </select>
                            </span>

                        </div>
                        <div class="ControlDiv">
                            <span class="LeftSpan">
                                <label for="txtFare">
                                    Fare :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="RightSpan">
                                <input id="txtFare" type="text" maxlength="30" placeholder="Fare" />
                            </span>
                        </div>
                        <div class="FareButtons">
                            <span class="ButtonSpan">
                                <input id="btnSubmitFare" type="button" value="Submit" />
                            </span>
                            <span class="ButtonSpan">
                                <input id="btnClearFare" type="button" value="Clear" />
                            </span>
                        </div>
                    </div>
                </div>
                <div id="TrainSchedule">
                    <div id="TrainScheduleGrid">
                    </div>
                </div>


            </div>
        </div>

    </form>
</body>
</html>
