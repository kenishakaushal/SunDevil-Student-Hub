<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="SunDevilStudentHub.Staff.StaffPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Portal — SunDevil Student Hub</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #F5F5F5; }
        .header { background-color: #8C1D40; color: white; padding: 20px 30px; }
        .header h1 { margin: 0; font-size: 24px; }
        .header p { margin: 5px 0 0; font-size: 14px; color: #FFC627; }
        .content { max-width: 960px; margin: 20px auto; padding: 20px; }
        .card { background: white; border-radius: 8px; padding: 20px; margin-bottom: 20px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); }
        .card h2 { color: #8C1D40; margin-top: 0; font-size: 18px; }
        table { width: 100%; border-collapse: collapse; margin-top: 10px; }
        th { background-color: #8C1D40; color: white; padding: 10px; text-align: left; }
        td { padding: 8px 10px; border-bottom: 1px solid #ddd; }
        tr:nth-child(even) { background-color: #f9f9f9; }
        .btn { padding: 8px 16px; border: none; border-radius: 4px; cursor: pointer; font-size: 13px; margin: 4px; }
        .btn-primary { background-color: #8C1D40; color: white; }
        .btn-gold { background-color: #FFC627; color: #333; }
        .btn-logout { background-color: #666; color: white; }
        .info-label { background-color: #E8F5E9; padding: 8px 12px; border-radius: 4px; margin: 5px 0; display: inline-block; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>☀ Staff Portal — SunDevil Student Hub</h1>
            <p>Authorized staff access only</p>
        </div>

        <div class="content">
            <!-- Greeting -->
            <div class="card">
                <h2>Welcome</h2>
                <asp:Label ID="lblGreeting" runat="server" Font-Size="15px" />
                <br /><br />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-logout" OnClick="btnLogout_Click" />
                <asp:Button ID="btnHome" runat="server" Text="Back to Home" CssClass="btn btn-gold" OnClick="btnHome_Click" />
            </div>

            <!-- Registered Members Viewer -->
            <div class="card">
                <h2>Registered Members</h2>
                <p>View all members who have registered through the Member portal.</p>
                <asp:Button ID="btnLoadMembers" runat="server" Text="Load Members from XML" CssClass="btn btn-primary" OnClick="btnLoadMembers_Click" />
                <br /><br />
                <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="False"
                    CellPadding="6" GridLines="Horizontal" Width="100%"
                    HeaderStyle-BackColor="#8C1D40" HeaderStyle-ForeColor="White">
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="Username" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="interest" HeaderText="Interest" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMemberStatus" runat="server" ForeColor="Gray" Font-Size="12px" />
            </div>

            <!-- Announcements Manager -->
            <div class="card">
                <h2>Announcements</h2>
                <p>View and manage announcements stored in Announcements.xml.</p>
                <asp:Button ID="btnLoadAnnouncements" runat="server" Text="Load Announcements" CssClass="btn btn-primary" OnClick="btnLoadAnnouncements_Click" />
                <br /><br />
                <asp:GridView ID="gvAnnouncements" runat="server" AutoGenerateColumns="False"
                    CellPadding="6" GridLines="Horizontal" Width="100%"
                    HeaderStyle-BackColor="#8C1D40" HeaderStyle-ForeColor="White">
                    <Columns>
                        <asp:BoundField DataField="title" HeaderText="Title" />
                        <asp:BoundField DataField="message" HeaderText="Message" />
                    </Columns>
                </asp:GridView>

                <br />
                <asp:Label ID="lblAnnouncementTitle" runat="server" Text="Title:" Font-Size="13px" /><br />
                <asp:TextBox ID="txtAnnouncementTitle" runat="server" Width="300px" /><br />
                <asp:Label ID="lblAnnouncementMsg" runat="server" Text="Message:" Font-Size="13px" /><br />
                <asp:TextBox ID="txtAnnouncementMsg" runat="server" Width="300px" TextMode="MultiLine" Rows="3" /><br /><br />
                <asp:Button ID="btnAddAnnouncement" runat="server" Text="Add Announcement" CssClass="btn btn-primary" OnClick="btnAddAnnouncement_Click" />
                <asp:Label ID="lblAnnouncementStatus" runat="server" ForeColor="Green" Font-Size="12px" />
            </div>

            <!-- Staff Service Testing -->
            <div class="card">
                <h2>Service Testing (Staff)</h2>
                <p>Test the CampusResourceService from the staff portal.</p>
                <asp:Label ID="lblCategoryInput" runat="server" Text="Category:" Font-Size="13px" />
                <asp:TextBox ID="txtCategory" runat="server" Width="200px" />&nbsp;
                <asp:Button ID="btnTestService" runat="server" Text="Test CampusResourceService" CssClass="btn btn-primary" OnClick="btnTestService_Click" /><br /><br />
                <asp:Label ID="lblServiceOutput" runat="server" CssClass="info-label" />
            </div>
        </div>
    </form>
</body>
</html>
