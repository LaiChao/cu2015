function preview() {
    bdhtml = window.document.body.innerHTML; //获取页面内容
    sprnstr = "<!--startprint-->"; //前段标记 sprnstr.length=17
    eprnstr = "<!--endprint-->"; //后段标记
    prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + sprnstr.length); //去掉前段
    prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr)); //去掉后段
    alert(prnhtml);
    //window.document.body.innerHTML = prnhtml; //页面内容
   // window.print(); //打印方法
}