using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyllyPeliNamespace
{
    /// <summary>
    /// Pelin tila enum.
    /// </summary>
    public enum Pelitila
    {
        Odota,
        Lisaa,
        Siirra,
        Poista
    }


    /// <summary>
    /// Nappulan valinta handler.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ValittuChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Nappulan siirtämimen handler.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ValittuPoistettuEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Nappulan poistaminen handler.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ValittuSiirrettyEventHandler(object sender, EventArgs e);


    /// <summary>
    /// Itse peli luokka.
    /// Toteutus on vähän puolitiessä.
    /// </summary>
    public class MyllyPeli
    {
        public Pelitila tila = new Pelitila();
        public Lauta lauta = new Lauta();
        public Nappula valittuNappula = null;

        private int _targetKoord;
        private int vuoro = 0;
        private Pelaaja[] pelaajat = new Pelaaja[] { new Pelaaja(), new Pelaaja() };


        /// <summary>
        /// Laittaa pelin Siirrä tilaan jos soveliasta.
        /// </summary>
        public void Siirra()
        {
            if (valittuNappula == null || tila != Pelitila.Odota)
            {
                return;
            }
            tila = Pelitila.Siirra;
        }


        /// <summary>
        /// Asettaa kohde koordinaatin ja kutsuu tilan perusteella oikeaa metodia.
        /// </summary>
        /// <param name="targetKoord">Pelin koordinaatti johon halutaan lisätä tai siirtää.</param>
        /// <returns>Nappula joka siirrettiin tai lisättiin.</returns>
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


        /// <summary>
        /// Siirtää valittuna olevan nappulan _targetKoord osoittamaan paikkaan, mikäli soveliasta.
        /// </summary>
        /// <returns>Nappula joka siirrettiin, jos voitiin siirtää, null jos ei.</returns>
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


        /// <summary>
        /// Valitsee nappulan joka annetaan, jos peli on tilassa jossa voi tehdä valinnan.
        /// </summary>
        /// <param name="valinta">nappula joka halutaan valita.</param>
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


        /// <summary>
        /// EI KÄYTÖSSÄ.
        /// Vaihtaa pelivuoron.
        /// </summary>
        private void vaihdaVuoro()
        {
            vuoro = (vuoro == 0) ? 1 : 0;
        }


        /// <summary>
        /// Tekee uuden nappulan.
        /// </summary>
        /// <returns>Nappula joka lisättiin.</returns>
        private Nappula UusiNappula()
        {
            Nappula uusi = null;
            if (pelaajat[vuoro].nappuloita > 0)
            {
                uusi = LisaaNappula();
            }
            
            tila = Pelitila.Odota;

            return uusi;
        }


        /// <summary>
        /// Laittaa uuden nappulan paikkaan _targetKoord.
        /// </summary>
        /// <returns>nappula joka lisättiin.</returns>
        private Nappula LisaaNappula()
        {
            Nappula uusi = new Nappula(_targetKoord, pelaajat[vuoro]);
            lauta.Lisaa(uusi, _targetKoord);
            //OnChanged(new EventArgs());
            return uusi;
        }


        /// <summary>
        /// Antaa nappulan paikassa paikka.
        /// </summary>
        /// <param name="paikka">paikka josta nappula annetaan.</param>
        /// <returns>Nappula</returns>
        public Nappula NappulaPaikassa(int paikka)
        {
            return lauta.nappulat[paikka];
        }


        /// <summary>
        /// Poistaa valittuna olevan nappulan.
        /// </summary>
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


    /// <summary>
    /// Pelaaja luokka.
    /// ei ole toteutettu kunnolla.
    /// </summary>
    public class Pelaaja
    {
        public int nappuloita = 7;

        List<Nappula> nappulat = new List<Nappula>();
    }


    /// <summary>
    /// Napppulaluokkka. 
    /// </summary>
    public class Nappula
    {
        /// <summary>
        /// EventHandleri valittu eventille.
        /// </summary>
        public event ValittuChangedEventHandler ValittuChangedHandler;
        /// <summary>
        /// Eventhandleri valitun poistamiselle.
        /// </summary>
        public event ValittuPoistettuEventHandler ValittuPoistettuHandler;
        /// <summary>
        /// EventHandleri valitun siirtämiselle.
        /// </summary>
        public event ValittuSiirrettyEventHandler ValittuSiirrettyHandler;

        public int _paikka = -1;
        public bool poydalla = false;
        private bool _onValittu = false;
        Pelaaja pelaaja;


        /// <summary>
        /// Constructori.
        /// </summary>
        /// <param name="paikka">Paikka jossa nappula on.</param>
        /// <param name="pelaaja">Nappulan omistava pelaaja.</param>
        public Nappula(int paikka, Pelaaja pelaaja)
        {
            this.Paikka = paikka;
            this.pelaaja = pelaaja;
        }


        /// <summary>
        /// Paikka jossa nappula on. Muuttaminen laukoo Siirretty eventin.
        /// </summary>
        public int Paikka
        {
            get { return _paikka; }
            set
            {
                onSiirretty(new EventArgs());
                _paikka = value;
            }
        }


        /// <summary>
        /// Onko nappula valittu. Muuttaminen laukoo Valittu eventin.
        /// </summary>
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


        /// <summary>
        /// Heittää ValittuChangedEventin.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onChangedValittu(EventArgs e)
        {
            if (ValittuChangedHandler != null)
                ValittuChangedHandler(this, e);
        }


        /// <summary>
        /// Heittää poistettu eventin.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onPoistettu(EventArgs e)
        {
            if (ValittuPoistettuHandler != null)
                ValittuPoistettuHandler(this, e);
        }


        /// <summary>
        /// Heittää siirretty eventin.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onSiirretty(EventArgs e)
        {
            if (ValittuSiirrettyHandler != null)
                ValittuSiirrettyHandler(this, e);
        }


        /// <summary>
        /// Heittää poistettu eventin.
        /// </summary>
        public void Poistetaan()
        {
            onPoistettu(new EventArgs());
        }
    }


    /// <summary>
    /// Lauta luokka.
    /// Koostuu järjestyksessä numeroiduista Paikoista jotka vastaavat Mylly laudalla mahdollisia paikkoja nappuloille.
    /// 0--------1--------2
    /// |        |        |
    /// |  3-----4-----5  | 
    /// |  |     |     |  |
    /// |  |  6--7--8  |  |
    /// |  |  |     |  |  |
    /// 9--10-11    12-13-14
    /// |  |  |     |  |  |
    /// |  |  15-16-17 |  |
    /// |  |     |     |  |
    /// |  18----19----20 |
    /// |        |        |
    /// 21-------22-------23
    /// </summary>
    public class Lauta
    {
        public Nappula[] nappulat = new Nappula[24];

  
        /// <summary>
        /// Laudalla mahdolliset naapurit. 
        /// Esim paikalla  0 on naapurit Naapurit[0] = {1, 9}.
        ///               16 on naapurit Naapurit[16] = {15, 17, 19}.
        /// </summary>
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

            new int[]{0, 10, 21},
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


        /// <summary>
        /// Pelilaudalla mahdolliset myllyt.
        /// </summary>
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


        /// <summary>
        /// Tarkistaa onko paikka tyhjä.
        /// </summary>
        /// <param name="paikka">paikka</param>
        /// <returns>true jos tyhjä.</returns>
        public bool Tyhja(int paikka)
        {
            return nappulat[paikka] == null;
        }


        /// <summary>
        /// Tarkistaa onko sovelias paikka lisätä nappula.
        /// </summary>
        /// <param name="paikka">paikka.</param>
        /// <returns>true jos voi lisätä.</returns>
        public bool ValidiPaikkaLisata(int paikka)
        {
            return Tyhja(paikka);
        }


        /// <summary>
        /// Tarkistaa onko sovelias paikka siirtää nappula.
        /// Tällä hetkellä voi jos paikka on tyhjä ja naapuri.
        /// </summary>
        /// <param name="mista">Mistä paikasta siirretään.</param>
        /// <param name="mihin">Mihin siirretään.s</param>
        /// <returns>true jos voi.</returns>
        public bool ValidiPaikkaSiirtää(int mista, int mihin)
        {
            return (Tyhja(mihin) && OnkoNaapuri(mista, mihin));
        }


        /// <summary>
        /// Tarkistaa onko paikka ja naapuri naapureita.
        /// </summary>
        /// <param name="paikka">paikka</param>
        /// <param name="naapuri">mahdollinen naapuri</param>
        /// <returns>true jos on.</returns>
        public bool OnkoNaapuri(int paikka, int naapuri)
        {
            return Naapurit[paikka].Contains(naapuri);
        }

        /// <summary>
        /// Lisää nappulan annettuun paikkaan jos voi.
        /// </summary>
        /// <param name="nappula">nappula joka lisätään.</param>
        /// <param name="paikka">paikka johon lisätään.</param>
        /// <returns>true jos voitiin lisätä.</returns>
        public bool Lisaa(Nappula nappula, int paikka)
        {
            if (!ValidiPaikkaLisata(paikka))
            {
                return false;
            }

            nappulat[paikka] = nappula;
            return true;
        }


        /// <summary>
        /// Siirtää nappulan jos voi siirtää.
        /// </summary>
        /// <param name="nappula">Nappula joka halutaan siirtää.</param>
        /// <param name="paikka">Paikka johon halutaan siirtää.</param>
        /// <returns>true jos siirtäminen siirrettiin.</returns>
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


        /// <summary>
        /// Poistaa nappulan joka annetaan.
        /// </summary>
        /// <param name="nappula">Nappula joka halutaan poistaa.</param>
        public void poista(Nappula nappula)
        {
            nappulat[nappula.Paikka] = null;
        }
    }
}
