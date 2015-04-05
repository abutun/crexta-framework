<%@ Page Title="" Language="C#" MasterPageFile="~/en/Inner_en.Master" AutoEventWireup="true" CodeBehind="Api.aspx.cs" Inherits="Crexta.Live.en.Api" %>
<asp:Content ID="Content1" ContentPlaceHolderID="innerTopContentPlaceHolder" runat="server">
    <article class="pad">
    <h2>Crexta API (Application Programming Interface)</h2>
	    <div class="wrapper marg_top">
		    <p class="pad_bot2">Crexta collects and extracts data from the web using pre-defined Crextors and stores all collected data to a relational database management system. Users can use XML web services API in order to get data from Crexta. </p>
	    </div>
    </article>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="innerMainContentPlaceHolder" runat="server">
	<div class="pad" style="padding-top: 20px;">
		<p>You can use Crexta API service from the URL below (see below method definitions). You have to have a valid credential in order to use the API. Please <a href="Contact.aspx">contact</a> us for furher information or to get a valid credential.</p>
        <a href="/ws/Api.asmx" title="Crexta API URL">http://www.crexta.com/ws/Api.asmx</a>
	</div>
    <article class="pad">
    <h2>GetAllResults</h2>
	    <div class="wrapper marg_top">
		    <p>By using this method, users can get all the data collected by pre-defined Crextors (defined by the user or company).</p>
	    </div>
    </article>
    <article class="pad">
    <h2>GetCrextorResults</h2>
	    <div class="wrapper marg_top">
		    <p>By using this method, users can get all the data collected only by a specified Crextor. For example, if you want to get all the product information listed by Amazon then you can use this method.</p>
	    </div>
    </article>
    <article class="pad">
    <h2>GetGroupResults</h2>
	    <div class="wrapper marg_top">
		    <p>Data collected by the Crextors can be grouped in certain categories such as news, products or financial data etc. By using this method, users can get all the data which belongs to a specified group or category.</p>
	    </div>
    </article>
    <article class="pad">
    <h2>XML data structure</h2>
	    <div class="wrapper marg_top">
            <pre style='color:#000000;background:#ffffff;'><span style='color:#7f0055; '>&lt;</span><span style='color:#7f0055; '>rule</span> name=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> tableName=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> crextorId=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> queueId=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> url=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> miniPart=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> crextor=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span>
             crextorDescription=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> resourceId=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> resourceKey=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> pubDate=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> countryId=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> hash1=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> hash2=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span><span style='color:#7f0055; '>></span>
            <span style='color:#7f0055; '>&lt;</span><span style='color:#7f0055; '>criteria</span> name=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> columnName=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> columnType=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span><span style='color:#7f0055; '>></span>
            <span style='color:#7f0055; '>&lt;</span><span style='color:#7f0055; '>item</span> default=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>0</span><span style='color:#2a00ff; '>"</span><span style='color:#7f0055; '>></span><span style='color:#7f0055; '>&lt;/</span><span style='color:#7f0055; '>item</span><span style='color:#7f0055; '>></span>
            <span style='color:#7f0055; '>&lt;/</span><span style='color:#7f0055; '>criteria</span><span style='color:#7f0055; '>></span>
            <span style='color:#7f0055; '>&lt;</span><span style='color:#7f0055; '>criteria</span> name=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> columnName=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span> columnType=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>"</span><span style='color:#7f0055; '>></span>
            <span style='color:#7f0055; '>&lt;</span><span style='color:#7f0055; '>item</span> default=<span style='color:#2a00ff; '>"</span><span style='color:#2a00ff; '>0</span><span style='color:#2a00ff; '>"</span><span style='color:#7f0055; '>></span><span style='color:#7f0055; '>&lt;/</span><span style='color:#7f0055; '>item</span><span style='color:#7f0055; '>></span>
            <span style='color:#7f0055; '>&lt;/</span><span style='color:#7f0055; '>criteria</span><span style='color:#7f0055; '>></span>
            <span style='color:#7f0055; '>&lt;/</span><span style='color:#7f0055; '>rule</span><span style='color:#7f0055; '>></span>
            </pre>
	    </div>
    </article>
    <h2>Sample XML output</h2>
	    <div class="wrapper marg_top">
		    <a href="/images/crexta_xml_output_big_en.jpg" target="_blank"><figure class="left marg_right1" style="margin-bottom:40px"><img style="border:1px solid #000" src="/images/crexta_xml_output_small_en.jpg" alt="" width="850" />
            <figcaption style="text-align:center">Figure 1. API - Sampe XML Output</figcaption></figure></a>
	    </div>
</asp:Content>

