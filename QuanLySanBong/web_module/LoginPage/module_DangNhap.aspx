<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_DangNhap.aspx.cs" Inherits="web_module_module_DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="index">
        <div class="d-flex justify-content-center align-items-center" style="padding-top: 10vh">
            <div id="login-form">
                <!-- Pills navs -->
                <ul class="nav nav-pills nav-justified mb-3" id="ex1" rrpquanaoole="tablist">
                    <li class="nav-item" role="presentation">
                        <a class="nav-link active" id="tab-login" data-mdb-toggle="pill" href="#pills-login" role="tab"
                            aria-controls="pills-login" aria-selected="true">Đăng nhập</a>
                    </li>
                    <li class="nav-item" role="presentation">
                        <a class="nav-link" id="tab-register" data-mdb-toggle="pill" href="#pills-register" role="tab"
                            aria-controls="pills-register" aria-selected="false">Đăng ký</a>
                    </li>
                </ul>
                <!-- Pills navs -->

                <!-- Pills content -->
                <div class="tab-content">
                    <div class="tab-pane fade show active" id="pills-login" role="tabpanel" aria-labelledby="tab-login">
                        <div class="text-center mb-3">
                            <p>Đăng nhập với:</p>

                            <button type="button" class="btn btn-link btn-floating mx-1">
                                <i class="fab fa-facebook-f"></i>
                            </button>

                            <button type="button" class="btn btn-link btn-floating mx-1">
                                <i class="fab fa-google"></i>
                            </button>

                            <button type="button" class="btn btn-link btn-floating mx-1">
                                <i class="fab fa-twitter"></i>
                            </button>

                            <button type="button" class="btn btn-link btn-floating mx-1">
                                <i class="fab fa-github"></i>
                            </button>
                        </div>

                        <p class="text-center">Hoặc:</p>

                        <!-- Email input -->
                        <div class="form-outline mb-4">
                            <input type="text" id="loginName" runat="server" class="form-control" />
                            <label class="form-label" for="loginName">Tài khoản</label>
                        </div>

                        <!-- Password input -->
                        <div class="form-outline mb-4">
                            <input type="password" id="loginPassword" runat="server" class="form-control" />
                            <label class="form-label" for="loginPassword">Mật khẩu</label>
                        </div>

                        <%--2 column grid layout--%>
                        <div class="row mb-4">
                            <div class="col-md-6 d-flex justify-content-center">
                                <div class="form-check mb-3 mb-md-0">
                                    <input class="form-check-input" type="checkbox" value="" id="loginCheck" checked />
                                    <label class="form-check-label" for="loginCheck">Ghi nhớ đăng nhập </label>
                                </div>
                            </div>

                            <div class="col-md-6 d-flex justify-content-center">
                                <a href="/quen-mat-khau">Quên mật khẩu?</a>
                            </div>
                        </div>

                        <!-- Submit button -->
                        <button type="submit" id="btnLogin" runat="server" onserverclick="btnLogin_ServerClick" class="btn btn-primary btn-block mb-4">Đăng nhập</button>

                        <!-- Register buttons 
                                <div class="text-center">
                                    <p>Not a member? <a href="#!">Register</a></p>
                                </div>-->
                    </div>
                    <div class="tab-pane fade" id="pills-register" role="tabpanel" aria-labelledby="tab-register">
                        <div class="text-center mb-3">
                            <p>Đăng nhập với:</p>
                            <button type="button" class="btn btn-link btn-floating mx-1">
                                <i class="fab fa-facebook-f"></i>
                            </button>

                            <button type="button" class="btn btn-link btn-floating mx-1">
                                <i class="fab fa-google"></i>
                            </button>

                            <button type="button" class="btn btn-link btn-floating mx-1">
                                <i class="fab fa-twitter"></i>
                            </button>

                            <button type="button" class="btn btn-link btn-floating mx-1">
                                <i class="fab fa-github"></i>
                            </button>
                        </div>

                        <p class="text-center">or:</p>
                        <div class="row">
                            <div class="col-md-6">
                                <!-- Username input -->
                                <div class="form-outline mb-2">
                                    <input type="text" id="registerUsername" runat="server" class="form-control" />
                                    <label class="form-label" for="registerUsername">Tài khoản</label>
                                </div>

                                <!-- Password input -->
                                <div class="form-outline mb-2">
                                    <input type="password" id="registerPassword" runat="server" class="form-control" />
                                    <label class="form-label" for="registerPassword">Mật khẩu</label>
                                </div>
                                <!-- Repeat Password input -->
                                <div class="form-outline mb-2">
                                    <input type="password" id="registerRepeatPassword" runat="server" class="form-control" />
                                    <label class="form-label" for="registerRepeatPassword">Nhập lại mật khẩu</label>
                                </div>
                                <!-- Phone numbers input -->
                                <div class="form-outline mb-2">
                                    <input type="text" id="phoneNumbers" runat="server" class="form-control" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*?)\..*/g, '$1');" />
                                    <label class="form-label" for="phoneNumbers">Số điện thoại</label>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <!-- Name input -->
                                <div class="form-outline mb-2">
                                    <input type="text" id="registerName" runat="server" class="form-control" />
                                    <label class="form-label" for="registerName">Họ và tên</label>
                                </div>
                                
                                <div class="form-outline mb-2">
                                    <input type="email" id="registerEmail" runat="server" class="form-control" />
                                    <label class="form-label" for="registerEmail">Email</label>
                                </div>

                                <asp:RegularExpressionValidator ID="validateEmail"
                                    runat="server" ErrorMessage="Invalid email." ForeColor="red"
                                    ControlToValidate="registerEmail"
                                    ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                            </div>

                        </div>


                        <!-- Checkbox -->
                        <div class="form-check d-flex justify-content-start mb-2">
                            <input class="form-check-input me-2" type="checkbox" value="" id="registerCheck" checked
                                aria-describedby="registerCheckHelpText" />
                            <label class="form-check-label" for="registerCheck">
                                Tôi đã đọc và đồng ý với điều khoản
                            </label>
                        </div>

                        <!-- Submit button -->
                        <button type="submit" id="btnRegister" runat="server" onserverclick="btnRegister_ServerClick" class="btn btn-primary btn-block mb-3">Đăng ký</button>
                    </div>
                </div>
                <!-- Pills content -->
            </div>
        </div>
    </div>
</asp:Content>

