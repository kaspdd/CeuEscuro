﻿<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManagerUser.aspx.cs" Inherits="CeuEscuro.adm.ManagerUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Conteudo fica aqui dentro -->
    <asp:Label ID="lblSession" runat="server" Text=""></asp:Label>


    <!-- Formulario -->
    <ul>
        <li>
            <asp:TextBox ID="txtIdUsuario" placeholder="Id:" runat="server"></asp:TextBox>
        </li>
        <li>
            <asp:TextBox ID="txtNomeUsuario" MaxLength="150" placeholder="Nome:" runat="server"></asp:TextBox>
            <asp:Label ID="lblNomeUsuario" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtEmailUsuario" MaxLength="150" placeholder="Email:" runat="server"></asp:TextBox>
            <asp:Label ID="lblEmailUsuario" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtSenhaUsuario" MaxLength="6" placeholder="Senha:" runat="server"></asp:TextBox>
            <asp:Label ID="lblSenhaUsuario" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtDtNascUsuario" onkeypress="$(this).mask('00/00/0000')"  placeholder="Data de nascimento:" runat="server"></asp:TextBox>
            <asp:Label ID="lblDtNascUsuario" runat="server" Text=""></asp:Label>
        </li>
        <li>                                                                            <!--serve para passar o valor--><!--serve para receber o valor-->
            <asp:DropDownList ID="ddl1" Width="160px" Height="27px" AutoPostBack="false" DataValueField="IdTipoUsuario" DataTextField="DescricaoTipoUsuario" runat="server">

            </asp:DropDownList>
        </li>
        <li>

            <asp:Button ID="btnRecord" runat="server" Text="Record" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" />
            <asp:Button ID="btnDelete" OnClientClick="if(!confirm('Deseja realmente eliminar este registro?'))return false" runat="server" Text="Delete" />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" placeholder="Search by name" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
    </ul>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <!-- GridView-->
    <!-- Listando usuarios -->
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options"/>
            <asp:BoundField DataField="IdUsuario" HeaderText="Codigo" />
            <asp:BoundField DataField="NomeUsuario" HeaderText="Nome" />
            <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
            <asp:BoundField DataField="SenhaUsuario" HeaderText="Senha" />
            <asp:BoundField DataField="DtNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissao" />
        </Columns>
    </asp:GridView>
</asp:Content>
