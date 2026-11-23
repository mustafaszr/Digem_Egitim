using Ders2;

Console.WriteLine("Digem Banka Hoşgeldiniz");

int kontrolPin = 1234;
decimal bakiye = 1000;

List<HesapEkstre> hesapEkstres = new List<HesapEkstre>();

var auth = new Auhentication(kontrolPin);

for (int i = 1; i < 4; i++)
{
    Console.Write("Pin Kodunuzu giriniz:");
    int? pinKodu = Convert.ToInt32(Console.ReadLine());

    if (!auth.SifreKontrol(pinKodu.Value))
    {
        if (i == 3)
        {
            Console.WriteLine("3 Kez hatalı giriş yaptınız. Daha fazla deneme yapazmazsınız!");
        }
        else
        {
            Console.WriteLine("Hatalı pin kodu");
        }
    }
    else
    {
        Console.WriteLine("Giriş başarılı");
        break;
    }
}

Console.WriteLine($"Bakiyeniz: {bakiye} TL");

while (true)
{
    Console.WriteLine("Yapmak istediğiniz işlemi seçiniz:");
    Console.WriteLine("1 - Para Çekme");
    Console.WriteLine("2 - Para Yatırma");
    Console.WriteLine("3 - Pin kodunu değiştir");
    Console.WriteLine("4 - Bakiye Sorgulama");
    Console.WriteLine("5 - Hesap Ekstresi");
    Console.WriteLine("0 - Çıkış");

    int secim = Convert.ToInt32(Console.ReadLine());

    switch (secim)
    {
        case 1:
            Console.Write("Çekmek istediğiniz tutarı giriniz: ");
            decimal cekilecekTutar = Convert.ToDecimal(Console.ReadLine());
            if (cekilecekTutar <= bakiye)
            {
                bakiye = bakiye - cekilecekTutar;
                var paraCekmeEkstre = new HesapEkstre
                {
                    IslemTarihi = DateTime.Now,
                    YapilanIslem = "Para Çekme",
                    Tutar = cekilecekTutar
                };
                hesapEkstres.Add(paraCekmeEkstre);
                Console.WriteLine($"Para çekme işlemi başarılı. Kalan bakiyeniz: {bakiye} TL");
            }
            else
            {
                Console.WriteLine($"Yetersiz bakiye. Mevcut bakiyeniz: {bakiye} TL");
            }

            break;
        case 2:
            Console.Write("Yatırmak istediğiniz tutarı giriniz: ");
            decimal yatirilacakTutar = Convert.ToDecimal(Console.ReadLine());
            bakiye = bakiye + yatirilacakTutar;
            var ekstre = new HesapEkstre
            {
                IslemTarihi = DateTime.Now,
                YapilanIslem = "Para Yatırma",
                Tutar = yatirilacakTutar
            };
            hesapEkstres.Add(ekstre);

            Console.WriteLine($"Para yatırma işlemi başarılı. Yeni bakiyeniz: {bakiye} TL");
            break;
        case 3:
            Console.Write("Yeni pin kodunuzu giriniz: ");
            int yeniPin = Convert.ToInt32(Console.ReadLine());
            kontrolPin = yeniPin;
            Console.WriteLine("Pin kodunuz başarıyla değiştirildi.");

            for (int i = 1; i < 4; i++)
            {
                Console.Write("Pin Kodunuzu giriniz:");
                int? pinKodu = Convert.ToInt32(Console.ReadLine());

                if (!auth.SifreKontrol(pinKodu.Value))
                {
                    if (i == 3)
                    {
                        Console.WriteLine("3 Kez hatalı giriş yaptınız. Daha fazla deneme yapazmazsınız!");
                    }
                    else
                    {
                        Console.WriteLine("Hatalı pin kodu");
                    }
                }
                else
                {
                    Console.WriteLine("Giriş başarılı");
                    break;
                }
            }
            break;
        case 4:
            Console.WriteLine($"Mevcut bakiyeniz: {bakiye} TL");
            break;
        case 5:
            foreach (var hesapEkstre in hesapEkstres)
            {
                Console.WriteLine($"İşlem Tarihi: {hesapEkstre.IslemTarihi}, İşlem Türü: {hesapEkstre.YapilanIslem}, Tutar: {hesapEkstre.Tutar}");
            }
            break;
        case 0:
            Console.WriteLine("Çıkış yapılıyor...");
            return;
        default:
            Console.WriteLine("Lütfen geçerli bir işlem seçiniz.");
            break;
    }
}


public class HesapEkstre
{
    public DateTime IslemTarihi { get; set; }
    public string YapilanIslem { get; set; } = default!;
    public decimal Tutar { get; set; }
}