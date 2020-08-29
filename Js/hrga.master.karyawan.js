
var oldRows = 0;

$(document).ready(function () {
    loadgridKaryawan();

    loadDropdownDept();

    loadDropdownPOH();

    loadDropdownMarital();

    loadDropdownBank()

    $(".inputAll").attr("disabled", true);

    var $demoMaskedInput = $('.demo-masked-input');
    //$demoMaskedInput.find('.date').inputmask('yyyy-MM-dd', { placeholder: '__/__/____' });
})

function formatDate(str) {
    if (str != null) {
        reqDate = new Date(str.match(/\d+/) * 1);

        var date = new Date(reqDate),
            mnth = ("0" + (date.getMonth() + 1)).slice(-2),
            day = ("0" + date.getDate()).slice(-2);
        return [date.getFullYear(), mnth, day].join("-");
    }
    else {
        return "";
    }
}

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

function loadgridKaryawan() {
    if ($("#gridKaryawan").data().kendoGrid != null) {
        $('#gridKaryawan').data().kendoGrid.destroy(); // to destory instance            
        $('#gridKaryawan').empty(); // to destroy component
    }

    var grid = $("#gridKaryawan").kendoGrid({
        dataSource: {
            type: "json"
            , error: function (e) {
                if (e.errors == true) {
                    var grid_error = $("#gridKaryawan").data('kendoGrid');
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
                    $("#gridKaryawan").data("kendoGrid").dataSource.read();
                    //var grid = $("#gridAllTrans").data("kendoGrid");
                    //grid.hideColumn("pilihSup");
                    //grid.hideColumn("PID_SUPPLIER");
                }
            },
            transport: {
                read: {
                    url: $("#urlPath").val() + "/MasterKaryawan/jsonGetKaryawan",
                    contentType: "application/json",
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
                    id: "Nrp",
                    fields: {
                        Nrp: { type: "string", editable: false },
                        Nama: { type: "string", editable: false },
                        TempatLahir: { type: "string", editable: false },
                        TglLahir: { type: "date", editable: false },
                        JenisKelamin: { type: "string", editable: false },
                        GolonganDarah: { type: "string", editable: false },
                        StatusKawin: { type: "string", editable: false },
                        Agama: { type: "string", editable: false },
                        Pendidikan: { type: "string", editable: false },
                        AlamatTinggal: { type: "string", editable: false },
                        Jamsostek: { type: "string", editable: false },
                        DPA: { type: "string", editable: false },
                        TglMasukPama: { type: "date", editable: false },
                        TglPensiun: { type: "date", editable: false },
                        Golongan: { type: "string", editable: false },
                        TglPromosi: { type: "date", editable: false },
                        IDJabatan: { type: "string", editable: false },
                        Jabatan: { type: "string", editable: false },
                        TglMutasi: { type: "date", editable: false },
                        StatusBawaKeluarga: { type: "string", editable: false },
                        TglBawaKeluarga: { type: "date", editable: false },
                        Departemen: { type: "string", editable: false },
                        StatusPenerimaan: { type: "string", editable: false },
                        POH: { type: "string", editable: false },
                        Gaji: { type: "number", editable: false },
                        RateUlap: { type: "string", editable: false },
                        Telepon: { type: "string", editable: false },
                        Lokasi: { type: "string", editable: false },
                        Approve: { type: "string", editable: false },
                        SisaCutiPeriode1: { type: "string", editable: false },
                        SisaCutiPeriode2: { type: "string", editable: false },
                        SisaCutiBesar: { type: "string", editable: false },
                        OnSite: { type: "boolean", editable: false },
                        Rekening: { type: "string", editable: false },
                        PemilikRekening: { type: "string", editable: false },
                        KodeBank: { type: "string", editable: false },
                        StatusPekerjaan: { type: "string", editable: false },
                        RewardSarana: { type: "string", editable: false },
                        Company: { type: "string", editable: false },
                        HariKe7: { type: "string", editable: false },
                        RosterCode: { type: "string", editable: false },
                        SisaUangObat: { type: "string", editable: false },
                        TglUpdate: { type: "date", editable: false },
                        updateby: { type: "string", editable: false },
                        KTP: { type: "string", editable: false },
                        NPWP: { type: "string", editable: false },
                        EMAIL: { type: "string", editable: false },
                        TeleponWA: { type: "string", editable: false },
                        TanggalUpdateHariKe7: { type: "date", editable: false },
                        JenisOperator: { type: "string", editable: false },
                    }
                }
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
        columns: [

            {
                title: "No",
                width: 30,
                template: "#= ++rowNo #",
                filterable: false,
                sortable: false,
                editable: false
            },
            {
                command: [{text:"Edit", name:"update", click:loadEditData}], title: "Action", width: 50
            },
            {
                field: "Nrp", title: "Nrp", width: 50, filterable: { extra: false, operators: { string: { eq: "Is equal to" } },}
            },
            {
                field: "Nama", title: "Nama", width: 125, filterable: { extra: false, operators: { string: { eq: "Is equal to" } }, }
            },
            {
                field: "TglMasukPama",
                title: "Tgl. Masuk Pama",
                width: 100,
                template: "#= (TglMasukPama == null)? '' : kendo.toString(kendo.parseDate(TglMasukPama, 'yyyy-MM-dd'), 'yyyy-MM-dd')#",
                filterable: false
            },
            {
                field: "Golongan", title: "Gol", width: 40, filterable: { extra: false, operators: { string: { eq: "Is equal to" } }, }
            },
            {
                field: "Jabatan", title: "Jabatan", width: 100, filterable: { extra: false, operators: { string: { eq: "Is equal to" } }, }
            },
            {
                field: "Departemen", title: "Dept", width: 50, filterable: { extra: false, operators: { string: { eq: "Is equal to" } }, }
            },
        ],
        dataBinding: function () {
            window.rowNo = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    });
}

function loadDataEllipse() {
    $.ajax({
        url: $("#urlPath").val() + "/MasterKaryawan/jsonGetData",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ sParameter: $("#inputNrp").val() }),
        contentType: "application/json",
        success: function (result) {
            console.log(result.data);

            if (result.data.Nama == null) {
                alert("Data karyawan belum ada di sistem");
                $(".inputAll").attr("disabled", false);

                $("#inputNama").val("");
                $("#inputTempatLahir").val("");
                $("#inputTglLahir").val("");
                $("#inputJnsKelamin").val("");
                $("#inputGolDarah").val("");
                $("#inputStatusKawin").val("");
                $("#inputAgama").val("");
                $("#inputPendidikan").val("");
                $("#inputAlamatTinggal").val("");
                $("#inputJamsostek").val("");
                $("#inputDPA").val("");
                $("#inputTglMasukPama").val("");
                $("#inputTglPensiun").val("");
                $("#inputGolongan").val("");
                $("#inputTglPromosi").val("");
                $("#inputIDJabatan").val("");
                $("#inputJabatan").val("");
                $("#inputTglMutasi").val("");
                $("#inputStatusKeluarga").val("");
                $("#inputStatusBawaKeluarga").val("");
                $("#inputTglBawaKeluarga").val("");
                $("#inputDepartemen").val("");
                $("#inputStatusPenerimaan").val("");
                $("#inputPOH").val("");
                $("#inputGaji").val(0);
                $("#inputRateUlap").val(0);
                $("#inputTelepon").val("");
                $("#inputLokasi").val("");
                $("#inputOnSite").val("");
                $("#inputRekening").val("");
                $("#inputPemilikRekening").val("");
                $("#inputKodeBank").val("");
                $("#inputStatusPekerjaan").val("");
                $("#inputCompany").val("");
                $("#inputHariKe7").val("");
                $("#inputKTP").val("");
                $("#inputNPWP").val("");
                $("#inputEmail").val("");
                $("#inputTelpWa").val("");
            } else {
                alert("Data Karyawan terdaftar di sistem. Silahkan cek kelengkapan data");
                $(".inputAll").attr("disabled", false);

                console.log(formatDate(result.data.TglLahir))

                $("#inputNama").val(result.data.Nama);
                $("#inputTempatLahir").val(result.data.TempatLahir);
                $("#inputTglLahir").val(formatDate(result.data.TglLahir));
                $("#inputJnsKelamin").val(result.data.JenisKelamin);
                $("#inputGolDarah").val(result.data.GolonganDarah);
                $("#inputStatusKawin").val(result.data.StatusKawin);
                $("#inputAgama").val(result.data.Agama);
                $("#inputPendidikan").val(result.data.Pendidikan);
                $("#inputAlamatTinggal").val(result.data.AlamatTinggal);
                $("#inputJamsostek").val(result.data.Jamsostek);
                $("#inputDPA").val(result.data.DPA);
                $("#inputTglMasukPama").val(formatDate(result.data.TglMasukPama));
                $("#inputTglPensiun").val(formatDate(result.data.TglPensiun));
                $("#inputGolongan").val(result.data.Golongan);
                $("#inputTglPromosi").val(formatDate(result.data.TglPromosi));
                $("#inputIDJabatan").val(result.data.IDJabatan);
                $("#inputJabatan").val(result.data.Jabatan);
                $("#inputTglMutasi").val(formatDate(result.data.TglMutasi));
                $("#inputStatusKeluarga").val(result.data.StatusKeluarga);
                //$("#inputStatusBawaKeluarga").val(result.data.StatusBawaKeluarga);
                $('#inputStatusBawaKeluarga option[value="' + result.data.StatusBawaKeluarga + '"]').prop('selected', true);
                $("#inputTglBawaKeluarga").val(formatDate(result.data.TglBawaKeluarga));
                $("#inputDepartemen").val(result.data.Departemen);
                $("#inputStatusPenerimaan").val(result.data.StatusPenerimaan);
                //$("#inputPOH").val(result.data.POH);
                $('#inputPOH option[value="' + result.data.POH + '"]').prop('selected', true);
                $("#inputGaji").val(0);
                $("#inputRateUlap").val(0);
                $("#inputTelepon").val(result.data.Telepon);
                $("#inputLokasi").val(result.data.Lokasi);
                //$("#inputOnSite").val(result.data.OnSite);
                $('#inputOnSite option[value="' + result.data.OnSite + '"]').prop('selected', true);
                $("#inputRekening").val(result.data.Rekening);
                $("#inputPemilikRekening").val(result.data.PemilikRekening);
                $("#inputKodeBank").val(result.data.KodeBank);
                $("#inputStatusPekerjaan").val(result.data.StatusPekerjaan);
                $("#inputCompany").val(result.data.Company);
                $("#inputHariKe7").val(result.data.HariKe7);
                $("#inputKTP").val(result.data.KTP);
                $("#inputNPWP").val(result.data.NPWP);
                $("#inputEmail").val(result.data.EMAIL);
                $("#inputTelpWa").val(result.data.TeleponWA);
            }
        }
    })
}

function loadEditData(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    console.log(dataItem);

    window.location.href = '#formKaryawan';

    $(".inputAll").attr("disabled", false);

    $("#inputNama").val(dataItem.Nama);
    $("#inputTempatLahir").val(dataItem.TempatLahir);
    $("#inputTglLahir").val(formatDateSql(dataItem.TglLahir));
    $("#inputJnsKelamin").val(dataItem.JenisKelamin);
    $("#inputGolDarah").val(dataItem.GolonganDarah);
    $("#inputStatusKawin").val(dataItem.StatusKawin);
    $("#inputAgama").val(dataItem.Agama);
    $("#inputPendidikan").val(dataItem.Pendidikan);
    $("#inputAlamatTinggal").val(dataItem.AlamatTinggal);
    $("#inputJamsostek").val(dataItem.Jamsostek);
    $("#inputDPA").val(dataItem.DPA);
    $("#inputTglMasukPama").val(formatDateSql(dataItem.TglMasukPama));
    $("#inputTglPensiun").val(formatDateSql(dataItem.TglPensiun));
    $("#inputGolongan").val(dataItem.Golongan);
    $("#inputTglPromosi").val(formatDateSql(dataItem.TglPromosi));
    $("#inputIDJabatan").val(dataItem.IDJabatan);
    $("#inputJabatan").val(dataItem.Jabatan);
    $("#inputTglMutasi").val(formatDateSql(dataItem.TglMutasi));
    $("#inputStatusKeluarga").val(dataItem.StatusKeluarga);
    $("#inputStatusBawaKeluarga").val(dataItem.StatusBawaKeluarga);
    $('#inputStatusBawaKeluarga option[value="' + dataItem.StatusBawaKeluarga + '"]').prop('selected', true);
    $("#inputTglBawaKeluarga").val(formatDateSql(dataItem.TglBawaKeluarga));
    $("#inputDepartemen").val(dataItem.Departemen);
    $("#inputStatusPenerimaan").val(dataItem.StatusPenerimaan);
    $("#inputPOH").val(dataItem.POH);
    $('#inputPOH option[value="' + dataItem.POH + '"]').prop('selected', true);
    $("#inputGaji").val(0);
    $("#inputRateUlap").val(0);
    $("#inputTelepon").val(dataItem.Telepon);
    $("#inputLokasi").val(dataItem.Lokasi);
    $("#inputOnSite").val(dataItem.OnSite);
    $('#inputOnSite option[value="' + dataItem.OnSite + '"]').prop('selected', true);
    $("#inputRekening").val(dataItem.Rekening);
    $("#inputPemilikRekening").val(dataItem.PemilikRekening);
    $("#inputKodeBank").val(dataItem.KodeBank);
    $("#inputStatusPekerjaan").val(dataItem.StatusPekerjaan);
    $("#inputCompany").val(dataItem.Company);
    $("#inputHariKe7").val(dataItem.HariKe7);
    $("#inputKTP").val(dataItem.KTP);
    $("#inputNPWP").val(dataItem.NPWP);
    $("#inputEmail").val(dataItem.EMAIL);
    $("#inputTelpWa").val(dataItem.TeleponWA);
}

function loadDropdownDept() {
    $.ajax({
        url: $("#urlPath").val() + "/MasterKaryawan/jsonGetDept",
        dataType: "json",
        type: "POST",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < result.Total; i++) {
                $("#inputDepartemen").append('<option value=' + result.Data[i].Dept + '>' + result.Data[i].Dept + '</option>')
            }
            $("#inputDepartemen").change();
        }
    })
}

function loadDropdownPOH() {
    $.ajax({
        url: $("#urlPath").val() + "/MasterKaryawan/jsonGetPOH",
        dataType: "json",
        type: "POST",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < result.Total; i++) {
                $("#inputPOH").append('<option value=' + result.Data[i].POINT_OF_HIRE_DESC + '>' + result.Data[i].POINT_OF_HIRE_DESC + '</option>')
            }
            $("#inputPOH").change();
        }
    })
}

function loadDropdownBank() {
    $.ajax({
        url: $("#urlPath").val() + "/MasterKaryawan/jsonGetBank",
        dataType: "json",
        type: "POST",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < result.Total; i++) {
                $("#inputKodeBank").append('<option value=' + result.Data[i].NAMA_BANK + '>' + result.Data[i].NAMA_BANK + '</option>')
            }
            $("#inputKodeBank").change();
        }
    })
}

function loadDropdownMarital() {
    $.ajax({
        url: $("#urlPath").val() + "/MasterKaryawan/jsonGetMarital",
        dataType: "json",
        type: "POST",
        contentType: "application/json",
        success: function (result) {
            for (i = 0; i < result.Total; i++) {
                $("#inputStatusKeluarga").append('<option value=' + result.Data[i].MARITAL_CODE + '>' + result.Data[i].MARITAL_DESC + '</option>')
            }
            $("#inputStatusKeluarga").change();
        }
    })
}

function resetData() {
    $(".inputAll").attr("disabled", true);

    $("inputNrp").val("");
    $("#inputNama").val("");
    $("#inputTempatLahir").val("");
    $("#inputTglLahir").val("");
    $("#inputJnsKelamin").val("");
    $("#inputGolDarah").val("");
    $("#inputStatusKawin").val("");
    $("#inputAgama").val("");
    $("#inputPendidikan").val("");
    $("#inputAlamatTinggal").val("");
    $("#inputJamsostek").val("");
    $("#inputDPA").val("");
    $("#inputTglMasukPama").val("");
    $("#inputTglPensiun").val("");
    $("#inputGolongan").val("");
    $("#inputTglPromosi").val("");
    $("#inputIDJabatan").val("");
    $("#inputJabatan").val("");
    $("#inputTglMutasi").val("");
    $("#inputStatusKeluarga").val("");
    $("#inputStatusBawaKeluarga").val("");
    $("#inputTglBawaKeluarga").val("");
    $("#inputDepartemen").val("");
    $("#inputStatusPenerimaan").val("");
    $("#inputPOH").val("");
    $("#inputGaji").val(0);
    $("#inputRateUlap").val(0);
    $("#inputTelepon").val("");
    $("#inputLokasi").val("");
    $("#inputOnSite").val("");
    $("#inputRekening").val("");
    $("#inputPemilikRekening").val("");
    $("#inputKodeBank").val("");
    $("#inputStatusPekerjaan").val("");
    $("#inputCompany").val("");
    $("#inputHariKe7").val("");
    $("#inputKTP").val("");
    $("#inputNPWP").val("");
    $("#inputEmail").val("");
    $("#inputTelpWa").val("");
}

function saveData() {
    var sParameter = {
        Nrp: $("#inputNrp").val(),
        Nama: $("#inputNama").val(),
        TempatLahir: $("#inputTempatLahir").val(),
        TglLahir: $("#inputTglLahir").val(),
        JenisKelamin: $("#inputJnsKelamin").val(),
        GolonganDarah: $("#inputGolDarah").val(),
        StatusKawin: $("#inputStatusKawin").val(),
        Agama: $("#inputAgama").val(),
        Pendidikan: $("#inputPendidikan").val(),
        AlamatTinggal: $("#inputAlamatTinggal").val(),
        Jamsostek: $("#inputJamsostek").val(),
        DPA: $("#inputDPA").val(),
        TglMasukPama: $("#inputTglMasukPama").val(),
        TglPensiun: $("#inputTglPensiun").val(),
        Golongan: $("#inputGolongan").val(),
        TglPromosi: $("#inputTglPromosi").val(),
        IDJabatan: $("#inputIDJabatan").val(),
        Jabatan: $("#inputJabatan").val(),
        TglMutasi: $("#inputTglMutasi").val(),
        StatusKeluarga: $("#inputStatusKeluarga").val(),
        StatusBawaKeluarga: $("#inputStatusBawaKeluarga").val(),
        TglBawaKeluarga: $("#inputTglBawaKeluarga").val(),
        Departemen: $("#inputDepartemen").val(),
        StatusPenerimaan: $("#inputStatusPenerimaan").val(),
        POH: $("#inputPOH").val(),
        Telepon: $("#inputTelepon").val(),
        Lokasi: $("#inputLokasi").val(),
        OnSite: $("#inputOnSite").val(),
        Rekening: $("#inputRekening").val(),
        PemilikRekening: $("#inputPemilikRekening").val(),
        KodeBank: $("#inputKodeBank").val(),
        StatusPekerjaan: $("#inputStatusPekerjaan").val(),
        Company: $("#inputCompany").val(),
        KTP: $("#inputKTP").val(),
        NPWP: $("#inputNPWP").val(),
        EMAIL: $("#inputEmail").val(),
        TeleponWA: $("#inputTelpWa").val(),
        HariKe7: $("#inputHariKe7").val(),
    }

    $.ajax({
        url: $("#urlPath").val() + "/MasterKaryawan/jsonValidKaryawan",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ sClsKaryawan: sParameter }),
        contentType: "application/json",
        success: function (result) {
            alert(result.remarks);
            resetData();
        }
    })
}