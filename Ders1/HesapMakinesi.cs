
namespace Ders1;

public class HesapMakinesi
{
    public int Topla(int sayi1, int sayi2)
    {
        return sayi1 + sayi2;
    }

    public int Cikar(int sayi1, int sayi2)
    {
        return sayi1 - sayi2;
    }

    public int Carp(int sayi1, int sayi2)
    {
        return sayi1 * sayi2;
    }

    public int Bol(int sayi1, int sayi2)
    {
        if (sayi2 == 0)
            throw new DivideByZeroException("Bir sayı sıfıra bölünemez.");

        return sayi1 / sayi2;
    }
}
