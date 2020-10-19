using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GegevensQualityVoorNaRace : IRaceGegevensView
    {
        public IParticipant Deelnemer { get; set; }
        public int QualityVoorRace { get; set; }
        public int QualityNaRace { get; set; }
        public Track Track { get; set; }
        public override string ToString()
        {
            return $"{Deelnemer.Name} : kwaliteit voor race {QualityVoorRace}, na race {QualityNaRace} op track {Track.Name}";
        }

        public void Add(List<IRaceGegevensView> list)
        {
            foreach (IRaceGegevensView var in list)
            {
                GegevensQualityVoorNaRace gegevens = (GegevensQualityVoorNaRace)var;

                if (gegevens.Deelnemer == this.Deelnemer && gegevens.Track == this.Track)
                {
                    gegevens.QualityNaRace = this.QualityNaRace;
                    gegevens.QualityVoorRace = this.QualityVoorRace;
                    return;
                }
            }
            list.Add(this);
        }
        public string GetBestParticipant(List<IRaceGegevensView> list)
        {
            GegevensQualityVoorNaRace besteDeelnemer = new GegevensQualityVoorNaRace();
            foreach (IRaceGegevensView var in list)
            {
                GegevensQualityVoorNaRace gegevens = (GegevensQualityVoorNaRace)var;
                if (gegevens.QualityNaRace > besteDeelnemer.QualityNaRace)
                {
                    besteDeelnemer = gegevens;
                }
            }
            return $"De driver met de meeste kwaliteit na de race is : {besteDeelnemer.Deelnemer.Name} op de track : {besteDeelnemer.Track.Name}";
        }
    }
}
