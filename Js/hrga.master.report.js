$(document).ready(function () {
    loadGridReport();
})

function loadGridReport() {
    if ($("#gridReport").data().kendoGrid != null) {
        $('#gridReport').data().kendoGrid.destroy(); // to destory instance            
        $('#gridReport').empty(); // to destroy component
    }

    var grid = $("#gridReport").kendoGrid({
        dataSource: {
            type: "json"
            , error: function (e) {
                if (e.errors == true) {
                    var grid_error = $("#gridMenu").data('kendoGrid');
                    grid_error.one("dataBinding", function (e) {
                        e.preventDefault();
                    });
                    //this.cancelChanges();
                }
            }
            , requestEnd: function (e) {
                if (e.type == "destroy" && e.response.status == false) {
                    this.cancelChanges();
                }
                if ((e.type == "create" || e.type == "update") && e.response.status == true) {
                    $("#gridReport").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/MasterReport/jsonGetReport",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                create: {
                    url: $("#urlPath").val() + "/MasterReport/jsonInsertReport",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                update: {
                    url: $("#urlPath").val() + "/MasterReport/jsonUpdateReport",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                destroy: {
                    url: $("#urlPath").val() + "/MasterReport/jsonDeleteReport",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                parameterMap: function (data, operation) {
                    return kendo.stringify(data)
                }
            },
            schema: {
                errors: function (response) {
                    if (response.status == false) {
                        alert("Error: " + response.remarks);
                        return true;
                    } else if (response.status == true) {
                        alert(response.remarks);
                    }
                    return false;
                },
                data: "Data",
                total: "Total",
                model: {
                    id: "REPORT_ID",
                    fields: {
                        REPORT_ID: { type: "string", editable: true },
                        REPORT_NAME: { type: "string", editable: true },
                        REPORT_SERVER: { type: "string", editable: true },
                        REPORT_PATH: { type: "string", editable: true },
                        REPORT_CATEGORY: { type: "string", editable: true },
                        STATUS: { type: "boolean", editable: true }
                        //REMARKS_UPLOAD: { type: "string", editable: false }
                    }
                }
            },
            pageSize: 31,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true,

        },
        editable: "inline",
        filterable: true,
        sortable: true,
        pageable: true,
        scrollable: true,
        selectable: true,
        resizable: true,
        pageable: {
            refresh: true,
            buttonCount: 10,
            input: true,
            pageSizes: [10, 20, 50, 100, 1000, 100000],
            info: true,
            messages: {
            }
        },
        //toolbar: [{ template: '<label class="control-label">Cari Berdasarkan : </label>&nbsp;<input id="cmbCari" name="cmbCari" />' }],
        toolbar: ["create"],
        columns: [
            {
                command: [
                    "edit",
                    "destroy"
                ],
                title: "Action",
                width: 17,
            },
            {
                field: "REPORT_NAME", title: "Name", width: 15
            },
            {
                field: "REPORT_SERVER", title: "Server", width: 15
            },
            {
                field: "REPORT_PATH", title: "Path", width: 20
            },
            {
                field: "REPORT_CATEGORY", title: "Category", width: 15, editor: dropDownCategory
            },
            {
                field: "STATUS", title: "Status", width: 10, template: "#= STATUS == true ? 'Yes' : 'No'#", editor: statusBoolEditor
            },
        ],
        dataBinding: function () {
            window.rowNo = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    });
}

function statusBoolEditor(container, options) {
    $('<input type="checkbox"  name="STATUS" id="STATUS"  data-type="boolean" data-bind="checked:STATUS"><label for="STATUS"></label>').appendTo(container);
}

function dropDownCategory(container, options) {
    $('<input required name="REPORT_CATEGORY" id="REPORT_CATEGORY" data-value-field="REPORT_CATEGORY" data-text-field="REPORT_CATEGORY" data-bind="value:' + options.field + '"/>')
        .appendTo(container)
        .kendoDropDownList({
            autoBind: true,
            optionLabel: "--Select",
            dataTextField: "REPORT_CATEGORY",
            dataValueField: "REPORT_CATEGORY",
            dataSource: {
                type: "json",
                transport: {
                    read: {
                        url: $("#urlPath").val() + "/MasterReport/jsonGetCategory",
                        contentType: "application/json",
                        type: "POST",
                        cache: false
                    }
                },
                schema: {
                    data: "Data",
                    total: "Total"
                }
            }
        });
}
