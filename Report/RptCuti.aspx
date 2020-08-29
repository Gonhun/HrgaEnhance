<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptCuti.aspx.cs" Inherits="HrgaEnhance.Report.RptCuti" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Surat Cuti</title>
        <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
        <link href="~/Content/bootstrap-theme.min.css" rel="stylesheet" />
        <link href="~/Content/AdminBSB/materialize.css" rel="stylesheet" />
        <link href="~/Content/AdminBSB/style.min.css" rel="stylesheet" />
        <link href="~/Content/AdminBSB/Color/theme-light-blue.min.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="row clearfix">
                <input type="hidden" id="urlPath" name="urlPath" value="@ViewBag.pathParent" />
                <div class="col-sm-12">
                    <div class="card">
                        <div class="body">
                            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="56000"></asp:ScriptManager>
                            <div class="row clearfix">
                                <div class="col-lg-12">
                                    <rsweb:ReportViewer ID="rvCuti" runat="server" ProcessingMode="Remote" Height="760px" Width="100%" AsyncRendering="False" SizeToReportContent="True" ShowParameterPrompts="false">
                                    </rsweb:ReportViewer>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </form>
    </body>
</html>
