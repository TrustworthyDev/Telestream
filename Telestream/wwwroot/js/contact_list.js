function ftt(){
    $('#contact-list-file').click();
}
function onFileChange(){
    var ft = $('#contact-list-file').val();
    $('#foto').val(ft);
}

function submitForm() {
    if (!$('#foto').val()) {
        $('#foto').click();
        return;
    }
    $("#contact-list-form").submit();
}

function viewContactList(listName) {
    const csvTableOption = {
        tableClass: "table align-items-center table-bordered",
        theadClass: "thead-light"
    };

    $('#csv-table-container').CSVToTable('/uploads/' + listName, csvTableOption);

    $("#modal-contactlist-detail").modal();
}

function deleteContactList(id) {
    if (!confirm("Are you sure to delete this cocntact list?")) {
        return;
    }

    $.ajax({
        url: '/contact_list',
        type: 'DELETE',
        data: {id},
        dataType: "json",
        success: function (data, textStatus, xhr) {
            $("tr[data-id='" + id + "']").remove();
        },
    });
}