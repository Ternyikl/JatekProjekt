using JatekProjekt;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class KarakterElemzo
    {
        private List<Karakter> karakterek;

        // Konstruktor: példányosítja az adatbázis-kezelőt és betölti az adatokat a listába
        public KarakterElemzo()
        {
            var dbKezelo = new AdatbazisKezelo();
            this.karakterek = dbKezelo.AdatokBetoltese();
        }

        // Gyűjti az összes karakter nevét aki 80-as szint vagy a felett van
        public List<string> MagasSzintuKarakterek()
        {
            List<string> magasSzintuek = karakterek.Where(x => x.Szint >= 80).Select(x => x.Nev).ToList();

            return magasSzintuek;
        }

        // Gyűjtsd ki az összes "Mágus" osztályú karakter nevét!
        public List<string> MagusOsztalyuNevek()
        {
            List<string> magusok = karakterek.Where(x => x.Osztaly == "Mágus").Select(x => x.Nev).ToList();

            return magusok;
        }

        // Add vissza az összes karakter nevét egy egyszerű listában!
        public List<string> OsszesKarakterNevListaba()
        {
            List<string> mindenki =  karakterek.Select(x => x.Nev).ToList();

            return mindenki;
        }

        // Szűrd ki azokat a karaktereket, amelyek valamelyik "EU-"-val kezdődő szerveren játszanak, és add vissza a nevüket listában!
        public List<string> EuSzerveresKarakterek()
        {
            List<string> eubol = karakterek.Where(x => x.Szerver.StartsWith("EU-")).Select(x => x.Nev).ToList();

            return eubol;
        }

        // Válaszd ki az összes egyedi (különböző) szervernevet, ahol a karakterek játszanak (Distinct segítségével)!
        public List<string> EgyediSzerverNevek()
        {
            List<string> szerverek = karakterek.Select(x => x.Szerver).Distinct().ToList();

            return szerverek;
        }


        // ==========================================
        // 2. EGYSZERŰ AGGREGÁCIÓK ÉS ELDÖNTÉsek
        // ==========================================

        // Számold meg Sum segítségével, hogy mennyi a karakterek összes aranya a szerveren!
        public int OsszesAranyMennyiseg()
        {
            int osszesArany = karakterek.Sum(x => x.Arany);

            return osszesArany;
        }

        // Számítsd ki Average segítségével a karakterek átlagos szintjét double értékként!
        public double AtlagSzint()
        {
            double atlagSzint = karakterek.Average(x => x.Szint);

            return atlagSzint;
        }

        // Állapítsd meg Any segítségével, hogy van-e olyan "Tolvaj" osztályú karakter, akinek a szintje eléri vagy meghaladja a 40-et!
        public bool VaneMagasSzintuTolvaj()
        {
            bool vanTolvaj = karakterek.Any(x => x.Osztaly == "Tolvaj" && x.Szint >= 40);

            return vanTolvaj;
        }

        // Ellenőrizd Any segítségével, hogy létezik-e olyan karakter, akinek 10 000 aranynál több van a zsebében!
        public bool VanETizEzerAranynalTobb()
        {
            bool whale = karakterek.Any(x => x.Arany >= 10000);

            return whale;
        }

        // Keresd meg FirstOrDefault segítségével az első olyan karaktert, akinek az aranya meghaladja az 5000-et!
        public Karakter LegelsoOvenKarakter()
        {
            Karakter elso5kplusz = karakterek.FirstOrDefault(x => x.Arany > 5000);

            return elso5kplusz;
        }


        // ==========================================
        // 3. RENDEZÉsek ÉS KERESÉsek
        // ==========================================

        // Add vissza az összes karaktert szint szerint csökkenő, azon belül pedig név szerint növekvő sorrendbe rendezve!
        public List<Karakter> KarakterekSzintSzerintRendezve()
        {
            throw new NotImplementedException();
        }

        // Keresd meg OrderByDescending és FirstOrDefault segítségével annak a karakternek a nevét, akinek a legtöbb aranya van!
        public string LeggazdagabbKarakterNeve()
        {
            throw new NotImplementedException();
        }

        // Keresd meg OrderBy és FirstOrDefault segítségével a legszegényebb (legkevesebb aranyú) karakter nevét!
        public string LegszegenyebbKarakterNeve()
        {
            throw new NotImplementedException();
        }

        // Keresd meg Max segítségével a legmagasabb szintű karakter szintjét!
        public int LegmagasabbSzint()
        {
            throw new NotImplementedException();
        }

        // Rendezd a karaktereket a nevük hossza szerint növekvő sorrendbe!
        public List<Karakter> KarakterekNevHosszaSzerint()
        {
            throw new NotImplementedException();
        }


        // ==========================================
        // 4. CSOPORTOSÍTÁS ÉS ÖSSzetettebb LINQ MŰVELETek
        // ==========================================

        // Csoportosítsd a karaktereket az Osztaly tulajdonságuk alapján, és alakítsd át ToDictionary-vel úgy, hogy a kulcs az osztály neve, az érték pedig a karakterek darabszáma legyen!
        public Dictionary<string, int> OsztalyonkentKarakterSzam()
        {
            throw new NotImplementedException();
        }

        // Csoportosítsd a karaktereket a Szerver tulajdonságuk alapján, és számold meg, hány karakter játszik az egyes szervereken!
        public Dictionary<string, int> SzerverenKarakterekSzama()
        {
            throw new NotImplementedException();
        }

        // Gyűjtsd ki az összes "Harcos" osztályú karakter azonosítóját (Id) egy listába!
        public List<int> HarcosokAzonositoi()
        {
            throw new NotImplementedException();
        }

        // Állapítsd meg, hogy van-e olyan 50-es szintnél magasabb Mágus, akinek 3000-nél kevesebb aranya van!
        public bool VanETolvajSpecKondicioval()
        {
            throw new NotImplementedException();
        }

        // Keresd meg és add vissza a legmagasabb szintű karakter objektumát!
        public Karakter LegmagasabbSzintuKarakterObjektum()
        {
            throw new NotImplementedException();
        }

    }
}