$(document).ready(function () {
    loadGridAkses();
})

function loadGridAkses() {
    if ($("#gridAkses").data().kendoGrid != null) {
        $('#gridAkses').data().kendoGrid.destroy(); // to destory instance            
        $('#gridAkses').empty(); // to destroy component
    }

    var grid = $("#gridAkses").kendoGrid({
        dataSource: {
            type: "json"
            , error: function (e) {
                if (e.errors == true) {
                    var grid_error = $("#gridAkses").data('kendoGrid');
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
                    $("#gridAkses").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/MasterMappingAkses/jsonGetAkses",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                create: {
                    url: $("#urlPath").val() + "/MasterMappingAkses/jsonInsertAkses",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                update: {
                    url: $("#urlPath").val() + "/MasterMappingAkses/jsonUpdateAkses",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                destroy: {
                    url: $("#urlPath").val() + "/MasterMappingAkses/jsonDeleteAkses",
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
                    id: "PID_MAPPING_AKSES",
                    fields: {
                        PID_MAPPING_AKSES: { type: "string", editable: true },
                        ID_PROFILE: { type: "string", editable: true },
                        PROFILE_NAME: { type: "string", editable: true },
                        MENU_PID: { type: "string", editable: true },
                        MENU_DESC: { type: "string", editable: true },
                        C: { type: "bool", editable: true },
                        R: { type: "bool", editable: true },
                        U: { type: "bool", editable: true },
                        D: { type: "bool", editable: true }
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
                field: "MENU_PID", title: "Menu", template: "#= MENU_DESC #", width: 25, editor: dropDownMenu
            },
            {
                field: "C", title: "Create", width: 10
            },
            {
                field: "R", title: "Read", width: 10
            },
            {
                field: "U", title: "Update", width: 10
            },
            {
                field: "D", title: "Delete", width: 10
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

function dropDownMenu(container, options) {
    $('<input required name="MENU_PID" id="MENU_PID" data-value-field="PID_MENU" data-text-field="MENU_DESC" data-bind="value:' + options.field + '"/>')
        .appendTo(container)
        .kendoDropDownList({
            autoBind: true,
            optionLabel: "--Select",
            dataTextField: "MENU_DESC",
            dataValueField: "PID_MENU",
            dataSource: {
                type: "json",
                transport: {
                    read: {
                        url: $("#urlPath").val() + "/MasterMappingAkses/jsonGetMenu",
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
