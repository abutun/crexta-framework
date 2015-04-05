<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.Master" AutoEventWireup="true" CodeBehind="What.aspx.cs" Inherits="Crexta.Live.WhatIs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="innerTopContentPlaceHolder" runat="server">
    <article class="pad">
    <h2>Crexta nedir?</h2>
	    <div class="wrapper marg_top">
		    <figure class="left marg_right1"><img src="images/page3_img1.jpg" alt="" /></figure>
		    <p class="pad_bot2">Crexta, internet üzerinde yer alan web sitelerindeki içerikleri, istenilen formatta, istenilen zamanda, hızlı ve verimli bir şekilde toplamayı sağlayan bir alt yapıdır.</p>
		    <p>Crexta alt yapısı 3 ana uygulamadan oluşur.</p>
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
		<p><strong>Explorer</strong>, web siteleri için kurallar ve kriterler oluşturmak için kullanılır. Oluşturulan bu kurallar ve kriterler, <strong>Server</strong>'lar ve <strong>Client</strong>'lar tarafından işlenir ve veriye dönüştürülür. Web sitelerinde yer alan bilgiler, kendileri için tanımlanmış olan kural ve kriter "süzgeç"'lerinden geçirilerek nihayi veri elde edilir.</p>
        <p>Bir web sitesi için yalnıca bir <strong>Crextor</strong> tanımlamak yeterlidir ancak ihtiyaç duyulması halinde, bir web sitesi için birden fazla <strong>Crextor</strong> tanımı yapılabilir. <strong>Crextor</strong>'lar kurallardan, kurallar ise kriterlerden oluşur. Bir <strong>Crextor</strong> birden fazla kural içerebilir ve bir kural kümesi birden fazla kriter barındırabilir (ki genellikle öyle olmalıdır).</p>
        <div class="wrapper pad_bot1"><a href="Screenshots.aspx#explorer" class="link1">Ekran görüntüleri</a></div>
		<h2>Crexta Server</h2>
		<p><strong>Server</strong>, <strong>Client</strong>'lar arasında iş bölümü ve görev dağılımını yapar. <strong>Explorer</strong>'lar tarafından tanımlanan bilgileri <strong>Client</strong>'lara iletir ve <strong>Client</strong>'lar tarafından toplanan verileri, kullanıcılara daha sonra ya da anında sunulmak üzere merkezi bir veri tabanına kaydeder. Bir fiziksel sunucu üzerine birden fazla <strong>Server</strong> uygulaması kurulabilir.</p>
        <div class="wrapper pad_bot1"><a href="Screenshots.aspx#server" class="link1">Ekran görüntüleri</a></div>
		<h2>Crexta Client</h2>
		<p><strong>Client</strong>'lar, Server'lar tarafından kendilerine iletilen görevleri yerine getirirler. <strong>Client</strong>'lar iki modda çalışırlar: <strong>Data Extractor</strong> ve <strong>URL Finder</strong>. Data Extractor modunda çalışan <strong>Client</strong>'lar, web siteleri üzerinden, belirlenen kural ve kriterler doğrultusunda veri toplarlar. URL Finder modunda çalışan <strong>Client</strong>'lar ise web siteleri üzerinde belirlenen kural ve kriterlere uyan URL (Unified Resource Locator) tanımlarını bulurlar. Bir fiziksel sunucu üzerinde birden fazla <strong>Client</strong> uygulaması çalışabilir.</p>
		<div class="wrapper pad_bot1"><a href="Screenshots.aspx#client" class="link1">Ekran görüntüleri</a></div>
	</article>
</asp:Content>
