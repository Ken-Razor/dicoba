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
            debugger;
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