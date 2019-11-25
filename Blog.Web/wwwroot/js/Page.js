var Page = {
    Contact: {

        Send: function () {
            var name = $("#Name").val();
            var surname = $("#Surname").val();
            var message = $("#Message").val();

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
                dataType: "json",
                contentType :"application/json"
            });

        },
        Send_Callback: function(result){
            console.log(result);

        }



    }


}