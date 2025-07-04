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

function GetListKarayawan(PersonalNumber) {
    $("#hfdPersnom").val(PersonalNumber); 
    
    var GetEmployeeData = {
        ID: PersonalNumber
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
            $("#txtNIK").html(x["NIK"]);
            $("#txtNama").html(x["Nama"]);
            $("#txtPosisi").html(x["Posisi"]);
            $("#txtDepartement").html(x["UnitKerja"]);
            $("#txtEmail").html(x["Email"]);
            $("#txtAlamat").html(x["Alamat"]);
            var str = x["Email"];
            var res = str.split("@");
            $("#txtUsername").val(res[0]);
            
            $('#btnClose')[0].click();

          

        }
    });
}

function GetListProjectByID(ProgramNumber) {
     var GetProject = {
        IDProgram : ProgramNumber
    };
        

    $.ajax({
        url: GetListProject,
        type: 'POST',
        data: {
            __RequestVerificationToken: token,
            GetProject: GetProject
        },
        success: function (result) {

            //var html = "";
           
            //var obj = result._ListProject;
            //debugger;
            //$('.ddlProject').empty();
            //if (obj.length > 0) {
            //    for (var prop in obj) {
            //        if (obj.hasOwnProperty(prop)) {
            //            var newOption = new Option(obj[prop]["ProjectName"], obj[prop]["IDProject"], false, false);
                         
            //             $('.ddlProject').append(newOption).trigger('change');

            //        }
            //    }
            //} else {
            //    $('.ddlProject').empty();
            //    $('.ddlProject').val(null).trigger('change');
            //}






            debugger;
            var select = document.getElementById("ddlProject");
            select.innerHTML = "";

            select.innerHTML += "<option value=0>Pilih Project</option>";

            if (result._ListProject.length > 0) {
                for (var i = 0; i <= result._ListProject.length; i++) {
                    select.innerHTML += "<option value=\"" + result._ListProject[i].IDProject + "\">" + result._ListProject[i].ProjectName + "</option>";
                }
            }
            
        }
    });
}

