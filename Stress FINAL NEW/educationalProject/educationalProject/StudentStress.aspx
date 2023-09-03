<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterpage.Master" AutoEventWireup="true" CodeBehind="StudentStress.aspx.cs" Inherits="educationalProject.StudentStress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    <!-- Start contact Area -->  
    <div id="about" class="about-area area-padding">
   <div class="container">
      <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
          <div class="section-headline text-center">
            <h2>Stress Prediction - Enter Parameters</h2>
          </div>
        </div>
      </div>
      <div class="row">
        <!-- single-well start-->
       
        <!-- single-well end-->
        <div class="col-md-6 col-sm-6 col-xs-12">
          <div class="well-middle">
            <div class="single-well">
              
                <h4 class="sec-head">Student Parameters</h4>
                <table style="width:100%;">
                    <tr>
                        <td>
                            <p>
                                Enter Gender</p>
                        </td>
                        <td>
                            <p>
                                Enter Financial_Issues</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Value="1">male</asp:ListItem>
                                <asp:ListItem Value="2">female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem Value="0">no</asp:ListItem>
                                <asp:ListItem Value="1">yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>
                                Gender: 1- male , 2 - female</h6>
                        </td>
                        <td>
                            <h6>
                                Financial_Issues: 0- No , 1 - Yes</h6>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" Visible="False">
                                <p> 
                                                                  
                                                                   
                                    <asp:CheckBox ID="FIRadioButton6" runat="server" GroupName="b" 
                                        Text="Are you involved in high uncontrolled spending ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton7" runat="server" GroupName="b" 
                                        Text="Do you use instant loan app/credit card ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton8" runat="server" GroupName="b" 
                                        Text="Do you track your expenditure?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton9" runat="server" GroupName="b" 
                                        Text="Do you track your expenditure?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton10" runat="server" GroupName="b" 
                                        Text="are you able to afford the college fee ?" />
                                </p>
                                <p>
                                    &nbsp;</p>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>
                                Enter Family_Issues</p>
                        </td>
                        <td>
                            <p>
                                Enter Study_Hours</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                                <asp:ListItem Value="0">no</asp:ListItem>
                                <asp:ListItem Value="1">yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList4" runat="server">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>&gt;4</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>
                                Family_Issues: 0- No , 1 - Yes</h6>
                        </td>
                        <td>
                            <h6>
                                Study_Hours: Numeric 1,2,3 ....</h6>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server" Visible="False">
                                <p>
                                    <asp:CheckBox ID="FIRadioButton1" runat="server" GroupName="a" 
                                        Text="Do you stay alone away from your family ?" />
                                    &nbsp;</p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton2" runat="server" GroupName="a" 
                                        Text="Do you face sibling bullying/jealousy/fighting issues ?" />
                                    &nbsp;</p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton3" runat="server" GroupName="a" 
                                        Text="Do you have Any dependents on you ?" />
                                    &nbsp;</p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton4" runat="server" GroupName="a" 
                                        Text="Did you learn of the death of relatives or closed ones ?" />
                                    &nbsp;</p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton5" runat="server" GroupName="a" 
                                        Text="Do you have any family dysfunction issues like parents arguing/ divorce or separation ?" />
                                </p>
                            </asp:Panel>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <p>
                                Enter Teaching_Method</p>
                        </td>
                        <td>
                            <p>
                                Enter Health_Issues</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList5_SelectedIndexChanged">
                                <asp:ListItem Value="1">fair</asp:ListItem>
                                <asp:ListItem Value="2">not good</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList6_SelectedIndexChanged">
                                <asp:ListItem Value="0">no</asp:ListItem>
                                <asp:ListItem Value="1">yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>
                                Teaching_Method: 1- Fair / 2- Not Good.</h6>
                        </td>
                        <td>
                            <h6>
                                Health_Issues: 0- No , 1 - Yes</h6>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel4" runat="server" Visible="False">
                                <p>
                                    <asp:CheckBox ID="FIRadioButton11" runat="server" GroupName="c" 
                                        Text="Do you have difficulty in concentrating?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton12" runat="server" GroupName="c" 
                                        Text="Do you have too many distractions ?	" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton13" runat="server" GroupName="c" 
                                        Text="Do you enjoy the subject you're studying ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton14" runat="server" GroupName="c" 
                                        Text="Do you lack motivation to study ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton15" runat="server" GroupName="c" 
                                        Text="Do you have difficulty remembering facts and figures ?" />
                                </p>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="Panel5" runat="server" Visible="False">
                                <p>
                                    <asp:CheckBox ID="FIRadioButton16" runat="server" GroupName="d" 
                                        Text="are you or anyone in your family affected by Covid-19 ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton17" runat="server" GroupName="d" 
                                        Text="Do you have any chronic diseases ?" />
                                </p>
                                <p>
                                    &nbsp;</p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton18" runat="server" GroupName="d" 
                                        Text="Are you addicted to any kind of drugs/alcohol/smoking ?" />
                                </p>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <p>
                                Enter Partiality_Fix</p>
                        </td>
                        <td>
                            <p>
                                Enter Exam_Schedule</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList7_SelectedIndexChanged">
                                <asp:ListItem Value="0">no</asp:ListItem>
                                <asp:ListItem Value="1">yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList8" runat="server">
                                <asp:ListItem Value="1">Monthly</asp:ListItem>
                                <asp:ListItem Value="2">Half</asp:ListItem>
                                <asp:ListItem Value="3">yearly</asp:ListItem>
                                <asp:ListItem Value="4">Annual</asp:ListItem>
                                <asp:ListItem Value="5">Slip Test</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>
                                Partiality_Fix: 0- No , 1 - Yes</h6>
                        </td>
                        <td>
                            <h6>
                                Exam_Schedule: 1-Monthly/ 2-Half/ 3-yearly/ 4-Annual/ 5-Slip Test/</h6>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel6" runat="server" Visible="False">
                                <p>
                                    <asp:CheckBox ID="FIRadioButton19" runat="server" GroupName="e" 
                                        Text="Does your lecturer show favoritism ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton20" runat="server" GroupName="e" 
                                        Text="Does your parents show partiality between you and your siblings ?" />
                                </p>
                            </asp:Panel>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <p>
                                Enter Friends_Issue</p>
                        </td>
                        <td>
                            <p>
                                Enter Pressure</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownList9" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList9_SelectedIndexChanged">
                                <asp:ListItem Value="0">no</asp:ListItem>
                                <asp:ListItem Value="1">yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList10_SelectedIndexChanged">
                                <asp:ListItem Value="0">no</asp:ListItem>
                                <asp:ListItem Value="1">yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>
                                Friends_Issue: 0- No , 1 - Yes</h6>
                        </td>
                        <td>
                            <h6>
                                Pressure: 0- No , 1 - Yes</h6>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel7" runat="server" Visible="False">
                                <p>
                                    <asp:CheckBox ID="FIRadioButton21" runat="server" GroupName="f" 
                                        Text="do you face bullying ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton22" runat="server" GroupName="f" 
                                        Text="Are you involved in toxic friendship ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton23" runat="server" GroupName="f" 
                                        Text="Are you facing social exclusion or left out feeling among your friends ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton24" runat="server" GroupName="f" 
                                        Text="Are you facing any harassment issues ?" />
                                </p>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="Panel8" runat="server" Visible="False">
                                <p>
                                    <asp:CheckBox ID="FIRadioButton25" runat="server" GroupName="g" 
                                        Text="Are you experiencing perceived parental pressure ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton26" runat="server" GroupName="g" 
                                        Text="Are you experiencing negative peer pressure ?" />
                                </p>
                                <p>
                                    <asp:CheckBox ID="FIRadioButton27" runat="server" GroupName="g" 
                                        Text="are you able to cope up with your academic pressure?" />
                                </p>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>
                                Enter Regular</p>
                        </td>
                        <td>
                            <p>
                                Enter Interaction</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownList11" runat="server">
                                <asp:ListItem Value="1">no</asp:ListItem>
                                <asp:ListItem Value="2">yes</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList12" runat="server">
                                <asp:ListItem Value="1">Excellent</asp:ListItem>
                                <asp:ListItem Value="2">Good</asp:ListItem>
                                <asp:ListItem Value="3">Average</asp:ListItem>
                                <asp:ListItem Value="4">Poor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>
                                Regular: 1- No , 2 - Yes</h6>
                        </td>
                        <td>
                            <h6>
                                Interaction: 1- Excellent , 2 - Good, 3 - Average, 4 - Poor</h6>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
             
              
             

               

                <br />

     <div>           
    <asp:Button ID="btnSubmit" runat="server" Text="Predict Stress Level" 
             ValidationGroup="a" onclick="btnSubmit_Click" Height="50px" 
              />
               <br />
               <br />
                <h4>Outcome: 0 - Normal, 1 - 25% Stress Level, 2 - 50% Stress level, 3 - 100% Stress Level</h4>
         <br />
         <asp:Label ID="lblResult" runat="server"></asp:Label>
               <br />
         <br />
         <h1>Solution Recommendation</h1>
         <p>
             <asp:Label ID="Label1" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label2" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label3" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label4" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label5" runat="server"></asp:Label>
         </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Label6" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label7" runat="server"></asp:Label>
         </p>
                <p>
                    <asp:Label ID="Label8" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label9" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label10" runat="server"></asp:Label>
         </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Label11" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label12" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label13" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label14" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label15" runat="server"></asp:Label>
         </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Label16" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label17" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label18" runat="server"></asp:Label>
         </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Label19" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label20" runat="server"></asp:Label>
         </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Label21" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label22" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label23" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label24" runat="server"></asp:Label>
         </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Label25" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label26" runat="server"></asp:Label>
         </p>
         <p>
             <asp:Label ID="Label27" runat="server"></asp:Label>
         </p>
         <p>
             &nbsp;</p>
                </div>
             


            </div>
          </div>
        </div>
        <!-- End col-->
      </div>
    </div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>




</asp:Content>
