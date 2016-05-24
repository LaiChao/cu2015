
　　var LODOP; //声明为全局变量    
        //打印报表  
        function prnTable_preview() {
            CreateOneFormPage_Table();
            //  LODOP.PREVIEW();
            // LODOP.PRINT_SETUP();
            LODOP.PRINT_DESIGN();

        };
        //打印图表
        function prnPic_preview() {
            CreateOneFormPage_Pic();
            //          LODOP.PREVIEW();
            //        LODOP.PRINT_SETUP();
            LODOP.PRINT_DESIGN();
        };
        //divReport:报表外面Div的Id
        function CreateOneFormPage_Table() {
            LODOP = getLodop();
            LODOP.PRINT_INIT("打印控件功能演示_Lodop功能_表单一");
            LODOP.SET_PRINT_STYLE("FontSize", 18);
            LODOP.SET_PRINT_STYLE("Bold", 1);
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", document.getElementById("divReport").innerHTML);
        };
        //divChart:图表外面Div的Id
        function CreateOneFormPage_Pic() {
            LODOP = getLodop();
            LODOP.PRINT_INIT("打印控件功能演示_Lodop功能_表单一");
            LODOP.SET_PRINT_STYLE("FontSize", 18);
            LODOP.SET_PRINT_STYLE("Bold", 1);
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", document.getElementById("divChart").innerHTML);
            //        LODOP.ADD_PRINT_IMAGE(0, 0, "100%", "100%", document.getElementById("divChart").innerHTML);
            //        LODOP.SET_PRINT_STYLEA(0, "Stretch", 2); //按原图比例(不变形)缩放模式,image有效，htm无效；design横向旋转后，打印无图像

        };
