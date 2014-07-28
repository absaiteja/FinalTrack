<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyTrack.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <script src="Scripts/jquery-1.11.1.js"></script>
    <script src="Scripts/jquery-ui.min.js"></script>
    <link href="Scripts/jquery-ui.min.css" rel="stylesheet" />
    <script src="Scripts/MyScript.js"></script>
    <script src="Scripts/AdminScript.js"></script>
    <link href="CSS/Styles.css" rel="stylesheet" />
    <link href="Scripts/generic.css" rel="stylesheet" />
    <link href="Scripts/js-image-slider.css" rel="stylesheet" />
    <script src="Scripts/js-image-slider.js"></script>
    <link href="CSS/LoginStyles.css" rel="stylesheet" />
    
</head>
<body oncontextmenu="return false">
    <div>
        <form id="form1" runat="server">
            <div class="header">
                <h1><span class="left">
                    <img src="Images/logo.jpg" height="80" width="200" />
                </span>
                    <span class="right">Online Railway Reservation </span></h1>
            </div>
            <div class="tabs">
                <ul>
                    <li><a href="#Home" id="btnHome">Home</a></li>
                    <li><a href="#admin" id="btnadmin">Login</a></li>
                    <li><a href="#Registration" id="btnregistration">Registration </a></li>
                    <li class="Contact" style="float: right"><a href="#Contact" id="btnContact">Contact Us </a></li>
                </ul>
                <div id="Home">
                    <div class="Text">
                        <marquee>Hai Welcome To My Track </marquee>
                    </div>
                    <div id="sliderFrame">
                        <div id="slider" style="height: 400px">
                            <img src="Images/kbjj.JPG" />
                            <img src="Images/images%20(22).jpg" />
                            <img src="Images/images%20(2).jpg" />
                            <img src="Images/images%20(17).jpg" />
                            <img src="Images/images%20(10).jpg" />
                            <img src="Images/gugi.jpg" />
                        </div>
                    </div>
                </div>
                <div id="admin">
                    <div id="loginform">
                        <div class="heading">
                            Login 
                        </div>
                        <div class="body">
                            <span>
                                <label id="lblName">
                                    Email ID :
                                      
                                </label>
                            </span>
                            <span>
                               <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your Email Id"></asp:TextBox>
                            </span>
                        </div>
                        <div class="body">
                            <span>
                                <label id="lblPassword">Password :</label>
                            </span>
                            <span>
                                <input type="password" id="txtPassword" placeholder="Enter Your Password" />
                            </span>
                        </div>
                        <div class ="Password">
                            <a href="#forgot">Forgot Password  </a>
                        </div>
                        <div class="button">
                            <asp:HiddenField ID="hdnValue" runat="server" />
                            <span>
                               <input type ="button" value ="Login" id="btnSubmit" />
                               
                            </span>
                        </div>
                    </div>
                </div>
                <div id="forgot">
                    <div id="loginForm">
                        <div class="body">
                            <span>
                                <label id="lblFEmail">
                                    Email ID :
                                </label>
                            </span>
                            <span>
                                <input type="text" id="txtFmail" placeholder="Enter your Email Id" />
                            </span>
                        </div>
                        <div class="button">
                            <span>
                                <input type="button" value="submit" id="btnFSubmit" />
                            </span>
                        </div>
                    </div>
                </div>
                <div id="Registration">
                    <div class="main-container">
                        <div class="first-row">
                            <label id="lblFirstName">
                                User Name :
                            </label>
                            <span style="color: red">*
                            </span>
                        </div>
                        <div class="second-row">
                            <input type="text" id="txtFirstName" />
                        </div>
                        <div class="first-row">
                            <label id="txtGender">Gender :</label>
                            <span style="color: red">*
                            </span>
                        </div>
                        <div class="second-row">
                            <span>
                                <input type="radio" id="rdoMale" name="rdoGender" />
                                <label for="rdoMale">Male</label>
                            </span>
                            <span>
                                <input type="radio" id="rdoFemale" name="rdoGender" />
                                <label for="rdoFemale">Female</label>
                            </span>
                        </div>
                        <div class="first-row">
                            <label id="lblContactNumber">Contact Number :</label>
                            <span style="color: red">*
                            </span>
                        </div>
                        <div class="second-row">
                            <input type="text" id="txtContactNumber" />
                        </div>
                        <div class="first-row">
                            <label id="lblUserName">Email ID  :</label>
                            <span style="color: red">*
                            </span>
                        </div>
                        <div class="second-row">
                            <input type="text" id="txtUserName" />
                        </div>
                        <div class="first-row">
                            <label id="lblRPassword">
                                Password :
                            </label>
                            <span style="color: red">*
                            </span>
                        </div>
                        <div class="second-row">
                            <input type="password" id="txtRPassword" />
                        </div>
                        <div class="first-row">
                            <label id="lblConfirmPassword">
                                Confirm Password :
                            </label>
                            <span style="color: red">*
                            </span>
                        </div>
                        <div class="second-row">
                            <input type="password" id="txtConfirmPassword" />
                        </div>
                        <div class="bottom-row">
                            <span>
                                <input type="button" id="btnRsubmit" value="Submit" />
                            </span>
                            <span>
                                <input type="button" id="btnClear" value="Clear" />
                            </span>
                        </div>
                    </div>
                </div>
                <div id="Contact">
                    <div>
                        Customer Care No. <span style="color: red">040-23340000</span>
                        Fax no.<span style="color: red">040-23345400</span>
                        Chennai Customer Care No. <span style="color: red">040-25300000</span>

                        For Railway tickets booked through My Track
                        General Information
                        I-tickets/e-tickets:<span style="color: red">care@mytrack.co.in</span>
                        <p class="para">
                            Registered Office / Corporate Office :
                        My Track Corporation Ltd.,
                        5th Floor, White House Building,
                        Begumpet,Hyderabad 500072.
                        Tel: 040-23311263/23311264
                        Fax: 040-23311259
                        </p>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
