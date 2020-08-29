$(document).ready(function () {
    loadGridKompensasi()
})

function loadGridKompensasi() {
    if ($("#gridKompensasi").data().kendoGrid != null) {
        $('#gridKompensasi').data().kendoGrid.destroy(); // to destory instance            
        $('#gridKompensasi').empty(); // to destroy component
    }

    var grid = $("#gridKompensasi").kendoGrid({
        dataSource: {
            type: "json"
            , error: function (e) {
                if (e.errors == true) {
                    var grid_error = $("#gridKompensasi").data('kendoGrid');
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
                    $("#gridKompensasi").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/MasterKompensasi/jsonGetKompensasi",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                update: {
                    url: $("#urlPath").val() + "/MasterKompensasi/jsonValidKompensasi",
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
                    id: "PID_KOMPENSASI",
                    fields: {
                        PID_KOMPENSASI: { type: "string", editable: true },
                        nrp: { type: "string", editable: true },
                        Nama: { type: "string", editable: true },
                        Absent: { type: "string", editable: true },
                        tanggal: { type: "date", editable: true },
                        shift: { type: "number", editable: true },
                        in: { type: "date", editable: true },
                        out: { type: "date", editable: true },
                        STATUS_KOMP: { type: "string", editable: true },
                        //REMARKS_UPLOAD: { type: "string", editable: false }
                    }
                }
            },
            pageSize: 31,
            serverPaging: true,
            serverFiltering: false,
            serverSorting: false,

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
        columns: [
            {
                command: [
                    "edit"
                ],
                title: "Action",
                width: 15,
            },
            {
                field: "nrp", title: "Nrp", width: 10, sortable: false, filterable: {extra: false}
            },
            {
                field: "Nama", title: "Nama", width: 20, sortable: false, filterable: { extra: false }
            },
            {
                field: "Absent"
                , title: "Kode"
                , width: 10
                , sortable: false
            },
            {
                field: "tanggal"
                , title: "Tanggal"
                , width: 15
                , template: "#= (tanggal == null)? '' : kendo.toString(kendo.parseDate(tanggal, 'yyyy-MM-dd'), 'yyyy-MM-dd')#"
                , sortable: true
            },
            {
                field: "shift", title: "Shift", width: 10
            },
            {
                field: "in"
                , title: "In"
                , width: 20
                , format: "{0:HH:mm:ss}"
                , parseFormats: ["HH:mm:ss"]
                , sortable: false
            },
            {
                //field: "out", title: "out", width: 40, template: "#= (out == null)? '' : kendo.toString(kendo.parseDate(out, 'yyyy-MM-dd HH:MM:ss'), 'HH:MM')#"
                field: "out"
                , title: "Out"
                , width: 20
                , format: "{0:HH:mm:ss}"
                , parseFormats: ["HH:mm:ss"]
                , sortable: false
            },
            {
                field: "STATUS_KOMP", title: "STATUS", width: 20, editor: dropDownStatus
            },
        ],
        edit: function (e) {
            if (!e.model.isValid) {
                e.container.find("input[name='Nama'").attr("disabled", true)
                e.container.find("input[name='Nama'").css("background", "gainsboro")

                e.container.find("input[name='nrp'").attr("disabled", true)
                e.container.find("input[name='nrp'").css("background", "gainsboro")

                e.container.find("input[name='Absent'").attr("disabled", true)
                e.container.find("input[name='Absent'").css("background", "gainsboro")

                e.container.find("input[name='tanggal'").attr("disabled", true)
                e.container.find("input[name='tanggal'").css("background", "gainsboro")

                e.container.find("input[name='shift'").attr("disabled", true)
                e.container.find("input[name='shift'").css("background", "gainsboro")

                e.container.find("input[name='in'").attr("disabled", true)
                e.container.find("input[name='in'").css("background", "gainsboro")

                e.container.find("input[name='out'").attr("disabled", true)
                e.container.find("input[name='out'").css("background", "gainsboro")
            }
        },
        dataBinding: function () {
            window.rowNo = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    });
}

function dropDownStatus(container, options) {
    $('<input name="STATUS_KOMP" id="STATUS_KOMP" data-value-field="STATUS_KOMP" data-text-field="STATUS_KOMP" data-bind="value:' + options.field + '"/>')
        .appendTo(container)
        .kendoDropDownList({
            autoBind: false,
            valuePrimitive: true,
            dataTextField: "STATUS_KOMP",
            dataValueField: "STATUS_KOMP",
            dataSource: {
                type: "json",
                transport: {
                    read: {
                        url: $("#urlPath").val() + "/MasterKompensasi/jsonGetJnsKompensasi",
                        contentType: "application/json",
                        type: "POST",
                        cache: false,
                        complete: function (e) {
                            console.log(e);
                        }
                    }
                },
                schema: {
                    data: "Data",
                    total: "Total"
                }
            }
        });
}