﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Personel<string, double> personel = new Personel<string, double>();
            personel.PersonelEkle();
        }
    }
}
