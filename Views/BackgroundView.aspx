<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminView.Master" AutoEventWireup="true" CodeBehind="BackgroundView.aspx.cs" Inherits="QuizBook.Views.BackgroundView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        $("#<%=print.ClientID %>").button();
        $("#<%=LinkButton1.ClientID %>").button();
        $("#<%=print.ClientID %>").click(function () {
            window.print()
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width: 80%; height:auto; margin:0 auto; font-size:10pt;">
<style type="text/css">
td
{
padding-top:7px;
padding-bottom:7px;
padding-right:5px;
padding-left:5px;
}

.qtd
{
padding-top:5px;
padding-bottom:5px;
padding-right:5px;
padding-left:25px;
}
    .subhead
    {
        font-size:11pt;
        font-weight:800;
        color:Black;
    }
    .sanswer
    {
        width:90%;
    }
    .manswer
    {
        vertical-align:top;
        text-align:left;
         width:90%;
         height:100px;
         overflow-x:hidden;
         overflow-y:auto;
    }
   input[type="radio"]
    {
        width:auto;
    }
    
</style>
<table   style=" border: thick solid #000000; height: auto; width: 100%; margin:0 auto;">
<tr>
         <td  colspan="" style=" text-align:left;" >
         <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btnstyle" style="font-weight: 700" 
                    onclick="LinkButton1_Click">Back</asp:LinkButton>
         </td>
         <td  colspan="" style=" text-align:right;" >
                <asp:LinkButton ID="print" CssClass="btnstyle" runat="server" 
        style="font-weight: 700"  >Print</asp:LinkButton>
            </td>
        </tr>
<tr>
            <td  colspan="2" >
             <hr style="width:100%;" />
            </td>
        </tr>
   <tr>
            <td style="border: medium solid #000000; font-weight: bold; font-size:large; text-align: left; background-color:#00844F; color:White;"  
                colspan="2" >
               Employee Background Questionaire View
            </td>
        </tr>
        <tr>
            <td  colspan="2" >
              <hr style="width:100%;" />
            </td>
        </tr>
        <tr>
            <td  colspan="2" >
            <table style="border: thin solid #008080; width: 90%; margin:0 auto; ">
  
        <tr>
            <td style="width:50%;">
                <strong>Candidate Code
            </strong><span id="ccode" runat="server"></span>
            </td>
            <td style="width:50%;">
              <strong>Gender</strong><span id="CGender" runat="server"></span>
            </td>
        </tr>
        <tr>
            <td style="width:50%;border-top: thin solid #008080; border-left-style: none; border-right-style: none; border-bottom-style: none;">
                <strong>Surname
            </strong><span id="Surname" runat="server"></span>
            </td>
            <td style="width:50%;border-top: thin solid #008080; border-left-style: none; border-right-style: none; border-bottom-style: none;" >
                <strong>Other Names</strong><span id="COthernames" runat="server"></span>
            </td>
        </tr>
          <tr>
            <td style="width:50%; border-style: solid none none none; border-top-width: thin; border-top-color: #008080;">
                <strong>Date of Birth
            </strong><span id="CDob" runat="server"></span>
            </td>
            <td style="width:50%; border-style: solid none none none; border-top-width: thin; border-top-color: #008080;">
                <strong>Test Grade</strong><span id="cgrade" runat="server"></span>
            </td>
        </tr>
    </table>
                </td>
        </tr>


        <tr>
            <td  colspan="2" class="subhead" >
              
                (A) Your Formative Years 
              
            </td>
        </tr>
                <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>1.</strong>
            </td>
            <td style=" font-weight:600;">
            Where were you born?<br />
            Answer:<br />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="sanswer" Enabled="false"></asp:TextBox>
                
            </td>
        </tr>
         <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>2.</strong>
            </td>
            <td style=" font-weight:600;">
            Which town/city did you grow up?<br />Answer:<br /><asp:TextBox ID="TextBox2" 
                    runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>3.</strong>
            </td>
            <td style=" font-weight:600;">
            What position are you in your  family?<br />Answer:<br /><asp:TextBox ID="TextBox3" 
                    runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>4.</strong>
            </td>
            <td style=" font-weight:600;">
           Did you grow up in 
                
                <input id="RadioButton1" name ="r1"  type="radio" 
                    value="housing estate" />
                a housing   estate;<input id="RadioButton2" name ="r1"  
                    type="radio" value="barracks" />
&nbsp;barracks; <input id="RadioButton3" name ="r1"  type="radio" 
                    value="staff quarters" /> staff quarters; 
                <input id="RadioButton4" name ="r1"  type="radio" 
                    value="camp  etc" />
                camp  etc?  Please circle the right option: If none of the above, please state where:<br />Answer:<br />A<br /><asp:TextBox ID="TextBox41" Enabled="false" runat="server" CssClass="sanswer"></asp:TextBox><br />B<br /><asp:TextBox ID="TextBox4" runat="server" Enabled="false" CssClass="sanswer"></asp:TextBox>
           </td>
        </tr>
                <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>5.</strong>
            </td>
            <td style=" font-weight:600;">
           (a)  What do you remember most as a six (6) year old?<br />Answer:<br />
           <asp:TextBox ID="TextBox5" runat="server" CssClass="sanswer" Enabled="false"></asp:TextBox>
           <br />(b ) Who was your hero then?<br />Answer:<br />
           <asp:TextBox ID="TextBox6" runat="server" CssClass="sanswer" Enabled="false"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>6.</strong>
            </td>
            <td style=" font-weight:600;">
           (a)  What do you remember most as a ten (10) year old?<br />Answer:<br />
           <asp:TextBox ID="TextBox7" runat="server" CssClass="sanswer" Enabled="false"></asp:TextBox>
           <br />(b ) Who was your hero then?<br />Answer:<br />
           <asp:TextBox ID="TextBox8" runat="server" CssClass="sanswer" Enabled="false"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>7.</strong>
            </td>
            <td style=" font-weight:600;">
           (a)  Who was your greatest influence in your teenage years?<br />Answer:<br />
           <asp:TextBox ID="TextBox9" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
           <br />(b ) Why?<br />Answer:<br />
           <asp:TextBox ID="TextBox10" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  colspan="2" class="subhead" >
              
                (B )  Young Adulthood 
              
            </td>
        </tr>
          <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>8.</strong>
            </td>
            <td style=" font-weight:600;">
           (a)  Who was your greatest influence in University?<br />Answer:<br />
           <asp:TextBox ID="TextBox11" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
           <br />(b ) Why?<br />Answer:<br />
           <asp:TextBox ID="TextBox12" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>9.</strong>
            </td>
            <td style=" font-weight:600;">
           (a)  What is your father’ s occupation? <br />Answer:<br />
           <asp:TextBox ID="TextBox13" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
           <br />(b) What are his hobbies?<br />Answer:<br />
           <asp:TextBox ID="TextBox14" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>10.</strong>
            </td>
            <td style=" font-weight:600;">
           (a)  What is your mother’ s occupation?<br />Answer:<br />
           <asp:TextBox ID="TextBox15" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
           <br />(b) What are her hobbies? <br />Answer:<br />
           <asp:TextBox ID="TextBox16" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
                 <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>11.</strong>
            </td>
            <td style=" font-weight:600;">
            Which cult(s) did you belong to in school (Secondary/University)?<br />Answer:<br />
                <asp:TextBox ID="TextBox17" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
                 <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>12.</strong>
            </td>
            <td style=" font-weight:600;">
            Which club(s)  did you belong to in schoo l (Secondary/University)?<br />Answer:<br />
                <asp:TextBox ID="TextBox18" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  colspan="2" class="subhead" >
              
                (C )  Your Life Perspective   
              
            </td>
        </tr>
               <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>13.</strong>
            </td>
            <td style=" font-weight:600;">
            Briefly describe yourself, from <strong>your own</strong> perspective.<br />Answer:<br />
                <asp:TextBox ID="TextBox19" runat="server" Wrap="true" CssClass="manswer" 
                    TextMode="MultiLine" Enabled="False"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>14.</strong>
            </td>
            <td style=" font-weight:600;">
            What do you enjoy doing most?<br />Answer:<br /><asp:TextBox ID="TextBox20" 
                    runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>15.</strong>
            </td>
            <td style=" font-weight:600;">
            Name three (3) of  your major weaknesses? <br />(i)<br />Answer:<br />
                <asp:TextBox ID="TextBox21" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            <br />(ii)<br />Answer:<br /><asp:TextBox ID="TextBox22" runat="server" 
                    CssClass="sanswer" Enabled="False"></asp:TextBox>
            <br />(iii)<br />Answer:<br /><asp:TextBox ID="TextBox23" runat="server" 
                    CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>16.</strong>
            </td>
            <td style=" font-weight:600;">
            If you were to liken yourself to an animal (any creature on this earth), which would you be   and why?<br />Answer:<br />
            <asp:TextBox ID="TextBox24" runat="server" CssClass="manswer" Wrap="true" 
                    TextMode="MultiLine" Enabled="False"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>17.</strong>
            </td>
            <td style=" font-weight:600;">
          What  role would you prefer to play in a  team? 
                <input id="RadioButton5" name ="r2"  value="Leader" type="radio" />
                
                Leader;<input id="RadioButton6" name ="r2"  value="Follower" type="radio" />
&nbsp;Follower; 
                <input id="RadioButton7" name ="r2"  value="Unsure" type="radio" />
                Unsure?  Please circle the right option.:<br />Answer:<br />
                <asp:TextBox ID="TextBox42" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox><br />(b ) Why?<br />
                <asp:TextBox ID="TextBox25" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
           </td>
        </tr>

        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>18.</strong>
            </td>
            <td style=" font-weight:600;">
          (a)  In your free time, what would you rather do?
          <input id="RadioButton8" name ="r3"  type="radio" 
                    value="Vist Friends" />
                
                Vist Friends; <input id="RadioButton9" name ="r3" runat="server" type="radio" 
                    value="Read" />
Read; 
                <input id="RadioButton10" name ="r3" runat="server" type="radio" 
                    value="Watch TV" />
                Watch TV?  Please circle the right option.<br />Answer:<br />
                <asp:TextBox ID="TextBox43" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox> <br />(b ) Why?<br />Answer:<br />
                <asp:TextBox ID="TextBox26" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
           </td>
        </tr>
        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>19.</strong>
            </td>
            <td style=" font-weight:600;">
            When with people, do you initiate conversation or wait to be approached?<br />Answer:<br />
                <asp:TextBox ID="TextBox27" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>20.</strong>
            </td>
            <td style=" font-weight:600;">
          (a)  Would you describe yourself as
           
                 <input id="RadioButton11" name ="r4"  type="radio" 
                    value="Aggressive" />
                Aggressive;<input id="RadioButton12" name ="r4"  type="radio" 
                    value="Assertive" />
Assertive; 
                <input id="RadioButton13" name ="r4"  type="radio" 
                    onclick="return RadioButton13_onclick()" value="Submissive" />
                Submissive?  Please circle the right option.<br />Answer:<br />
                <asp:TextBox ID="TextBox44" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox><br /> (b ) Why?<br />Answer:<br />
                <asp:TextBox ID="TextBox28" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
           </td>
        </tr>

        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>21.</strong>
            </td>
            <td style=" font-weight:600;">
          (a)  At a party, do you:
          <input id="RadioButton14" name ="r5"  type="radio" 
                    value="interact with only the friends you know" />
                
                interact with only   the  friends   you know;<input id="RadioButton15" 
                    name ="r5"  type="radio" 
                    value="you mingle with many, including strangers" />or
you mingle with many, including strangers; ?  Please circle the right option.<br />Answer:<br />
                <asp:TextBox ID="TextBox45" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox> <br />(b ) Why?<br />Answer:<br />
                <asp:TextBox ID="TextBox29" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
           </td>
        </tr>
        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>22.</strong>
            </td>
            <td style=" font-weight:600;">
             If you   had enough resources,  what brand  of car would you like  to buy?<br />Answer:<br />
                <asp:TextBox ID="TextBox30" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>23.</strong>
            </td>
            <td style=" font-weight:600;">
            (a)  Five (5)   years f rom now, list  three things you hope to have achieved? <br />(i)<br />Answer:<br />
                <asp:TextBox ID="TextBox31" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            <br />(ii)<br />Answer:<br /><asp:TextBox ID="TextBox32" runat="server" 
                    CssClass="sanswer" Enabled="False"></asp:TextBox>
            <br />(iii)<br />Answer:<br /><asp:TextBox ID="TextBox33" runat="server" 
                    CssClass="sanswer" Enabled="False"></asp:TextBox>
            <br />
            <br />
             (b)  List three (3) things you  must do to  achieve them? <br />(i)<br />Answer:<br />
                <asp:TextBox ID="TextBox34" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            <br />(ii)<br />Answer:<br /><asp:TextBox ID="TextBox35" runat="server" CssClass="sanswer" 
                    Enabled="False"></asp:TextBox>
            <br />(iii)<br />Answer:<br /><asp:TextBox ID="TextBox36" runat="server" CssClass="sanswer" 
                    Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong>24.</strong>
            </td>
            <td style=" font-weight:600;">
             In university, what are the names of y our  best two (2) friends? <br />(i)<br />Answer:<br />
                <asp:TextBox ID="TextBox37" runat="server" CssClass="sanswer" Enabled="False"></asp:TextBox>
            <br />(ii)<br />Answer:<br /><asp:TextBox ID="TextBox38" runat="server" 
                    CssClass="sanswer" Enabled="False"></asp:TextBox>
            <br />
            <br />
           (b) What do they do now?<br />Answer:<br />
            <asp:TextBox ID="TextBox39" runat="server"  CssClass="manswer" Wrap="true" 
                    TextMode="MultiLine" Enabled="False"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td class="q.td" style="width:5%; vertical-align:top;" >
            <strong>25.</strong>
            </td>
            <td style=" font-weight:600;">
           What would you like to be remembered for when you’ re 70 years old? <br />Answer:<br />
                <asp:TextBox ID="TextBox40" Wrap="true" 
                    runat="server" CssClass="manswer" TextMode="MultiLine" Enabled="False"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            
            </td>
            <td style=" font-weight:600;">
            <strong>DECLARATION:The information/statements provided in this questionnaire are true and accurate to the best of my knowledge.</strong><input id="RadioButton16" name ="r6"  type="radio" value="Yes" /> Yes
                <input id="RadioButton17" name ="r6"  type="radio" value="No" /> No<br />Answer:<br /><asp:TextBox ID="TextBox46" runat="server" 
                    CssClass="sanswer" Enabled="False"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="qtd" style="width:5%; vertical-align:top;" >
            <strong></strong>
            </td>
            <td style=" font-weight:600; text-align: right;">
                
            </td>
        </tr>
        <tr>
            <td  style="font-weight: bold; text-align: center; background-color:#2E3E3F;" colspan="2" >
          &nbsp;
            </td>
        </tr>
        </table>
</div>
</asp:Content>
