<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_ThemDonHang.aspx.cs" Inherits="admin_page_QuanLyDonHang_module_ThemDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <style> 
        #btnAdd{
            align-items: center;
            background-image: linear-gradient(144deg,#AF40FF, #5B42F3 50%,#00DDEB);
            border: 0;
            border-radius: 8px;
            box-shadow: rgba(151, 65, 252, 0.2) 0 15px 30px -5px;
            box-sizing: border-box;
            color: #FFFFFF;
            display: flex;
            font-family: Phantomsans, sans-serif;
            font-size: 20px;
            justify-content: center;
            line-height: 1em;
            max-width: 100%;
            min-width: 140px;
            padding: 3px;
            text-decoration: none;
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
            white-space: nowrap;
            cursor: pointer;
            margin-top:5%;
        }
        #btnAdd:active,
        #btnAdd:hover {
            outline: 0;
        }
        #btnAdd span {
            background-color: rgb(5, 6, 45);
            padding: 16px 24px;
            border-radius: 6px;
            width: 100%;
            height: 100%;
            transition: 300ms;
        }
        #btnAdd:hover span {
            background: none;
        }
        @media (min-width: 768px) {
            #btnAdd {
                font-size: 24px;
                min-width: 196px;
            }
        }
        
        

        #bodyCart >div >select{
            margin:10px;
            border-radius: 10px;
            height: 33.2px;
        }
        #bodyCart >div >input{
            margin:10px;
            
        }
        #bodyCart >div >button{
            margin:20px;
            width:4rem;
            align-self: center;
  background-color: #fff;
  background-image: none;
  background-position: 0 90%;
  background-repeat: repeat no-repeat;
  background-size: 4px 3px;
  border-radius: 15px 225px 255px 15px 15px 255px 225px 15px;
  border-style: solid;
  border-width: 2px;
  box-shadow: rgba(0, 0, 0, .2) 15px 28px 25px -18px;
  box-sizing: border-box;
  color: #41403e;
  cursor: pointer;
  display: inline-block;
  font-family: Neucha, sans-serif;
  font-size: 1rem;
  line-height: 23px;
  outline: none;
  padding: .75rem;
  text-decoration: none;
  transition: all 235ms ease-in-out;
  border-bottom-left-radius: 15px 255px;
  border-bottom-right-radius: 225px 15px;
  border-top-left-radius: 255px 15px;
  border-top-right-radius: 15px 225px;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
        }
        #bodyCart >div >button:hover {
  box-shadow: rgba(0, 0, 0, .3) 2px 8px 8px -5px;
  transform: translate3d(0, 2px, 0);
}
        #bodyCart >div >button:focus {
  box-shadow: rgba(0, 0, 0, .3) 2px 8px 4px -6px;
}

        #sum{
            margin:20px;            
        }
        #ContentPlaceHolder1_txtTong{
            text-align:right;
        }
    </style>

    <div id="cont">
        <button id="btnAdd" type="button" onclick="btnAddInput()"><span class="text">+ Thêm đơn hàng</span></button>
        <formview id="cont3">

        

        <div id="bodyCart"></div>

        <div>
            <label id="sum">Tổng tiền</label>
            <input type="text" id="txtTong" runat="server"/>
            <button style="margin-left:10rem" type="button" class="btn btn-primary" onclick="btnThem()">Lưu</button>
        </div>

        <div class="d-none">
            <button id="save" runat="server" onserverclick="save_ServerClick"></button>

            <input type="text" id="txtIdProductsSelect" runat="server" />
            <input type="text" id="txtQuantitysProducts" runat="server" />
            <input type="text" runat="server" id="txtProductsName" />
            <input type="text" runat="server" id="txtProductsId" />
            <input type="text" runat="server" id="txtProductsPrice" />
        </div>

    </formview>
    </div>
    
    <script>

        const bodyCart = document.getElementById("bodyCart");

        let count = 0;

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

        function btnThem() {

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

