<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProteinTracker.aspx.cs" Inherits="ProteinTrackerClientWebAjax.ProteinTracker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        // ADD ALL JAVASCRIPT FUNCITONS HERE
        function AddUser() {
            var name = $("Name").val();
            
        }

        function PopulateSelectUsers() {
            // do stuff here
        }

        // Ajax
        $.ajax({
            type: "POST",
            url: "ProtenTracker.aspx/AddUser",
            data: JSON.stringify({ 'name': name, 'goal': goal }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: PopulateSelectUsers
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select id ="select-user"></select>
    </div>
    </form>
</body>
</html>
