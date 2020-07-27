
var oldRows = 0;

$(document).ready(function () {
    loadgridKaryawan();

    var $demoMaskedInput = $('.demo-masked-input');
    $demoMaskedInput.find('.date').inputmask('dd/mm/yyyy', { placeholder: '__/__/____' });
})

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
                    url: $("#urlPath").val() +"/MasterKaryawan/jsonGetKaryawan",
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
                        OnSite: { type: "number", editable: false },
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
            pageSize: 15,
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
                command: ["edit", "destroy"], title: "Action", width: 100
            },
            {
                field: "Nrp", title: "Nrp", width: 50
            },
            {
                field: "Nama", title: "Nama", width: 125
            },
            {
                field: "TglMasukPama", title: "Tgl. Masuk Pama", width: 100, template: "#= (TglMasukPama == null)? '' : kendo.toString(kendo.parseDate(TglMasukPama, 'yyyy-MM-dd'), 'yyyy-MM-dd')#"
            },
            {
                field: "Golongan", title: "Gol", width: 40
            },
            {
                field: "Jabatan", title: "Jabatan", width: 100
            },
            {
                field: "Departemen", title: "Dept", width: 50
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
            if (result.data.NRP == null) {
                alert("Data karyawan belum ada di ellipse");

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
                alert("Data Karyawan terdaftar di ellipse. Silahkan cek kelengkapan data");

                $("#inputNama").val(result.data.NAME);
                $("#inputTempatLahir").val(result.data.BIRTH_PLACE);
                $("#inputTglLahir").val(result.data.BIRT_DATE);
                $("#inputJnsKelamin").val(result.data.GENDER_CODE);
                $("#inputGolDarah").val(result.data.BLOOD_TYPE);
                $("#inputStatusKawin").val();
                $("#inputAgama").val(result.data.RELIGION);
                $("#inputPendidikan").val(result.data.LAST_EDUCATION);
                $("#inputAlamatTinggal").val(result.data.RES_ADDRESS_1 + " " + result.data.RES_ADDRESS_2 + " " + result.data.RES_ADDRESS_3);
                $("#inputJamsostek").val();
                $("#inputDPA").val();
                $("#inputTglMasukPama").val(result.data.HIRE_DATE);
                $("#inputTglPensiun").val();
                $("#inputGolongan").val(result.data.GOLONGAN);
                $("#inputTglPromosi").val();
                $("#inputIDJabatan").val(result.data.POSITION_ID);
                $("#inputJabatan").val(result.data.POST_TITLE);
                $("#inputTglMutasi").val();
                $("#inputStatusKeluarga").val();
                $("#inputStatusBawaKeluarga").val();
                $("#inputTglBawaKeluarga").val();
                $("#inputDepartemen").val(result.data.DEPT_CODE);
                $("#inputStatusPenerimaan").val();
                $("#inputPOH").val(result.data.POINT_OF_HIRE);
                $("#inputGaji").val(0);
                $("#inputRateUlap").val(0);
                $("#inputTelepon").val();
                $("#inputLokasi").val();
                $("#inputOnSite").val();
                $("#inputRekening").val();
                $("#inputPemilikRekening").val();
                $("#inputKodeBank").val();
                $("#inputStatusPekerjaan").val();
                $("#inputCompany").val();
                $("#inputHariKe7").val();
                $("#inputKTP").val();
                $("#inputNPWP").val();
                $("#inputEmail").val();
                $("#inputTelpWa").val();
            }
        }
    })
}