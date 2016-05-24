using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///GridView中的按钮：删除等
/// </summary>
public static class lyf_GridViewButten
{
    //删除按钮：true为显示，false为不显示
    private static bool _btnDelete = true;
    public static bool BtnDeleteVisible { get { return _btnDelete; } set { _btnDelete = value; } }
    //编辑按钮：true为显示，false为不显示
    private static bool _btnEdit = true;
    public static bool BtnEditVisible { get { return _btnEdit; } set { _btnEdit = value; } }
}