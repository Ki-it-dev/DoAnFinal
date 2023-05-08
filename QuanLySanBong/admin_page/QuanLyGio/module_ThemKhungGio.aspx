<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_ThemKhungGio.aspx.cs" Inherits="admin_page_QuanLyGio_module_ThemKhungGio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <button id="btn">+Add input</button>

    <formview>
        <div id='input-cont'>
            <input type="time" id="txtStart0" />
            <input type="time" id="txtEnd0" />
        </div>

        <button type="button" class="btn btn-primary" onclick="btnThem()">Lưu</button>

        <div class="d-none">
            <input type="text" id="timeValueArr" runat="server" name="name" value="" />
            <input type="text" id="timeStartArr" runat="server" name="name" value="" />
            <input type="text" id="timeEndArr" runat="server" name="name" value="" />
            <input type="text" id="txtCount" runat="server" name="name" value="" />
            <button id="save" runat="server" onserverclick="save_ServerClick"></button>
        </div>
    </formview>
    <script>
        const container = document.getElementById('input-cont');

        var count = 0
        // Call addInput() function on button click
        document.getElementById("btn").addEventListener("click", function (event) {
            event.preventDefault()

            const div = document.createElement('div')

            count += 1;

            let input1 = document.createElement('input');
            let input2 = document.createElement('input');

            input1.setAttribute("id", "txtStart" + count);
            input2.setAttribute("id", "txtEnd" + count);

            input1.type = "time";
            input2.type = "time";

            div.appendChild(input1);
            div.appendChild(input2);

            container.appendChild(div)

        });

        function btnThem() {
            document.getElementById("<%=timeValueArr.ClientID%>").value = ""

            var arrStart = []
            var arrEnd = []

            for (var i = 0; i <= count; i++) {
                var valueTimeStart = document.getElementById("txtStart" + i).value
                var valueTimeEnd = document.getElementById("txtEnd" + i).value

                if (valueTimeStart == "" || valueTimeEnd == "") return;

                if (i == count) document.getElementById("<%=timeValueArr.ClientID%>").value += valueTimeStart + "|" + valueTimeEnd
                else document.getElementById("<%=timeValueArr.ClientID%>").value += valueTimeStart + "|" + valueTimeEnd + ","

                arrStart.push(valueTimeStart)
                arrEnd.push(valueTimeEnd)
            }

            //console.log(arrStart, arrEnd)

            document.getElementById("<%=timeStartArr.ClientID%>").value = arrStart
            document.getElementById("<%=timeEndArr.ClientID%>").value = arrEnd
            document.getElementById("<%=txtCount.ClientID%>").value = count

            document.getElementById('<%=save.ClientID%>').click()
        }
    </script>
</asp:Content>

