<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebDemoImportFile._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">


        <h1>How to use this website to test ?</h1>
        <h2>Click FileUpload to select target( .JSON, XML) -> Click "Upload" Button -> The data will be analysised and will be added to database.</h2>

                <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Table]"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            </asp:GridView>


                    <asp:GridView ID="GridView2" runat="server" BorderStyle="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    </asp:GridView>


        </div>



        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="UploadButton" runat="server" OnClick="UploadButton_Click" Text="Upload" />
        <asp:TextBox ID="TextBoxDisplay" runat="server" Height="132px" Width="409px"></asp:TextBox>
        <asp:Label ID="RequestDataAPIsButton" runat="server" Text="RequestdataAPIs" Visible="False"></asp:Label>



        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />



    </div>




    <div class="row">


    </div>

</asp:Content>
