<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyNest.aspx.cs" Inherits="DatingSite.Web_Forms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <link href="~/Styling/Theme.css" rel="stylesheet" />
    <title>Plenty of Finch</title>
</head>
<body>
    <form id="mynest" runat="server" class="d-flex flex-column min-vh-100 mb-0">
        <nav class='navbar navbar-expand navbar-dark custom-nav mb-4'>
            <div class='container'>
                <a class='navbar-brand' href='Search.aspx'>Plenty of Finch</a>
                <ul class='navbar-nav ms-auto flex-row'>
                    <li class='nav-item'>
                        <a class='nav-link px-3' href='index.html'>Home</a>
                    </li>
                    <li class='nav-item'>
                        <a class='nav-link px-3' href='Search.aspx'>Find Flocks</a>
                    </li>
                    <li class='nav-item'>
                        <a class='nav-link px-3 active' href='MyNest.aspx'>My Nest</a>
                    </li>
                    <li class='nav-item'>
                        <a class='nav-link px-3' href='MyProfile.aspx'>My Profile</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="container my-4 flex-grow-1">

            <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3 fw-bold text-success text-center"></asp:Label>

            <div class="card p-4 mx-auto mb-4" style="max-width: 900px; background-color: #1e293b; border: 2px solid #334155;">
                <h3 class="text-center mb-4" style="color: #ef4444;">My Nest</h3>
                <p class="text-center" style="color: #94a3b8;">These are the birds you've saved to your flock.</p>
                <asp:Literal ID="litNestBirds" runat="server"></asp:Literal>
            </div>

            <div class="card p-4 mx-auto mb-4" style="max-width: 900px; background-color: #1e293b; border: 2px solid #334155;">
                <h3 class="text-center mb-4" style="color: #ef4444;">Upcoming Dates</h3>
                <p class="text-center" style="color: #94a3b8;">Birds who accepted your date request or whose request you accepted.</p>
                <asp:Literal ID="litUpcomingDates" runat="server"></asp:Literal>
            </div>

            <div class="card p-4 mx-auto mb-4" style="max-width: 900px; background-color: #1e293b; border: 2px solid #334155;">
                <h3 class="text-center mb-4" style="color: #ef4444;">Plan a Date</h3>
                <p class="text-center" style="color: #94a3b8;">Select a matched bird and set up a date.</p>

                <div class="row g-3">
                    <div class="col-md-6">
                        <label class="form-label" style="color: #f8fafc;">Choose a Match</label>
                        <asp:DropDownList ID="ddlDateMatch" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label" style="color: #f8fafc;">Date &amp; Time</label>
                        <asp:TextBox ID="txtDateTime" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label" style="color: #f8fafc;">Location</label>
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" placeholder="Rittenhouse Square Park"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label" style="color: #f8fafc;">Description</label>
                        <asp:TextBox ID="txtDateDescription" runat="server" CssClass="form-control" placeholder="Sunset birdwatching by the river"></asp:TextBox>
                    </div>
                    <div class="col-12">
                        <asp:Button ID="btnPlanDate" runat="server" Text="Plan This Date"
                            CssClass="btn fw-bold w-100" Style="background-color: #ef4444; color: white;"
                            OnClick="btnPlanDate_Click" />
                    </div>
                </div>
            </div>

            <div class="card p-4 mx-auto mb-4" style="max-width: 900px; background-color: #1e293b; border: 2px solid #334155;">
                <h3 class="text-center mb-4" style="color: #ef4444;">Planned Dates</h3>
                <asp:Literal ID="litPlannedDates" runat="server"></asp:Literal>
            </div>

        </div>

        <footer class='mt-auto py-2'>
            <div class='container'>
                <div class='row'>
                    <div class='col-md-5 mb-3'>
                        <h5>Plenty of Finch</h5>
                        <p class='text-muted small'>No Catfish. Just Finches.</p>
                    </div>
                    <div class='col-md-3 mb-3'>
                        <h5>Explore</h5>
                        <ul class='list-unstyled'>
                            <li><a href='Search.aspx'>Search Flocks</a></li>
                            <li><a href='MyNest.aspx'>My Nest</a></li>
                            <li><a href='Register.aspx'>Register</a></li>
                            <li><a href='MyProfile.aspx'>Profile</a></li>

                        </ul>
                    </div>
                    <div class='col-md-4 mb-3'>
                        <h5>Project Info</h5>
                        <ul class='list-unstyled text-muted small'>
                            <li>CIS 3342 - Project 2</li>
                            <li>Spring 2026</li>
                            <li>&copy; Amelia Edgar</li>
                        </ul>
                    </div>
                </div>
            </div>
        </footer>

    </form>
</body>
</html>
