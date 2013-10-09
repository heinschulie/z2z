<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileUploadExample.aspx.cs" Inherits="z2z.fileUploadExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script type="text/javascript" src="scripts/jquery-1.10.1.min.js"></script>  
      <script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>
      <script type="text/javascript" src="scripts/test.js"></script>
</head>
<body>
    <form id="form1" enctype="multipart/form-data" method="post" action="Upload.aspx">
    <div class="row">
      <label for="fileToUpload">Select a File to Upload</label><br />
      <input type="file" name="fileToUpload" id="fileToUpload" onchange="fileSelected();"/>
    </div>
    <div id="fileName"></div>
    <div id="fileSize"></div>
    <div id="fileType"></div>
    <div class="row">
      <input type="button" onclick="uploadFile()" value="Upload" />
    </div>
    <div id="progressNumber"></div>
  </form>
</body>
</html>
