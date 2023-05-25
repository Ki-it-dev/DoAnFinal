<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_ThemKhungGio.aspx.cs" Inherits="admin_page_QuanLyGio_module_ThemKhungGio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style> 
        .tkh{
            display: flex;
            justify-content: center;
            padding-top:100px;
        }
        #btn{
            border-radius: 100px;
            box-shadow: rgba(44, 187, 99, .2) 0 -25px 18px -14px inset,rgba(44, 187, 99, .15) 0 1px 2px,rgba(44, 187, 99, .15) 0 2px 4px,rgba(44, 187, 99, .15) 0 4px 8px,rgba(44, 187, 99, .15) 0 8px 16px,rgba(44, 187, 99, .15) 0 16px 32px;
            color: #DD0000;
            cursor: pointer;
            display: inline-block;
            font-family: CerebriSans-Regular,-apple-system,system-ui,Roboto,sans-serif;
            padding: 7px 20px;
            text-align: center;
            text-decoration: none;
            transition: all 250ms;
            border: 0;
            font-size: 16px;
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
            background-color:#c2fbd7;
            margin: 15px;
            max-height:38px;
        }
        #s{
            margin:20px;
        }
        #s:hover {
            box-shadow: rgba(44,187,99,.35) 0 -25px 18px -14px inset,rgba(44,187,99,.25) 0 1px 2px,rgba(44,187,99,.25) 0 2px 4px,rgba(44,187,99,.25) 0 4px 8px,rgba(44,187,99,.25) 0 8px 16px,rgba(44,187,99,.25) 0 16px 32px;
            transform: scale(1.05) rotate(-1deg);
        }
        input{
            margin:4px;
        }
    </style>
    
    <div class="tkh">
        <button id="btn" >Thêm khung giờ</button>

    <formview >
        <div id='input-cont'>
            <input type="time" id="txtStart0" />
            <input type="time" id="txtEnd0" />
        </div>

        <button id="s" type="button" class="btn btn-primary" onclick="btnThem()">Lưu</button>

        <div class="d-none">
            <input type="text" id="timeValueArr" runat="server" name="name" value="" />
            <input type="text" id="timeStartArr" runat="server" name="name" value="" />
            <input type="text" id="timeEndArr" runat="server" name="name" value="" />
            <input type="text" id="txtCount" runat="server" name="name" value="" />
            <button id="save" runat="server" onserverclick="save_ServerClick"></button>
        </div>
    </formview>
    </div>
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

