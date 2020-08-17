$(document).ready(function () {
    loadGridUser();
})

function loadGridUser() {
    if ($("#gridUser").data().kendoGrid != null) {
        $('#gridUser').data().kendoGrid.destroy(); // to destory instance            
        $('#gridUser').empty(); // to destroy component
    }

    var grid = $("#gridUser").kendoGrid({
        dataSource: {
            type: "json"
            , error: function (e) {
                if (e.errors == true) {
                    var grid_error = $("#gridUser").data('kendoGrid');
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
                    $("#gridUser").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/MasterUser/jsonGetUser",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                create: {
                    url: $("#urlPath").val() + "/MasterUser/jsonInsertUser",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                update: {
                    url: $("#urlPath").val() + "/MasterUser/jsonUpdateUser",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                destroy: {
                    url: $("#urlPath").val() + "/MasterUser/jsonDeleteUser",
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
                    id: "PID_MAPPING_PROFILE",
                    fields: {
                        PID_MAPPING_PROFILE: { type: "string", editable: true },
                        USERID: { type: "string", editable: true },
                        Nama: { type: "string", editable: true },
                        ID_PROFILE: { type: "number", editable: true },
                        PROFILE_NAME: { type: "string", editable: true },
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
                width: 15,
            },
            {
                field: "USERID", title: "Nrp", width: 15
            },
            {
                field: "Nama", title: "Nama", width: 15
            },
            {
                field: "ID_PROFILE"
                , title: "Profile"
                , template: "#= PROFILE_NAME #"
                , width: 25
                , editor: dropDownProfile
            },
        ],
        edit: function (e) {
            if (!e.model.isValid) {
                e.container.find("input[name='Nama'").attr("disabled", true)
                e.container.find("input[name='Nama'").css("background", "gainsboro")
            }

            e.container.find("input[name='USERID'").change(function () {
                $.ajax({
                    url: $("#urlPath").val() + "/MasterUser/jsonGetNama",
                    dataType: "json",
                    type: "POST",
                    data: JSON.stringify({ sParameter: e.container.find("input[name='USERID'").val() }),
                    contentType: "application/json",
                    complete: function (result) {
                        console.log(result.responseJSON.Data);
                        e.container.find("input[name='Nama'").val(result.responseJSON.Data);
                    }
                })
            })
        },
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
                        url: $("#urlPath").val() + "/MasterUser/jsonGetProfile",
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
