$(document).ready(function () {

    $("#SelectedProject").change(function () {
        $("reportsTable").DataTable().destroy();
        initTable();
    })

    function initTable() {
        $("#reportsTable").DataTable({
            "processing": true,
            "serverSide": true,
            "filter": true,
            "destroy": true,
            "initComplete": function (settings, json) {
                $("#totalPrice").text($("#reportsTable").DataTable().column(4).data().sum());
            },
            "orderMulti": false,
            "ajax": {
                "url": "/TimeReport/LoadData",
                "type": "POST",
                "data": { projectId: $("#SelectedProject").val() },
                "datatype": "json"
            },
            "columnDefs": [{
                "defaultContent": "-",
                "targets": "_all"
            }],
            "columns": [
                { "data": "id", "name": "id", "autoWidth": true },
                { "data": "taskId", "name": "taskId", "autoWidth": true },
                { "data": "creationDate", "name": "creationDate", "autoWidth": true },
                { "data": "hoursSpent", "name": "hoursSpent", "autoWidth": true },
                { "data": "price", "name": "price", "autoWidth": true },
                { "data": "submitted", "name": "submitted", "autoWidth": true },
                { "data": "description", "name": "description", "autoWidth": true },


                {
                    "render": function (data, type, full, meta)
                    { return '<a class="btn btn-info" href="/TimeReport/Edit?timeReportId=' + full.id + '">Edit</a>'; }
                },
                {
                    data: null, render: function (data, type, row) {
                        return "<a href='#' class='btn btn-danger' onclick=deleteData('" + row.id + "'); >Delete</a>";
                    }
                },
            ]
        });
    }

    initTable();
});


function deleteData(reportId) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(reoportId);
    }
    else {
        return false;
    }
}

function Delete(reportId) {
    var url = "/TimeReport/Delete?timeReportId=" + reportId;

    $.post(url, { ID: reportId }, function (data) {
        if (data) {
            oTable = $('#reportsTable').DataTable();
            oTable.draw();
        }
        else {
            alert("Something Went Wrong!");
        }
    });
}