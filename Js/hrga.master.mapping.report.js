$(document).ready(function () {
    loadGridAksesReport()
})

function loadGridAksesReport() {
    if ($("#gridAksesReport").data().kendoGrid != null) {
        $('#gridAksesReport').data().kendoGrid.destroy(); // to destory instance            
        $('#gridAksesReport').empty(); // to destroy component
    }

    var grid = $("#gridAksesReport").kendoGrid({
        dataSource: {
            type: "json"
            , error: function (e) {
                if (e.errors == true) {
                    var grid_error = $("#gridAksesReport").data('kendoGrid');
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
                    $("#gridAksesReport").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/MasterMappingReport/jsonGetAksesReport",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                create: {
                    url: $("#urlPath").val() + "/MasterMappingReport/jsonInsertAksesReport",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                update: {
                    url: $("#urlPath").val() + "/MasterMappingReport/jsonUpdateAksesReport",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                destroy: {
                    url: $("#urlPath").val() + "/MasterMappingReport/jsonDeleteAksesReport",
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
                    id: "PID_MAPPING_REPORT",
                    fields: {
                        PID_MAPPING_REPORT: { type: "string", editable: true },
                        ID_PROFILE: { type: "string", editable: true },
                        PROFILE_NAME: { type: "string", editable: true },
                        REPORT_ID: { type: "string", editable: true },
                        REPORT_NAME: { type: "string", editable: true },
                        REPORT_CATEGORY: { type: "string", editable: false }
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
                width: 20,
            },
            {
                field: "ID_PROFILE", title: "Profile", template: "#= PROFILE_NAME#", width: 15, editor: dropDownProfile
            },
            {
                field: "REPORT_ID", title: "Menu", template: "#= REPORT_NAME #", width: 25, editor: dropDownReport
            },
            {
                field: "REPORT_CATEGORY", title: "Category", width: 25
            },
        ],
        dataBinding: function () {
            window.rowNo = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    });
}

function dropDownProfile(container, options) {
    $('<input required name="ID_PROFILE" id="ID_PROFILE" data-value-field="ID_PROFILE" data-text-field="PROFILE_NAME" data-bind="value:' + options.field + '"/>')
        .appendTo(container)
        .kendoDropDownList({
            autoBind: true,
            optionLabel: "--Select",
            dataTextField: "PROFILE_NAME",
            dataValueField: "ID_PROFILE",
            dataSource: {
                type: "json",
                transport: {
                    read: {
                        url: $("#urlPath").val() + "/MasterMappingAkses/jsonGetProfile",
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

function dropDownReport(container, options) {
    $('<input required name="REPORT_ID" id="REPORT_ID" data-value-field="REPORT_ID" data-text-field="REPORT_NAME" data-bind="value:' + options.field + '"/>')
        .appendTo(container)
        .kendoDropDownList({
            autoBind: true,
            optionLabel: "--Select",
            dataTextField: "REPORT_NAME",
            dataValueField: "REPORT_ID",
            dataSource: {
                type: "json",
                transport: {
                    read: {
                        url: $("#urlPath").val() + "/MasterMappingReport/jsonGetReport",
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