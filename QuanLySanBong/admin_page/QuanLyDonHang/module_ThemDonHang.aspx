<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_ThemDonHang.aspx.cs" Inherits="admin_page_QuanLyDonHang_module_ThemDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <button id="btn">+Add input</button>

    <formview>
        <div class="d-flex" id='input-cont'>
            <input type="time" id="txtStart0" />
            <input type="time" id="txtEnd0" />
        </div>

        <button type="button" class="btn btn-primary" onclick="btnThem()">Lưu</button>

        <div class="">
            <button id="save" runat="server" onserverclick="save_ServerClick"></button>
        </div>
    </formview>
    <script>
        const container = document.getElementById('input-cont');
        var count = 0
        // Call addInput() function on button click
        document.getElementById("btn").addEventListener("click", function (event) {
            event.preventDefault()
            count += 1;

            let input1 = document.createElement('input');
            let input2 = document.createElement('input');

            input1.setAttribute("id", "txtStart" + count);
            input2.setAttribute("id", "txtEnd" + count);

            input1.type = "time";
            input2.type = "time";

            container.appendChild(input1);
            container.appendChild(input2);
        });

        function btnThem() {
            <%--document.getElementById("<%=timeValueArr.ClientID%>").value = ""

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

            document.getElementById('<%=save.ClientID%>').click()--%>
        }
    </script>
</asp:Content>

