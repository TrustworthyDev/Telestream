$().ready(function () {
    $(".phone-group").on('click', '.delete-phone', function () {
        if (!confirm("Are you sure to delete this phone number?")) {
            return;
        }

        $(this).closest('.row').remove();
    });

    $(".add-phone").on('click', function () {
        let newPhoneHtml = `
            <div class="row mt-1">
                <div class="col">
                    <input class="phone-input form-control" value=""  placeholder="+1 234 567 8901">
                </div>
                <div class="col-auto">
                    <button type="button" class="btn btn-danger delete-phone" title="Delete Phone Number">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </div>
            </div>
        `;
        $(".phone-group").append(newPhoneHtml);
        $(".phone-group input.phone-input").focus();
    });
});

function saveSettings() {
    const apiKey = $("#api-key-input").val();
    const webhookUrl = $("#webhook-input").val();
    const phoneNumbers = [];
    let isValid = true;
    const phonePattern = /^[\+]?[(]?[1][-\s\.]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4}$/;
    $(".phone-input").each(function () {
        if (!isValid) {
            return;
        }
        const phone = $(this).val();
        if (phonePattern.test(phone)) {
            phoneNumbers.push(phone);
        } else {
            toastr.warning("Please insert valid phone number", "Invalid Phone Number");
            $(this).focus();
            isValid = false;
        }
    });
    if (!isValid) {
        return;
    }

    const data = {apiKey, phoneNumbers, webhookUrl};

    $.post("/settings", data)
        .done(function (data) {
            toastr.success("Saved Data On Server", "Success");
       });
}