<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="DatingSite.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Plenty of Finch </title>
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
                        <a class="nav-link" href="Search.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="index.html">Project Page</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="MyNest.aspx">My Nest</a>
                    </li>

                    <li class='nav-item'>
                        <a class='nav-link px-3' href='MyProfile.aspx'>My Profile</a>
                    </li>

                </ul>
            </div>
        </div>
    </nav>

    <form id="search" runat="server" class="d-flex flex-column min-vh-100 mb-0">

        <div class="container my-5 flex-grow-1">

            <h2 class="mb-4" style="color: #ef4444;">Discover Your Flock</h2>
            <div class="row g-3 align-items-end">

                <div class="col-md-2">
                    <label class="text-small">State</label>
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="Filters_Changed">
                    </asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <label class="text-small">Looking For</label>
                    <asp:DropDownList ID="ddlCommitment" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="Filters_Changed">
                        <asp:ListItem Value="">Any</asp:ListItem>
                        <asp:ListItem Value="Nest Builder">Nest Builder</asp:ListItem>
                        <asp:ListItem Value="Migratory Fling">Migratory Fling</asp:ListItem>
                        <asp:ListItem Value="Mating for Life">Mating for Life</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <label class="text-small">Age</label>
                    <asp:DropDownList ID="ddlAge" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="Filters_Changed">
                        <asp:ListItem Value="">Any Age</asp:ListItem>
                        <asp:ListItem Value="1-2">Fledgling (1-2 yrs)</asp:ListItem>
                        <asp:ListItem Value="3-8">Prime Adult (3-8 yrs)</asp:ListItem>
                        <asp:ListItem Value="8-15">Wise Elder (8-15 yrs)</asp:ListItem>
                        <asp:ListItem Value="15-50">Ancient (15-50 yrs)</asp:ListItem>
                    </asp:DropDownList>
                </div>



                <div class="col-md-3">
                    <label class="text-small">Wing Span</label>
                    <asp:DropDownList ID="ddlWingspan" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="Filters_Changed">
                        <asp:ListItem Value="">Any</asp:ListItem>
                        <asp:ListItem Value="Small">Small (0-20 in)</asp:ListItem>
                        <asp:ListItem Value="Medium">Medium (20-40 in)</asp:ListItem>
                        <asp:ListItem Value="Large">Large (41+ in)</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <hr style="border-color: #ef4444; border-width: 3px; margin-top: 1.5rem; margin-bottom: 1.5rem;" />

                <asp:Literal ID="litSearch" runat="server"></asp:Literal>


            </div>

        </div>
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
                            <li><a href='Search.aspx'>Search Flocks</a></li>
                            <li><a href='MyNest.aspx'>My Nest</a></li>
                            <li><a href='Register.aspx'>Register</a></li>
                            <li><a href='MyProfile.aspx'>Profile</a></li>
                        </ul>
                    </div>

                    <div class='col-md-4 mb-1'>
                        <h5>Project Info</h5>
                        <ul class='list-unstyled text-muted small'>
                            <li>CIS 3342 - Project 2</li>
                            <li>Spring 2026</li>
                            <li>Amelia Edgar</li>
                        </ul>
                    </div>

                </div>
            </div>
        </footer>
    </form>
</body>
</html>
