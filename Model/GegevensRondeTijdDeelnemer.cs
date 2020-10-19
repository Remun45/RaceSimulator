using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GegevensRondeTijdDeelnemer : IRaceGegevensView
    {
        public TimeSpan SectionTime { get; set; }
        public IParticipant Deelnemer { get; set; }
        public Section Section { get; set; }

        public override string ToString()
        {
            return $"{Deelnemer.Name} rijd de section : {Section.SectionType} in {SectionTime / 10000} milliseconden";
        }

        public void Add(List<IRaceGegevensView> list)
        {
            foreach (IRaceGegevensView var in list)
            {
                GegevensRondeTijdDeelnemer gegevens = (GegevensRondeTijdDeelnemer)var;
                if (gegevens.Deelnemer == this.Deelnemer && gegevens.Section == this.Section)
                {
                    gegevens.SectionTime = this.SectionTime;
                    return;
                }
            }
            list.Add(this);
        }
        public string GetBestParticipant(List<IRaceGegevensView> list)
        {
            GegevensRondeTijdDeelnemer besteDeelnemer = new GegevensRondeTijdDeelnemer();
            foreach (IRaceGegevensView var in list)
            {
                GegevensRondeTijdDeelnemer gegevens = (GegevensRondeTijdDeelnemer)var;
                if (gegevens.SectionTime < besteDeelnemer.SectionTime)
                {
                    besteDeelnemer = gegevens;
                }
            }

            return $"De driver met de laagste rondetijden is : {besteDeelnemer.Deelnemer.Name}";
        }
    }
}