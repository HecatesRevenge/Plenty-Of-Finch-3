<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DatingSite.Web_Forms.Login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login - Plenty of Finch</title>
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
                        <a class="nav-link" href="index.html">Home</a>
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

    <form id="login" runat="server">
        <main class="flex-grow-1 d-flex justify-content-center align-items-center my-5">
            <div style="width: 100%; max-width: 400px; padding: 0 15px;">
                <div class="card shadow-lg p-4" style="background-color: #1e293b; border: 4px solid #334155;">

                    <div class="text-center mb-4">
                        <h2 style="color: #ef4444;">Welcome Back!</h2>
                        <p class="text" style="color: #cbd5e1 !important;">Ready To Find Your Finch?</p>
                    </div>

                    <div class="mb-3 text-center">
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold"></asp:Label>
                    </div>

                    <div class="mb-3">
                        <label for="txtUsername" class="form-label" style="color: #f8fafc;">Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                    </div>

                    <div class="mb-4">
                        <label for="txtPassword" class="form-label" style="color: #f8fafc;">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                    </div>

                    <div class="d-grid gap-2 mt-4">
                        <asp:Button ID="btnLogin" runat="server" Text="Log In" CssClass="btn fw-bold" Style="background-color: #ef4444; color: white;" OnClick="btnLogin_Click" />
                    </div>

                    <div class="text-center mt-3">
                        <small style="color: #cbd5e1;">Don't have an account? <a href="Register.aspx" style="color: #f87171; text-decoration: none;">Sign up here</a></small>
                    </div>

                </div>
            </div>
        </main>
    </form>


    <footer class='mt-auto py-2'>
        <div class='container'>
            <div class='row'>
                <div class='col-md-5 mb-1'>
                    <h5>Plenty of Finch</h5>
                    <p class='text small'>
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
                    <ul class='list-unstyled text small'>
                        <li>CIS 3342 - Project 2</li>
                        <li>Spring 2026</li>
                        <li>&copy; [Amelia Edgar]</li>
                    </ul>
                </div>
            </div>
        </div>
    </footer>
</body>
</html>
