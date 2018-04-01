<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestRequestEntryForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemApp.TestRequestEntryForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Test Request Entry</h3>
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label">Patient Name</label>
                <asp:TextBox ID="patientNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="control-label">Date Of Birth</label>
                <asp:TextBox ID="dateOfBirthTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="control-label">Mobile No</label>
                <asp:TextBox ID="mobileNoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
             <div class="form-group">
                <label class="control-label">Select Test</label>
                <asp:DropDownList ID="testDropDownList" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="testDropDownList_SelectedIndexChanged"></asp:DropDownList>
            </div>
            
            <div class="form-group">
                <label class="control-label">Fee</label>
                <asp:TextBox ID="feeTextBox" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <asp:Button ID="addButton" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="addButton_Click" />
            </div>
            
            <div class="form-group">
                <asp:Label ID="messageLabel" runat="server" Text="" Width="100%"></asp:Label>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
    
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-7">
            <asp:GridView ID="testRequestGridView" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False">
                <columns>
                    <asp:TemplateField HeaderText="Serial">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                        <ItemTemplate> 
                            <asp:Label ID="gdvSerialLabel" runat="server" Text='<%#Eval("Serial") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Id" Visible="False">
                        <ItemStyle HorizontalAlign="Left" Width="40%" ></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvTestIdLabel" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
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
                </columns>
            </asp:GridView>
        </div>
        <div class="col-md-2"></div>
    </div>
    
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label">Total Amount</label>
                <asp:TextBox ID="totalAmountTextBox" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="saveButton" runat="server" CssClass="btn btn-primary pull-right" Text="Save" />
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
</asp:Content>
