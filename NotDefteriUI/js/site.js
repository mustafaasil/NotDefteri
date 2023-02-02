const apiUrl = "https://localhost:7107/api/Notlar";
let notlar = [];
let seciliNot = null;

function listele() {
    $("#notlar").html("");

    $.get(apiUrl, data => {
        notlar = data;
        for (const not of notlar) {
            let a = $("<a/>")
                .addClass("list-group-item")
                .addClass("list-group-action")
                .text(not.baslik)
                .attr("href", "#!")
                .attr("data-id", not.id)
                .click((e) => {
                    e.preventDefault();
                    ac(not);
                });

            if (not.id == seciliNot?.id) {
                seciliNot = not;
                a.addClass("active");
            }

            $("#notlar").append(a);
        }

    });
}

function ac(not) {
    seciliNot = not;
    $("#txtBaslik").val(not.baslik);
    $("#txtIcerik").val(not.icerik);
    $("#notlar>a").removeClass("active");
    $("#notlar>a[data-id=" + not.id + "]").addClass("active");
}

function kaydet(event) {
    event.preventDefault();
    if (seciliNot) {

        let not = { ...seciliNot };
        not.baslik = $("#txtBaslik").val();
        not.icerik = $("#txtIcerik").val();
        $.ajax({
            contentType: "application/json",
            type: "put",
            url: apiUrl + "/" + not.id,
            data: JSON.stringify(not),
            success: function (data) {
                seciliNot = data;
                listele();
            }
        });
    }

    else {
        let not = {};
        not.baslik = $("#txtBaslik").val();
        not.icerik = $("#txtIcerik").val();
        $.ajax({
            contentType: "application/json",
            type: "post",
            url: apiUrl,
            data: JSON.stringify(not),
            success: function (data) {
                seciliNot = data;
                listele();
            }
        });
    }
}

function yeni() {
    seciliNot = null;
    $("#notlar>a").removeClass("active");
    $("#txtBaslik").val("");
    $("#txtIcerik").val("");
}

function sil() {
    if (seciliNot) {
        $.ajax({
            type: "delete",
            url: apiUrl + "/" + seciliNot.id,
            success: function () {
                yeni();
                listele();
            }
        });
    }
}

$("#frmNot").submit(kaydet);
$("#btnYeni").click(yeni);
$("#btnSil").click(sil);

listele();