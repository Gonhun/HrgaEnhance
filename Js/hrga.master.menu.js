$(document).ready(function () {
    loadGridMenu();
})

function loadGridMenu() {
    if ($("#gridMenu").data().kendoGrid != null) {
        $('#gridMenu').data().kendoGrid.destroy(); // to destory instance            
        $('#gridMenu').empty(); // to destroy component
    }

    var grid = $("#gridMenu").kendoGrid({
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
                    $("#gridMenu").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/MasterMenu/jsonGetMenu",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                create: {
                    url: $("#urlPath").val() + "/MasterMenu/jsonInsertMenu",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                update: {
                    url: $("#urlPath").val() + "/MasterMenu/jsonUpdateMenu",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                destroy: {
                    url: $("#urlPath").val() + "/MasterMenu/jsonDeleteMenu",
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
                    id: "PID_MENU",
                    fields: {
                        PID_MENU: { type: "string", editable: true },
                        MENU_DESC: { type: "string", editable: true },
                        PARENT_PID: { type: "string", editable: true },
                        MENU_PARENT: { type: "string", editable: true },
                        SORT_ORDER: { type: "number", editable: true },
                        MENU_LINK: { type: "string", editable: true },
                        CLASS: { type: "string", editable: true },
                        ICON: { type: "string", editable: true },
                        POSITON_ID: { type: "number", editable: true },
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
                field: "MENU_DESC", title: "DESC", width: 15
            },
            {
                field: "PARENT_PID", title: "PARENT", template: "#= MENU_PARENT #", width: 15, editor: dropDownParent
            },
            {
                field: "SORT_ORDER", title: "SORT", width: 10
            },
            {
                field: "MENU_LINK", title: "LINK", width: 15
            },
            {
                field: "CLASS", title: "CLASS", width: 10
            },
            {
                field: "ICON", title: "ICON", width: 15
            },
            {
                field: "POSITON_ID", title: "POSITION", width: 10
            },
        ],
        dataBinding: function () {
            window.rowNo = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    });
}

function dropDownParent(container, options) {
    $('<input name="PARENT_PID" id="PARENT_PID" data-value-field="PID_MENU" data-text-field="MENU_DESC" data-bind="value:' + options.field + '"/>')
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
                        url: $("#urlPath").val() + "/MasterMenu/jsonGetParent",
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
