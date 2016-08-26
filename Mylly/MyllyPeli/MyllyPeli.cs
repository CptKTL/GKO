using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyllyPeliNamespace
{
    public enum Pelitila
    {
        Odota,
        Lisaa,
        Siirra,
        Poista
    }

    public delegate void ChangedEventHandler(object sender, EventArgs e);
    public delegate void ValittuEventHandler(object sender, EventArgs e);

    public class MyllyPeli
    {
        public event ChangedEventHandler Changed;

        public Pelitila tila = new Pelitila();
        public Lauta lauta = new Lauta();
        public Nappula valittuNappula = null;
        private int _targetKoord;
        private int fromX;
        private int fromY;

        private int vuoro = 0;
        private Pelaaja[] pelaajat = new Pelaaja[] { new Pelaaja(), new Pelaaja() };

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public Nappula setTargetKoord(int targetKoord)
        {
            _targetKoord = targetKoord;

            switch (tila)
            {
                case (Pelitila.Lisaa):
                    {
                        return UusiNappula();
                        break;
                    }
            }

            return null;
        }

        public void setFromKoords(int x, int y)
        {
            fromX = x;
            fromY = y;
        }

        public MyllyPeli()
        {

        }

        public void ValitseNappula(Nappula valinta)
        {
            if (valittuNappula != null)
            {
                valittuNappula.Valittu = false;
            }
            valittuNappula = valinta;
            valittuNappula.Valittu = true;

        }

        private void vaihdaVuoro()
        {
            vuoro = (vuoro == 0) ? 1 : 0;
        }



        private Nappula UusiNappula()
        {
            Nappula uusi = null;
            if (pelaajat[vuoro].nappuloita > 0)
            {
                uusi = LisaaNappula();
            }

            OnChanged(new EventArgs());
            return uusi;
        }

        private Nappula LisaaNappula()
        {
            Nappula uusi = new Nappula(_targetKoord, pelaajat[vuoro]);
            lauta.Lisaa(uusi, _targetKoord);
            OnChanged(new EventArgs());
            return uusi;
        }


        public Nappula NappulaPaikassa(int paikka)
        {
            return lauta.nappulat[paikka];
        }
    }

    public class Pelaaja
    {
        public int nappuloita = 7;

        List<Nappula> nappulat = new List<Nappula>();

    }

    public class Nappula
    {
        public event ValittuEventHandler ValittuHandler;


        public int paikka = -1;
        public bool poydalla = false;
        private bool _onValittu = false;
        Pelaaja pelaaja;

        public Nappula(int paikka, Pelaaja pelaaja)
        {
            this.paikka = paikka;
            this.pelaaja = pelaaja;
        }
        

        public bool Valittu
        {
            get
            {
                return _onValittu;
            }
            set
            {
                _onValittu = value;
            }
        }

        protected virtual void onValittu(EventArgs e)
        {
            if (ValittuHandler != null)
                ValittuHandler(this, e);
        }
    }


    public class Lauta
    {
        public Nappula[] nappulat = new Nappula[24];

        public int[][] Naapurit = new int[][]
        {
            new int[]{1, 9},
            new int[]{0, 2, 4},
            new int[]{1, 14},
            new int[]{4, 5, 10},
            new int[]{1, 3, 5, 7},
            new int[]{4, 13},
            new int[]{7, 11},
            new int[]{4, 6, 8},
            new int[]{7, 12},
            new int[]{0, 21},
            new int[]{3, 9, 11, 18},
            new int[]{6, 10 ,15},
            new int[]{8, 13, 17},
            new int[]{5, 12, 14, 20},
            new int[]{2, 13, 23},
            new int[]{11, 16},
            new int[]{15, 17, 19},
            new int[]{12, 16},
            new int[]{10, 19},
            new int[]{16, 18, 20, 22},
            new int[]{13, 19},
            new int[]{9, 22},
            new int[]{19, 21, 23},
            new int[]{14, 22}
        };

        public int[][] Myllyt = new int[][]{
            new int[]{0,1,2},
            new int[]{3,4,5},
            new int[]{6,7,8},
            new int[]{9,10,11},
            new int[]{12,13,14},
            new int[]{15,16,17},
            new int[]{18,19,20},
            new int[]{21,22,23},

            new int[]{0,9,21},
            new int[]{3,10,18},
            new int[]{6,11,15},
            new int[]{1,4,7},
            new int[]{16,19,22},
            new int[]{8,12,17},
            new int[]{5,13,20},
            new int[]{2,14,23}
        };



        public bool Tyhja(int paikka)
        {
            return nappulat[paikka] != null;
        }

        public bool ValidiPaikkaLisata(int paikka)
        {
            return Tyhja(paikka);
        }



        public bool ValidiPaikkaSiirtää(int mista, int mihin)
        {
            return (Tyhja(mista) && OnkoNaapuri(mista, mihin));
        }

        public bool OnkoNaapuri(int paikka, int naapuri)
        {
            foreach (var naapuriMahdollisuus in Naapurit)
            {
                if (naapuriMahdollisuus.Contains(paikka) && naapuriMahdollisuus.Contains(naapuri))
                    return true;
            }
            return false;
        }

        public bool Lisaa(Nappula nappula, int paikka)
        {
            if (!ValidiPaikkaLisata(paikka))
            {
                return false;
            }

            nappulat[paikka] = nappula;
            return true;
        }

        public bool Siirra(Nappula nappula, int paikka)
        {
            if (!ValidiPaikkaSiirtää(nappula.paikka, paikka))
            {
                return false;
            }

            nappulat[paikka] = nappula;
            nappulat[nappula.paikka] = null;
            return true;
        }

        public Lauta()
        {

        }
    }
}
