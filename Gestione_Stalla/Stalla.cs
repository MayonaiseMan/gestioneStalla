using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestione_Stalla
{
    public class Stalla
    {
        List<Animale> _animali;

        public Stalla()
        {
            _animali = new List<Animale>();

        }

        public List<Animale> Animali
        {
            get
            {
                return _animali;
            }
        }

        public void CompraCapo(string nomeCapo, int razzaCapo, DateTime nascitaCapo)
        {
            Animale.Razze razza = (Animale.Razze)razzaCapo;
            Animale capo = new Animale(nomeCapo, razza, nascitaCapo);
            _animali.Add(capo);
        }

        public void CompraCapo(Animale a)
        {
            _animali.Add(a);
        }

        public List<Animale> VendiAnimaliMesi(int mesi)
        {
            List<Animale> Venduti = new List<Animale>();
            foreach (Animale a in _animali)
            {
                if (a.Mesi == mesi)
                {
                    _animali.Remove(a);
                    Venduti.Add(a);
                }

            }

            return Venduti;

        }

        public List<Animale> GetAnimaliRazza(Animale.Razze razza)
        {
            List<Animale> vs = new List<Animale>();
            foreach (Animale a in _animali)
            {
                if (a.Razza == razza)
                {
                    vs.Add(a);
                }
            }

            return vs;

        }
    }
}