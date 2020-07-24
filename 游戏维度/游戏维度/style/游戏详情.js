$(function () {
    $(".ThePlayer>input[type='button']").on("click", function () {
        var session = $("#session").val();
        var a = $("<div class='ShowMe'><label>" + session + ":</label><div></div></div>");
        var b = $("<input type='image' src='../Resources/image/小x.png' value='删除' style='opacity:0.6' />");
        /*<input type='image' src='../Resources/image/X.png' value='删除' />*/
        var c = $(".ThePlayer>textarea");
        var d = $("<br /><a href='#'>更多</a>");
        if (c.val() != "") {
            a.children("div").text(c.val());
            a.children("div").append(d);
            b.click(function () {
                alert("删除成功！");
                $(this).parent().parent().remove();
                window.location="游戏详情.aspx";
            })
            $(".AllPlayer li:nth-child(1)>div").append(a);
            $(".AllPlayer li:nth-child(1)>div").append(b);
            $(".AllPlayer li:nth-child(1)").css("display", "block");
            alert("发表评论成功!");
        }
        else
            alert("添加失败!评论不能为空");
    })

    $(".media>input[type='button']").click(function () {
        if ($(this).val() == "<") {//$(".media>div:eq(1)>ul:eq(1)").addClass("HideComment");
            //$(".media>div:eq(1)>ul").removeClass();
            $(".media>div:nth-child(2)>ul").animate({
                left: "0px",
            }, 600)
        }
        else if ($(this).val() == ">") {
            //$(".media>div:eq(1)>ul").removeClass();
            //$(".media>div:eq(1)>ul:eq(0)").addClass("HideComment");
            $(".media>div:nth-child(2)>ul").animate({
                left: "-944px",

            }, 600)
        }
    })

    $(".buy").click(function () {
        location.href = "购物车.html";
    })
})