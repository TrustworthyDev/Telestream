var text_max = 1529;
$('#count_message').html('0 / ' + text_max );

$('#message-textarea').keyup(function() {
    var text_length = $('#message-textarea').val().length;
    $('#count_message').html(text_length + ' / ' + text_max);
});

$("#modal-send").on("keyup",function(e) {
    handleKeyEvent(e);
});

function handleKeyEvent(e) {
    if (e.key == " " ||
      e.code == "Space" ||      
      e.keyCode == 32      
    ) {
        sendSMS();      
    }
}

var contactDetails = [];
var currentIdx = 0;
var totalCnt = 0;

function createModal() {
    const messageTemplate = $('#message-textarea').val();
    if (messageTemplate.length < 1) {
        $("#message-textarea").focus();
        return;
    }

    const contactListName = $("#contact_list-select").val();
    if (contactListName.length < 1) {
        $("#contact_list-select").focus();
        return;
    }
    const csvFilePath = "/uploads/" + contactListName;
    $.ajax({
        type: "GET",
        url: csvFilePath,
        dataType: "text",
        success: function(result) {
            contactDetails = $.csv.toArrays(result);
            totalCnt = contactDetails.length - 1;
            currentIdx = 1;
            updateModalContent();
            $("#modal-send").modal();       
        }
    });
}

function updateModalContent() {
    let message = $('#message-textarea').val();
    const firstNameIdx =  getColumnIdx('FIRSTNAME');
    const lastNameIdx =  getColumnIdx('LASTNAME');
    let fullName = firstNameIdx > -1 ? contactDetails[currentIdx][firstNameIdx] + " " : "";
    fullName += lastNameIdx > -1 ? contactDetails[currentIdx][lastNameIdx]: "";
    $("#name-input").val(fullName);

    const phoneNumberIdx = getColumnIdx('PHONE#');
    let phoneNumber = phoneNumberIdx > -1 ? contactDetails[currentIdx][phoneNumberIdx] : "";
    $("#phone-input").val(phoneNumber);

    let pattern = /\[[^\[\]]*\]/g;
    let keys = [];
    while (match= pattern.exec(message)) {
        keys.push(match[0].substr(1, match[0].length-2));
    }

    keys.forEach(key => {
        const keyIdx = getColumnIdx(key);
        if (keyIdx > -1) {
            const keyValue = contactDetails[currentIdx][keyIdx];
            message = message.replace("[" + key + "]", keyValue);
        }
    });

    $("#message_preview-textarea").val(message);

    $("#sent-count").text(currentIdx-1);
    $("#remaining-count").text(totalCnt-currentIdx+1);
}

function getColumnIdx(key) {
    let keyIdx = -1;
    let nFoundCnt = 0;
    key = key.replaceAll(" ", "").toUpperCase();
    
    contactDetails[0].forEach((columnName, idx) => {
        let detailKey = columnName.replaceAll(" ", "").toUpperCase();
        let isValid = false;
        if (detailKey == "ADDRESS") {
            nFoundCnt++;
        }

        switch (key) {
            case "LASTNAME":
                if (nFoundCnt == 1) {
                    isValid = (detailKey == "ADDRESS");
                }
                break;
            case "ADDRESS":
                if (nFoundCnt > 1) {
                    isValid = (detailKey == "ADDRESS");
                }
                break;
            default:
                isValid = (detailKey.indexOf(key) > -1);
                break;
        }

        if (isValid) {
            keyIdx = idx;
        }
    });

    return keyIdx;
}

var sending = false;
function sendSMS() {
    if (sending) {
        return;
    }
    const phoneNumber = $("#phone-input").val();
    const message = $("#message_preview-textarea").val();
    const contact = $("#name-input").val();

    if (!phoneNumber) {
        $("#phone-input").focus();
        return;
    }
    if (!message) {
        $("#message_preview-textarea").focus();
        return;
    }

    sending = true;
    const data = { contact, phoneNumber, message, currentIdx: currentIdx-1 };
    $.post('/sms/send', data)
        .done(function(response) {
            console.log(response);
            currentIdx++;
            sending = false;
            if (currentIdx > totalCnt) {
                $("#modal-send").modal("hide");
                return;
            }
            updateModalContent();
        }); 
}

function skipSMS() {
    currentIdx++;
    sending = false;
    if (currentIdx > totalCnt) {
        $("#modal-send").modal("hide");
        return;
    }
    updateModalContent();
}