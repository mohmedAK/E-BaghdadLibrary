<%@ Page Title="FeedBack" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="ELibrary.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxName" runat="server" placeholder="Name" ></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxEmailID" runat="server" TextMode="Email" placeholder="Email ID" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                             <div class="col">
                                <label>Your Feedback</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxFullfeedback" TextMode="MultiLine" runat="server"    ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                             <div class="col">
                                
                                <div class="form-group">
                                    <asp:Button ID="ButtonSubmit" CssClass="btn btn-primary btn-block btn-lg " runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
