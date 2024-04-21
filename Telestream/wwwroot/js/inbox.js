$().ready(function() {
    const phoneNumberFromUrl = location.search.substring(1);
    let name, phoneNumber;
    if (phoneNumberFromUrl) {
        name = $("#contact-detail-container li[data-phone='" + phoneNumberFromUrl + "'] .name").text().trim();
        phoneNumber = $("#contact-detail-container li[data-phone='" + phoneNumberFromUrl + "'] .phone-number").text().trim();
    } else {
        name = $("#contact-detail-container li:first .name").text().trim();
        phoneNumber = $("#contact-detail-container li:first .phone-number").text().trim();
    }
    openMessages(phoneNumber, name);
});

var text_max = 1529;
$('#count_message').html('0 / ' + text_max );

$('#message-textarea').keyup(function() {
    var text_length = $('#message-textarea').val().length;
    $('#count_message').html(text_length + ' / ' + text_max);
});

var currentPhonenumber = "";
var currentName = "";
var isLastMessageSent = -1;

function openMessages(phoneNumber, name) {
    if (!phoneNumber) {
        return;
    }
    $("#message-container").empty();
    isLastMessageSent = -1;

    currentPhonenumber = phoneNumber;
    currentName = name;
    $("#contact-detail-container .active").removeClass('active');
    $("#contact-detail-container .fa-envelope-open").removeClass('fa-envelope-open').addClass('fa-envelope');

    $("li[data-phone='" + phoneNumber + "']").addClass('active');
    $("li[data-phone='" + phoneNumber + "'] .fa-envelope").removeClass('fa-envelope').addClass('fa-envelope-open');

    $.ajax({
        type: "GET",
        url: "/message_list",
        dataType: "json",
        data: {phoneNumber},
        success: function(result) {
            const messages = result.messages;
            messages.forEach(message => {
                renderMessage(message);
            });
        }
    });
}

function renderMessage(message) {
    let messageHtml = "";
    if (isLastMessageSent == message.sent) {
        if (message.sent) {
            messageHtml += "<div class='my-message-container'><div class='message my-message'><pre>" + message.content + "</pre></div></div>";
        } else {
            messageHtml += "<div class='other-message-container'><div class='message other-message'><pre>" + message.content + "</pre></div></div>";
        }
        $("#message-container li").last().append(messageHtml);
    } else {
        messageHtml = "<li class='clearfix'>";
        if (message.sent) {
            messageHtml += "<div class='my-message-container'><div class='message-data text-right'>";
            messageHtml += "<span class='message-data-time'>You</span>";
            messageHtml += "</div></div>";
            messageHtml += "<div class='my-message-container'><div class='message my-message'><pre>" + message.content + "</pre></div></div>";
        } else {
            messageHtml += "<div class='other-message-container'><div class='message-data'>";
            messageHtml += "<span class='message-data-time'>" + message.contact + "</span>";
            messageHtml += "</div></div>";
            messageHtml += "<div class='other-message-container'><div class='message other-message'><pre>" + message.content + "</pre></div></div>";
        }
        messageHtml += "</li>";
        
        $("#message-container").append(messageHtml);
    }

    isLastMessageSent = message.sent;
    $('.chat-history').scrollTop($('.chat-history')[0].scrollHeight);

}

function sendMessage() {
    const message = $("#message-textarea").val();
    if (!currentPhonenumber || !message) {
        $("#message-textarea").focus();
        return;
    }
    $("#message-textarea").val("");

    const data = {contact: currentName, phoneNumber: currentPhonenumber, message};
    $.post('/sms/send', data)
        .done(function(response) {
            const newMessage = {
                contact: currentName,
                sent: true,
                content: message
            };
            renderMessage(newMessage);
        });
}

function filterContact() {
    const searchKey = $("#search-people-input").val().toLowerCase().trim();
    $("#contact-detail-container li").show();
    if (searchKey.length < 1) {
        return;
    }

    $("#contact-detail-container li").each((idx, item) => {
        const name = $(item).find('.name').text().toLowerCase().trim();
        const phoneNumber = $(item).find('.phone-number').text().toLowerCase().trim();
        if (name.indexOf(searchKey) > -1 || phoneNumber.indexOf(searchKey) > -1) {
            $(item).show();
        } else {
            $(item).hide();
        }
    })
}

function deleteContact(phoneNumber) {
    window.event.stopImmediatePropagation()
    if (!confirm("Are you sure to delete this cocntact list?")) {
        return false;
    }

    $("li[data-phone='" + phoneNumber + "'").remove();
    if (phoneNumber == currentPhonenumber) {
        $("#message-container").empty();
        currentName = '';
        currentPhonenumber = '';
    }

    $.ajax({
        url: '/message_list',
        type: 'DELETE',
        data: {phoneNumber},
        dataType: "json",
        success: function (data, textStatus, xhr) {
            console.log(data);
        },
    });
}

var onMessageArrived = (message) => {
    if (!message) {
        return;
    }

    if (message.from == currentPhonenumber) {
        renderMessage(message);
    }
};

function deleteAllSMS() {
    //window.event.stopImmediatePropagation();

    $("#contact-detail-container").empty();
    $("#message-container").empty();

    $.ajax({
        url: '/clear_all',
        type: 'POST',
        data: {  },
        dataType: "json",
        success: function (data) {
            console.log(data);
        }
    });
    
}