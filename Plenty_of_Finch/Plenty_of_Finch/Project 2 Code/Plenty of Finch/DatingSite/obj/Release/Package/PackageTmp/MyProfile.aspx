<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="DatingSite.MyProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Profile - Plenty of Finch</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <link href="~/Styling/Theme.css" rel="stylesheet" />
</head>
<body>
    <form id="myProfileForm" runat="server" class="d-flex flex-column min-vh-100 mb-0">
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
                        <a class='nav-link px-3' href='MyNest.aspx'>My Nest</a>
                    </li>
                    <li class='nav-item'>
                        <a class='nav-link px-3 active' href='MyProfile.aspx'>My Profile</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="container my-4 flex-grow-1">

            <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3 fw-bold text-success text-center"></asp:Label>
            <asp:Literal ID="litNotifications" runat="server"></asp:Literal>


            <div class="card p-4 mx-auto mb-4" style="max-width: 900px; background-color: #1e293b; border: 2px solid #334155;">
                <h3 class="text-center mb-4" style="color: #ef4444;">
                    <asp:Label ID="lblPageTitle" runat="server" Text="Create Your Dating Profile"></asp:Label>
                </h3>

                <div class="row">
                    <div class="col-md-6">
                        <h5 style="color: #ef4444; border-bottom: 2px solid #334155; padding-bottom: 5px;">About You</h5>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Biography</label>
                            <asp:TextBox ID="txtBiography" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Profile Image URL</label>
                            <asp:TextBox ID="txtProfileImage" runat="server" CssClass="form-control" placeholder="robin.png"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Species</label>
                            <asp:TextBox ID="txtSpecies" runat="server" CssClass="form-control" placeholder="American Robin"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Wingspan (inches)</label>
                            <asp:TextBox ID="txtWingspan" runat="server" CssClass="form-control" placeholder="14" TextMode="Number"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Plumage</label>
                            <asp:TextBox ID="txtPlumage" runat="server" CssClass="form-control" placeholder="Red and Brown"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <h5 style="color: #ef4444; border-bottom: 2px solid #334155; padding-bottom: 5px;">Preferences</h5>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Occupation</label>
                            <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control" placeholder="Worm Inspector"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Favorite Seed</label>
                            <asp:TextBox ID="txtFavoriteSeed" runat="server" CssClass="form-control" placeholder="Sunflower"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Commitment Type</label>
                            <asp:DropDownList ID="ddlCommitmentType" runat="server" CssClass="form-select">
                                <asp:ListItem Value="" Text="Select..."></asp:ListItem>
                                <asp:ListItem Value="Nest Builder" Text="Nest Builder"></asp:ListItem>
                                <asp:ListItem Value="Migratory Fling" Text="Migratory Fling"></asp:ListItem>
                                <asp:ListItem Value="Mating for Life" Text="Mating for Life"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Goals</label>
                            <asp:TextBox ID="txtGoals" runat="server" CssClass="form-control" placeholder="Find a nesting partner"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label" style="color: #f8fafc;">Preferred Age Range</label>
                            <asp:TextBox ID="txtAgeRange" runat="server" CssClass="form-control" placeholder="22-30"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:CheckBox ID="chkVisible" runat="server" Checked="true" />
                            <label class="form-label" style="color: #f8fafc;">Make my profile visible</label>
                        </div>
                    </div>
                </div>

                <h5 class="mt-3" style="color: #ef4444; border-bottom: 2px solid #334155; padding-bottom: 5px;">Likes &amp; Dislikes</h5>
                <div class="row">
                    <div class="col-md-6">
                        <label class="form-label" style="color: #f8fafc;">Likes (one per line)</label>
                        <asp:TextBox ID="txtLikes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Foraging&#10;Singing&#10;Bathing"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label" style="color: #f8fafc;">Dislikes (one per line)</label>
                        <asp:TextBox ID="txtDislikes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Cold Weather&#10;Predators"></asp:TextBox>
                    </div>
                </div>

                <div class="d-grid gap-2 mt-4">
                    <asp:Button ID="btnSaveProfile" runat="server" Text="Save Profile" CssClass="btn btn-lg fw-bold" Style="background-color: #ef4444; color: white;" OnClick="btnSaveProfile_Click" />
                </div>
            </div>

            <div class="card p-4 mx-auto mb-4" style="max-width: 900px; background-color: #1e293b; border: 2px solid #334155;">
                <h3 class="text-center mb-4" style="color: #ef4444;">Date Requests</h3>

                <h5 style="color: #f8fafc; border-bottom: 2px solid #334155; padding-bottom: 5px;">Incoming Requests</h5>
                <asp:Literal ID="litIncomingRequests" runat="server"></asp:Literal>

                <h5 class="mt-4" style="color: #f8fafc; border-bottom: 2px solid #334155; padding-bottom: 5px;">Outgoing Requests</h5>
                <asp:Literal ID="litOutgoingRequests" runat="server"></asp:Literal>
            </div>

        </div>

        <div class="card p-4 mx-auto mb-4" style="max-width: 900px; background-color: #1e293b; border: 2px solid #334155;">
            <h3 class="text-center mb-4" style="color: #ef4444;">Who Viewed My Profile</h3>
            <asp:Label ID="lblTotalProfileViews" runat="server" CssClass="text-center d-block mb-3" Style="color: #94a3b8;"></asp:Label>
            <asp:Literal ID="litProfileViewers" runat="server"></asp:Literal>
        </div>

        <div class="d-grid gap-2 mx-auto mb-4" style="max-width: 900px;">
            <asp:Button ID="btnLogout" runat="server" Text="Log Out"
                CssClass="btn btn-outline-danger btn-lg fw-bold"
                OnClick="btnLogout_Click" />
        </div>

        <footer class='mt-auto py-2'>
            <div class='container'>
                <div class='row'>
                    <div class='col-md-5 mb-3'>
                        <h5>Plenty of Finch</h5>
                        <p class='text small'>No Catfish. Just Finches.</p>
                    </div>
                    <div class='col-md-3 mb-3'>
                        <h5>Explore</h5>
                        <ul class='list-unstyled'>
                            <li><a href='index.html'>Project Page</a></li>
                            <li><a href='Search.aspx'>Search Flocks</a></li>
                            <li><a href='MyNest.aspx'>My Nest</a></li>
                            <li><a href='Register.aspx'>Register</a></li>
                            <li><a href='MyProfile.aspx'>Profile</a></li>
                        </ul>
                    </div>
                    <div class='col-md-4 mb-3'>
                        <h5>Project Info</h5>
                        <ul class='list-unstyled text small'>
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
