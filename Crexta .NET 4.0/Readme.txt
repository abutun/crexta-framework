Proje ile ilgili �nemli notlar

	- NZemberek,
	  Kaddet.Indexer Debug/Release alt�nda kaynaklar dizini MUTLAKA yer almal�d�r.
	  Kaddet root dizini alt�nda Kaddet.Live taraf�ndan kullan�lan kaynaklar dizini MUTLAKA yer almal�d�r. (Publish edildi�inde nas�l olacak �imdilik bilmiyorum)
	  
	- Projede NetTiers kullan�ld��� i�in (belki bu k�s�m da ileride de�i�tirilebilir, kendi k�t�phanemizi kullan�r�z) App.Config dosyalar� herbir
	  proje i�in �ok �nemli
	  
	  
	- Loglama,
	  NetTiers ile App.Config dosyas� de�i�ti�inde loglama yap�lan uygulamalara MUTLAKA a�a��daki sat�rlar� ekle (App.Config dosyas�na)
	  
	  <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
	  
      <log4net configSource="log4net.config"/>
      
    
    - Deploy ederken
      App.Config dosyalar�n� exe rootlar�na koymay� UNUTMA!
      
      
      
---------------------------------------------------------------------------------------------------------------------------------------
15.06.2010 - PROJE BU NOKTADAN SONRA TAMAMEN DE����YOR

	- ItemExplorer
		Ana makina �zerinde �al���r ve output olarak "MainList.zip", "BrandList" adl� bir dosyalar olu�turulur. Dosyan�n versiyon numaras� bulunur ve dosya 
		Client'lar taraf�ndan versiyon kontrol�ne tabi tutulur ve gerekirse lokal makineye indirilir.
		
	- Client
		Hem URLFounder hem de DataExtractor g�revi g�ren (iki modda �al��an) uygulamad�r. Kullan�c�lar www.kaddet.com �zerinden client'� indirirler ve
		kendi lokal makinelerinde �al��t�r�rlar. Client elde etti�i bilgileri ana sunucuya iletir.
			
			URLFounder
			DataExtractor
		
	- Indexer
		Burada pek bir de�i�iklik yok! Ana veri tablosundaki bilgileri indexler.
		
	- Data2DB
		Client'lar taraf�ndan iletilen �r�n bilgilerini veri taban�na ta��r.
		

17.06.2010
	
	ItemExplorer -> Explorer
	
	
29.06.2010

	URUN ve QUEUE tablolar�nda u2m.me servisinin kullan�lmas�a karar verildi. (1.10.6.28 s�r�m� normal URL ler ile �al���yor!)
	
30.06.2010

	TurkCrawler->NCrawler son s�r�m e�le�tirilmesi yap�ld�!	(NCrawler en son stable s�r�m : 1.10.6.30)

14.06.2011

	Yakla��k bir y�l olmu� be! Askerden gelince bir dalm��t�m projeye, dal�� o dal��, projede neler de�i�ti neler. 
	�u an stable ilk s�r�m�n� ��kartmaya �al���yorum. Bitti bitiyooooor.