<%@ Page Title="" Language="C#" MasterPageFile="~/en/Inner_en.Master" AutoEventWireup="true" CodeBehind="What.aspx.cs" Inherits="Crexta.Live.en.What" %>
<asp:Content ID="Content1" ContentPlaceHolderID="innerTopContentPlaceHolder" runat="server">
    <article class="pad">
    <h2>What is Crexta?</h2>
	    <div class="wrapper marg_top">
		    <figure class="left marg_right1"><img src="/images/page3_img1.jpg" alt="" /></figure>
		    <p class="pad_bot2">Crexta is a powerfull web data extraction framework which makes web data extraction easier and safer. Crexta uses different types of criterias to collect data from the web.</p>
		    <p>Crexta framework contains 3 main applications.</p>
            <ul class="list2 pad_bot1" style="margin-left:130px;padding-bottom: 0;">
                <li><strong>Crexta Explorer</strong></li>
                <li><strong>Crexta Server</strong></li>
                <li><strong>Crexta Client</strong></li>
			</ul>
	    </div>
    </article>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="innerMainContentPlaceHolder" runat="server">
	<article class="col2 pad_left1">
		<h2>Crexta Explorer</h2>
		<p><strong>Explorer</strong> is an application used for creating <strong>Crextors</strong>. A <strong>Crextor</strong> is a stack of information that contains rule definitions and criterias. <strong>Crexta Servers</strong> (application) and <strong>Crexta Clients</strong> (application) then uses these <strong>Crextors</strong> in order to extract data from web sites.</p>
        <p>Usually, creating only one <strong>Crextor</strong> is enough for a single web site. However, if needed, multiple <strong>Crextors</strong> may be defined for a web site. A <strong>Crextor</strong> may contain multiple rules, thus you can get different types of information from a single web site, and a rule may contain multiple criterias that are used to match information.</p>
        <div class="wrapper pad_bot1"><a href="Screenshots.aspx#explorer" class="link1">Screenshots</a></div>
		<h2>Crexta Server</h2>
        <p><strong>Server</strong> is an application which is responsible for distributing tasks to the <strong>Clients</strong>. <strong>Server</strong> delivers <strong>Crextor</strong> definitions to the <strong>Clients</strong> and then validates and stores the data collected by the <strong>Clients</strong>. Stored data is served from an <a href="Api.aspx">API</a> provided by <strong>Crexta</strong>. One physical server (hardware) may contain multiple <strong>Crexta Server</strong> applications.</p>
        <div class="wrapper pad_bot1"><a href="Screenshots.aspx#server" class="link1">Screenshots</a></div>
		<h2>Crexta Client</h2>
        <p><strong>Client</strong> is an application which is responsible for accomplishing the tasks delivered by the <strong>Server</strong>. Clients work in two different modes: <strong>Data Extractor</strong> ve <strong>URL Finder</strong>. Clients working as a <strong>Data Extractor</strong>, extract data from the targeted web sites by using the <strong>Crextor</strong> definitions delivered by the Servers to them. However, Clients working as a <strong>URL Finder</strong>, find specific URLs of a web site by using rule definitions. These collected URLs are then used by other Clients (working as Data Extractors) in order to extract data. One physical server (hardware) may contain multiple <strong>Crexta Client</strong> applications.</p>
		<div class="wrapper pad_bot1"><a href="Screenshots.aspx#client" class="link1">Screenshots</a></div>
	</article>
</asp:Content>