<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintTicket.aspx.cs" Inherits="MyTrack.Ticket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Ticket</title>
    <link href="CSS/UserStyles.css" rel="stylesheet" />

</head>
<body oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="80%" align="center" border="0">
            <tbody>
                <tr>
                    <td>
                        <div id="printTicketBorder1">

                            <table width="700px" align="center" border="0" cellpadding="2" cellspacing="0">

                                <tbody>
                                    <tr>
                                        <td width="100%">
                                            <table width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td width="15%" align="left">
                                                            <img src="../Images/MyTrack.jpg" alt="MyTrack" hspace="10" /></td>
                                                        <td class="styleWL" valign="middle" width="10%" align="right">&nbsp;</td>
                                                        <td width="50%" align="center"><span style="font: bold 15px arial;"><u>MyTrack Online Ticketing</u><br>
                                                            <u>E-Ticket&nbsp;</u></span></td>
                                                        <td class="styleWL" valign="middle" width="10%" align="left">&nbsp;</td>
                                                        <td width="15%" align="center">
                                                            <div style="width: 75px; height: 48px; text-align: right; float: right">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td colspan="5" width="100%">
                                            <table width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt" align="justify">
                                                            <ul>


                                                                <li><b>This ticket will only be valid along with an ID proof in original. If found travelling without ID Proof,Passenger will be <b>treated as without ticket and charged as per extant Railway rules.</b></b></li>
                                                                <li><b>Valid IDs to be presented during train journey by
 one of the passenger booked on an e-ticket .</b></li>
                                                            </ul>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="5">
                                            <table class="tablebdr" style="margin-top: 0px;" width="100%" border="0" cellpadding="2" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt"><b>&nbsp;PNR No:&nbsp;<asp:Label runat="server" ID="lblPnr"></asp:Label></b></td>
                                                        <td class="txt">&nbsp;Train Name:&nbsp;<asp:Label runat="server" ID="lblDispTrainName"></asp:Label>


                                                        </td>
                                                        <td class="txt">&nbsp;Train Number:&nbsp;<asp:Label runat="server" ID="lblTrainId"></asp:Label></td>
                                                    </tr>

                                                    <tr>
                                                        <td class="txt">&nbsp; ID:&nbsp;<asp:Label runat="server" ID="lblTransactionId"></asp:Label></td>
                                                        <td class="txt">&nbsp;Date of Booking:&nbsp;<asp:Label runat="server" ID="lblDateOfBooking"></asp:Label></td>
                                                        <td class="txt">&nbsp;Class:&nbsp;<asp:Label runat="server" ID="lblClass"></asp:Label></td>
                                                    </tr>

                                                    <tr>
                                                        <td class="txt">&nbsp;From:&nbsp;<asp:Label runat="server" ID="lblFrom"></asp:Label></td>
                                                        <td class="txt">&nbsp;Date of Journey:&nbsp;<asp:Label runat="server" ID="lblDoj"></asp:Label></td>
                                                        <td class="txt">&nbsp;To:&nbsp;<asp:Label runat="server" ID="lblTo"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txt">&nbsp;Boarding:&nbsp;<asp:Label runat="server" ID="lblFromNew"></asp:Label></td>
                                                        <td class="txt">&nbsp;Date&nbsp;of&nbsp;Boarding:&nbsp;<asp:Label runat="server" ID="lblDojNew"></asp:Label>
                                                        </td>




                                                        <td class="txt">&nbsp;Scheduled Departure:&nbsp;14:25&nbsp;
           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txt">&nbsp;Resv Upto:&nbsp;<asp:Label runat="server" ID="lblToNew"></asp:Label>
                                                        </td>
                                                        <td class="txt">&nbsp;Distance:&nbsp;<asp:Label runat="server" ID="lblDistance"></asp:Label></td>
                                                        <td class="txt">&nbsp;Passengers:&nbsp;
                                                            <asp:Label runat="server" ID="lblNoOfPassengers"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txt">&nbsp;Passenger Mobile Number:&nbsp;<asp:Label runat="server" ID="lblMobile"></asp:Label></td>
                                                        <td colspan="2" class="txt">&nbsp;&nbsp;
                                                        </td>
                                                    </tr>


                                                    <tr>
                                                        <td class="txt" colspan="3">&nbsp;<b>Passenger Email&nbsp;:-</b>&nbsp;<asp:Label runat="server" ID="lblEmailId"></asp:Label></td>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>



                                    <tr>
                                        <td colspan="5" width="100%">
                                            <table style="margin-top: 0px;" width="100%" border="0" cellpadding="2" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt"><b>FARE DETAILS :</b></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <table class="tablebdr" width="100%" border="0" cellpadding="2" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt">&nbsp;&nbsp;1</td>
                                                        <td class="txt">&nbsp;&nbsp;Ticket&nbsp;Fare</td>
                                                        <td class="txt" align="right">Rs.&nbsp;<asp:Label runat="server" ID="lblFare"></asp:Label>&nbsp;
                                                        </td>

                                                    </tr>

                                                </tbody>
                                            </table>

                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="5" width="100%">
                                            <table style="margin-top: 0px;" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt"><b>PASSENGER DETAILS :</b></td>
                                                    </tr>
                                                </tbody>
                                            </table>

                                            <table class="tablebdr" width="100%" border="0" cellpadding="2" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt" width="5%">&nbsp;SNo.</td>
                                                        <td class="txt" width="22%">&nbsp;Name</td>
                                                        <td class="txt" wisth="5%">&nbsp;Age</td>
                                                        <td class="txt" width="6%">&nbsp;Sex</td>
                                                        <td class="txt" width="25%">&nbsp;Seat Number</td>

                                                    </tr>

                                                    <tr>
                                                        <td class="txt" width="5%">&nbsp;1</td>
                                                        <td class="txt" width="22%">
                                                            <asp:Label runat="server" ID="lblNameNew"></asp:Label></td>
                                                        <td class="txt" width="5%">&nbsp;<asp:Label runat="server" ID="lblAgeNew"></asp:Label></td>
                                                        <td class="txt" width="6%">&nbsp;<asp:Label runat="server" ID="lblGender"></asp:Label></td>
                                                        <td class="txt" width="25%">&nbsp;<asp:Label runat="server" ID="lblSeatNumber"></asp:Label>

                                                        </td>

                                                    </tr>
                                                </tbody>
                                            </table>




                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" width="100%">
                                            <b><u><span style="font-size: 12px; font-family: arial">This 
ticket is to be shown whenever asked by our Authorities.OtherWise which,My Track may reserve rights to take criminal charges.</span></u></b>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td colspan="5" width="100%">
                                            <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" OnClick="btnSendMail_Click" />
                                        <!-- td with colspan 5 -->
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
        <br>
    </form>
</body>
</html>
