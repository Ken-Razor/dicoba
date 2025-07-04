
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
            $("#txtExistingName").val(x["Nama"]);
            $("#txtExistingPersonalNumber").val(PersNumber);
            $("#txtExistingPositionCode").val(x["Posisi"]);
            var str = x["Email"];
            var res = str.split("@");
            $("#txtExistingUsername").val(res[0]);

            $('#btnClose')[0].click();
            document.getElementById("divAddRole").style.display = "block";
        }
    });
}

function SetFieldUserPJS(PersNumber) {
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
            $("#txtPJSName").val(x["Nama"]);
            $("#txtPJSPersonalNumber").val(PersNumber);
            $("#txtPJSPositionCode").val(x["Posisi"]);
            var str = x["Email"];
            var res = str.split("@");
            $("#txtPJSUsername").val(res[0]);

            $('#btnClose')[0].click();
            document.getElementById("divAddRole").style.display = "block";
        }
    });
}
