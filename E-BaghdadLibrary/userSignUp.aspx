<%@ Page Title="Sign up" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userSignUp.aspx.cs" Inherits="ELibrary.userSignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                           <h4>User Registration</h4>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxFullName" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxDateOfBirth" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxContactNo" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxEmailId" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownListState" runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Erbil" Value="Erbil" />
                                        <asp:ListItem Text="Anbar" Value="Anbar" />
                                        <asp:ListItem Text="Babylon" Value="Babylon" />
                                        <asp:ListItem Text="Baghdad" Value="Baghdad" />
                                        <asp:ListItem Text="Basra" Value="Basra" />
                                        <asp:ListItem Text="Dohuk" Value="Dohuk" />
                                        <asp:ListItem Text="Diwaniyah" Value="Diwaniyah" />
                                        <asp:ListItem Text="Dhi Qar" Value="Dhi Qar" />
                                        <asp:ListItem Text="Sulaymaniyah" Value="Sulaymaniyah" />
                                        <asp:ListItem Text="Salahaddin" Value="Salahaddin" />
                                        <asp:ListItem Text="Kirkuk" Value="Kirkuk" />
                                        <asp:ListItem Text="Karbala" Value="Karbala" />
                                        <asp:ListItem Text="Almuthana" Value="Almuthana" />
                                        <asp:ListItem Text="Maysan" Value="Maysan" />
                                        <asp:ListItem Text="Najaf" Value="Najaf" />
                                        <asp:ListItem Text="Nineveh" Value="Nineveh" />
                                        <asp:ListItem Text="Wasit" Value="Wasit" />
                                         
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBoxCity" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBoxPinCode" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxFullAddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                             <span class="badge badge-pill badge-info">Login Credentials</span>
                         </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBoxMemberId" runat="server" placeholder="User ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBoxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="ButtonSignUp" runat="server" Text="Sign Up" OnClick="ButtonSignUp_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>

        </div>
    </div>

</asp:Content>
