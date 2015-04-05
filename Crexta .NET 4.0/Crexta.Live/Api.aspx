<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.Master" AutoEventWireup="true" CodeBehind="Api.aspx.cs" Inherits="Crexta.Live.Api" %>
<asp:Content ID="Content1" ContentPlaceHolderID="innerTopContentPlaceHolder" runat="server">
    <article class="pad">
    <h2>Crexta API (Uygulama Programlama Arayüzü)</h2>
	    <div class="wrapper marg_top">
		    <p class="pad_bot2">Crexta, tek bir merkezi veri tabanında topladığı tüm verileri belirli erişim izinleri çerçevesinde, XML web servislerinin gücünü kullanarak bir API ile müşterilerine sunar.</p>
	    </div>
    </article>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="innerMainContentPlaceHolder" runat="server">
	<div class="pad" style="padding-top: 20px;">
		<p>Crexta API arayüzüne aşağıdaki adresten ulaşılabilir. Aşağıda belirtilen metot detaylarına API arayüzü üzerinden ulaşabilirsiniz. Daha detaylı bilgi için lütfen bizimle <a href="Contact.aspx">iletişime</a> geçiniz.</p>
        <a href="ws/Api.asmx" title="Crexta API URL">http://www.crexta.com/ws/Api.asmx</a>
	</div>
    <article class="pad">
    <h2>GetAllResults</h2>
	    <div class="wrapper marg_top">
		    <p>Kullanıcılar bu metodu kullanarak kendileri için tanımlanmış (ya da kendilerinin tanımladıkları) tüm Crextor'ların topladıkları verilere ulaşabilirler.</p>
	    </div>
    </article>
    <article class="pad">
    <h2>GetCrextorResults</h2>
	    <div class="wrapper marg_top">
		    <p>Kullanıcılar bu metod ile yalnızca bir Crextor tarafından toplanmış verilere ulaşabilirler. Örneğin yalnızca bir web sitesine ait verilere ulaşmak için bu metot kullanılabilir.</p>
	    </div>
    </article>
    <article class="pad">
    <h2>GetGroupResults</h2>
	    <div class="wrapper marg_top">
		    <p>Crextor'lar tarafından toplanan veriler belirli veri grupları (haber, kampanya, ürün, emlak, finans vs.) altında toplanabilirler. Belirli bir grup altında toplanan tüm verilere ulaşmak için bu metot kullanılabilir. Örneğin, yalnızca "haber" içeren tüm web sitelerine ait verilere ulaşmak için bu metot kullanılmalıdır.</p>
	    </div>
    </article>
    <article class="pad">
    <h2>XML veri yapısı</h2>
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
    <h2>Örnek XML çıktısı</h2>
	    <div class="wrapper marg_top">
		    <a href="/images/crexta_xml_output_big_tr.jpg" target="_blank"><figure class="left marg_right1" style="margin-bottom:40px"><img style="border:1px solid #000" src="/images/crexta_xml_output_small_tr.jpg" alt="" width="850" />
            <figcaption style="text-align:center">Figure 1. API - Örnek XML çıktısı</figcaption></figure></a>
	    </div>
</asp:Content>
