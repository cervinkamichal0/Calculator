<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Calculator</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT TOP 5 * FROM [HistoryTable] ORDER BY id DESC"></asp:SqlDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="calculatorPanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="calculatorContainer">

                    <div class="calculator">

                        <h1>CALCULATOR</h1>

                        <asp:Label ID="lMode" runat="server" Text="RETURNING: DECIMAL"></asp:Label>
                        <asp:TextBox ID="tB_display" runat="server" Height="40px" Width="280px" Text="0" BackColor="#99FF99" OnTextChanged="tB_display_TextChanged" CssClass="tB_display" BorderStyle="None" Enabled="False"></asp:TextBox>
                        <div class="calcuatorButton">

                            <asp:Button ID="b1" runat="server" Text="1" CssClass="calculatorButton" OnClick="b1_Click" />
                            <asp:Button ID="b2" runat="server" Text="2" CssClass="calculatorButton" OnClick="b2_Click" />
                            <asp:Button ID="b3" runat="server" Text="3" CssClass="calculatorButton" OnClick="b3_Click" />
                            <asp:Button ID="bPlus" runat="server" Text="+" CssClass="calculatorButton" BackColor="#3399FF" OnClick="bPlus_Click" />
                            <br />
                            <asp:Button ID="b4" runat="server" Text="4" CssClass="calculatorButton" OnClick="b4_Click" />
                            <asp:Button ID="b5" runat="server" Text="5" CssClass="calculatorButton" OnClick="b5_Click" />
                            <asp:Button ID="b6" runat="server" Text="6" CssClass="calculatorButton" OnClick="b6_Click" />
                            <asp:Button ID="bMinus" runat="server" Text="-" CssClass="calculatorButton" BackColor="#3399FF" OnClick="bMinus_Click" />
                            <br />
                            <asp:Button ID="b7" runat="server" Text="7" CssClass="calculatorButton" OnClick="b7_Click" />
                            <asp:Button ID="b8" runat="server" Text="8" CssClass="calculatorButton" OnClick="b8_Click" />
                            <asp:Button ID="b9" runat="server" Text="9" CssClass="calculatorButton" OnClick="b9_Click" />
                            <asp:Button ID="bMultiply" runat="server" Text="*" CssClass="calculatorButton" BackColor="#3399FF" OnClick="bMultiply_Click" />
                            <br />
                            <asp:Button ID="b0" runat="server" Text="0" CssClass="calculatorButton" OnClick="b0_Click" />
                            <asp:Button ID="bDot" runat="server" Text="." CssClass="calculatorButton" OnClick="bDot_Click" />
                            <asp:Button ID="bDelete" runat="server" Text="C" CssClass="calculatorButton" BackColor="#FF9999" OnClick="bDelete_Click" />
                            <asp:Button ID="bDivide" runat="server" Text="/" CssClass="calculatorButton" BackColor="#3399FF" OnClick="bDivide_Click" />
                            <br />
                            <asp:Button ID="bEquals" runat="server" Text="=" Width="280" CssClass="calculatorButton" BackColor="#33CC33" OnClick="bEquals_Click" />
                            <br />
                            <asp:Button ID="bDecimal" runat="server" Text="DECIMAL" Width="120" CssClass="calculatorButton" BackColor="#666699" OnClick="bDecimal_Click" Enabled="False" />
                            <asp:Button ID="bInteger" runat="server" Text="INTEGER" Width="120" CssClass="calculatorButton" BackColor="#666699" OnClick="bInteger_Click" />
                        </div>
                    </div>
                    <div class="history">
                        <h1>HISTORY</h1>
                        
                        <asp:GridView ID="gVHistory" CssClass="gVHistory" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1"  Height="485px" Width="335px" BackColor="#99FF99" ShowHeader ="False" HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundField DataField="Equation" SortExpression="Equation"></asp:BoundField>
                            </Columns>
                        </asp:GridView>                  
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

