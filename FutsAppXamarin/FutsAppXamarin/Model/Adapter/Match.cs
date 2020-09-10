﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FutsAppXamarin.Model
{

    public class Match
    {
        public IList teams { get; set; }
        public String data { get; set; }
        public String orario { get; set; }
        public String luogo { get; set; }

        public String risultato { get; set; }
        public IList golgioc { get; set; }

        public static Match[] daFare;
        public static Match[] giocate;
        public static Match[] daRegistrare;

        public Match(IList teams, String data, String orario, String luogo, String risultato)
        {
            this.teams = teams;
            this.data = data;
            this.orario = orario;
            this.luogo = luogo;
            this.risultato = risultato;
        }

        

        public String getgolCasa() { return risultato.Substring(0, risultato.IndexOf("-")).Trim(); }

        public String getgolOspite()
        {
            return risultato.Substring(risultato.IndexOf("-") + 1).Trim();

        }

    }
}

