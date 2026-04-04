<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DatingSite.Web_Forms.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register - Plenty of Finch</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <link href="~/Styling/Theme.css" rel="stylesheet" />
</head>
<body class="bg-dark text-light d-flex flex-column min-vh-100">

    <nav class="navbar navbar-expand-lg navbar-dark" style="background-color: #0f172a; border-bottom: 2px solid #ef4444;">
        <div class="container">
            <a class="navbar-brand fw-bold" href="#" style="color: #ef4444;">Plenty of Finch</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item">
                        <a href='index.html'>Project Page</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Register.aspx">Register</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link active" href="Login.aspx">Login</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <form id="register" runat="server">
        <div class="container d-flex justify-content-center align-items-center mt-5 mb-5">

            <div class="card shadow-lg p-4" style="max-width: 800px; width: 100%; background-color: #1e293b; border: 4px solid #334155;">

                <div class="text-center mb-2">
                    <h2 style="color: #ef4444;">Join Plenty of Finch!</h2>
                    <p class="text" style="color: #f8fafc;">Create your account to find your perfect match.</p>
                </div>

                <div class="mb-3 text-center">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold"></asp:Label>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <h5 style="color: #ef4444; border-bottom: 3px solid #334155; padding-bottom: 5px;">Personal Info</h5>

                        <div class="mb-3">
                            <label for="txtFirstName" class="form-label" style="color: #f8fafc;">First Name</label>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtLastName" class="form-label" style="color: #f8fafc;">Last Name</label>
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="row">
                            <div class="col-6 mb-3">

                                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="col-6 mb-3">
                                <label for="ddlGender" class="form-label" style="color: #f8fafc;">Gender</label>
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="" Text="Select..."></asp:ListItem>
                                    <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                    <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="mb-3">
                            <label for="txtEmail" class="form-label" style="color: #f8fafc;">Email Address</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="txtPhone" class="form-label" style="color: #f8fafc;">Phone Number</label>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Phone" placeholder="(555) 867-5309"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <h5 style="color: #ef4444; border-bottom: 3px solid #334155; padding-bottom: 5px;">Location</h5>

                        <div class="mb-3">
                            <label for="txtAddress" class="form-label" style="color: #f8fafc;">Home Address</label>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="row">
                            <div class="col-8 mb-3">
                                <label for="txtCity" class="form-label" style="color: #f8fafc;">City</label>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Philadelphia"></asp:TextBox>
                            </div>

                            <div class="col-4 mb-3">
                                <label for="txtState" class="form-label" style="color: #f8fafc;">State</label>
                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" MaxLength="2" placeholder="PA"></asp:TextBox>
                            </div>
                        </div>

                        <h5 class="mt-4" style="color: #ef4444; border-bottom: 3px solid #334155; padding-bottom: 5px;">Account Details</h5>

                        <div class="mb-3">
                            <label for="txtUsername" class="form-label" style="color: #f8fafc;">Username</label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="txtPassword" class="form-label" style="color: #f8fafc;">Password</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="d-grid gap-2 mt-4">
                    <asp:Button ID="btnRegister" runat="server" Text="Create Account" CssClass="btn btn-lg fw-bold" Style="background-color: #ef4444; color: white;" OnClick="btnRegister_Click" />
                </div>

                <div class="text-center mt-3">
                    <small style="color: #cbd5e1;">Already have an account? <a href="Login.aspx" style="color: #f87171; text-decoration: none;">Log in here</a></small>
                </div>

            </div>
        </div>
    </form>
    <footer class='mt-auto py-2'>

        <div class='container'>
            <div class='row'>
                <div class='col-md-5 mb-1'>
                    <h5>Plenty of Finch</h5>
                    <p class='text-muted small'>
                        No Catfish. Just Finches.
                    </p>
                </div>

                <div class='col-md-3 mb-1'>
                    <h5>Explore</h5>
                    <ul class='list-unstyled'>

                        <li><a href='index.html'>Project Page</a></li>
                        <li><a href='Register.aspx'>Register</a></li>
                        <li><a href='Login.aspx'>Login</a></li>
                    </ul>
                </div>

                <div class='col-md-4 mb-1'>
                    <h5>Project Info</h5>
                    <ul class='list-unstyled text-muted small'>
                        <li>CIS 3342 - Project 2</li>
                        <li>Spring 2026</li>
                        <li>[Amelia Edgar]</li>
                    </ul>
                </div>

            </div>
        </div>
    </footer>
</body>
</html>
