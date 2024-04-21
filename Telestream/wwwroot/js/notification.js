"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();
var onMessageArrived = (message) => {
    console.log(message);
}

connection.on("DLRCallback", (message) => {
    let title = "Sent to " + message.to;
    let content = message.content.length > 53 ? message.content.substr(0, 50) + " ..." : message.content;

    toastr.success(content, title);
});

connection.on("InboundCallback", (message) => {
    let title = "Received from " + message.from;
    let content = message.content.length > 53 ? message.content.substr(0, 50) + " ..." : message.content;
    toastr.info(content, title, {onclick: () => {
      document.location.href = "/inbox?" + message.from;
    }});
    onMessageArrived(message);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});