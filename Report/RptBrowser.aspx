<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptBrowser.aspx.cs" Inherits="HrgaEnhance.Report.RptBrowser" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Browser</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="~/Content/AdminBSB/materialize.css" rel="stylesheet" />
    <link href="~/Content/AdminBSB/style.min.css" rel="stylesheet" />
    <link href="~/Content/AdminBSB/Color/theme-light-blue.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card" style="font-size: small">
            <div class="body">
                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="56000"></asp:ScriptManager>

                <div class="row clearfix">
                    <div class="col-sm-2">
                        <b>Kategori</b>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <i class="glyphicon glyphicon-user"></i>
                            </span>
                            <div class="form-line">
                                <asp:DropDownList ID="ddlKategori" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlKategori_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <b>Pilih Report</b>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <i class="glyphicon glyphicon-calendar"></i>
                            </span>
                            <div class="form-line">
                                <asp:DropDownList ID="ddlReport" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row clearfix">
                    <div class="col-lg-12">
                        <rsweb:ReportViewer ID="rvBrowser" runat="server" ProcessingMode="Remote" Height="760px" Width="100%" AsyncRendering="False" SizeToReportContent="True" Visible="false">
                        </rsweb:ReportViewer>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>