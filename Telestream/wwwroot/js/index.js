$().ready(function () {
    doSearch();
});

var recentSmsTable;
function doSearch() {
    const searchKey = $("#search-input").val();
    const data = {searchKey};
    $.get('/recent', data)
    .done(function(response) {
        const recentSMSes = response.recentSMS;
        const nUnread = response.nUnread;

        $("#unread-span").text(nUnread);
        if (recentSmsTable) {
            recentSmsTable.destroy();
        }

        let tbodyHtml = '';
        recentSMSes.forEach(sms => {
            const unreadClass = sms.read ? '' : 'unread'
            const subContent = sms.content.length > 23 ? sms.content.substr(0, 20) + " ..." : sms.content;
            tbodyHtml += "<tr class='" + unreadClass + "' data-id='" + sms.id + "' onclick='onSmsClick(" + sms.id + ", \"" + sms.from + "\")'>";
            tbodyHtml += "<td>" + sms.contact + "</td>";
            tbodyHtml += "<td>" + sms.from + "</td>";
            tbodyHtml += "<td>" + sms.createdAt + "</td>";
            tbodyHtml += "<td>" + subContent + "</td>";
            tbodyHtml += "<td>";
            if (!sms.read) {
                tbodyHtml += "<i class='fa fa-circle-info text-danger mr-1 unread-marker'></i> Unread </td>";
            } else {
                tbodyHtml += "Read </td>";
            }

            tbodyHtml += "<td>";
            if (!sms.read) {
                tbodyHtml += "<i class='fa-regular fa-circle-check mr-3 mark-read' onclick='markRead(" + sms.id + ")'  style='cursor: pointer'></i>";
            }
            tbodyHtml += "<i class='fa-solid fa-trash' onclick='deleteSMSOnDashboard(" + sms.id + ")' style='cursor: pointer'></i>"
            tbodyHtml += "</td></tr>";
        });
        $("#recent-table tbody").html(tbodyHtml);
        makeDatatable();
    });
}

function makeDatatable() {
    recentSmsTable = $('#recent-table').DataTable({
        dom: 'rt<"bottom"lp><"clear">',
        searching: false,
        info: false,
        language: {
            paginate: {
              previous: "<",
              next: ">"
            },
            lengthMenu: "Items per page _MENU_"
        }
    });
}

function onSmsClick(id, phoneNumber) {
    window.event.stopImmediatePropagation()
    const markReadCallback = (id) => {
        document.location.href = "/inbox?" + phoneNumber;
    }
    postAsRead(id, markReadCallback);
    return false;
}

function markRead(id) {
    window.event.stopImmediatePropagation();
    const markReadCallback = (id) => {
        if ($("tr[data-id=" + id + "]").hasClass('unread')) {
            $("#unread-span").text(Math.max($("#unread-span").text()-1, 0));
            $("tr[data-id=" + id + "]").removeClass('unread');
            $("tr[data-id=" + id + "] .unread-marker").remove();
            $("tr[data-id=" + id + "] .mark-read").remove();
        }
    };
    postAsRead(id, markReadCallback);
    return false;
}

function deleteSMSOnDashboard(id) {
    window.event.stopImmediatePropagation();
    const deleteSMSOnDashboardCallback = (id) => {
        $("tr[data-id=" + id + "]").hide();
    }

    postAsRead(id, deleteSMSOnDashboardCallback);
}

function postAsRead(id, callback) {
    const data = {id};
    $.post('/sms/read', data)
        .done(function(response) {
            callback(id);
        });
}


function deleteSMS(id) {
    window.event.stopImmediatePropagation()
    if (!confirm("Are you sure to delete this cocntact list?")) {
        return false;
    }

    $.ajax({
        url: '/sms',
        type: 'delete',
        data: {id},
        datatype: "json",
        success: function (data, textstatus, xhr) {
            if (recentsmstable) {
                recentsmstable.destroy();
            }
            if ($("tr[data-id=" + id + "]").hasclass('unread')) {
                $("#unread-span").text(math.max($("#unread-span").text()-1, 0));
            }    
            $("tr[data-id='" + id + "']").remove();
            makedatatable();
        },
    });

    return false;
}

var onMessageArrived = (message) => {
    if (!message) {
        return;
    }
    doSearch();
};