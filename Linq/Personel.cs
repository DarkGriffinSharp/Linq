using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Personel<T, T1>
    {
        Guid guid = Guid.NewGuid();
        private string id { get; set; }
        public T Ad { get; set; }
        public T Soyad { get; set; }
        public T1 Maas { get; set; }
        public string identifier { get { return id; } set { id = value; } }
        public Personel<string, double> p;
        public List<Personel<string, double>> pList;
        public void PersonelEkle()
        {
            try
            {
                Console.Write("Kaç personel bilgisi girmek istiyorsunuz: ");
                int pSayi = int.Parse(Console.ReadLine());
                pList = new List<Personel<string, double>>();
                for (int i = 0; i < pSayi; i++)
                {
                    p = new Personel<string, double>();
                    p.identifier = guid.ToString();
                    Console.Write("Personel adı: ");
                    p.Ad = Console.ReadLine();
                    Console.Write("Personel soyadı: ");
                    p.Soyad = Console.ReadLine();
                    Console.Write("Personel maaşı: ");
                    p.Maas = double.Parse(Console.ReadLine());
                    pList.Add(p);
                    Console.Clear();
                }
                
                EklenenPersoneller(ref pList);
                LinqKullanimi(ref pList);
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı tür girişi");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EklenenPersoneller(ref List<Personel<string, double>> pList)
        {
            pList = this.pList;
            Console.Clear();
            try
            {
                Console.WriteLine("Eklenen Personel Listesi");
                foreach (var item in pList)
                {
                    Console.WriteLine($"id: {item.identifier}\nAdı: {item.Ad}\nSoyadı: {item.Soyad}\nMaaş:  {item.Maas}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void LinqKullanimi(ref List<Personel<string, double>> personels)
        {
            personels = pList;

            var kontrol = personels.Where(x => x.Maas > 2000);
            Console.WriteLine("Maaşı 2000 TL'den fazla olanlar\n");
            foreach (var item in kontrol)
            {
                Console.WriteLine($"{item.Ad} {item.Soyad}");
            }

            Console.Write("Aramak istediğiniz isim/soyisim: ");
            string ad = Console.ReadLine().ToLower();
            kontrol = personels.Where(x => x.Ad.ToLower().Contains(ad) | x.Soyad.ToLower().Contains(ad));

            foreach (var item in kontrol)
            {
                Console.WriteLine($"{RenklendirBiziSkadi(ConsoleColor.Green)}{item.Ad + " " + item.Soyad} bulundu.");
            }
        }


        public object RenklendirBiziSkadi(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            return "";
        }
        public object EskiyeDondurSkadi()
        {
            Console.ResetColor();
            return "";
        }
    }
}