<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_SuaDonHang.aspx.cs" Inherits="admin_page_QuanLyDonHang_module_SuaDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <button id="btnAdd" type="button" onclick="btnAddInput()">+Thêm đơn hàng</button>

    <formview>

        <button type="button" class="btn btn-primary" onclick="btnSua()">Lưu</button>

        <div id="bodyCart"></div>

        <input type="text" id="txtTong" runat="server"/>

        <div class="d-none">
            <button id="save" runat="server" onserverclick="save_ServerClick"></button>

            <input type="text" id="txtIdProductsSelect" runat="server" />
            <input type="text" id="txtQuantitysProducts" runat="server" />

            <input type="text" runat="server" id="txtQuantityOnServer" />
            <input type="text" runat="server" id="txtProductsNameOnServer" />
            <input type="text" id="txtPriceOnServer" runat="server" />

            <input type="text" runat="server" id="txtProductsName" />
            <input type="text" runat="server" id="txtProductsId" />
            <input type="text" runat="server" id="txtProductsPrice" />
        </div>

    </formview>
    <script>

        const bodyCart = document.getElementById("bodyCart");

        var count = document.getElementById("<%=txtProductsNameOnServer.ClientID%>").value.split(',').length

        $(document).ready(function () {
            //Create array of options to be added
            let arrNameProduct = document.getElementById("<%=txtProductsName.ClientID%>").value.split(',')
            let arrIdProduct = document.getElementById("<%=txtProductsId.ClientID%>").value.split(',')

            let arrQuantityOnServer = document.getElementById("<%=txtQuantityOnServer.ClientID%>").value.split(',')
            let arrLengthProductsOnServer = document.getElementById("<%=txtProductsNameOnServer.ClientID%>").value.split(',')
            let arrPriceProductOnServer = document.getElementById("<%=txtPriceOnServer.ClientID%>").value.split(',')

            for (var i = 0; i < arrLengthProductsOnServer.length; i++) {
                var divMain = document.createElement("div")
                divMain.setAttribute("id", "divSelector_" + (i + 1))
                bodyCart.appendChild(divMain)
                //Create and append select list
                var selectList = document.createElement("select");
                selectList.setAttribute("id", "select_" + (i + 1));
                selectList.setAttribute("onchange", "funcChange(" + (i + 1) + ")");
                divMain.appendChild(selectList);
                for (var j = 0; j < arrNameProduct.length; j++) {
                    //Create and append the options
                    var option = document.createElement("option");
                    option.setAttribute("value", arrIdProduct[j]);
                    option.text = arrNameProduct[j];

                    if (arrLengthProductsOnServer[i] == arrNameProduct[j])
                        option.setAttribute("selected", "selected");

                    selectList.appendChild(option);
                }
                var x = document.createElement("input");
                x.setAttribute("type", "number");
                x.setAttribute("placeholder", "Số lượng");
                x.setAttribute("id", "txtSoLuong_" + (i + 1));
                x.setAttribute("min", 1);
                x.setAttribute("onchange", "funcChange(" + (i + 1) + ")");
                x.value = arrQuantityOnServer[i]
                divMain.appendChild(x);

                var y = document.createElement("input");
                y.setAttribute("type", "number");
                y.setAttribute("name", "moneyProducts");
                y.readOnly = true;
                y.setAttribute("placeholder", "Thành tiền");
                y.setAttribute("id", "txtThanhTien_" + (i + 1));
                y.value = parseFloat(arrPriceProductOnServer[i] * arrQuantityOnServer[i])
                divMain.appendChild(y);

                var btn = document.createElement("button")
                btn.innerHTML = "Xóa"
                btn.setAttribute("id", "btnDel_" + (i + 1));
                btn.setAttribute("onclick", "funcDel(" + (i + 1) + ")")
                divMain.appendChild(btn);

            }

            var arr = document.getElementsByName('moneyProducts');
            var total = 0;
            for (var i = 0; i < arr.length; i++) {
                if (parseInt(arr[i].value))
                    total += parseInt(arr[i].value);
            }
            document.getElementById("<%=txtTong.ClientID%>").value = total;
        })

        function btnAddInput() {

            count += 1;

            //Create array of options to be added
            let arrNameProduct = document.getElementById("<%=txtProductsName.ClientID%>").value.split(',')
            let arrIdProduct = document.getElementById("<%=txtProductsId.ClientID%>").value.split(',')

            var divMain = document.createElement("div")
            divMain.setAttribute("id", "divSelector_" + count)
            bodyCart.appendChild(divMain)
            //Create and append select list
            var selectList = document.createElement("select");
            selectList.setAttribute("id", "select_" + count);
            selectList.setAttribute("onchange", "funcChange(" + count + ")");
            divMain.appendChild(selectList);

            //Create and append the options
            for (var i = 0; i < arrNameProduct.length; i++) {
                var option = document.createElement("option");
                option.setAttribute("value", arrIdProduct[i]);
                option.text = arrNameProduct[i];
                selectList.appendChild(option);
            }

            var x = document.createElement("input");
            x.setAttribute("type", "number");
            x.setAttribute("placeholder", "Số lượng");
            x.setAttribute("id", "txtSoLuong_" + count);
            x.setAttribute("min", 1);
            x.setAttribute("onchange", "funcChange(" + count + ")");
            divMain.appendChild(x);

            var y = document.createElement("input");
            y.setAttribute("type", "number");
            y.setAttribute("name", "moneyProducts");
            y.readOnly = true;
            y.setAttribute("placeholder", "Thành tiền");
            y.setAttribute("id", "txtThanhTien_" + count);
            divMain.appendChild(y);

            var btn = document.createElement("button")
            btn.innerHTML = "Xóa"
            btn.setAttribute("id", "btnDel_" + count);
            btn.setAttribute("onclick", "funcDel(" + count + ")")
            divMain.appendChild(btn);
        }

        function funcDel(count) {
            document.getElementById("divSelector_" + count).remove();
        }

        function funcChange(count) {
            let arrPriceProduct = document.getElementById("<%=txtProductsPrice.ClientID%>").value.split(',')
            let arrIdProduct = document.getElementById("<%=txtProductsId.ClientID%>").value.split(',')

            let elementSoLuong = document.getElementById("txtSoLuong_" + count).value
            let selectOptions = document.getElementById("select_" + count).value

            var price = 0;

            for (var i = 0; i < arrIdProduct.length; i++) {
                if (selectOptions == arrIdProduct[i])
                    price = arrPriceProduct[i]
            }

            document.getElementById("txtThanhTien_" + count).value = price * elementSoLuong

            var arr = document.getElementsByName('moneyProducts');
            var total = 0;
            for (var i = 0; i < arr.length; i++) {
                if (parseInt(arr[i].value))
                    total += parseInt(arr[i].value);
            }
            document.getElementById("<%=txtTong.ClientID%>").value = total;
        }

        function btnSua() {

            var select = document.querySelectorAll('[id ^= "select_"]')
            var quantity = document.querySelectorAll('[id ^= "txtSoLuong_"]')

            var arrIdProducts = []
            var arrQuantitys = []

            for (var i = 0; i < select.length; i++) {
                arrIdProducts.push(select[i].value)
                arrQuantitys.push(quantity[i].value)
            }

            document.getElementById("<%=txtQuantitysProducts.ClientID%>").value = arrQuantitys
            document.getElementById("<%=txtIdProductsSelect.ClientID%>").value = arrIdProducts
            document.getElementById('<%=save.ClientID%>').click()
        }
    </script>

</asp:Content>

