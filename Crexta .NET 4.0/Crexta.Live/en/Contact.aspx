<%@ Page Title="" Language="C#" MasterPageFile="~/en/Inner_en.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Crexta.Live.en.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="innerTopContentPlaceHolder" runat="server">
    <article class="pad_left2 col3">
		<h2>Our Contacts</h2>
		<p class="marg_top">
			<strong>Country: </strong>Turkey<br />
			<strong>City: </strong>İstanbul and İzmir<br />
			<strong>Email: </strong><a href="mailto:info@crexta.com">info@crexta.com</a><br />
            <strong>Twitter: </strong><a href="http://twitter.com/crextacom/">@crextacom</a>
		</p>
	</article>
	<article class="pad_left1">
			<h2>Use Crexta now!</h2>
			<p class="marg_top">If you think that Crexta could be useful for your company or if you have further questions about Crexta, please feel free to contact us. Thank you.</p>
	</article>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="innerMainContentPlaceHolder" runat="server">
    <article class="pad_left2">
	    <form id="Form1" runat="server">
	    <h2>Contact Form <asp:Label ID="resultLabel" runat="server" ForeColor="#009933" Font-Size="Small"></asp:Label></h2>
		    <div class="wrapper">
			    <div class="wrapper"><p>Name:</p><asp:TextBox runat="server" ID="nameTextBox" CssClass="input"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="nameTextBox" 
                        ErrorMessage="* Name required"></asp:RequiredFieldValidator></div>
			    <div class="wrapper"><p>Email:</p><asp:TextBox runat="server" ID="emailTextBox" CssClass="input"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="emailTextBox" 
                        ErrorMessage="* Email required"></asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="emailTextBox" ErrorMessage="* A valid email required" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
			    <div class="wrapper"><p>Phone:</p><asp:TextBox runat="server" ID="phoneTextBox" CssClass="input"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="phoneTextBox" 
                        ErrorMessage="* Phone required"></asp:RequiredFieldValidator></div>
			    <div class="wrapper"><p>Message:</p><asp:TextBox runat="server" 
                        ID="messageTextBox" Rows="1" Columns="1" TextMode="MultiLine"></asp:TextBox><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="messageTextBox" 
                        ErrorMessage="* Message required"></asp:RequiredFieldValidator></div>
			    <div class="wrapper">
				    <asp:LinkButton runat="server" ID="sendButton" CssClass="link1 right" 
                        Text="Send" onclick="sendButton_Click"></asp:LinkButton>
				    <a href="#" class="link1 right" onClick="document.getElementById('aspnetForm').reset();return false;">Clear</a>
			    </div>
		    </div>
	    </form>
    </article>
</asp:Content>
