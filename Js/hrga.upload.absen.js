$(document).ready(function () {
    $("#csvUpload").kendoUpload({
        multiple: true,
        async: {
            saveUrl: "save",
            removeUrl: onClear,
            autoUpload: false
        },
        upload: uploadFile,
        success: onSuccessUpload
    });

    function onClear(e) {
        // Optionally cancel the clear operation by calling preventDefault method
        e.preventDefault();
    };
})

function uploadFile(e) {
    var files = e.files;
    $.each(files, function () {
        //$("#csvUpload").data("kendoUpload").options.async.saveUrl = $("#urlPath").val() + '/MasterAbsen/jsonUploadCsv?type=0';
        $("#csvUpload").data("kendoUpload").options.async.saveUrl = $("#urlPath").val() + '/UploadAbsen/jsonUploadCsv?type=0';
    })
    //kendo.ui.progress($("#divgrid"), true);
}

function onSuccessUpload(e) {
    alert("Status : " + e.response.status + "," + e.response.remarks);
}

$("#btnSearch").click(function () {
    if ($("#txtNrp").val == "" || $("#txtAwal").val() == "" || $("#txtAkhir").val() == "") {
        alert("lengkapi nrp, tanggal awal dan akhir pencarian")
    }
    else {
        loadGridAbsen();
    }
})

$("#btnClear").click(function () {
    $("#inputNrp").val("")
    $("#inputAwal").val("")
    $("#inputAkhir").val("")
    loadGridAbsen();
})

function formatTime(time) {
    if (time != null) {
        var date = new Date(parseInt(time.substr(6)));
        var formatted;

        if (date.getHours() < 10 && date.getMinutes() < 10) {
            formatted = "0" + date.getHours() + ":0" + date.getMinutes();
        }
        else if (date.getHours() > 10 && date.getMinutes() < 10) {
            formatted = date.getHours() + ":0" + date.getMinutes();
        }
        else if (date.getHours() < 10 && date.getMinutes() > 10) {
            formatted = "0" + date.getHours() + ":" + date.getMinutes();
        }
        else {
            formatted = date.getHours() + ":" + date.getMinutes();
        }

        return formatted;
    }
    else {
        return "";
    }
}

function loadGridAbsen() {
    if ($("#gridAbsen").data().kendoGrid != null) {
        $('#gridAbsen').data().kendoGrid.destroy(); // to destory instance            
        $('#gridAbsen').empty(); // to destroy component
    }

    var grid = $("#gridAbsen").kendoGrid({
        dataSource: {
            type: "json"
            , error: function (e) {
                if (e.errors == true) {
                    var grid_error = $("#gridAbsen").data('kendoGrid');
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
                    $("#gridAbsen").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/UploadAbsen/jsonGetAbsen",
                    contentType: "application/json",
                    data: { s_Nrp: $("#inputNrp").val(), s_Awal: $("#inputAwal").val(), s_Akhir: $("#inputAkhir").val() },
                    type: "POST",
                    cache: false
                },
                update: {
                    url: $("#urlPath").val() + "/UploadAbsen/jsonUpdateAbsen",
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
                    id: "id",
                    fields: {
                        nrp: { type: "string", editable: true },
                        tanggal: { type: "date", editable: true },
                        shift: { type: "number", editable: true },
                        Absent: { type: "string", editable: true },
                        in: { type: "date", editable: true },
                        out: { type: "date", editable: true },
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
        toolbar: [{ template: '<a href=' + $("#urlPath").val() + '"Csv/Absen/Template/Contoh Upload Absen.csv" id="btn_template" class="k-button"><span class="glyphicon glyphicon-download"></span> Download Template</a>' }],
        columns: [
            {
                command: [
                    "edit"
                ],
                title: "Action",
                width: 15,
            },
            {
                title: "No",
                width: 10,
                template: "#= ++rowNo #",
                filterable: false,
                sortable: false,
                editable: false
            },
            {
                field: "nrp", title: "Nrp", width: 20
            },
            {
                field: "tanggal"
                , title: "Tanggal"
                , width: 15
                , template: "#= (tanggal == null)? '' : kendo.toString(kendo.parseDate(tanggal, 'yyyy-MM-dd'), 'yyyy-MM-dd')#"
                , sortable: true
            },
            {
                field: "Absent"
                , title: "Kode"
                , width: 25
                , editor: dropDownAbsent
            },
            {
                field: "shift", title: "Shift", width: 10
            },
            {
                field: "in"
                , title: "In"
                , width: 30
                , format: "{0:HH:mm:ss}"
                , parseFormats: ["HH:mm:ss"]
                , editor: editInTime
            },
            {
                //field: "out", title: "out", width: 40, template: "#= (out == null)? '' : kendo.toString(kendo.parseDate(out, 'yyyy-MM-dd HH:MM:ss'), 'HH:MM')#"
                field: "out"
                , title: "Out"
                , width: 30
                , format: "{0:HH:mm:ss}"
                , parseFormats: ["HH:mm:ss"]
                , editor: editOutTime
            }
        ],
        edit: function (e) {
            if (!e.model.isValid) {
                e.container.find("input[name='nrp'").attr("disabled", true)
                e.container.find("input[name='nrp'").css("background", "gainsboro")

                e.container.find("input[name='tanggal'").attr("disabled", true)
                e.container.find("input[name='tanggal'").css("background", "gainsboro")

                e.container.find("input[name='shift'").attr("disabled", true)
                e.container.find("input[name='shift'").css("background", "gainsboro")
            }
        },
        dataBinding: function () {
            window.rowNo = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    });
}

function dropDownAbsent(container, options) {
    $('<input required name="' + options.field + '"/>')
        .appendTo(container)
        .kendoDropDownList({
            autoBind: false,
            optionLabel: "--Select",
            dataTextField: "Keterangan",
            dataValueField: "Code",
            dataSource: {
                type: "json",
                transport: {
                    read: {
                        url: $("#urlPath").val() + "/UploadAbsen/jsonGetAbsenCode",
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

function editInTime(container, options) {
    $('<input type="text" data-text-field="in" data-value-field="in" name="in" data-bind="value:' + options.field + '" class="k-textbox"/>')
        .appendTo(container)
}

function editOutTime(container, options) {
    $('<input type="text" data-text-field="out" data-value-field="out" name="out" data-bind="value:' + options.field + '" class="k-textbox"/>')
        .appendTo(container)
}
