<h2 align="center">
:fire:  ASP.NET CORE StackExchange.Redis Library Usage :fire: 
</h2>
 
## :pushpin: Caching Nedir ?
Caching (önbellekleme) işlemi, sık kullanılan verilerin sürekli veri tabanı, dosya gibi veri kaynağına bağlanılıp alınmaması için verilerin geçici olarak bellekte saklanması işlemidir.

## :pushpin: Distributed Caching Nedir ?
Distributed caching, önbelleğe alınacak verilerin farklı sunucularda tutulması işlemidir yani önbellekteki veriler projemizin barındığı sunucuda saklanmaz.

## :pushpin: Redis Nedir ?
Redis (Remote Dictionary Server), veriyi key-value şeklinde in-memory (hafıza/RAM) tutan açık kaynaklı bir veritabanıdır. 

## :pushpin: Redis Veri Tipleri ve Komutları Nelerdir ?
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/140789913-ac414b0a-2d48-4420-ac9f-fe8153ae4819.png"> </br>
<em>http://www.canertosuner.com/post/windows-uzerinde-redis-server-kurulumu-ve-kullanimi</em>
 </p>

* <b> Strings: </b> Karakter seti 
* <b> Lists: </b> Eklenme sırasına göre birden fazla string tutar.
* <b> Sets: </b> Sırasız bir şekilde birden fazla string tutar. 
* <b> Hashes: </b> Map şeklinde (key-value) string saklar 
* <b> Sorted Sets: </b> Sırasız bir şekilde birden fazla string tutar. Her elementten score adı verilen bir sayı üretilir ve değeri aynı olan iki kayıt eklenemez.

* * *

## Strings Type
Strings veri tipi, verilerin string formatı olarak tutulduğu veri yapısıdır. <key,value> çiftinde değer kısmı maksimum 512 MB yer tutar.

SET/GET : Değer atama / okuma </br>
INCR/DECR : Text’in veri tipi int (rakam) ise INCR ile değerini artırıp DECR ile de değerini azaltabiliriz </br>
MSET/MGET : Birden fazla değer atama / okuma </br>
APPEND : Kayıt birleştirme </br>
GETRANGE : Değerin belirli bir kısmını (substring gibi) döner </br>
STRLEN : Değeri uzunluğunu döner </br>

## Lists Type
Lists veri tipi, metinsel ifadeler listesini temsil ediyor. Listeye eklenme sırasına göre sıralama uygular. Listelerin kuyruk gibi kullanıldığı durumlar da mevcuttur.

LPUSH/RPUSH : Listenin başına / sonuna kayıt ekleme </br>
LPOP/RPOP : Listenin başından / sonundan kayıt silme </br>
LREM : Listeden kayıt silme </br>
LSET : Belirtilen index (sıra no.) sonucu kayıt ekleme </br>
LINDEX : Belirtilen index’e göre kayıt getirme </br>
LRANGE  : Belirtilen aralıkta kayıtları getirir </br>
LLEN : Listenin uzunluğunu getirir </br>
LTRIM : Belirtilen aralıkta listeyi keser </br>

## Sets Type
Set veri tipi, verileri sırasız (rastgele sırada eklenilen) ve unique (benzersiz) olarak tutan veri tipidir. Aynı veriden birden fazla bulunmamaktadır.

SADD : Listeye kayıt ekleme </br>
SCARD : Listeden kayıt döner </br>
SDIFF, SINTER, SUNION : Difference, Intersection, Union matematiksel işlemleri </br>
SISMEMBER : Kayıt listede mevcut mu değil mi kontrolü </br>
SMOVE : Bir listenin kayıtlarını diğer listeye taşıma </br>
SREM : Listeden kayıt silme </br>

## Hashes Type
Hash veri tipi, bir key’e karşılık birden fazla field (alan tutmaya) yarayan veri tipidir. Bir objenin birden fazla değeri olabilir. 

HSET/HGET : Kayıt atama / alma </br>
HMSET/HMGET : Çoklu kayıt atama / alma </br>
HGETALL : Tüm kayıtları döndürür </br>
HDEL : Kayıt silme </br>
HEXISTS : Kayıt var mı kontrolü </br>
HINCRBY : Integer kaydın değerini artırma </br>
HKEYS / HVALS : Tüm anahtar (key) / değerleri döndürür </br>

## Sorted Sets
Sorted set veri tipi, Set veri yapısının benzerdir. Verileri unique (benzersiz) olarak tutmakla beraber score dediğimiz değere göre sıralama işlemi yapmaktadır.

ZADD : Bir veya birden fazla kayıt ekleme. Kayıt varsa score güncellenir </br>
ZCARD : Setteki kayıtların sayısını döndürür </br>
ZCOUNT : Setteki belirli aralıkta score’u bulunan kayıtları döndürür </br>
ZINCRBY : Setteki kaydın score değerini artırır </br>
ZRANGE : Setteki belirli aralıkta kayıtları döner (index’e göre) </br>
ZRANK : Setteki kaydın index bilgisini döner </br>
ZREM : Bir veya birden fazla kaydı silme </br>
ZSCORE : Setteki kaydın score’unu döner </br>

***

Redis veri tipleri ile ilgili daha fazla bilgi almak için ziyaret ediniz;
* https://redis.io/topics/data-types
* https://github.com/microsoftarchive/redis
* https://github.com/redis/redis-doc

***
## :pushpin: Kurulum
* Docker ile çalışmak isteyenler: https://hub.docker.com/_/redis
* Kurulum yapmak isteyenler: https://redis.io/download </br>
ilgili linklerden kurulumunlarını yaparak projeyi ayaga kaldırabilirler.
