<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemApp.TestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-md-12">
            <h3>Test Form</h3>
        </div>
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label">Test Name</label>
                <asp:TextBox ID="testNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="control-label">Fee (BDT)</label>
                <asp:TextBox ID="feeTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="control-label">Test Type</label>
                <asp:DropDownList ID="testTypeDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            
            <asp:HiddenField ID="idHiddenField" runat="server" />
            <div class="form-group">
                <div class="col-md-2 btn-group">
                    <asp:Button ID="saveButton" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="saveButton_Click" />
                </div>
                
                <div class="col-md-2 btn-group">
                    <asp:Button ID="findButton" runat="server" CssClass="btn btn-primary" Text="Find" OnClick="findButton_Click" />
                </div>
                
                <div class="col-md-2 btn-group">
                    <asp:Button ID="updateButton" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="updateButton_Click" />
                </div>
                
                <div class="col-md-2 btn-group">
                    <asp:Button ID="deleteButton" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="deleteButton_Click" />
                </div>
            </div>
            
            <div class="form-group">
                <asp:Label ID="messageLabel" runat="server" Text="" Width="100%"></asp:Label>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
    
    <div class="row">
        <div class="col-md-2">
            
        </div>
        <div class="col-md-8">
            <asp:GridView ID="testGridView" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False">
                <columns>
                    <asp:TemplateField HeaderText="Serial">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                        <ItemTemplate> 
                            <asp:Label ID="gdvSerialLabel" runat="server" Text='<%#Eval("Serial") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Test Name">
                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvTestNameLabel" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Fee (BDT)">
                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvFeeLabel" runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Type Name">
                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvTypeNameLabel" runat="server" Text='<%#Eval("TestTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </columns>
            </asp:GridView>
        </div>
        <div class="col-md-2">
            
        </div>
    </div>
</asp:Content>
