using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestione_Stalla
{
    public class Animale
    {
        public enum Razze { VaccaVecchiaPiemontese, VaccaVecchiaGaliziana, RubiaGaliega }
        private DateTime _nascita;
        private string _nome;
        private Razze _razza;

        public Animale(string nomeCapo, Razze razzaCapo, DateTime nascitaCapo)
        {
            try
            {
                if (string.IsNullOrEmpty(nomeCapo) == false)
                    _nome = nomeCapo;
                else
                    throw new Exception("nome non valido");

                _razza = razzaCapo;

                _nascita = nascitaCapo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Mesi
        {
            get
            {
                return CalcolaMesi();
            }

        }

        public string Nome
        {
            get
            {
                return _nome;
            }

        }

        public Razze Razza
        {
            get
            {
                return _razza;
            }
        }

        private int CalcolaMesi()
        {
            int anni = DateTime.Now.Year - _nascita.Year;
            int mesi = DateTime.Now.Month - _nascita.Month;
            int totale = anni * 12 + mesi;
            return totale;
        }

        public override string ToString()
        {
            return Nome + " razza: " + Razza;
        }



    }
}