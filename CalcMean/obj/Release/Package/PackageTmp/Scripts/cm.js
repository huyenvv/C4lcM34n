$(document).ready(function () {
    $(".confirmDelete").click(function () {
        return confirm("Bạn có chắc?");
    });
    $("ul#Menu li a").each(function () {
        var item = $(this);
        var link = item.attr('href') + "/" + item.attr('data-href') + "/";
        var isActive = link.indexOf(getController() + "/") != -1 && link.indexOf(getAction() + "/") != -1;
        if (isActive) {
            item.parent().addClass('active');
        }
    });

    $("#SoTien").autoNumeric("init", {
        aSep: ',',
        aDec: '.',
        mDec: 0
    });
});

function beforAddMoney() {
    var newValue = $("#SoTien").val().replace(/,/g, "");
    $("#SoTien").val(newValue);
    return true;
}

// show hide button Edit & Delete when click checkbox
$(".checkAll").click(function () {
    if ($(this).is(':checked')) {
        $(".checkitem").prop('checked', true);
    } else {
        $(".checkitem").prop('checked', false);
    }
});
$(".checkitem").click(function () {
    var numberOfChecked = $('input:checkbox:checked').length;
    var numberItem = $('input:checkbox.checkitem').length;
    if ($(this).is(':checked')) {
        if (numberItem === numberOfChecked) {
            $(".checkAll").prop('checked', true);
        }
    } else {
        $(".checkAll").prop('checked', false);
    }
});
