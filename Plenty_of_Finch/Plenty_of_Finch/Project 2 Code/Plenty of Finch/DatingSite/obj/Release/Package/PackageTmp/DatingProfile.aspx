<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatingProfile.aspx.cs" Inherits="DatingSite.ShowProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plenty of Finch: No Catfish. Just Finches </title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <link href="~/Styling/Theme.css" rel="stylesheet" />
</head>
<body>
    <form id="profile" runat="server" class="d-flex flex-column min-vh-100 mb-0">
        <nav class='navbar navbar-expand navbar-dark custom-nav mb-4'>
            <div class='container'>
                <a class='navbar-brand' href=''>
                    <i class='bi bi-card-heading'></i>Plenty of Finch
                </a>

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
        </nav>

        <div class="container my-5 flex-grow-1">
            <div class="card bird-card p-4 mx-auto">
                <div class="row">

                    <div class="col-12 text-center border-secondary">
                        <asp:Image ID="imgProfile" runat="server"
                            CssClass="img-fluid rounded-circle mb-1 border border-3 border-danger" Style="max-width: 200px;" />

                        <h3 style="color: #334155;">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </h3>

                        <asp:Label ID="lblAge" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblGender" runat="server"></asp:Label>

                        <p class="text-muted">
                            <i class="bi bi-geo-alt"></i>
                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                        </p>

                        <div class="d-flex justify-content-center gap-3 mb-4 text-medium">

                            <div>
                                <strong style="color: #ef4444;">
                                    <asp:Label ID="lblTotalLikes" runat="server"></asp:Label>
                                </strong>Likes
                           
                            </div>
                            <div>

                                <strong style="color: #3b82f6;">
                                    <asp:Label ID="lblTotalViews" runat="server"></asp:Label>
                                </strong>Views
                           
                            </div>
                        </div>

                        <asp:Label ID="lblMessage" runat="server" CssClass="d-block mt-2 fw-bold text-success"></asp:Label>
                    </div>

                    <h6 class="text-muted mt-2 border-bottom border-secondary pb-1">About Me</h6>
                    <p>
                        <asp:TextBox ID="txtbBio" runat="server" ReadOnly="True" Rows="4" TextMode="MultiLine"
                            CssClass="form-control custom-bio-box" Style="resize: none;"></asp:TextBox>
                    </p>

                    <asp:Panel ID="pnlContactInfo" runat="server" Visible="false">

                        <h6 class="text-muted mt-3 border-bottom border-secondary pb-1">Contact Information</h6>

                        <div class="row mb-3">

                            <div class="col-sm-4">
                                <strong>Email:</strong>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </div>

                            <div class="col-sm-4">
                                <strong>Phone:</strong>
                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                            </div>

                            <div class="col-sm-4">
                                <strong>Address:</strong>
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </div>

                        </div>

                    </asp:Panel>

                    <h6 class="text-muted mt-3 border-bottom border-secondary pb-1">Likes / Dislikes</h6>

                    <div class="row">

                        <div class="col-md-6">
                            <strong class="fw-bold mb-2 d-block">Likes</strong>
                            <asp:Literal ID="litLikes" runat="server"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <strong class="fw-bold mb-2 d-block">Dislikes</strong>
                            <asp:Literal ID="litDislikes" runat="server"></asp:Literal>
                        </div>

                    </div>

                    <h6 class="text-muted mt-4 border-bottom border-secondary pb-1 pt-4">Dating Preferences</h6>

                    <div class="row mb-3">

                        <div class="col-sm-4">
                            <strong>Goals:</strong>
                            <asp:Label ID="lblGoal" runat="server"></asp:Label>
                        </div>

                        <div class="col-sm-4">
                            <strong>Commitment Type:</strong>
                            <asp:Label ID="lblCommitment" runat="server"></asp:Label>
                        </div>

                        <div class="col-sm-4">
                            <strong>Age Range:</strong>
                            <asp:Label ID="lblAgeRange" runat="server"></asp:Label>
                        </div>

                    </div>

                    <h6 class="text-muted mt-4 border-bottom border-secondary pb-1">Avian Traits</h6>

                    <div class="row">

                        <div class="col-sm-6 mb-1">
                            <strong>Species:</strong>
                            <asp:Label ID="lblSpecies" runat="server"></asp:Label>
                        </div>

                        <div class="col-sm-6 mb-1">
                            <strong>Wingspan:</strong>
                            <asp:Label ID="lblWingspan" runat="server"></asp:Label>
                        </div>

                        <div class="col-sm-6 mb-1">
                            <strong>Favorite Seed:</strong>
                            <asp:Label ID="lblSeed" runat="server"></asp:Label>
                        </div>

                        <div class="col-sm-6 mb-1">
                            <strong>Plumage:</strong>
                            <asp:Label ID="lblPlumage" runat="server"></asp:Label>
                        </div>

                        <div class="col-sm-6 mb-1">
                            <strong>Occupation:</strong>
                            <asp:Label ID="lblOccupation" runat="server"></asp:Label>
                        </div>

                    </div>

                    <div class="row mt-3">

                        <div class="col-sm-6">
                            <asp:Button ID="btnLike" runat="server" Text="Add to My Nest"
                                CssClass="btn btn-primary w-100 mt-2" OnClick="btnSave_Click" />
                        </div>

                        <div class="col-sm-6">
                            <asp:Button ID="btnRequestDate" runat="server" Text="Request a Date"
                                CssClass="btn btn-danger w-100 mt-2" OnClick="btnRequestDate_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <footer class='mt-auto py-2'>
            <div class='container'>
                <div class='row'>
                    <div class='col-md-5 mb-3'>
                        <h5>Plenty of Finch</h5>
                        <p class='text-muted small'>
                            No Catfish. Just Finches.
                        </p>
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
