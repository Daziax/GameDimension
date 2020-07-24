$(function () {
    $(".clsnav>a").click(function () {
        $(this).removeClass(); 
        var index = $(this).index();
        $(".clscont>div").each(function () {
            $(".clscont>div").removeClass();
        })
        $(".clscont>div:eq(" + index + ")").addClass("ClsContItemCurrent");
    })
})