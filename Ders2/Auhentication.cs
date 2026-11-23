namespace Ders2;

public class Auhentication
{
    int defaultPin = 1234;
    public Auhentication(int kontrolPin)
    {
        defaultPin = kontrolPin;
    }

    public bool SifreKontrol(int pin)
    {
        return pin == defaultPin;
    }
}
