<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="z2z.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>z2z - Dashboard</title>
        <link href="styles/testCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
        <div class="tramColumn">
            <div class="heading">
                <h2>Categories</h2>
            </div>
            <div class="category" id="catAdmin"><h3>Admin</h3></div>
            <div class="category" id="catClient">
                <h3>Clients</h3>
            </div>
            <div class="category" id="catContibutor">
                <h3>Contributors</h3>
            </div>
            <div class="category" id="catService"><h3>Services</h3></div>
            <div class="category" id="catLanguage"><h3>Languages</h3></div>
        </div>
        <div class="navColumn">
            <div class="heading">
                <h2>Navigation</h2>
            </div>
        </div>
        <div class="tramColumn">
            <div class="heading">
                <h2>Properties</h2>
            </div>
        </div>
    </div>
    </form>
    
      <%--Scripts--%>
        <script type="text/javascript" src="scripts/jquery-1.10.1.min.js"></script>  
      <script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>
    <script src="http://mbostock.github.com/d3/d3.layout.js?2.7.1"></script>
<%--    <script type="text/javascript" src="scripts/d3.v3.js"></script>--%>
      <script type="text/javascript" src="scripts/z2z.js"></script>
</body>
</html>
