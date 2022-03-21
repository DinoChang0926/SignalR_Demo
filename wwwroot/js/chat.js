var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var group = "ReceiveMessage"; //接收訊息的目標
    //$.ajax({
    //    url: "home/test",
    //    type: "post",
    //    async: false,
    //    data: {
    //        //'key1': value,
    //        //'key2': value,
    //    },
    //    beforeSend: function (xhr) {
    //        //for CSRF
    //        xhr.setRequestHeader("requestverificationtoken",
    //            $('input:hidden[name="__RequestVerificationToken"]').val());
    //    },
    //    success: function (result) {
           
    //    },
    //    error: function () {
    //        console.log("Error bind.");
    //    }
    //});
   
    connection.invoke("SendMessage", user, message, group).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});