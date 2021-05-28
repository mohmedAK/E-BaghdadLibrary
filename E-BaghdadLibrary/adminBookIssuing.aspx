<%@ Page Title="Book Issuing" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminBookIssuing.aspx.cs" Inherits="ELibrary.adminBookIssuing" %>

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
            <div class="col-md-5 ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4>Book Issuing</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                   <img width="100px" src="imgs/books.png"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxMemberID" runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxBookID" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:Button ID="ButtonGo" class="btn btn-dark" runat="server" Text="Go" OnClick="ButtonGo_Click" />
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxMemberName" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxBookName" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxStartDate" runat="server" TextMode="Date" placeholder="Member Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxEndDate" runat="server" TextMode="Date" placeholder="Book Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                         <div class="row">
                            <div class="col-md-6">
                                
                                <div class="form-group">
                                    <asp:Button ID="ButtonIssue" CssClass="btn-primary btn btn-block btn-lg" runat="server" Text="Issue" OnClick="ButtonIssue_Click" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                
                                <div class="form-group">
                                    <asp:Button ID="ButtonReturn" CssClass="btn-success btn btn-block btn-lg" runat="server" Text="Return" OnClick="ButtonReturn_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                 <a href="homepage.aspx"><< Back to Home</a><br><br>
            </div>
            <div class="col-md-7">
                 <div class="card">
                    <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4>Issued Book List</h4>
                                </center>
                             </div>
                          </div>

                        <div class="row">
                             <div class="col">
                                <hr />
                             </div>
                        </div>
                        
                       <div class="row">
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [tbl_book_issue]"></asp:SqlDataSource>
                             <div class="col">
                                 <asp:GridView class="table table-striped table-hover table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                     <Columns>
                                         <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" />
                                         <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                         <asp:BoundField DataField="book_id" HeaderText="Book Id" SortExpression="book_id" />
                                         <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                         <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                         <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
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
