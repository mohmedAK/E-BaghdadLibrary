<%@ Page Title="Publisher Management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminPublisherManagment.aspx.cs" Inherits="ELibrary.adminPublisherManagment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
            $(document).ready(function () {
                $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                             <div class="col">
                                <center>
                                   <h4>Publisher Details</h4>
                                </center>
                             </div>
                        </div>
                        <div class="row">
                             <div class="col">
                                <center>
                                   <img width="100px" src="imgs/publisher.png"/>
                                </center>
                             </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBoxPublisherID" runat="server" placeholder="ID"></asp:TextBox>
                                       <asp:Button ID="ButtonGo" class="btn btn-secondary" runat="server" Text="Go" OnClick="ButtonGo_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBoxPublisherName" runat="server" placeholder="Publisher Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 ">
                                <div class="form-group">
                                    <asp:Button ID="ButtonAdd" class="btn btn-success btn-lg btn-block" runat="server" Text="Add" OnClick="ButtonAdd_Click" />
                                </div>
                            </div>
                             <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button ID="ButtonUpdate" class="btn btn-primary btn-lg btn-block" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
                                </div>
                            </div>
                             <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button ID="ButtonDelete" class="btn btn-danger btn-lg btn-block" runat="server" Text="Delete" OnClick="ButtonDelete_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                 <a href="homepage.aspx"><< Back to Home</a><br><br>
            </div>
            <div class="col-md-6 ">
                <div class="card">
                    <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4>Publisher List</h4>
                                </center>
                             </div>
                          </div>

                        <div class="row">
                             <div class="col">
                                <hr />
                             </div>
                        </div>
                        
                       <div class="row">
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [tbl_publisher_master]"></asp:SqlDataSource>
                             <div class="col">
                                 <asp:GridView class="table table-striped table-hover table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                     <Columns>
                                         <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                         <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                     </Columns>
                                 </asp:GridView>
                             </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
