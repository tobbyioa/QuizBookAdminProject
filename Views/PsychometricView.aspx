<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminView.Master" AutoEventWireup="true" CodeBehind="PsychometricView.aspx.cs" Inherits="QuizBook.Views.PsychometricView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    $(function () {
        $("#<%=print.ClientID %>").button();
        $("#<%=BackToPTR.ClientID %>").button();
        $("#<%=print.ClientID %>").click(function () {
            window.print()
        });
    });
</script>

<style type="text/css">
       
        td
{ 
        padding: 7px 5px;
            font-weight:bold;
            text-align: left;
            font-size: medium;
        }
 #answers > td
 {
     border: thin solid #000000;
     width:100%;
     background-color: #008000;
 }
  .nopadding
{
   
padding-top:0px;
padding-bottom:0px;
padding-right:0px;
padding-left:0px;
}
.tobechecked
{
    background-color:White;
    text-align:center;
    vertical-align:middle;
    width: auto;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="width: 90%; height:auto; margin:0 auto; font-size:10pt;">
 <table style="width: 100%;">
 <tr>
 
 <td style="text-align:left;">
     <asp:LinkButton ID="BackToPTR"  CssClass="btnstyle" runat="server" onclick="BackToPTR_Click">Back</asp:LinkButton>
     </td>
     <td style="text-align:right;">
     <asp:LinkButton ID="print" CssClass="btnstyle" runat="server" 
        style="font-weight: 700"  >Print</asp:LinkButton>
     </td>
     </tr>
 </table>
 <table  style="border: thin solid #008080; width: 90%; margin:0 auto; ">
  <tr>
            <td style="border-style: solid none solid solid; border-width: medium; border-color: #000000; font-weight: bold; font-size:large; text-align: left; background-color:#008080; color:White;" >
               Multiple Intelligence Test
            </td>
            <td style="border-style: solid solid solid none; border-width: medium; border-color: #000000; font-weight: bold; font-size:large; text-align: right; background-color:#008080; color:White;" >
                Howard Gardner's MI Model Based</td>
        </tr>
 </table>
 <table style="border: thin solid #008080; width: 90%; margin:0 auto; ">
  
        <tr>
            <td style="width:50%;">
                <strong>Candidate Code:
            </strong>&nbsp;&nbsp;<span id="ccode" runat="server" style=" font-weight:normal;"></span>
            </td>
            <td style="width:50%;">
              <strong>Gender:</strong>&nbsp;&nbsp;<span id="CGender" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
        <tr>
            <td style="width:50%;border-top: thin solid #008080; border-left-style: none; border-right-style: none; border-bottom-style: none;">
                <strong>Surname:
            </strong>&nbsp;&nbsp;<span id="Surname" runat="server" style=" font-weight:normal;"></span>
            </td>
            <td style="width:50%;border-top: thin solid #008080; border-left-style: none; border-right-style: none; border-bottom-style: none;" >
                <strong>Other Names:</strong>&nbsp;&nbsp;<span id="COthernames" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
          <tr>
            <td style="width:50%; border-style: solid none none none; border-top-width: thin; border-top-color: #008080;">
                <strong>Date of Birth:
            </strong>&nbsp;&nbsp;<span id="CDob" runat="server" style=" font-weight:normal;"></span>
            </td>
            <td style="width:50%; border-style: solid none none none; border-top-width: thin; border-top-color: #008080;">
                <strong>Test Grade:</strong>&nbsp;&nbsp;<span id="cgrade" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
    </table>
 <table style=" width:100%;">
              <tr><td style="width:5%;"></td><td style="width:60%;"></td><td style="width:35%;" class="nopadding">
                  <table style="border: thin solid #000000; width:100%;">
                     <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                             &nbsp;</td>
                     </tr>
                     
                 </table></td></tr>
             <tr><td style="border: thin solid #000000; font-weight: 700;">1</td>
                 <td style="border: thin solid #000000;">I like to learn more about myself</td>
                 <td class="nopadding" style="width:35%;">
                 <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                     <tr>
                         
                            <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 
                                 <asp:TextBox ID="TextBox1" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox>
                                 </td>
                                 
                     </tr>
                 </table>
                 </td></tr>
             <tr><td style="border: thin solid #000000;"><strong>2</strong></td>
                 <td style="border: thin solid #000000;">I can play a musical instrument</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                     <tr>
                         
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox31" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>

                     </tr>
                 </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;"><strong>3</strong></td>
                 <td style="border: thin solid #000000;">I find it easiet to solve problems when I am doing something physical</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                     <tr>
                         
 <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox40" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>

                     </tr>
                 </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;"><strong>4</strong></td>
                 <td style="border: thin solid #000000;">I often have a song or a piece of music in my head</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                     <tr>
                         
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox32" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>

                     </tr>
                 </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;"><strong>5</strong></td>
                 <td style="border: thin solid #000000;">I find budgeting and managing my money easy</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox21" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;"><strong>6</strong></td>
                 <td style="border: thin solid #000000;">I find it easy to make up stories</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox11" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">7</td>
                 <td style="border: thin solid #000000;">I have always been physically well co-ordinated</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox41" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">8</td>
                 <td style="border: thin solid #000000;">When talking to someone, I tend to listen to the words they use not just what they mean</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox12" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">9</td>
                 <td style="border: thin solid #000000;">When talking to someone, I tend to listen to the words they use not just what they mean</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox13" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">10</td>
                 <td style="border: thin solid #000000;">I don't like ambiguity, I like things to be clear</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox22" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">11</td>
                 <td style="border: thin solid #000000;">I enjoy logic puzzles such as 'sudoku'</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox23" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">12</td>
                 <td style="border: thin solid #000000;">I like to meditate</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox2" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">13</td>
                 <td style="border: thin solid #000000;">Music is very important to me</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox33" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">14</td>
                 <td style="border: thin solid #000000;">I am a convincing liar(if I want to be)</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox14" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">15</td>
                 <td style="border: thin solid #000000;">I play a sport or a dance</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox42" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">16</td>
                 <td style="border: thin solid #000000;">I am very interested in pschometrics(personality testing) and IQ tests</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox3" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">17</td>
                 <td style="border: thin solid #000000;">People behaving irrationally annoy me</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox24" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">18</td>
                 <td style="border: thin solid #000000;">I find that music that appeals to me is often based on how I feel emotionally</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox34" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">19</td>
                 <td style="border: thin solid #000000;">I am a very social person and like being with other people</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox61" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">20</td>
                 <td style="border: thin solid #000000;">I like to be systematic and thorough</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox25" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">21</td>
                 <td style="border: thin solid #000000;">I find graphs and charts easy to understand</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox51" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">22</td>
                 <td style="border: thin solid #000000;">I can throw things well - darts, skimming pebbles, frisbees, etc</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox43" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">23</td>
                 <td style="border: thin solid #000000;">I find it easy to remember quotes or phrases</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox15" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">24</td>
                 <td style="border: thin solid #000000;">I can always recognise places that I have been before, even when I was very young</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                           <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox52" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">25</td>
                 <td style="border: thin solid #000000;">I enjoy a wide variety of musical styles</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox35" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox>
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">26</td>
                 <td style="border: thin solid #000000;">When I am concentrating I tend to doodle</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox53" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">27</td>
                 <td style="border: thin solid #000000;">I could manipulate people if I choose to</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox62" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">28</td>
                 <td style="border: thin solid #000000;">I can predict my feelings and behaviours in certain situations fairly accurately</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox4" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">29</td>
                 <td style="border: thin solid #000000;">I find mental arithmetic easy</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox26" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">30</td>
                 <td style="border: thin solid #000000;">I can identify most sounds without seeing what causes them</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox36" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">31</td>
                 <td style="border: thin solid #000000;">At school one of my favourite subjects is/was English</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox16" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">32</td>
                 <td style="border: thin solid #000000;">I like to think through a problem carefully, considering all the consequences</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox27" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">33</td>
                 <td style="border: thin solid #000000;">I enjoy debates and discussions</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox17" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">34</td>
                 <td style="border: thin solid #000000;">I love adrenaline sports and scary rides</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox44" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">35</td>
                 <td style="border: thin solid #000000;">I enjoy individual sports best</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox5" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">36</td>
                 <td style="border: thin solid #000000;">I care about how those around me feel</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox63" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">37</td>
                 <td style="border: thin solid #000000;">My house is full of pictures and photographs</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                           <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox54" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">38</td>
                 <td style="border: thin solid #000000;">I enjoy and am good at making things - I'm good with my hands</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox45" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">39</td>
                 <td style="border: thin solid #000000;">I like having music on in the background</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox37" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">40</td>
                 <td style="border: thin solid #000000;">I find it easy to remember telephone numbers</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                           <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox28" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">41</td>
                 <td style="border: thin solid #000000;">I set myself goals and plans for the future</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox6" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">42</td>
                 <td style="border: thin solid #000000;">I am a very tactile person</td>
                 <td class="nopadding" style="width:35%;">
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox46" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">43</td>
                 <td style="border: thin solid #000000;">I can tell easily whether someone likes me or dislikes me</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox64" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">44</td>
                 <td style="border: thin solid #000000;">I can easily imagine how an object would look like from another perspective</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox55" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">45</td>
                 <td style="border: thin solid #000000;">I never use instructions for flat-pack furniture</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox47" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">46</td>
                 <td style="border: thin solid #000000;">I find it easy to talk to new people</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox65" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">47</td>
                 <td style="border: thin solid #000000;">To learn something new, I need to just get on and try it</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox48" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">48</td>
                 <td style="border: thin solid #000000;">I often see clear images when I close my eyes</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox56" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">49</td>
                 <td style="border: thin solid #000000;">I don't use my fingers when I count</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox29" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">50</td>
                 <td style="border: thin solid #000000;">I often talk to myself - out loud in my head</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox18" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">51</td>
                 <td style="border: thin solid #000000;">At school I loved/love music lessons</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox38" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">52</td>
                 <td style="border: thin solid #000000;">When I am abroad, I find it easy to pick the basics of another language</td>
                 <td class="nopadding" style="width:35%;">
                 <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                     <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox19" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     
                     </table>
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">53</td>
                 <td style="border: thin solid #000000;">I find ball games easy and enjoyable</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox49" runat="server" CssClass="D4" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">54</td>
                 <td style="border: thin solid #000000;">My favourite subject at school is/was maths</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox30" runat="server" CssClass="D2" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">55</td>
                 <td style="border: thin solid #000000;">I always know how I am feeling</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                           <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox7" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">56</td>
                 <td style="border: thin solid #000000;">I am realistic about my strenghts and weaknesses</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox8" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">57</td>
                 <td style="border: thin solid #000000;">I keep a diary</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox9" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">58</td>
                 <td style="border: thin solid #000000;">I am very aware of other people's body language</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox66" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">59</td>
                 <td style="border: thin solid #000000;">My favourite subject at school was/is art</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox57" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">60</td>
                 <td style="border: thin solid #000000;">I find pleasure in reading</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox20" runat="server" CssClass="D1" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">61</td>
                 <td style="border: thin solid #000000;">I can read a map easily</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox58" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">62</td>
                 <td style="border: thin solid #000000;">It upsets me to see someone cry and not be able to help</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox67" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">63</td>
                 <td style="border: thin solid #000000;">I am good at solving disputes between others</td>
                 <td class="nopadding" style="width:35%;">
                     
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox68" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">64</td>
                 <td style="border: thin solid #000000;">I have always dreamed of being a musician or singer</td>
                 <td class="nopadding" style="width:35%;">
                 
                 
                  <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                      <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox39" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 

                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">65</td>
                 <td style="border: thin solid #000000;">I prefer team sports</td>
                 <td class="nopadding" style="width:35%;">
                 
                 
                  <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                      <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox69" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>

                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">66</td>
                 <td style="border: thin solid #000000;">Singing makes me feel happy</td>
                 <td class="nopadding" style="width:35%;">
                 
                 
                  <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                      <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox50" runat="server" CssClass="D3" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>

                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">67</td>
                 <td style="border: thin solid #000000;">I never get lost when I am on my way in a new place</td>
                 <td class="nopadding" style="width:35%;">
                 
                 
                  <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                      <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox59" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>

                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">68</td>
                 <td style="border: thin solid #000000;">If I am learning how to do something, I like to see drawings and diagrams of how it works</td>
                 <td class="nopadding" style="width:35%;">
                 
                  <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                      <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox60" runat="server" CssClass="D5" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>

                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">69</td>
                 <td style="border: thin solid #000000;">I am happy spending time alone</td>
                 <td class="nopadding" style="width:35%;">
                 
                  <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                       <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                   <asp:TextBox ID="TextBox10" runat="server" CssClass="D7" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     </table>

                 </td>
                 </tr>
             <tr><td style="border: thin solid #000000;">70</td>
                 <td style="border: thin solid #000000;">My friends always come to me for emotional support and advice</td>
                 <td class="nopadding" style="width:35%;">
                     
                      <table  style="border: thin solid #000000; width:100%; background-color: #008000;">
                          <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td class="tobechecked" style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox70" runat="server" CssClass="D6" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     </table>
                 
                 </td>
                 </tr>
             <tr><td style="border-style: none;"></td>
                 <td style="border-style: none;"></td><td style="width:35%;">
                 &nbsp;</td></tr>
                 <tr><td style="border: thin solid #000000;"></td>
                     <td style="border: thin solid #000000; font-size:large; text-align: right; font-weight:700; background-color:#2E3E3F; color:White;">Overall Total Scores</td><td style="width:35%;" 
                         class="nopadding">
                     <table style="border: thin solid #000000; width:100%; background-color: #008000;">
                     <tr>
                         <td style="border: thin solid #000000; text-align: center;">
                             <asp:TextBox ID="TextBox72" runat="server" CssClass="summation" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000; text-align: center;">
                              <asp:TextBox ID="TextBox73" runat="server" CssClass="summation" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000; text-align: center;">
                              <asp:TextBox ID="TextBox74" runat="server" CssClass="summation" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000; text-align: center;">
                                  <asp:TextBox ID="TextBox75" runat="server" CssClass="summation" style=" font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000; text-align: center;">
                                  <asp:TextBox ID="TextBox76" runat="server" CssClass="summation" style=" font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000; text-align: center;">
                                  <asp:TextBox ID="TextBox77" runat="server" CssClass="summation" style=" font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000; text-align: center;">
                                  <asp:TextBox ID="TextBox78" runat="server" CssClass="summation" style=" font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     
                 </table></td></tr>
                 <tr><td></td>
                     <td></td><td style="width:35%;">
                     &nbsp;</td></tr>
                      
             </table>
             <table style=" width:100%; ">
               <tr style="border: medium solid #000000; font-size:large; text-align: center; font-weight:700; background-color:#2E3E3F; color:White;"><td></td>
                     <td style=" text-align:center; font-size:large; font-weight:800;">Intelligence Type</td><td style="width:35%;">
                     &nbsp;</td></tr>
               <tr><td style="border: thin solid #000000;width:5%;"></td>
                     <td style="width:60%; border: thin solid #000000; text-align:center;">Linguistic </td>
                   <td style="width:35%; background-color: #008000;" class="nopadding" rowspan="7">
                     
                     <table style="border: thin solid #000000; width:100%;" class ="nopadding">
                     <tr>
                         <td style="border: thin solid #000000">
                             <asp:TextBox ID="TextBox79" runat="server" CssClass="analysis" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     
                     <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             <asp:TextBox ID="TextBox80" runat="server" CssClass="analysis" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     
                     <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             <asp:TextBox ID="TextBox81" runat="server" CssClass="analysis" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     
                     <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox82" runat="server" CssClass="analysis" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     
                     <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox83" runat="server" CssClass="analysis" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     
                     <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox84" runat="server" CssClass="analysis" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                     </tr>
                     
                     <tr>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                         <td style="border: thin solid #000000">
                             &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 &nbsp;</td>
                             <td style="border: thin solid #000000">
                                 <asp:TextBox ID="TextBox85" runat="server" CssClass="analysis" style="font-weight:bold;" Text="0" Enabled="false" Width="30px" ></asp:TextBox></td>
                     </tr>
                     
                 </table>
                     
                     </td></tr>
               <tr><td style="border: thin solid #000000;width:5%;"></td>
                     <td style="width:60%; border: thin solid #000000; text-align:center;">Logical-Mathematical</td></tr>
               <tr><td style="border: thin solid #000000;width:5%;text-align:center;"></td>
                     <td style="width:60%; border: thin solid #000000;text-align:center;">Musical</td></tr>
               <tr><td style="border: thin solid #000000;width:5%;text-align:center;"></td>
                     <td style="width:60%; border: thin solid #000000;text-align:center;">Bodily-Kinesthetic </td></tr>
               <tr><td style="border: thin solid #000000;width:5%;"></td>
                     <td style="width:60%; border: thin solid #000000;text-align:center;">Spatial-Visual</td></tr>
               <tr><td style="border: thin solid #000000;width:5%;text-align:center;"></td>
                     <td style="width:60%; border: thin solid #000000;text-align:center;">Interpersonal</td></tr>
               <tr><td style="border: thin solid #000000;width:5%;"></td>
                     <td style="width:60%; border: thin solid #000000;text-align:center;">Intrapersonal</td></tr></td></tr>
                     <tr style="border: medium solid #000000; font-size:medium; text-align: center; font-weight:700; background-color:#2E3E3F; color:White;"><td></td>
                     <td></td><td style="width:35%;">
                     &nbsp;</td></tr>
                     <tr><td></td>
                     <td></td><td style="width:35%;">
                     &nbsp;</td></tr>
                     <tr><td></td>
                     <td style=" text-align:right;"><strong>My strongest intelligences are:</strong></td>
                         <td style="width:35%; border-bottom-style: solid; border-bottom-width: thick; border-bottom-color: #000000;">
                             <asp:TextBox ID="TextBox71" runat="server" CssClass="intel" Width="80%" ReadOnly="true" style=" font-weight:700;"></asp:TextBox>
                             <asp:HiddenField ID="intelligence" runat="server" />
                         </td></tr>
                     <tr><td></td>
                     <td></td><td style="width:35%;">
                     &nbsp;</td></tr>
               </table>
 </div>
</asp:Content>
