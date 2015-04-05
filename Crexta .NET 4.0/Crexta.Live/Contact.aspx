<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Crexta.Live.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="innerTopContentPlaceHolder" runat="server">
    <article class="pad_left2 col3">
		<h2>İletişim Bilgileri</h2>
		<p class="marg_top">
			<strong>Ülke: </strong>Türkiye<br />
			<strong>Şehir: </strong>İstanbul ve İzmir<br />
			<strong>Eposta: </strong><a href="mailto:info@crexta.com">info@crexta.com</a><br />
            <strong>Twitter: </strong><a href="http://twitter.com/crextacom/">@crextacom</a>
		</p>
	</article>
	<article class="pad_left1">
			<h2>Crexta'yı hemen şimdi kullanın!</h2>
			<p class="marg_top">Crexta'nın size ya da şirketinize faydalı olacağını düşünüyorsanız ya da Crexta hakkında daha fazla bilgiye ve yardıma ihtiyacınız varsa lütfen hemen bizimle iletişime geçin. Size yardım etmekten memnuniyet duyacağız.</p>
	</article>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="innerMainContentPlaceHolder" runat="server">
    <article class="pad_left2">
	    <form runat="server">
	    <h2>İletişim Formu <asp:Label ID="resultLabel" runat="server" ForeColor="#009933" Font-Size="Small"></asp:Label></h2>
		    <div class="wrapper">
			    <div class="wrapper"><p>Adınız:</p><asp:TextBox runat="server" ID="nameTextBox" CssClass="input"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="nameTextBox" 
                        ErrorMessage="* İsim gerekli"></asp:RequiredFieldValidator></div>
			    <div class="wrapper"><p>Eposta:</p><asp:TextBox runat="server" ID="emailTextBox" CssClass="input"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="emailTextBox" 
                        ErrorMessage="* Eposta gerekli"></asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="emailTextBox" ErrorMessage="* Geçerli bir eposta gerekli" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
			    <div class="wrapper"><p>Telefon:</p><asp:TextBox runat="server" ID="phoneTextBox" CssClass="input"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="phoneTextBox" 
                        ErrorMessage="* Telefon gerekli"></asp:RequiredFieldValidator></div>
			    <div class="wrapper"><p>Mesajınız:</p><asp:TextBox runat="server" 
                        ID="messageTextBox" Rows="1" Columns="1" TextMode="MultiLine"></asp:TextBox><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="messageTextBox" 
                        ErrorMessage="* Mesaj gerekli"></asp:RequiredFieldValidator></div>
			    <div class="wrapper">
				    <asp:LinkButton runat="server" ID="sendButton" CssClass="link1 right" 
                        Text="Gönder" onclick="sendButton_Click"></asp:LinkButton>
				    <a href="#" class="link1 right" onClick="document.getElementById('aspnetForm').reset();return false;">Temizle</a>
			    </div>
		    </div>
	    </form>
    </article>
</asp:Content>
