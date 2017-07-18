<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="WebForm1.aspx.cs" Inherits="LaundryMangement.Pages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Testing!</title>
    <script type="text/javascript" src="../Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript">
        var PageData = "";

        function Load() {
            alert(PageData);
            var Data = $("#Txt_Input").val();
            PageData = Data;
            $.ajax({
                type: "POST"
                , url: "<%= this.Request.Url.AbsoluteUri %>"
                , data:
                    "IsAjax=1&Cmd=Load"
                , success:
                    function Load_Success(Data) {
                        $("#Main").html(Data);                        
                    }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="Txt_Input" />
        <button onclick="Load(); return false;">
            Click Here!
        </button>
        <div id="Main" />
    </form>
</body>
</html>
