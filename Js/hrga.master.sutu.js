$(document).ready(function () {

    loadDropdownKet()

    $(".all").hide();
    $(".cuti").hide();
    $(".dinas").hide();
})

function formatDateSql(str) {
    console.log(str);
    if (str != null) {

        var date = new Date(str),
            mnth = ("0" + (date.getMonth() + 1)).slice(-2),
            day = ("0" + date.getDate()).slice(-2);
        return [date.getFullYear(), mnth, day].join("-");


        //var y = str.substr(0, 4),
        //    m = ("0" + (str.substr(4, 2))).slice(-2),
        //    d = ("0" + str.substr(6, 2)).slice(-2);
        //var D = new Date(y, m, d);
        //return [y, m, d].join("-");
    }
    else {
        return "";
    }
}

$("#inputJnsSurat").change(function () {
    $("#inputKeperluan").val($("#inputJnsSurat").val());
    $("#inputSurat").hide();
})

$("#inputAwal").change(function () {
    $("#inputTglFlightCuti").val($("#inputAwal").val());
})

$("#inputAwal").change(function () {
    $("#inputTglFlightCuti").val($("#inputAwal").val());
})

$("#inputAkhir").change(function () {
    $("#inputTglFlightDinas").val($("#inputAkhir").val());
})

$("#chkCutiLapangan").change(function () {
    if (this.checked) {
        $("#inputCutiLapangan").attr("disabled", false);
    }
    else {
        $("#inputCutiLapangan").val(null);
        $("#inputCutiLapangan").attr("disabled", true);
    }
})

$("#chkCutiPerjalanan").change(function () {
    if (this.checked) {
        $("#inputCutiPerjalanan").attr("disabled", false);
    }
    else {
        $("#inputCutiPerjalanan").val(null);
        $("#inputCutiPerjalanan").attr("disabled", true);
    }
});

$("#chkCutiTahunan").change(function () {
    if (this.checked) {
        $("#inputCutiTahunan").attr("disabled", false);
    }
    else {
        $("#inputCutiTahunan").val(null);
        $("#inputCutiTahunan").attr("disabled", true);
    }
});

$("#chkCutiBesar").change(function () {
    if (this.checked) {
        $("#inputCutiBesar").attr("disabled", false);
    }
    else {
        $("#inputCutiBesar").val(null);
        $("#inputCutiBesar").attr("disabled", true);
    }
});

$("#chkCutiPenggantiOff").change(function () {
    if (this.checked) {
        $("#inputCutiPenggantiOff").attr("disabled", false);
    }
    else {
        $("#inputCutiPenggantiOff").val(null);
        $("#inputCutiPenggantiOff").attr("disabled", true);
    }
});

$("#chkCutiKompensasi").change(function () {
    if (this.checked) {
        $("#inputCutiKompensasi").attr("disabled", false);
    }
    else {
        $("#inputCutiKompensasi").val(null);
        $("#inputCutiKompensasi").attr("disabled", true);
    }
});

$("#btnSearch").click(function () {
    if ($("#inputJnsSurat").val == "" || $("#inputJnsSurat").val == null) {
        alert("Jenis surat belum dipilih");
    } else {
        $("#sutu").show();
        loadGridSutu();
    }

})

function loadGridSutu() {
    if ($("#gridSutu").data().kendoGrid != null) {
        $('#gridSutu').data().kendoGrid.destroy(); // to destory instance            
        $('#gridSutu').empty(); // to destroy component
    }

    var grid = $("#gridSutu").kendoGrid({
        dataSource: {
            type: "json"
            , error: function (e) {
                if (e.errors == true) {
                    var grid_error = $("#gridSutu").data('kendoGrid');
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
                    $("#gridSutu").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/MasterSutu/jsonGetSurat",
                    contentType: "application/json",
                    data: ({ sParameter: $("#inputJnsSurat").val() }),
                    type: "POST",
                    cache: false,
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
                    id: "NomorST",
                    fields: {
                        NomorST: { type: "string", editable: false },
                        Nrp: { type: "string", editable: false },
                        Nama: { type: "string", editable: false },
                        Departemen: { type: "string", editable: false },
                        tglST: { type: "date", editable: false},
                        Tujuan: { type: "string", editable: false },
                        Keperluan: { type: "string", editable: false },
                        awalst: { type: "date", editable: false },
                        akhirst: { type: "date", editable: false }, 
                        Status: {type:"string", editable: false}
                    }
                },
                sort: [{ field: "NomorST", dir: "desc" }]
            },
            pageSize: 10,
            serverPaging: false,
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
        toolbar: [{ template: '<button type="button" class="k-button" id="btnCreate" onclick="loadFormSurat()"><i class="glyphicon glyphicon-plus"></i>&nbsp;Create Surat</button>' }],
        columns: [
            {
                command: [
                    { name: "btnApprove", text: " Approve", iconClass: "glyphicon glyphicon-ok", click: loadApproveSurat },
                    { name: "btnReject", text: " Reject", iconClass: "glyphicon glyphicon-remove", click: loadRejectSurat },
                ], title: "Action", width: 185
            },
            {
                command: [
                    { name: "btnPrint", text: " ", iconClass: "glyphicon glyphicon-print", click: loadReportCuti }
                ]
            },
            {
                field: "NomorST",
                title: "No. Surat",
                width: 125,
                filterable: { extra: false, operators: { string: { eq: "Is equal to" } }, }
            },
            {
                field: "Nrp", title: "Nrp", width: 100, filterable: { extra: false, operators: { string: { eq: "Is equal to" } }, }
            },
            {
                field: "Departemen", title: "Dept", width: 100, filterable: { extra: false, operators: { string: { eq: "Is equal to" } }, }
            },
            {
                field: "Tujuan", title: "Tujuan", width: 100, filterable: { extra: false, operators: { string: { eq: "Is equal to" } }, }
            },
            {
                field: "awalst",
                title: "Awal",
                width: 100,
                template: "#= (awalst == null)? '' : kendo.toString(kendo.parseDate(awalst, 'yyyy-MM-dd'), 'yyyy-MM-dd')#",
                filterable: false
            },
            {
                field: "akhirst",
                title: "Akhir",
                width: 100,
                template: "#= (akhirst == null)? '' : kendo.toString(kendo.parseDate(akhirst, 'yyyy-MM-dd'), 'yyyy-MM-dd')#",
                filterable: false
            },
            {
                field: "Status", title: "Status", width: 100,
            },
        ],
        //dataBinding: function () {
        //    window.rowNo = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        //}
    }); 
}

function loadFormSurat() {
    window.location.href = "#inputSurat";

    $("#inputSurat").show();

    if ($("#inputJnsSurat").val() == "DINAS" || $("#inputJnsSurat").val() == "TUGAS") {
        $(".all").show();
        $(".cuti").hide();
        $(".dinas").show();
        $("#inputAkhir").attr("disabled", false);
    }
    else if ($("#inputJnsSurat").val() == "CUTI") {
        $(".all").show();
        $(".cuti").show();
        $(".dinas").hide();
        $("#inputAkhir").attr("disabled", true);
    }
}

$("#inputAwal").change(function () {
    loadAkhirTgl()
})

$("#inputCutiLapangan").change(function () {
    if ($("#inputAwal").val() == "" || $("#inputAwal").val() == null) {

    } else {
        loadAkhirTgl()
    }
})

$("#inputCutiPerjalanan").change(function () {
    if ($("#inputAwal").val() == "" || $("#inputAwal").val() == null) {

    } else {
        loadAkhirTgl()
    }
})

$("#inputCutiTahunan").change(function () {
    if ($("#inputAwal").val() == "" || $("#inputAwal").val() == null) {

    } else {
        loadAkhirTgl()
    }
})

$("#inputCutiBesar").change(function () {
    if ($("#inputAwal").val() == "" || $("#inputAwal").val() == null) {

    } else {
        loadAkhirTgl()
    }
})

$("#inputCutiKompensasi").change(function () {
    if ($("#inputAwal").val() == "" || $("#inputAwal").val() == null) {

    } else {
        loadAkhirTgl()
    }
})

$("#inputCutiPenggantiOff").change(function () {
    if ($("#inputAwal").val() == "" || $("#inputAwal").val() == null) {

    } else {
        loadAkhirTgl()
    }
})

function loadAkhirTgl() {
    var lapangan = $("#inputCutiLapangan").val();
    var perjalanan = $("#inputCutiPerjalanan").val();
    var tahunan = $("#inputCutiTahunan").val();
    var besar = $("#inputCutiBesar").val();
    var off = $("#inputCutiKompensasi").val();
    var kompensasi = $("#inputCutiPenggantiOff").val();

    if (lapangan == "")
        lapangan = 0;
    if (perjalanan == "")
        perjalanan = 0;
    if (tahunan == "")
        tahunan = 0;
    if (besar == "")
        besar = 0;
    if (off == "")
        off = 0;
    if (kompensasi == "")
        kompensasi = 0;

    var days = parseInt(lapangan) + parseInt(perjalanan) + parseInt(tahunan) + parseInt(besar) + parseInt(off) + parseInt(kompensasi)
    //var days = lapangan + perjalanan + tahunan + besar + off + kompensasi

    var result = new Date($("#inputAwal").val());

    result.setDate(result.getDate() + days);

    $("#inputAkhir").val(formatDateSql(result));
}

function loadApproveSurat(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    var conf = confirm("Approve surat ini ?")
    if (!conf) {
        alert("Surat batal diproses");
    } else {
        var sParameter = {
            NomorST: dataItem.NomorST,
            Nrp: dataItem.Nrp,
            Keperluan: dataItem.Keperluan,
            Awal: dataItem.awalst,
            Akhir: dataItem.akhirst
        }

        $.ajax({
            url: $("#urlPath").val() + "/MasterSutu/jsonApprovalSutu",
            dataType: "json",
            type: "POST",
            data: JSON.stringify({ sClsSutu: sParameter }),
            contentType: "application/json",
            success: function (result) {
                alert(result.remarks);
                loadGridSutu()
            }
        })
    }
}

function loadRejectSurat(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    var conf = confirm("Reject surat ini ?")
    if (!conf) {
        alert("Surat batal diproses");
    } else {
        var sParameter = {
            NomorST: dataItem.NomorST,
            Nrp: dataItem.Nrp,
            Keperluan: dataItem.Keperluan,
            Awal: dataItem.awalst,
            Akhir: dataItem.akhirst
        }

        $.ajax({
            url: $("#urlPath").val() + "/MasterSutu/jsonRejectSutu",
            dataType: "json",
            type: "POST",
            data: JSON.stringify({ sClsSutu: sParameter }),
            contentType: "application/json",
            success: function (result) {
                alert(result.remarks);
            }
        })
    }
}

function loadDropdownKet() {
    $.ajax({
        url: $("#urlPath").val() + "/MasterSutu/jsonGetKetCuti",
        dataType: "json",
        type: "POST",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < result.Total; i++) {
                $("#inputKeterangan").append('<option value=' + result.Data[i].id + '>' + result.Data[i].Keterangan + '</option>')
            }
            $("#inputKeterangan").change();
        }
    })
}

function loadDataKaryawan() {
    $.ajax({
        url: $("#urlPath").val() + "/MasterKaryawan/jsonGetData",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ sParameter: $("#inputNrp").val() }),
        contentType: "application/json",
        success: function (result) {
            $("#inputNama").val(result.data.Nama);
            $("#inputJabatan").val(result.data.Jabatan);
            $("#inputTelepon").val(result.data.Telepon);
            $("#inputStatusKawin").val(result.data.StatusKawin);
            $('#inputStatusBawaKeluarga option[value="' + result.data.StatusBawaKeluarga + '"]').prop('selected', true);
            $("#inputAlamatCuti").val(result.data.AlamatTinggal);
        }
    })
}

function loadFormTiket() {
    console.log($("input[name=inputTiket]:checked").val());
    
    if ($("input[name=inputTiket]:checked").val() == 1) {
        $("#formTiket").show();
    } else {
        $("#formTiket").hide();
    }
}

function loadReportCuti(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    console.log(dataItem.NomorST);

    var iframe = document.getElementById("iFrameReport");


    if ($("#inputJnsSurat").val() == "CUTI") {
        iframe.src = $('#urlPath').val() + "/Report/RptCuti.aspx?NomorST=" + dataItem.NomorST;
    }
    else if ($("#inputJnsSurat").val() == "DINAS") {
        iframe.src = $('#urlPath').val() + "/Report/RptDinas.aspx?NomorST=" + dataItem.NomorST;
    } else if ($("#inputJnsSurat").val() == "TUGAS"){
        iframe.src = $('#urlPath').val() + "/Report/RptTugas.aspx?NomorST=" + dataItem.NomorST;
    }

    popUpReport = $("#reportSurat").kendoWindow({
        title: "",
        modal: true,
        visible: false,
        draggable: true,
        width: "1024px",
        height: "768px",
        close: function () {

        },
        position: { top: 10 },
        actions: [
            "close"
        ],
        pinned: true
    }).data("kendoWindow");

    $("#reportSurat").removeAttr("hidden");
    popUpReport.center().open();
    popUpReport.title("Report");
}

function resetInputCuti() {
    $("#inputKeperluan").val("")
    $("#inputNrp").val("")
    $("#inputNama").val("")
    $("#inputJabatan").val("")
    $("#inputTelepon").val("")
    $("#inputStatusKawin").val("")
    $("#inputStatusBawaKeluarga").val("")
    $("#inputTujuan").val("");
    $("#inputAlamatCuti").val("")
    $("#inputAwal").val("");
    $("#inputAkhir").val("");
    $("#inputKeterangan").val("");
    document.getElementById("chkCutiLapangan").checked = false
    $("#inputCutiLapangan").val("")
    document.getElementById("chkCutiPerjalanan").checked = false
    $("#inputCutiPerjalanan").val("")
    document.getElementById("chkCutiTahunan").checked = false
    $("#inputCutiTahunan").val("")
    document.getElementById("chkCutiBesar").checked = false
    $("#inputCutiBesar").val("")
    document.getElementById("chkCutiPenggantiOff").checked = false
    $("#inputCutiPenggantiOff").val("")
    document.getElementById("chkCutiKompensasi").checked = false
    $("#inputCutiKompensasi").val("")
    document.getElementById("radioTiketYa").checked = false;
    document.getElementById("radioTiketTidak").checked = false;
}

function resetInputTiket() {
    $("#inputTglFlightCuti").val("");
    $("#inputTglFlightDinas").val("");
    $("#inputBerangkatCuti").val("");
    $("#inputTujuanCuti").val("");
    $("#inputBerangkatDinas").val("");
    $("#inputTujuanDinas").val("");

}

function loadSaveSurat() {
    var varTiket;
    var varKet;

    if ($("input[name=inputTiket]:checked").val() == 1) {
        varTiket = true;
    } else {
        varTiket = false;
    }

    if ($("#inputKeperluan").val() == "CUTI") {
        varKet = $("#inputKeteranganCuti").val()
    }
    else {
        varKet = $("#inputKeteranganDinas").val()
    }

    var sParameterCuti = {
        Nrp: $("#inputNrp").val(),
        Keperluan: $("#inputKeperluan").val(),
        Tujuan: $("#inputTujuan").val(),
        AlamatCuti: $("#inputAlamatCuti").val(),
        Awal: $("#inputAwal").val(),
        Akhir: $("#inputAkhir").val(),
        Keterangan: varKet,
        C_Lapangan: $("#inputCutiLapangan").val(),
        C_Perjalanan: $("#inputCutiPerjalanan").val(),
        C_Tahunan: $("#inputCutiTahunan").val(),
        C_Besar: $("#inputCutiBesar").val(),
        C_Kompensasi: $("#inputCutiKompensasi").val(),
        C_Lain2: $("#inputCutiPenggantiOff").val(),
        Tiket: varTiket
    }

    var sParameterTiket = {
        NRP: $("#inputNrp").val(),
        KEPERLUAN: $("#inputKeperluan").val(),
        NO_HP: $("#inputTelepon").val(),
        TANGGAL: $("#inputAwal").val(),
        TANGGAL_KEMBALI: $("#inputAkhir").val(),
        DARI: $("#inputBerangkatCuti").val(),
        TUJUAN: $("#inputTujuanCuti").val(),
        DARI_KEMBALI: $("#inputBerangkatDinas").val(),
        TUJUAN_KEMBALI: $("#inputTujuanDinas").val(),
    }

    console.log(sParameterCuti);
    console.log(sParameterTiket);

    $.ajax({
        url: $("#urlPath").val() + "/MasterSutu/jsonInsertSurat",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ sClsSutu: sParameterCuti, sClsTiket: sParameterTiket }),
        contentType: "application/json",
        success: function (result) {
            setTimeout(function () { $('.page-loader-wrapper').fadeOut(); }, 100);
            alert(result.remarks);
            resetInputCuti();
            resetInputTiket();
            $("#formTiket").hide();
            $("#inputSurat").hide();
            loadGridSutu();
        }
    })
}

function resetAll() {
    resetInputCuti();
    resetInputTiket();
    $("#formTiket").hide();
    $("#inputSurat").hide();
}