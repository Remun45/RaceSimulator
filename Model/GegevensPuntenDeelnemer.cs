using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GegevensPuntenDeelnemer : IRaceGegevensView
    {
        public IParticipant Deelnemer { get; set; }
        public int AantalPunten { get; set; }
        public Track Track { get; set; }
        public override string ToString()
        {
            return $"{Deelnemer.Name} heeft {AantalPunten} behaald op Track: {Track.Name}";
        }

        public void Add(List<IRaceGegevensView> list)
        {
            foreach (IRaceGegevensView var in list)
            {
                GegevensPuntenDeelnemer gegevens = (GegevensPuntenDeelnemer) var;
                if (gegevens.Deelnemer == this.Deelnemer)
                {
                    Console.WriteLine(gegevens.AantalPunten + " " + this.AantalPunten);
                    gegevens.AantalPunten += this.AantalPunten;
                    Console.WriteLine();
                    return;
                }
            }
            list.Add(this);
        }

        public string GetBestParticipant(List<IRaceGegevensView> list)
        {
            if (list.Count == 0)
            {
                return "";
            }
            GegevensPuntenDeelnemer besteDeelnemer = new GegevensPuntenDeelnemer();
            foreach (IRaceGegevensView var in list)
            {
                GegevensPuntenDeelnemer gegevens = (GegevensPuntenDeelnemer) var;
                if (gegevens.AantalPunten > besteDeelnemer.AantalPunten)
                {
                    besteDeelnemer = gegevens;
                }
            }

            return $"De meeste punten zijn voor: {besteDeelnemer.Deelnemer.Name}";
        }
    }
}
