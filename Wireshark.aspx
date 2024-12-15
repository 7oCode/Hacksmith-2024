<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Wireshark.aspx.cs" Inherits="HackSmith.Wireshark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-md-5 col-sm-5 md-margin-b-60">
        <div class="margin-t-50 margin-b-30">
            <h2>Analyze Wireshark</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
        </div>
        <!---<a href="#" class="btn-theme btn-theme-sm btn-white-bg text-uppercase">Upload</a>--->
        <form id="form1" runat="server">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Process" OnClick="btnAnalyze_Click" />

            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            <br />

            <asp:Label ID="MPopType" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="IsSyn" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="IsBlank" runat="server" Visible="False"></asp:Label>

        <asp:Label ID="StatusLabel" runat="server" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </form>

            <br />
            <br />
    </div>
    <div class="col-md-5 col-sm-7 col-md-offset-2">
        <!-- Accordion -->
        <!---commenta --->
        <div class="accordion">
            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingOne">
                        <h4 class="panel-title">
                            <a class="panel-title-child" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                Expert Research
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                        <div class="panel-body">
                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch.
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Accodrion -->
    </div>
</div>
    </asp:Content>