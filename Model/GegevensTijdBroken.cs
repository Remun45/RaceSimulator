using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GegevensTijdBroken : IRaceGegevensView
    {
        public IParticipant Deelnemer { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public Track Track { get; set; }
        public override string ToString()
        {
            return $"{Deelnemer.Name} : {TimeSpan} on track {Track.Name}";
        }

        public void Add(List<IRaceGegevensView> list)
        {
            foreach (IRaceGegevensView var in list)
            {
                GegevensTijdBroken gegevens = (GegevensTijdBroken)var;
                if (gegevens.Deelnemer == this.Deelnemer && gegevens.Track == this.Track)
                {
                    gegevens.TimeSpan += this.TimeSpan;
                    return;
                }
            }
            list.Add(this);
        }
        public string GetBestParticipant(List<IRaceGegevensView> list)
        {
            GegevensTijdBroken besteDeelnemer = new GegevensTijdBroken();
            foreach (IRaceGegevensView var in list)
            {
                GegevensTijdBroken gegevens = (GegevensTijdBroken)var;
                if (gegevens.TimeSpan < besteDeelnemer.TimeSpan)
                {
                    besteDeelnemer = gegevens;
                }
            }

            return $"De driver met de minste tijd kapot is: {besteDeelnemer.Deelnemer.Name}";
        }
    }
}
