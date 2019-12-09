var Page = {
    Init: function () {
        $.ajax({
            type: "GET",
            url: "/Module/Categories",
            data: [],
            success: function (result) {
                $("#Module-Categories").html(result);
            },
            dataType: "html"
        });
    },
    Contact: {
        Send: function () {
            var name = $("#Name").val();
            var surname = $("#Surname").val();
            var message = $("#Message").val();

            if (name && name.length < 2) {
                alert("İsim alanı 2 karakterden az olamaz!");
                return;
            }
            else if (surname && surname.length < 2) {
                alert("Soyisim alanı 2 karakterden az olamaz!");
                return;
            }
            else if (message && message.length < 3) {
                alert("Mesaj alanı 3 karakterden az olamaz!");
                return;
            }

            $("#Contact-Index-Form").hide();
            $("#Contact-Index-Sending").show();

            var data = {
                Name: name,
                Surname: surname,
                Message: message
            };

            $.ajax({
                type: "POST",
                url: "/Contact/Send",
                data: JSON.stringify(data),
                success: Page.Contact.Send_Callback,
                error: Page.Contact.Send_Callback_Error,
                dataType: "json",
                contentType: "application/json"
            });
        },
        Send_Callback: function (result) {
            $("#Contact-Index-Sending").hide();
            $("#Contact-Index-Sent").show();
            console.log(result);
        },
        Send_Callback_Error: function (request, status, error) {
            $("#Contact-Index-Sending").hide();
            $("#Contact-Index-Sent").hide();
            $("#Contact-Index-Form").show();
            alert("Validation error!");
        }
    },
    Blog: {
        New: {
            Save: function () {
                var title = $("#Title").val();
                var content = $("#Content").val();
                var categoryId = parseInt($("#Category").val());

                var data = {
                    Title: title,
                    Content: content,
                    CategoryId: categoryId
                };

                $.ajax({
                    type: "POST",
                    url: "/Blog/Add",
                    data: JSON.stringify(data),
                    success: Page.Blog.New.Save_Callback,
                    error: Page.Blog.New.Save_Callback_Error,
                    dataType: "json",
                    contentType: "application/json"
                });
            },
            Save_Callback: function (result) {
                window.location.href = "/blog/detail/" + result.id;
            },
            Save_Callback_Error: function (request, status, error) {
                console.log(request);
                console.log(status);
                console.log(error);
            }
        }
    },
    Manage: {
        Login: {
            Submit: function () {
                var email = $("#Email").val();
                var password = $("#Password").val();

                if (email.length < 6 || email.length > 345) {
                    alert("email format hatası");
                    return;
                } else if (password.length < 8 || password.length > 32) {
                    alert("şifre uzunluk hatası");
                    return;
                }

                var data = {
                    Email: email,
                    Password: password
                };

                $.ajax({
                    type: "POST",
                    url: "/Manage/LoginAction",
                    data: JSON.stringify(data),
                    success: Page.Manage.Login.Submit_Callback,
                    error: Page.Manage.Login.Submit_Callback_Error,
                    dataType: "json",
                    contentType: "application/json"
                });
            },
            Submit_Callback: function (result) {
                if (result.id == "0") {
                    alert("Kullanıcı adı veya şifre hatalı");
                } else {
                    window.location.href = "/Manage/Index";
                }
            },
            Submit_Callback_Error: function (result) {
                alert("Kullanıcı adı veya şifre hatalı");
            }
        },
        ManageBlog: {
            Save: function () {
                var title = $("#Title").val();
                var content = $("#Content").val();
                var categoryId = $("#CategoryId").val();
                var id = $("#Id").val();

                var data = {
                    Title: title,
                    Content: content,
                    CategoryId: categoryId,
                    Id: id
                };

                $.ajax({
                    type: "POST",
                    url: "/Manage/ManageBlogAction",
                    data: JSON.stringify(data),
                    success: Page.Manage.ManageBlog.Save_Callback,
                    error: Page.Manage.ManageBlog.Save_Callback_Error,
                    dataType: "json",
                    contentType: "application/json"
                });
            },
            Save_Callback: function (result) {
                console.log(result);

                window.location.href = "/Blog/Detail/" + result.id;
            },
            Save_Callback_Error: function (result) {
                console.log(result);
            }
        }
    }
}