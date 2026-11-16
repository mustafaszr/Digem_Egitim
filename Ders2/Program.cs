Console.WriteLine("Digem Banka Hoşgeldiniz");

int kontrolPin = 1234;
decimal bakiye = 1000;

for (int i = 1; i < 4; i++)
{
    Console.Write("Pin Kodunuzu giriniz:");
    int? pinKodu = Convert.ToInt32(Console.ReadLine());

    if (pinKodu != kontrolPin)
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
    Console.WriteLine("3 - Çıkış");

    int secim = Convert.ToInt32(Console.ReadLine());

    switch (secim)
    {
        case 1:
            Console.Write("Çekmek istediğiniz tutarı giriniz: ");
            decimal cekilecekTutar = Convert.ToDecimal(Console.ReadLine());
            if (cekilecekTutar <= bakiye)
            {
                bakiye = bakiye - cekilecekTutar;
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
            Console.WriteLine($"Para yatırma işlemi başarılı. Yeni bakiyeniz: {bakiye} TL");
            break;
            case 3:
                Console.WriteLine("Çıkış yapılıyor...");
                return;
        default:
            Console.WriteLine("Lütfen geçerli bir işlem seçiniz.");
            break;
    }
}
