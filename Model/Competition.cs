using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Model
{
    public class Competition
    {
        // variables
        public List<IParticipant> Participants { get; set; }
        public Queue<Track> Tracks { get; set; }
        public RaceGegevens<GegevensPuntenDeelnemer> DeelnemerPunten { get; set; }
        public RaceGegevens<GegevensRondeTijdDeelnemer> SectionTijden { get; set; }
        public RaceGegevens<GegevensTijdBroken> TijdBroken { get; set; }
        public RaceGegevens<GegevensQualityVoorNaRace> KwaliteitGegevens { get; set; }
        // constructor
        public Competition()
        {
            Participants = new List<IParticipant>();
            Tracks = new Queue<Track>();
            DeelnemerPunten = new RaceGegevens<GegevensPuntenDeelnemer>();
            SectionTijden = new RaceGegevens<GegevensRondeTijdDeelnemer>();
            TijdBroken = new RaceGegevens<GegevensTijdBroken>();
            KwaliteitGegevens = new RaceGegevens<GegevensQualityVoorNaRace>();
        }
        // return the next track
        public Track NextTrack()
        {
            if (Tracks.Count > 0)
            {
                return Tracks.Dequeue();
            }
            return null;
        }

        //when race is finished
        public void OnRaceFinished(object sender, RaceFinishedArgs args)
        {
            AwardPoints(args.Eindstand, args.Track);
            Console.WriteLine($"Track: {args.Track.Name}, uitslag:");
            while (args.Eindstand.Count != 0)
            {
                Console.WriteLine($"Plek {args.Eindstand.Count} is voor {args.Eindstand.Pop().Name}");
            }
            Console.WriteLine("");
            Console.WriteLine(DeelnemerPunten.Print());
            Console.WriteLine(KwaliteitGegevens.Print());
            Console.WriteLine("Wilt u door met de volgende race? (y/n)");
        }

        //Award points to participants
        public void AwardPoints(Stack<IParticipant> eindstand, Track track)
        {
            int punten = 10;
            foreach (IParticipant deelnemer in eindstand)
            {
                DeelnemerPunten.AddItemToList(new GegevensPuntenDeelnemer() { AantalPunten = punten, Deelnemer = deelnemer, Track = track});
                punten += punten / 2;
            }
        }
    }
}