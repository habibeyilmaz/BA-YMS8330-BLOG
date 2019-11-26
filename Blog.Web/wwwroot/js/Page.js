var Page = {
    Contact: {

        Send: function () {


            var name = $("#Name").val();
            var surname = $("#Surname").val();
            var message = $("#Message").val();

            if (name && name.length < 2) {
                alert("isim alanı 2 karakterden küçük olamaz.")
                return;
            }
            else if (surname && surname.length < 2) {
                alert("isim alanı 2 karakterden küçük olamaz.")
                return;
            }
            else if (message && message.length < 3) {
                alert("mesaj alanı 3 karakterden küçük olamaz.")
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
                contentType :"application/json"
            });

        },
        Send_Callback: function (result) {
            $("#Contact-Index-Sending").hide();
            $("#Contact-Index-Sent").show();
            console.log(result);

        },

        Send_Callback_Error: function () {
            $("#Contact-Index-Sending").hide();
            $("#Contact-Index-Sent").hide();
            $("#Contact-Index-Form").show();
          alert("Validation error!")
        }
    }
}