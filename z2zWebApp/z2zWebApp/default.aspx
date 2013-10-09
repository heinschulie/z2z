﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Z2Z._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index Page - under construction</title>
        <link href="styles/z2z.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
        <div class="header">
            <div class="logo">
                <img src="images/z2zLogo.png" height="125" width="340"/>
            </div>
            <div class="catContainer">
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
        </div>
        <div class="properties">
            <img src="images/tree.png"/>
            <label class="lblproperty" id="circleName">This is a label</label>
            <input class="txtproperty" />
        </div>
        <div class="navigation">          
        </div>  
    </div>
    </form>

    
      <%--Scripts--%>
        <script type="text/javascript" src="scripts/jquery-1.10.1.min.js"></script>  
      <script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>
    <script src="http://mbostock.github.com/d3/d3.layout.js?2.7.1"></script>
      <script type="text/javascript" src="scripts/z2z.js"></script>
</body>
</html>
