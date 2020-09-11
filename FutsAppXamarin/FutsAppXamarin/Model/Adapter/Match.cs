using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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

        public Color colore { get; set; }
        public ImageSource profile_image { get; set; }
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
            if (risultato.Length > 8)
            {
                Image img = new Image { Source = "user.png" };
                profile_image = img.Source;
            }
            else UpdateColor();
             
        }

        private void UpdateColor()
        {
            var name = Application.Current.Properties["username"];
            var casa = int.Parse(getgolCasa());
            var ospite = int.Parse(getgolOspite());
            if (((casa > ospite) && teams.IndexOf(name)<5) || ((casa < ospite) && teams.IndexOf(name) > 4))
                colore = Color.FromHex("#03b400");
            else if (casa==ospite)
                colore = Color.FromHex("#00bfff");
            else 
                colore = Color.FromHex("#f12213");
        }

        public String getgolCasa() { return risultato.Substring(0, risultato.IndexOf("-")).Trim(); }

        public String getgolOspite()
        {
            return risultato.Substring(risultato.IndexOf("-") + 1).Trim();
            
        }

    }
}

