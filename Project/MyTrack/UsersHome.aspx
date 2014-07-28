<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersHome.aspx.cs" Inherits="MyTrack.UsersHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="headUsers" runat="server">
    <title>Users</title>
    <link href="Scripts/jquery-ui.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.11.1.js"></script>
    <script src="Scripts/jquery-ui.min.js"></script>
    <script src="Chosen/choosen/chosen.jquery.min.js"></script>
    <link href="Chosen/choosen/chosen.min.css" rel="stylesheet" />
    <script src="jqwidgets/jqx-all.js"></script>
    <link href="jqwidgets/styles/jqx.base.css" rel="stylesheet" />
    <link href="jqwidgets/styles/jqx.metro.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css" />
    <script src="Scripts/MyTrack.js"></script>
    <link href="CSS/UserStyles.css" rel="stylesheet" />
    <link href="CSS/Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="frmUsers" runat="server">
         <div class="header">
                <h1><span class="left">
                    <img src="Images/logo.jpg" height="80" width="200" />
                </span>
                    <span class="right">Online Railway Reservation </span></h1>
            </div>
        <div id="Usertabs">
            <ul>
                <li><a href="#tabHome">Home</a></li>
                <li><a href="#tabReservations">Reservations</a></li>
                <li><a href="#tabPNR">PNR</a></li>
                <li><a href="#tabScheduling">Scheduling</a></li>
                <li id="logOut"><a href="#tabLogout">Logout</a></li>
            </ul>
            <div id="tabHome">
                <p>Welcome To MyTrack Online Reservation Portal</p>
            </div>
            <div id="tabReservations">
                <div class="Reservations-div">
                    <fieldset id="fdsSearchTrains">
                        <legend>Search Trains</legend>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="ddlFrom">
                                    From :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="rightSpan">
                                <select class="chosen ddlWidth" id="ddlFrom">
                                    <option value="Agra">Agra</option>
                                    <option value="Hyderabad">Hyderabad</option>
                                    <option value="Delhi">Delhi</option>
                                    <option value="Chennai">Chennai</option>
                                </select>
                            </span>
                        </div>
                        <asp:Label ID="lblDisplayHtml" runat="server"></asp:Label>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="ddlTo">
                                    To :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="rightSpan">
                                <select class="chosen ddlWidth" id="ddlTo">
                                    <option value="Agra">Agra</option>
                                    <option value="Hyderabad">Hyderabad</option>
                                    <option value="Delhi">Delhi</option>
                                    <option value="Chennai">Chennai</option>
                                </select>
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="datepicker">
                                    Date Of Journey :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input type="text" id="datepicker" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="ddllNoOfPassengers">
                                    Number Of Passengers :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="rightSpan">
                                <select class="ddlWidth" id="ddllNoOfPassengers">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                </select>
                            </span>
                        </div>
                        
                        <div class="middleDiv">
                            <span class="rightSpan">
                                <input type="button" id="btnSearchTrains" value="Find Trains" />
                  
                  
                            </span>
                            <asp:Button ID="btnPnr" runat="server" Text="Login" OnClick="btnPnr_Click" />
                        </div>
                    </fieldset>

                    <fieldset id="fdsShowTrains">
                        <legend>Available List of TraAvailable List of Trains</legend>               
                            <div id="TrainsGrid">
                        </div>
                        <div class="middleDiv">
                            <span class="rightSpan">&nbsp;</span>
                        </div>
                    </fieldset>

                    <fieldset id="fdsAddPassengers">
                        <legend>Add Passenger Details </legend>              
                            <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtAvailableTrain">
                                    Train :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input id="txtAvailableTrain" type="text" maxlength="40" placeholder="Train" readonly="true" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtTicketFrom">
                                    From :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input type="text" id="txtTicketFrom" readonly="true" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtTicketTo">
                                    To :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input type="text" id="txtTicketTo" readonly="true" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtDistance">
                                    Distance :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input id="txtDistance" type="text" maxlength="30" placeholder="Distance" readonly="true" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtFare">
                                    Fare :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input id="txtFare" type="text" maxlength="30" placeholder="Fare" readonly="true" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtPassengerName">
                                    Name :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input id="txtPassengerName" type="text" maxlength="30" placeholder="Name" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtAge">
                                    Age :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input id="txtAge" type="text" maxlength="3" placeholder="Age" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="rdoGender">
                                    Gender :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <span>
                                    <label>
                                        <input id="rdoMale" type="radio" name="gender" />Male</label></span>
                                <span>
                                    <label>
                                        <input id="rdoFemale" type="radio" name="gender" />Female</label></span>
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="ddlBerth">
                                    Berth :<span class="Mandatory">*</span>
                                </label>
                            </span>
                            <span class="rightSpan">
                                <select class="chosen ddlWidth" id="ddlBerth">
                                    <option value="Lower">Lower</option>
                                    <option value="Middle">Middle</option>
                                    <option value="Upper">Upper</option>
                                </select>
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtContactNumber">
                                    Contact Number :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input id="txtContactNumber" type="text" maxlength="30" placeholder="Contact Number" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="leftSpan">
                                <label for="txtEmail">
                                    Email :
                                </label>
                            </span>
                            <span class="rightSpan">
                                <input id="txtEmail" type="text" maxlength="30" placeholder="Email Id" />
                            </span>
                        </div>
                        <div class="middleDiv">
                            <span class="rightSpan"></span>
                        </div>
                        <div class="middleDiv">
                            <span class="rightSpan">
                                <input type="button" id="btnAddPassenger" value="Book Ticket" class="Button" />
                            </span>
                             <span class="rightSpan">
                                <input type="button" id="btnPrintTicket" value="Print Ticket" class="Button" />
                  
                                <input type="button" id="btnChangePlan" value="Change Plan Of Journey" class="Button" /></span></div>
                    </fieldset>
                </div>
            </div>
            <div id="tabPNR">
                <div class="middleDiv">
                    <span class="leftSpan">
                        <label for="txtPNR">
                            PNR Number :<span class="Mandatory">*</span>
                        </label>
                    </span>
                    <span class="rightSpan">
                        <input id="txtPNR" type="text" maxlength="30" placeholder="PNR Number" />
                    </span>
                </div>
                <div class="middleDiv">
                    <span class="rightSpan">
                        <input type="button" id="btnPNRStatus" value="Status" class="Button" />

                        <asp:HiddenField ID="hdnPnr" runat="server" />
                    </span>
                </div>
                <fieldset id="fdsPnrStatus">
                        <legend>Available List of Passengers</legend>
                        <div id="PnrGrid">
                        </div>
                        <div class="middleDiv">
                            <span class="rightSpan">&nbsp;</span>
                        </div>
                    </fieldset>
            </div>
            <div id="tabScheduling">
                <p>
                    Schedule Of Available Trains:
              </p>    
               </div>
            <div id="tabLogout">
                <p>LogOut</p>
            </div>
        </div>
    </form>
</body>
</html>
