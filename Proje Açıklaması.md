# Winform_AlarmProjesi
*Bir form üzerinde girilen tarih ve saat (saat ve dakika) geldiğinde hatırlatacak bir alarm uygulaması.
*Form üzerinde tarih seçimi için DateTimePicker, saat ve dakika girişi için MaskedTextBox kullanıldı.
*Ayrıca çok satırlı bir hatırlatma notu girilecek metin alanı oluşturuldu.
*Form üzerinde Alarm Kur butonuna tıklandığında form gizlenip, ikon halinde bekliyor, alarm zamanı geldiğinde ekran ön plana geliyor. 
O anda ekranda başka açık programlar olabileceği için form her şeyin önüne geliyor.
*Alarm kurulmadan önce ve sonra form açıkken şimdiki zaman saat, dakika ve saniye bilgisi form başlığında gösteriliyor.
*Alarm başladığında tekrar tekrar bir ses çalııyor, ekranda hatırlatma notu alanının arka planı kırmızı ve beyaz renkler arasında değişiyor
ve form üzerindeki bir zil resmi kendi etrafında küçük hareketler yaparak sarsılma etkisi oluşturuyor. 
Bu hareketler için Timer nesnesi kullanıldı.
*Form üzerinde Alarmı durdur butonuna tıklanınca Alarm hareketleri ve ses durduruluyor.
