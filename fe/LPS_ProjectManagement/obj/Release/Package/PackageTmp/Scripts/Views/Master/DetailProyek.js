
(function ($) {
    $.fn.extend({
        donetyping: function (callback, timeout) {
            timeout = timeout || 1e3; // 1 second default timeout
            var timeoutReference,
                doneTyping = function (el) {
                    if (!timeoutReference) return;
                    timeoutReference = null;
                    callback.call(el);
                };
            return this.each(function (i, el) {
                var $el = $(el);

                $el.is(':input') && $el.on('keyup keypress paste', function (e) {
                    if (e.type === 'keyup' && e.keyCode !== 8) return;

                    if (timeoutReference) clearTimeout(timeoutReference);
                    timeoutReference = setTimeout(function () {
                        doneTyping(el);
                    }, timeout);
                }).on('blur', function () {
                    doneTyping(el);
                });
            });
        }
    });
})(jQuery);


$('#txtCostCTR').donetyping(function () {
    var RKAT = {
        DESCRIPTION: $('#txtCostCTR').val()
    }
    $.ajax({
        url: urlTableSAPRkAT,
        type: 'POST',
        data: RKAT,
        success: function (result) {
            $('#tblListRKAT').DataTable().clear();
            $('#tblListRKAT').DataTable().destroy();

            var obj = result.ListRKAT;
            var html = "";
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    html += "<tr>" +
                        "<td>" + obj[prop]["IDSAP"] + "</td>" +
                        "<td>" + obj[prop]["DESCRIPTION"] + "</td>" +
                        "<td>" + obj[prop]["Value"] + "</td>" +
                        "<td>" +
                        "<button type=\"button\" class=\"btn btn-info btn-corner\" id=\"btnTambah\" onclick=\"AddListTableRKAT(" +
                        + obj[prop]["IDSAPRKAT"] + "," +
                        "'" + obj[prop]["IDSAP"] + "'," +
                        "'" + obj[prop]["DESCRIPTION"] + "'," +
                        "'" + obj[prop]["Value"] +
                        "')\"> <i class=\"fa fa-plus\"></i>&nbsp;&nbsp; Pilih</button>" +
                        "</a>" +
                        "</td>" +
                        "</tr>";

                }
            }
            $("#ListRKAT").append(html);
            $('#tblListRKAT').DataTable({
                "bLengthChange": false,
                searching: false,
                info: false,
                "pageLength": 4
            });
        }
    });
});

$('#txtNameKPI').donetyping(function () {
    debugger;
    var KPIO = {
        KPIName: $('#txtNameKPI').val()
    }
    $.ajax({
        url: urlTableMasterKPI,
        type: 'POST',
        data: KPIO,
        success: function (result) {
            $('#tblListKPI').DataTable().clear();
            $('#tblListKPI').DataTable().destroy();

            var obj = result.ListKPIOrganization;
            var html = "";

            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    html += "<tr>" +
                        "<td>" + obj[prop]["KPICode"] + "</td>" +
                        "<td>" + obj[prop]["KPIName"] + "</td>" +
                        "<td>" + obj[prop]["Year"] + "</td>" +
                        "<td>" +
                        "<button type=\"button\" class=\"btn btn-info btn-corner\" id=\"btnTambah\" onclick=\"AddListTableKPI(" +
                        +obj[prop]["IDKPIOrganization"] + "," +
                        "'" + obj[prop]["KPICode"] + "'," +
                        "'" + obj[prop]["KPIName"] + "'," +
                        "'" + obj[prop]["Year"] +
                        "')\"> <i class=\"fa fa-plus\"></i>&nbsp;&nbsp; Pilih</button>" +
                        "</a>" +
                        "</td>" +
                        "</tr>";
                }
            }
            $("#ListKPI").append(html);
            $('#tblListKPI').DataTable({
                "bLengthChange": false,
                searching: false,
                info: false,
                "pageLength": 4
            });
        }
    });
});

$('#txtMku').donetyping(function () {
    debugger;
    var MKUO = {
        DepartmentName: $('#txtMku').val()
    }
    $.ajax({
        url: urlTableMasterDepartment,
        type: 'POST',
        data: MKUO,
        success: function (result) {
            $('#tblListMKU').DataTable().clear();
            $('#tblListMKU').DataTable().destroy();

            var obj = result.ListDepartment;
            var html = "";

            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    html += "<tr>" +
                        "<td>" + obj[prop]["DepartmentCode"] + "</td>" +
                        "<td>" + obj[prop]["DepartmentName"] + "</td>" +
                        "<td>" +
                        "<button type=\"button\" class=\"btn btn-info btn-corner\" id=\"btnTambah\" onclick=\"AddListTableMKU(" +
                        +obj[prop]["IDDepartment"] + "," +
                        "'" + obj[prop]["DepartmentCode"] + "'," +
                        "'" + obj[prop]["DepartmentName"] +
                        "')\"> <i class=\"fa fa-plus\"></i>&nbsp;&nbsp; Pilih</button>" +
                        "</a>" +
                        "</td>" +
                        "</tr>";
                }
            }
            $("#ListMKU").append(html);
            $('#tblListMKU').DataTable({
                "bLengthChange": false,
                searching: false,
                info: false,
                "pageLength": 4
            });
        }
    });
});

$('#txtFullName').donetyping(function () {

    var GetEmployeeData = {
        ID: $('#txtFullName').val()
    }
    $.ajax({
        url: urlGetDataEmployeeByName,
        type: 'POST',
        data: {
            __RequestVerificationToken: token,
            GetEmployeeData: GetEmployeeData
        },
        success: function (result) {
            $('#tblListUserModal').DataTable().clear();
            $('#tblListUserModal').DataTable().destroy();

            var obj = result._search;
            var html = "";
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    html += "<tr>" +
                        "<td>" + obj[prop]["nama"] + "</td>" +
                        "<td>" + obj[prop]["posisi"] + "</td>" +
                        "<td>" +
                        "<button type='button' class='btn btn-info btn-corner' id='btnTambah' onclick='SetFieldUser(" + obj[prop]["personalnumber"] + ")'> <i class='fa fa-plus'></i>&nbsp;&nbsp; Pilih</button>" +
                        "</a>" +
                        "</td>" +
                        "</tr>";
                }
            }
            $("#ListUserBody").append(html);
            $('#tblListUserModal').DataTable({
                "bLengthChange": false,
                searching: false,
                info: false,
                "pageLength": 4
            });
        }
    });
});


function AddListTableRKAT(IDSAPRKAT, IDSAP, DESCRIPTION, Value) {

    var tableRKAT = $('#tblRKAT').DataTable();
    var dataRKAT = tableRKAT.rows().data();
    var Valid = true;

    for (i = 0; i < dataRKAT.length; i++) {
        var rowsRKAT = dataRKAT[i];

        if (IDSAPRKAT.toString() === rowsRKAT[0].toString()) {
            Valid = false;
        }

    }

    if (Valid === true) {

        if ($('#tblRKAT tr').length = 0) {
            $('#tblRKAT').DataTable().clear();
        }
        $('#tblRKAT').DataTable().destroy();

        $('#tblRKAT tbody').append('<tr><td style="display:none">' + IDSAPRKAT + '</td><td>' + IDSAP + '</td><td>' + DESCRIPTION + '</td><td>' + Value + '</td><td>  <a class="btn btn-danger tooltipcustom margin-top-5 margin-bottom-5" onclick="DeleteListTableRKAT(this)"><i class="fa fa-trash"></i><span class="tooltiptext"> Hapus</span></a> </td></tr>');

        $('#tblRKAT').DataTable({
            "bLengthChange": false,
            searching: false,
            info: false,
            "scrollX": true
        });
        $('#btnCloseRKATModal')[0].click();
    }
    else {
        alert("Kegiatan sudah di pilih");
    }
    
}

function AddListTableKPI(IDKPIOrganization, KPICode, KPIName, Year) {

    var tableKPI = $('#tblKPI').DataTable();
    var dataKPI = tableKPI.rows().data();
    var Valid = true;

    for (i = 0; i < dataKPI.length; i++) {
        var rowsKPI = dataKPI[i];

        if (IDKPIOrganization.toString() === rowsKPI[0].toString()) {
            Valid = false;
        }

    }

    if (Valid === true) {

        if ($('#tblKPI tr').length = 0) {
            $('#tblKPI').DataTable().clear();
        }
        $('#tblKPI').DataTable().destroy();

        $('#tblKPI tbody').append('<tr><td style="display:none">' + IDKPIOrganization + '</td><td>' + KPICode + '</td><td>' + KPIName + '</td><td>' + Year + '</td><td>  <a class="btn btn-danger tooltipcustom margin-top-5 margin-bottom-5" onclick="DeleteListTableKPI(this)"><i class="fa fa-trash"></i><span class="tooltiptext"> Hapus</span></a> </td></tr>');

        $('#tblKPI').DataTable({
            "bLengthChange": false,
            searching: false,
            info: false,
            "scrollX": true
        });

        $('#btnCloseKPIModal')[0].click();
    }
    else {
        alert("KPI sudah di pilih");
    }
}

function AddListTableMKU(IdDepartment, DepartmentCode, DepartmentName) {

    var tableMKU = $('#tblMKU').DataTable();
    var dataMKU = tableMKU.rows().data();
    var Valid = true;
    debugger;
    for (i = 0; i < dataMKU.length; i++) {
        var rowsKPI = dataMKU[i];

        if (IdDepartment.toString() === rowsKPI[0].toString()) {
            Valid = false;
        }

    }

    if (Valid === true) {

        if ($('#tblMKU tr').length = 0) {
            $('#tblMKU').DataTable().clear();
        }
        $('#tblMKU').DataTable().destroy();

        $('#tblMKU tbody').append('<tr><td style="display:none">' + IdDepartment + '</td><td>' + DepartmentCode + '</td><td>' + DepartmentName + '</td><td>  <a class="btn btn-danger tooltipcustom margin-top-5 margin-bottom-5" onclick="DeleteListTableMKU(this)"><i class="fa fa-trash"></i><span class="tooltiptext"> Hapus</span></a> </td></tr>');

        $('#tblMKU').DataTable({
            "bLengthChange": false,
            searching: false,
            info: false,
            "scrollX": true
        });

        $('#btnCloseMKUModal')[0].click();
    }
    else {
        alert("Unit Kerja sudah di pilih");
    }
}

function AddListTableUser() {

    document.getElementById("divAddRole").style.display = "none";

    var objLRG = ListRoleGroup;
    var RoleName = "";
    var RoleID = "";
    var Nama = $("#txtNamaDisable").val();
    var Username = $("#txtUsername").val();
    var Jabatan = $("#txtJabatan").val();

    for (x = 0; x < objLRG.length; x++) {
        var idcb = '#' + objLRG[x].IDRoleGroup;
        if ($(idcb).is(":checked")) {
            RoleName = RoleName + objLRG[x].RoleGroupName + ", ";
            RoleID = RoleID + objLRG[x].IDRoleGroup + "|";
        }
    }
    var newRoleID = RoleID.substr(0, RoleID.length - 1);

    if ($('#tblListUser tr').length = 0) {
        $('#tblListUser').DataTable().clear();
    }
    $('#tblListUser').DataTable().destroy();

    $('#tblListUser tbody').append('<tr><td>' + Jabatan + '</td><td>' + Nama + '</td><td style="display : none">' + Username + '</td><td>' + RoleName + '</td><td style="display : none">' + newRoleID + '</td><td>  <a class="btn btn-danger tooltipcustom margin-top-5 margin-bottom-5" onclick="DeleteListTableUser(this)"><i class="fa fa-trash"></i><span class="tooltiptext">Hapus</span></a> </td></tr>');

    $('#tblListUser').DataTable({
        "bLengthChange": false,
        searching: false,
        info: false
    }); 

}


function DeleteListTableRKAT(element) {
    var r = confirm("Anda yakin ingin menghapus Kegiatan ini ?");
    if (r == true) {
        if ($('#tblRKAT tr').length = 0) {
            $('#tblRKAT').DataTable().clear();
        }
        $('#tblRKAT').DataTable().destroy();

        document.getElementById("tblRKAT").deleteRow(element.parentNode.parentNode.rowIndex);

        $('#tblRKAT').DataTable({
            "bLengthChange": false,
            searching: false,
            info: false,
            "scrollX": true
        });

    }
}

function DeleteListTableKPI(element) {
    var r = confirm("Anda yakin ingin menghapus KPI ini ?");
    if (r == true) {
        if ($('#tblKPI tr').length = 0) {
            $('#tblKPI').DataTable().clear();
        }
        $('#tblKPI').DataTable().destroy();

        document.getElementById("tblKPI").deleteRow(element.parentNode.parentNode.rowIndex);

        $('#tblKPI').DataTable({
            "bLengthChange": false,
            searching: false,
            info: false,
            "scrollX": true
        });

    }
}

function DeleteListTableMKU(element) {
    var r = confirm("Anda yakin ingin menghapus Unit Kerja ini ?");
    if (r == true) {
        if ($('#tblMKU tr').length = 0) {
            $('#tblMKU').DataTable().clear();
        }
        $('#tblMKU').DataTable().destroy();

        document.getElementById("tblMKU").deleteRow(element.parentNode.parentNode.rowIndex);

        $('#tblMKU').DataTable({
            "bLengthChange": false,
            searching: false,
            info: false,
            "scrollX": true
        });

    }
}

function DeleteListTableUser(element) {
    var r = confirm("Anda yakin ingin menghapus User ini ?");
    if (r == true) {
        if ($('#tblListUser tr').length = 0) {
            $('#tblListUser').DataTable().clear();
        }
        $('#tblListUser').DataTable().destroy();

        document.getElementById("tblListUser").deleteRow(element.parentNode.parentNode.rowIndex);

        $('#tblListUser').DataTable({
            "bLengthChange": false,
            searching: false,
            info: false
        }); 

    }
}


function InsertMasterProject() {

    var ddlProgram = document.getElementById("ddlProgram");
    var IDProgram = ddlProgram.options[ddlProgram.selectedIndex].value;

    var ddlSO = document.getElementById("ddlSO");
    var IDStrategicObjective = ddlSO.options[ddlSO.selectedIndex].value;

    var ddlPP = document.getElementById("ddlPP");
    var IDProjectPriority = ddlPP.options[ddlPP.selectedIndex].value;

    var ddlDepartment = document.getElementById("ddlDepartment");
    var IDDepartment = ddlDepartment.options[ddlDepartment.selectedIndex].value;

    var ddlKategori = document.getElementById("ddlKategori");
    var IDKategoriProject = ddlKategori.options[ddlKategori.selectedIndex].value;

    var ddlYear = document.getElementById("ddlYear");
    var Year = ddlYear.options[ddlYear.selectedIndex].value;

    var ddlIsTransformasi = document.getElementById("ddlIsTransformasi");
    var result = ddlIsTransformasi.options[ddlIsTransformasi.selectedIndex].value;
    var IsTransformasi;

    if (result === '1') {
        IsTransformasi = 'true';
    } else {
        IsTransformasi = 'false';
    }

    var tableRKAT = $('#tblRKAT').DataTable();
    var dataRKAT = tableRKAT.rows().data();
    var ListRKAT = [];

    for (i = 0; i < dataRKAT.length; i++) {
        var rowsRKAT = dataRKAT[i];
        ListRKAT.push({ IDSAPRKAT: rowsRKAT[0] });
    }

    var tableKPI = $('#tblKPI').DataTable();
    var dataKPI = tableKPI.rows().data();
    var ListKPIOrganization = [];

    for (i = 0; i < dataKPI.length; i++) {
        var rowsKPI = dataKPI[i];
        ListKPIOrganization.push({ IDKPIOrganization: rowsKPI[0] });
    }

    var tableMKU = $('#tblMKU').DataTable();
    var dataMKU = tableMKU.rows().data();
    var ListMKU = [];

    for (i = 0; i < dataMKU.length; i++) {
        var rowsMKU = dataMKU[i];
        ListMKU.push({ IdDepartment: rowsMKU[0] });
    }

    var tableUser = $('#tblListUser').DataTable();
    var dataUser = tableUser.rows().data();
    var ListProjectRoleGroup = [];

    for (i = 0; i < dataUser.length; i++) {
        var rowsUser = dataUser[i];
        ListProjectRoleGroup.push({
            Username: rowsUser[2],
            RoleGroupID: rowsUser[4]
        });
    }
    
    var Project = {
        IDProgram: IDProgram,
        IDStrategicObjective: IDStrategicObjective,
        IDProjectPriority: IDProjectPriority,
        IDDepartment: IDDepartment,
        ProjectNo: $('#txtNoProject').val(),
        Year: Year,
        ProjectName: $('#txtProjectName').val(),
        Weight: $('#txtWeight').val(),
        Poin: $('#txtPoin').val(),
        IsTransformasi: IsTransformasi,
        CreatedBy: $('#hdf').val(),
        ListRKAT: ListRKAT,
        ListKPIOrganization: ListKPIOrganization,
        ListProjectRoleGroup: ListProjectRoleGroup,
        ListMKU : ListMKU,
        IDKategoriProject: IDKategoriProject,
    };
    console.log(Project);
    if (dataKPI.length === 0) {
        alert("Masukan KPI terlebih dahulu");
    }
    else if (dataRKAT.length === 0){
         alert("Masukan Kegiatan terlebih dahulu");
    }
    else
    {
            $.ajax({
                type: "POST",
                url: urlInsertProyek,
                data: Project,
                success: function (result) {
                    if (result.Result === "Success") {
                        alert(result.Message);
                        window.location.href = urlMasterProyek;
                    } else {
                        alert(result.Message);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                }
            });
    }
}

function UpdateMasterProject(IDProject) {
    var ddlProgram = document.getElementById("ddlProgram");
    var IDProgram = ddlProgram.options[ddlProgram.selectedIndex].value;

    var ddlSO = document.getElementById("ddlSO");
    var IDStrategicObjective = ddlSO.options[ddlSO.selectedIndex].value;

    var ddlPP = document.getElementById("ddlPP");
    var IDProjectPriority = ddlPP.options[ddlPP.selectedIndex].value;

    var ddlDepartment = document.getElementById("ddlDepartment");
    var IDDepartment = ddlDepartment.options[ddlDepartment.selectedIndex].value;

    var ddlKategori = document.getElementById("ddlKategori");
    var IDKategoriProject = ddlKategori.options[ddlKategori.selectedIndex].value;

    var ddlYear = document.getElementById("ddlYear");
    var Year = ddlYear.options[ddlYear.selectedIndex].value;

    var ddlIsTransformasi = document.getElementById("ddlIsTransformasi");
    var result = ddlIsTransformasi.options[ddlIsTransformasi.selectedIndex].value;
    var IsTransformasi;   
    if (result === '1') {
        IsTransformasi = 'true';
    } else {
        IsTransformasi = 'false';
    }

    var tableRKAT = $('#tblRKAT').DataTable();
    var dataRKAT = tableRKAT.rows().data();
    var ListRKAT = [];

    for (i = 0; i < dataRKAT.length; i++) {
        var rowsRKAT = dataRKAT[i];
        ListRKAT.push({ IDSAPRKAT: rowsRKAT[0] });
    }

    var tableKPI = $('#tblKPI').DataTable();
    var dataKPI = tableKPI.rows().data();
    var ListKPIOrganization = [];

    for (i = 0; i < dataKPI.length; i++) {
        var rowsKPI = dataKPI[i];
        ListKPIOrganization.push({ IDKPIOrganization: rowsKPI[0] });
    }

    var tableMKU = $('#tblMKU').DataTable();
    var dataMKU = tableMKU.rows().data();
    var ListMKU = [];

    for (i = 0; i < dataMKU.length; i++) {
        var rowsMKU = dataMKU[i];
        ListMKU.push({ IdDepartment: rowsMKU[0] });
    }

    var tableUser = $('#tblListUser').DataTable();
    var dataUser = tableUser.rows().data();
    var ListProjectRoleGroup = [];

    for (i = 0; i < dataUser.length; i++) {
        var rowsUser = dataUser[i];
        ListProjectRoleGroup.push({
            Username: rowsUser[2],
            RoleGroupID: rowsUser[4]
        });
    }
    
    var Project = {
        IDProject: IDProject,
        IDProgram: IDProgram,
        IDStrategicObjective: IDStrategicObjective,
        IDProjectPriority: IDProjectPriority,
        IDDepartment: IDDepartment,
        IDKategoriProject: IDKategoriProject,
        ProjectNo: $('#txtNoProject').val(),
        Year: Year,
        ProjectName: $('#txtProjectName').val(),
        Weight: $('#txtWeight').val(),
        Poin: $('#txtPoin').val(),
        IsTransformasi: IsTransformasi,
        CreatedBy: $('#hdf').val(),
        ListRKAT: ListRKAT,
        ListKPIOrganization: ListKPIOrganization,
        ListProjectRoleGroup: ListProjectRoleGroup,
        ListMKU: ListMKU,
    };
    if (dataKPI.length === 0) {
        alert("Masukan KPI terlebih dahulu");
    }
    else if (dataRKAT.length === 0) {
        alert("Masukan Kegiatan terlebih dahulu");
    }
    else {
        $.ajax({
            type: "POST",
            url: urlUpdateProyek,
            data: Project,
            success: function (result) {
                if (result.Result === "Success") {
                    alert(result.Message);
                    window.location.href = urlMasterProyek;
                } else {
                    alert(result.Message);
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    }
    
}


function SetFieldUser(PersNumber) {
    var GetEmployeeData = {
        ID: PersNumber
    };

    $.ajax({
        url: GetDetailKaryawanURl,
        type: 'POST',
        data: {
            __RequestVerificationToken: token,
            GetEmployeeData: GetEmployeeData
        },
        success: function (result) {
            var x = result._ListUser;
            $("#txtNamaDisable").val(x["Nama"]);
            $("#txtJabatan").val(x["Posisi"]);
            var str = x["Email"];
            var res = str.split("@");
            $("#txtUsername").val(res[0]);

            $('#btnClose')[0].click();
            document.getElementById("divAddRole").style.display = "block";
        }
    });
}
