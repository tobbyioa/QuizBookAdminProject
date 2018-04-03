<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Candidate.Master" AutoEventWireup="true" CodeBehind="MultiIntelligenceTest.aspx.cs" Inherits="QuizBook.Views.MultiIntelligenceTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(function () {
            //        var arrChkBox = document.getElementsByName("D7");
            //        var st = ""; alert(arrChkBox.length);

            $("#<%=Save.ClientID %>").button();
            $("#<%=msgLabel.ClientID %>").fadeOut(10000);
            $('.selectionMiniDropDown').change(function () {

                var total = 0;
                var name = $(this).attr('name');
                var arrChkBox = document.getElementsByName(name);

                var l = arrChkBox.length;

                for (var i = 0; i < l; i++) {
                    total += parseInt($(arrChkBox[i]).val());
                }

                if (name == "D1") {
                    $('#Text1').val(total);
                    $('#Text8').val(total);
                } else if (name == "D2") {
                    $('#Text2').val(total);
                    $('#Text9').val(total);
                } else if (name == "D3") {
                    $('#Text3').val(total);
                    $('#Text10').val(total);
                } else if (name == "D4") {
                    $('#Text4').val(total);
                    $('#Text11').val(total);
                } else if (name == "D5") {
                    $('#Text5').val(total);
                    $('#Text12').val(total);
                } else if (name == "D6") {
                    $('#Text6').val(total);
                    $('#Text13').val(total);
                } else if (name == "D7") {
                    $('#Text7').val(total);
                    $('#Text14').val(total);
                }
                var analysis = new Array("Linguistic", "Logical-Mathematical", "Musical", "Bodily-Kinesthetic ", "Spatial-Visual", "Interpersonal", "Intrapersonal");
                var maxArray = new Array($('#Text1').val(), $('#Text2').val(), $('#Text3').val(), $('#Text4').val(), $('#Text5').val(), $('#Text6').val(), $('#Text7').val());

                //get the first max
                var max = Array.max(maxArray);

                var count = maxArray.length;

                var index = 0;
                for (var x = 0; x < count; x++) {
                    var currentVal = maxArray[x];

                    if (currentVal == max) {
                        index = x;
                    }
                }

                var strength1 = analysis[index];





                maxArray.splice(index, 1);
                analysis.splice(index, 1);
                
                //get the second max
                var max2 = Array.max(maxArray);

                count = maxArray.length;

                index = 0;
                for (var y = 0; y < count; y++) {
                    var currentValx = maxArray[y];

                    if (currentValx == max2) {
                        index = y;
                    }
                }
                var strength2 = analysis[index];


               // alert(max + ", " + max2);

                if (max == max2) {
                    $("#<%=TextBox1.ClientID %>").val(strength1 + ", " + strength2);

                    $("#<%=intelligence.ClientID %>").val(strength1 + ", " + strength2);
                } else {
                    $("#<%=TextBox1.ClientID %>").val(strength1);
                    $("#<%=intelligence.ClientID %>").val(strength1);
                }

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
    <div style="width: 95%; height:auto; margin:0 auto; font-size:10pt;">
<table   style=" border: thick solid #000000; height: auto; width: 100%; margin:0 auto;">
<tr>
            <td  colspan="2" >
             <hr style="width:100%;" />
            </td>
        </tr>
   <tr>
            <td style="border-style: solid none solid solid; border-width: medium; border-color: #000000; font-weight: bold; font-size:large; text-align: left; background-color:#008080; color:White;" >
               Multiple Intelligence Test
            </td>
            <td style="border-style: solid solid solid none; border-width: medium; border-color: #000000; font-weight: bold; font-size:large; text-align: right; background-color:#008080; color:White;" >
                Howard Gardner's MI Model Based</td>
        </tr>
        <tr>
            <td  colspan="2" >
              <hr style="width:100%;" />
            </td>
        </tr>
        <tr>
        <td colspan="2">
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
        </td>
        </tr>
        <tr>
        <td colspan="2">
            <strong><em>Important Instruction:  
            <br />
            This questionnaire is designed to provide valuable feedback about you and will take only a few minutes to complete. Please respond to every question/statement and ensure that your answers are accurate and honest. While your responses will be treated as confidential, please note that the Bank reserves the right to verify the information you have provided and will take appropriate disciplinary measures in the event of false, inaccurate or misleading answers/statements.<br />
            <br />
&nbsp;To complete the form, simply score the statements: 1 = Mostly Disagree, 2 = Slightly Disagree, 3 = Slightly Agree, 4 = Mostly Agree<br />
            <br />
&nbsp;Tick the box if the statement is more true for you than not. </em></strong>

        </td>
        </tr>
        <tr>
        <td colspan="2" 
                
                style="border: medium solid #000000; font-size:large; text-align: center; font-weight:800; color:Red;">
            <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
        </td>
         </tr>
         <tr>
        <td colspan="2" 
                
                style="border: medium solid #000000; font-size:large; text-align: center; font-weight:800; background-color:#008080; color:White;">
           A: TEST QUESTIONS
        </td>
        </tr>
         <tr>
            <td  colspan="2" >
              <hr style="width:80%;" />
            </td>
        </tr>
          <tr>
            <td class="nopadding"  colspan="2" >
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
                                 <select id="Select1" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>

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
                                 <select id="Select2" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select3" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select4" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select6" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select7" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select5" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select8" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select9" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select10" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select11" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select12" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select13" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select14" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select15" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select16" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select17" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select18" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select19" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select20" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select21" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select22" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select23" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select24" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select25" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select26" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select27" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select28" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select29" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select30" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select31" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select32" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select33" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select34" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select35" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select36" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select37" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select38" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select39" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select40" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select41" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select42" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select43" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select44" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select45" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select46" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select47" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select48" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select49" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select50" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select51" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select52" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select53" name="D4" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select54" name="D2" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select55" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select56" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select57" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select58" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select59" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select60" name="D1" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select61" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select62" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select63" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select64" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select65" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select66" name="D3" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select67" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select68" name="D5" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select69" name="D7" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                                 <select id="Select70" name="D6" class="selectionMiniDropDown" >
                                     <option value="0">Select..</option><option value="1">1</option>
                                     <option value="2">2</option>
                                     <option value="3">3</option>
                                     <option value="4">4</option>
                                 </select></td>
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
                             <input id="Text1"  type="text" style="width:30px; font-weight: 700;" value="0"  
                                 readonly="readonly" name="Summation" /></td>
                         <td style="border: thin solid #000000; text-align: center;">
                             <input id="Text2" type="text" style="width:30px; font-weight: 700;" value="0" 
                                 readonly="readonly" name="Summation" /></td>
                         <td style="border: thin solid #000000; text-align: center;">
                             <input id="Text3" type="text"  style="width:30px; font-weight: 700;" value="0" 
                                 readonly="readonly" name="Summation"/></td>
                             <td style="border: thin solid #000000; text-align: center;">
                                 <input id="Text4" type="text" style="width:30px; font-weight: 700;" value="0" 
                                     readonly="readonly" name="Summation" /></td>
                             <td style="border: thin solid #000000; text-align: center;">
                                 <input id="Text5" type="text" style="width:30px; font-weight: 700;" value="0"  
                                     readonly="readonly" name="Summation" /></td>
                             <td style="border: thin solid #000000; text-align: center;">
                                 <input id="Text6" type="text" name="Summation" style="width:30px; font-weight: 700;" value="0" 
                                     readonly="readonly" /></td>
                             <td style="border: thin solid #000000; text-align: center;">
                                 <input id="Text7" type="text" style="width:30px; font-weight: 700;" value="0" 
                                     readonly="readonly" name="Summation" /></td>
                     </tr>
                     
                 </table></td></tr>
                 <tr><td></td>
                     <td></td><td style="width:35%;">
                     &nbsp;</td></tr>
                      
             </table>
            </td>
        </tr>
        <tr>
        <td colspan="2" 
                style="border: medium solid #000000; font-size:medium; text-align: center; font-weight:700; background-color:#2E3E3F; color:White;">
           B: ANALYSIS OF TEST SCORES


        </td>
        </tr>
         <tr>
            <td  colspan="2" >
              <hr style="width:80%;" />
            </td>
        </tr>
        <tr>
            <td  class="nopadding" colspan="2" >
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
                             <input id="Text8" readonly="readonly" style="width: 30px; font-weight: 700;" 
                                 type="text" value="0" /></td>
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
                             <input id="Text9" readonly="readonly" style="width: 30px; font-weight: 700;" 
                                 type="text" value="0" /></td>
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
                             <input id="Text10" readonly="readonly" style="width: 30px; font-weight: 700;" 
                                 type="text" value="0" /></td>
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
                                 <input id="Text11" readonly="readonly" style="width: 30px; font-weight: 700;" 
                                     type="text" value="0" /></td>
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
                                 <input id="Text12" readonly="readonly" style="width: 30px; font-weight: 700;" 
                                     type="text" value="0" /></td>
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
                                 <input id="Text13" readonly="readonly" style="width: 30px; font-weight: 700;" 
                                     type="text" value="0" /></td>
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
                                 <input id="Text14" readonly="readonly" style="width: 30px; font-weight: 700;" 
                                     type="text" value="0" /></td>
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
                             <asp:TextBox ID="TextBox1" runat="server" Width="80%" ReadOnly="true" style=" font-weight:700;"></asp:TextBox>
                             <asp:HiddenField ID="intelligence" runat="server" />
                         </td></tr>
                     <tr><td></td>
                     <td></td><td style="width:35%;">
                     &nbsp;</td></tr>
               </table>
            </td>
        </tr>
        <tr>
        <td colspan="2" 
                style="border: medium solid #000000; font-size:large; text-align: center; font-weight:700; background-color:#2E3E3F; color:White;">
           C: INTERPRETATION OF RESULTS ANALYSIS OF TEST SCORES


        </td>
        </tr>
         <tr>
            <td  colspan="2" >
              <hr style="width:80%;" />
            </td>
        </tr>
        <tr>
            <td  colspan="2" >
                <strong>1.&nbsp;&nbsp;	Your highest scores indicate your natural strenghts and potential - your natural intelligences.
                <br />
                <br />
                2.&nbsp;&nbsp;	This indicator can help you to focus on the sort of learning and work that will be most fulfilling and rewarding for you. 
                <br />
                <br />
                3.&nbsp;&nbsp;	There are no right or wrong answers. 
                <br />
                <br />
                4.&nbsp;&nbsp;	You are happiest & most successful when you learn, develop, & work in ways that make best use of your natural intelligences (your strengths, style & brain type) 
                </strong>							

            </td>
        </tr>
        <tr>
            <td  colspan="2"  style="text-align:right;">
                <asp:Button ID="Save" runat="server" Text="Submit" CssClass="btnstyle"  
                    Width="100px" onclick="Save_Click"/>
                </td>
        </tr>
        </table>
        
</div>
</asp:Content>
