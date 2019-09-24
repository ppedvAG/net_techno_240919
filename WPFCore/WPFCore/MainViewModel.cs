using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCore
{
    class MainViewModel
    {
        public List<Pillen> PillenListe { get; set; } = new List<Pillen>();

        public Pillen SelectedPille { get; set; }



        public MainViewModel()
        {
            PillenListe.Add(new Pillen() { Id = 1, Name = "Aspirin", Gewicht = 623 });
            PillenListe.Add(new Pillen() { Id = 2, Name = "Ibu", Gewicht = 1233 });
            PillenListe.Add(new Pillen() { Id = 3, Name = "Prägni", Gewicht = -265 });
        }
    }
}
