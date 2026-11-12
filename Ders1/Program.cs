
using Ders1;

HesapMakinesi hesapMakinesi = new HesapMakinesi();

while (true)
{
    Console.WriteLine("=== HESAP MAKİNESİ ===");
    Console.WriteLine("Toplama (+)");
    Console.WriteLine("Çıkarma (-)");
    Console.WriteLine("Çarpma (*)");
    Console.WriteLine("Bölme (/)");
    Console.WriteLine("Çıkış (q)");
    Console.Write("Yapmak istediğiniz işlemi seçiniz: ");

    string? secim = Console.ReadLine();

    if (secim == "q")
    {
        Console.WriteLine("Program kapatılıyor...");
        break;
    }

    try
    {
        Console.Write("Birinci sayıyı girin: ");
        int sayi1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("İkinci sayıyı girin: ");
        int sayi2 = Convert.ToInt32(Console.ReadLine());

        int sonuc;

        if (secim == "+")
        {
            sonuc = hesapMakinesi.Topla(sayi1, sayi2);
        }
        else if (secim == "-")
        {
            sonuc = hesapMakinesi.Cikar(sayi1, sayi2);
        }
        else if (secim == "*")
        {
            sonuc = hesapMakinesi.Carp(sayi1, sayi2);
        }
        else if (secim == "/")
        {
            sonuc = hesapMakinesi.Bol(sayi1, sayi2);
        }
        else
        {
            Console.WriteLine("Geçersiz operatör!");
            continue;
        }

        Console.WriteLine($"İşlem sonucu: {sonuc}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine(ex.Message);
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("-----------------------------------------");
    }
}
