using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace FutsAppXamarin
{
    public class Giocatore
    {
        public string username { get; set; }
        public Dictionary<string, object> dati { get; set; }

        public static Giocatore[] players;
        public static Giocatore[] amici;
        public static Giocatore user;
        public string Goal { get; set;  }
        public string Vinte { get; set; }

        public Giocatore(string username, Dictionary<string, object> dati)
        {
            this.username = username;
            this.dati = dati;
            this.Goal = dati["gol fatti"].ToString();
            this.Vinte = dati["vittorie"].ToString();

        }

        public Giocatore(string username)
        {
            this.username = username;
        }

        
        public void setAmici(List<String> nomi)
        {    
            Dictionary<string, object> m = dati;
            m.Remove("amici");
            m.Add("amici", nomi);
        }
    }
}
