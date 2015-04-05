Proje ile ilgili önemli notlar

	- NZemberek,
	  Kaddet.Indexer Debug/Release altýnda kaynaklar dizini MUTLAKA yer almalýdýr.
	  Kaddet root dizini altýnda Kaddet.Live tarafýndan kullanýlan kaynaklar dizini MUTLAKA yer almalýdýr. (Publish edildiðinde nasýl olacak þimdilik bilmiyorum)
	  
	- Projede NetTiers kullanýldýðý için (belki bu kýsým da ileride deðiþtirilebilir, kendi kütüphanemizi kullanýrýz) App.Config dosyalarý herbir
	  proje için çok önemli
	  
	  
	- Loglama,
	  NetTiers ile App.Config dosyasý deðiþtiðinde loglama yapýlan uygulamalara MUTLAKA aþaðýdaki satýrlarý ekle (App.Config dosyasýna)
	  
	  <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
	  
      <log4net configSource="log4net.config"/>
      
    
    - Deploy ederken
      App.Config dosyalarýný exe rootlarýna koymayý UNUTMA!
      
      
      
---------------------------------------------------------------------------------------------------------------------------------------
15.06.2010 - PROJE BU NOKTADAN SONRA TAMAMEN DEÐÝÞÝYOR

	- ItemExplorer
		Ana makina üzerinde çalýþýr ve output olarak "MainList.zip", "BrandList" adlý bir dosyalar oluþturulur. Dosyanýn versiyon numarasý bulunur ve dosya 
		Client'lar tarafýndan versiyon kontrolüne tabi tutulur ve gerekirse lokal makineye indirilir.
		
	- Client
		Hem URLFounder hem de DataExtractor görevi gören (iki modda çalýþan) uygulamadýr. Kullanýcýlar www.kaddet.com üzerinden client'ý indirirler ve
		kendi lokal makinelerinde çalýþtýrýrlar. Client elde ettiði bilgileri ana sunucuya iletir.
			
			URLFounder
			DataExtractor
		
	- Indexer
		Burada pek bir deðiþiklik yok! Ana veri tablosundaki bilgileri indexler.
		
	- Data2DB
		Client'lar tarafýndan iletilen ürün bilgilerini veri tabanýna taþýr.
		

17.06.2010
	
	ItemExplorer -> Explorer
	
	
29.06.2010

	URUN ve QUEUE tablolarýnda u2m.me servisinin kullanýlmasýa karar verildi. (1.10.6.28 sürümü normal URL ler ile çalýþýyor!)
	
30.06.2010

	TurkCrawler->NCrawler son sürüm eþleþtirilmesi yapýldý!	(NCrawler en son stable sürüm : 1.10.6.30)

14.06.2011

	Yaklaþýk bir yýl olmuþ be! Askerden gelince bir dalmýþtým projeye, dalýþ o dalýþ, projede neler deðiþti neler. 
	Þu an stable ilk sürümünü çýkartmaya çalýþýyorum. Bitti bitiyooooor.