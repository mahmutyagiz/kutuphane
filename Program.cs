

using System;
using System.Collections.Generic;

class Kutuphane
{
    private List<Kitap> kitaplar = new List<Kitap>();

    public void KitapEkle()
    {
        Console.Write("Kitap Adı: ");
        string kitapAdi = Console.ReadLine();
        Console.Write("Yazar Adı: ");
        string yazarAdi = Console.ReadLine();
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();
        Console.Write("Yayın Yılı: ");
        int yayinYili = int.Parse(Console.ReadLine());

        Kitap yeniKitap = new Kitap(kitapAdi, yazarAdi, isbn, yayinYili);
        kitaplar.Add(yeniKitap);

        Console.WriteLine("Kitap başarıyla eklendi!");
    }
    public void KitaplariListele()
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("Hiç kitap yok.");
        }
        else
        {
            foreach (var kitap in kitaplar)
            {
                kitap.KitapBilgisiGoster();
            }
        }
    }
    public void KitapAra()
    {
        Console.Write("Aramak istediğiniz kitabın adını girin: ");
        string kitapAdi = Console.ReadLine();
        var arananKitap = kitaplar.Find(kitap => kitap.KitapAdi.Equals(kitapAdi, StringComparison.OrdinalIgnoreCase));

        if (arananKitap != null)
        {
            arananKitap.KitapBilgisiGoster();
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
    }
    public void KitapSil()
    {
        Console.Write("Silmek istediğiniz kitabın ISBN numarasını girin: ");
        string isbn = Console.ReadLine();
        var silinecekKitap = kitaplar.Find(kitap => kitap.ISBN == isbn);

        if (silinecekKitap != null)
        {
            kitaplar.Remove(silinecekKitap);
            Console.WriteLine("Kitap başarıyla silindi!");
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
    }
}class Program
{
    static void Main(string[] args)
    {
        Kutuphane kutuphane = new Kutuphane();
        bool cikisYapildi = false;

        while (!cikisYapildi)
        {
            Console.WriteLine("\n--- Kütüphane Yönetim Sistemi ---");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitapları Listele");
            Console.WriteLine("3. Kitap Ara");
            Console.WriteLine("4. Kitap Sil");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    kutuphane.KitapEkle();
                    break;
                case "2":
                    kutuphane.KitaplariListele();
                    break;
                case "3":
                    kutuphane.KitapAra();
                    break;
                case "4":
                    kutuphane.KitapSil();
                    break;
                case "5":
                    cikisYapildi = true;
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
