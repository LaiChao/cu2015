clock();
function clock() //自动更新日期时间，格式为：2013年01月01日 11:01:01
{
    window.setTimeout('clock()', 1000);
    var now = new Date();

    var year = now.getFullYear();       //年
    var month = now.getMonth() + 1;     //月
    var day = now.getDate();            //日

    var hh = now.getHours();            //时
    var mm = now.getMinutes();          //分
    var ss = now.getSeconds();
    var clock = year + "年";

    if (month < 10)
        clock += "0";
    clock += month + "月";
    if (day < 10) clock += "0";
    clock += day + "日 ";
    if (hh < 10) clock += "0";
    clock += hh + ":";
    if (mm < 10) clock += '0';
    clock += mm + ":";
    if (ss < 10) clock += '0';
    clock += ss;
    divDate.innerHTML = clock;
}