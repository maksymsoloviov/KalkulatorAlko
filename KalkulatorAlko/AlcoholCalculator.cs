using System;
using System.Collections.Generic;

namespace KalkulatorAlko
{
    public class AlcoholCalculator
    {
        public static readonly Dictionary<string, double> TypoweNaczynia = new Dictionary<string, double>
        {
            { "-- Wybierz naczynie --", 0 },
            { "Kieliszek (50 ml)", 50.0 },
            { "Lampka wina (150 ml)", 150.0 },
            { "Szklanka (250 ml)", 250.0 },
            { "Kufel (500 ml)", 500.0 }
        };

        public static readonly Dictionary<string, double> TypoweNapoje = new Dictionary<string, double>
        {
            { "-- Wybierz napój --", 0 },
            { "Piwo (5%)", 5.0 },
            { "Wino (12%)", 12.0 },
            { "Likier (25%)", 25.0 },
            { "Wódka (40%)", 40.0 },
            { "Spirytus (95%)", 95.0 }
        };

        public static double ObliczObjetoscNapoju(double wielkoscNaczyniaMl, int iloscSztuk)
        {
            if (wielkoscNaczyniaMl < 0 || iloscSztuk < 0)
                throw new ArgumentException("Wartości nie mogą być ujemne.");
            return Math.Round(wielkoscNaczyniaMl * iloscSztuk, 2);
        }

        public static double ObliczObjetoscSpirytusu(double wielkoscNaczyniaMl, double procent, int iloscSztuk)
        {
            if (procent < 0 || procent > 100)
                throw new ArgumentException("Procent musi być w przedziale 0-100.");
            double objetoscNapoju = ObliczObjetoscNapoju(wielkoscNaczyniaMl, iloscSztuk);
            return Math.Round(objetoscNapoju * (procent / 100.0), 2);
        }
    }
}
