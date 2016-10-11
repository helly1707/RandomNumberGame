<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RandomNumberGame._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style>
    html
    {
        background: url(Images/background.jpg) no-repeat center center fixed; 
        -webkit-background-size: cover;
        -moz-background-size: cover;
        -o-background-size: cover;
        background-size: cover;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color:#19669C; margin:-10px 20%; height:1000px; color:#BFFDFC;">
        <asp:Button ID="btnPlay" runat="server" Text="PlayNow" BackColor="#BFFDFC" 
            style=" margin:5%; border-radius:10px;" Width="150px" Height="50px" 
            Font-Size="XX-Large" onclick="btnPlay_Click" />
        <div>
            <asp:Panel ID="Panel1" runat="server" Visible = "false" BackColor="Transparent" 
                BorderColor="#BFFDFC" BorderStyle="Dashed" style="border-radius:10px; margin:1% 5%; padding:2%;">

                Random Number:
                <asp:TextBox ID="txtRandom" runat="server" Text = "?" ReadOnly="true" style="background-color:Transparent; border-radius:10px; height:30px; width:50px; color:#BFFDFC; font-size:20px; font-weight:bold; text-align:center;"></asp:TextBox>

                <br />
                Choose Number between 1 to 100: 
                <asp:TextBox ID="txtNumber" runat="server" style="background-color:Transparent; border-radius:10px; height:30px; width:50px; color:#BFFDFC; font-size:20px; font-weight:bold; text-align:center;"></asp:TextBox>

                 <asp:Button ID="btnTry" runat="server" Text="Try Your Luck" BackColor="#BFFDFC" 
                style=" margin:5%; border-radius:10px;" Width="150px" Height="30px" 
                Font-Size="Large" OnClick="btnTry_Click" />
                <br />
                <asp:Label ID="lblMsg" runat="server" Text="" style="font-size:20px;"></asp:Label>

            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server" Visible = "false" BackColor="Transparent" 
                BorderColor="#BFFDFC" BorderStyle="Dashed" style="border-radius:10px; margin:1% 5%; padding:2%;">

                You have a High Score:
                <asp:TextBox ID="txtHighScore" runat="server" Text = "" ReadOnly="true" style="background-color:Transparent; border-radius:10px; height:30px; width:50px; color:#BFFDFC; font-size:20px; font-weight:bold; text-align:center;"></asp:TextBox>

                <br />
                Enter Your NickName: 
                <asp:TextBox ID="txtNickName" runat="server" style="background-color:Transparent; border-radius:10px; height:30px; width:50px; color:#BFFDFC; font-size:20px; font-weight:bold; text-align:center;"></asp:TextBox>

                 <asp:Button ID="btnSaveHighScore" runat="server" Text="Save High Score" BackColor="#BFFDFC" 
                style=" margin:5%; border-radius:10px;" Width="150px" Height="30px" 
                Font-Size="Large" OnClick="btnSaveHighScore_Click" />

                <br />
                <asp:Label ID="lblScore" runat="server" Text=""></asp:Label>
            </asp:Panel>

        </div>
    </div>
    </form>
</body>
</html>
