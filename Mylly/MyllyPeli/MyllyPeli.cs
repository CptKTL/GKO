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
    public delegate void ValittuChangedEventHandler(object sender, EventArgs e);
    public delegate void ValittuPoistettuEventHandler(object sender, EventArgs e);
    public delegate void ValittuSiirrettyEventHandler(object sender, EventArgs e);

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


        public void Siirra()
        {
            if (valittuNappula == null || tila != Pelitila.Odota)
            {

                return;
            }

            tila = Pelitila.Siirra;


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
                case (Pelitila.Siirra):
                    {
                        return SiirraNappula();
                        break;
                    }
            }

            return null;
        }

        private Nappula SiirraNappula()
        {

            if (valittuNappula == null)
                return null;


            tila = Pelitila.Odota;
            if (lauta.Siirra(valittuNappula, _targetKoord))
            {
                var temp = valittuNappula;
                ValitseNappula(null);
                return temp;
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
            if (tila != Pelitila.Odota)
            {
                tila = Pelitila.Odota;
                return;
            }
            if (valinta == valittuNappula && valittuNappula != null)
            {
                valittuNappula.Valittu = !valittuNappula.Valittu;
                valittuNappula = null;
                return;
            }


            if (valittuNappula != null)
            {
                valittuNappula.Valittu = false;
            }
            valittuNappula = valinta;

            if (valinta != null)
            {
                valittuNappula.Valittu = true;
            }
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
            tila = Pelitila.Odota;

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

        public void PoistaNappula()
        {
            if (valittuNappula != null)
            {
                valittuNappula.Poistetaan();
                lauta.poista(valittuNappula);
                valittuNappula = null;
            }
            tila = Pelitila.Odota;
        }
    }

    public class Pelaaja
    {
        public int nappuloita = 7;

        List<Nappula> nappulat = new List<Nappula>();

    }

    public class Nappula
    {
        public event ValittuChangedEventHandler ValittuChangedHandler;
        public event ValittuPoistettuEventHandler ValittuPoistettuHandler;
        public event ValittuSiirrettyEventHandler ValittuSiirrettyHandler;


        public int _paikka = -1;
        public bool poydalla = false;
        private bool _onValittu = false;
        Pelaaja pelaaja;

        public Nappula(int paikka, Pelaaja pelaaja)
        {
            this.Paikka = paikka;
            this.pelaaja = pelaaja;

        }

        public int Paikka
        {
            get { return _paikka; }
            set
            {
                onSiirretty(new EventArgs());
                _paikka = value;
            }
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
                onChangedValittu(new EventArgs());
            }
        }

        protected virtual void onChangedValittu(EventArgs e)
        {
            if (ValittuChangedHandler != null)
                ValittuChangedHandler(this, e);
        }

        protected virtual void onPoistettu(EventArgs e)
        {
            if (ValittuPoistettuHandler != null)
                ValittuPoistettuHandler(this, e);
        }

        protected virtual void onSiirretty(EventArgs e)
        {
            if (ValittuSiirrettyHandler != null)
                ValittuSiirrettyHandler(this, e);
        }

        public void Poistetaan()
        {
            onPoistettu(new EventArgs());
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
            return nappulat[paikka] == null;
        }

        public bool ValidiPaikkaLisata(int paikka)
        {
            return Tyhja(paikka);
        }



        public bool ValidiPaikkaSiirtää(int mista, int mihin)
        {
            return (Tyhja(mihin) && OnkoNaapuri(mista, mihin));
        }

        public bool OnkoNaapuri(int paikka, int naapuri)
        {
            return Naapurit[paikka].Contains(naapuri);

            //foreach (var naapuriMahdollisuus in Naapurit)
            //{
            //    if (naapuriMahdollisuus.Contains(paikka) && naapuriMahdollisuus.Contains(naapuri))
            //        return true;
            //}
            //return false;
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
            if (!ValidiPaikkaSiirtää(nappula.Paikka, paikka))
            {
                return false;
            }

            nappulat[paikka] = nappula;
            nappulat[nappula.Paikka] = null;
            nappula.Paikka = paikka;
            return true;
        }

        public void poista(Nappula nappula)
        {
            nappulat[nappula.Paikka] = null;
        }

        public Lauta()
        {

        }
    }
}
