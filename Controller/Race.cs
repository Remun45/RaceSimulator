using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Controller
{
    // delegates
    public delegate void OnDriversChanged(object sender, DriversChangedEventArgs args);
    public delegate void RaceFinished(object sender, RaceFinishedArgs args);
    public delegate void StartNextRace(object sender, EventArgs args);

    public class Race
    {
        // Variables
        public Track Track { get; set; }
        public List<IParticipant> Deelnemers { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random;
        private Dictionary<Section, SectionData> _positions;
        private Dictionary<IParticipant, int> _rounds;
        private Dictionary<IParticipant, TimeSpan> _timeBroken;
        private int _amountOfFinishedParticipants = 0;
        private Stack<IParticipant> eindstand = new Stack<IParticipant>();

        //events and timer
        public event OnDriversChanged DriversChanged;
        public event StartNextRace StartNextRace;
        public event RaceFinished RaceFinished;
        private Timer _timer;

        //Dictionary to keep track of last sectionTime
        private Dictionary<IParticipant, long> _sectionTijden;
        //Dictionary to keep track of quality
        private Dictionary<IParticipant, int> _quality;
        //Constructor
        public Race(Track track, List<IParticipant> deelnemers)
        {
            this.Track = track;
            this.Deelnemers = deelnemers;

            _random = new Random(DateTime.Now.Millisecond);
            StartTime = new DateTime();
            _positions = new Dictionary<Section, SectionData>();
            _rounds = new Dictionary<IParticipant, int>();
            _sectionTijden = new Dictionary<IParticipant, long>();
            _quality = new Dictionary<IParticipant, int>();
            _timeBroken = new Dictionary<IParticipant, TimeSpan>();

            SetAllSections();
            SetStartPositions();

            _timer = new Timer(500);
            _timer.Elapsed += OnTimedEvent;

            Start();
        }

        //Timer event
        public void OnTimedEvent(object sender, ElapsedEventArgs args)
        {
            Section vorigeSection = _positions.First().Key;

            foreach (KeyValuePair<Section, SectionData> valuePair in _positions.Reverse())
            {
                SectionData sectionData = valuePair.Value;
                if (sectionData.Left != null)
                {
                    IParticipant currentDeelnemer = valuePair.Value.Left;
                    if (!sectionData.Left.Equipment.isBroken)
                    {
                        sectionData.DistanceLeft +=
                            sectionData.Left.Equipment.Performance * sectionData.Left.Equipment.Speed;
                        if (sectionData.DistanceLeft >= 100)
                        {
                            if (valuePair.Key.SectionType == SectionTypes.Finish)
                            {
                                if (_rounds[sectionData.Left] > 0)
                                {
                                    ParticipantFinished(sectionData, 0);
                                }
                                else
                                {
                                    _rounds[sectionData.Left]++;
                                    SetParticipantNextSectionLeft(vorigeSection, sectionData);
                                }
                            }
                            else
                            {
                                SetParticipantNextSectionLeft(vorigeSection, sectionData);
                            }
                            SaveTimeForSectionAndParticipant(valuePair.Key, currentDeelnemer, args);
                        }
                    }
                }

                if (sectionData.Right != null)
                {
                    IParticipant currentDeelnemer = valuePair.Value.Right;
                    if (!sectionData.Right.Equipment.isBroken)
                    {
                        sectionData.DistanceRight +=
                            sectionData.Right.Equipment.Performance * sectionData.Right.Equipment.Speed;
                        if (sectionData.DistanceRight >= 100)
                        {
                            if (valuePair.Key.SectionType == SectionTypes.Finish)
                            {
                                if (_rounds[sectionData.Right] > 0)
                                {
                                    ParticipantFinished(sectionData, 1);
                                }
                                else
                                {
                                    _rounds[sectionData.Right]++;
                                    SetParticipantNextSectionRight(vorigeSection, sectionData);
                                }
                            }
                            else
                            {
                                SetParticipantNextSectionRight(vorigeSection, sectionData);
                            }
                            SaveTimeForSectionAndParticipant(valuePair.Key, currentDeelnemer, args);
                        }
                    }
                }

                vorigeSection = valuePair.Key;
            }
            CheckRaceFinish();
            SetRandomBroken(args);
            SetUnBroken();
            DriversChanged?.Invoke(this, new DriversChangedEventArgs() { Track = this.Track });
        }

        //start race
        public void Start()
        {
            foreach (IParticipant deelnemer in Deelnemers)
            {
                _sectionTijden.Add(deelnemer, 0);
                _timeBroken.Add(deelnemer, TimeSpan.Zero);
            }
            _timer.Start();
            StartTime = DateTime.Now;
        }

        //stop race
        public void Stop()
        {
            _timer.Stop();
            SaveTimeBroken();
            RaceFinished?.Invoke(this, new RaceFinishedArgs(){Eindstand = eindstand, Track = Track});

            // ask if they want to see the next race
            string tekst = Console.ReadLine();
            while (tekst != "y")
            {
                tekst = Console.ReadLine();
            }
            StartNextRace?.Invoke(this, EventArgs.Empty);
        }

        // get the data from a section
        public SectionData GetSectionData(Section section)
        {
            if (!_positions.ContainsKey(section))
            {
                _positions.Add(section, new SectionData());
            }
            return _positions[section];
        }

        // Randomize equipment for drivers
        private void RandomizeEquipment()
        {
            foreach (IParticipant deelnemer in Deelnemers)
            {
                deelnemer.Equipment.Performance = _random.Next(20, 30);
                deelnemer.Equipment.Quality = _random.Next(1, 10);
                _quality.Add(deelnemer, deelnemer.Equipment.Quality);
            }
        }

        // set driver start positions
        private void SetStartPositions()
        {
            int participants = 0;
            int max = Deelnemers.Count;
            RandomizeEquipment();
            foreach (KeyValuePair<Section, SectionData> keyValue in _positions)
            {
                if (keyValue.Key.SectionType == SectionTypes.StartGrid)
                {
                    if (participants + 1 < max)
                    {
                        keyValue.Value.Left = Deelnemers[participants];
                        _rounds.Add(Deelnemers[participants], 0);
                        keyValue.Value.Right = Deelnemers[participants + 1];
                        _rounds.Add(Deelnemers[participants + 1], 0);
                        participants += 2;
                    }
                    else if (participants < max)
                    {
                        keyValue.Value.Left = Deelnemers[participants];
                        _rounds.Add(Deelnemers[participants], 0);
                        participants += 1;
                    }
                }
            }
        }

        // set all the sections
        private void SetAllSections()
        {
            foreach (Section section in Track.Sections)
            {
                _positions.Add(section, new SectionData());
            }
        }

        //set participants to next section
        private void SetParticipantNextSectionLeft(Section vorigeSection, SectionData sectionData)
        {
            if (GetSectionData(vorigeSection).Left == null)
            {
                GetSectionData(vorigeSection).Left = sectionData.Left;
                GetSectionData(vorigeSection).DistanceLeft = sectionData.DistanceLeft - 100;
                sectionData.Left = null;
                sectionData.DistanceLeft = 0;
            }
            else if (GetSectionData(vorigeSection).Right == null)
            {
                GetSectionData(vorigeSection).Right = sectionData.Left;
                GetSectionData(vorigeSection).DistanceRight = 0;
                sectionData.Left = null;
                sectionData.DistanceLeft = 0;
            }
        }
        private void SetParticipantNextSectionRight(Section vorigeSection, SectionData sectionData)
        {
            if (GetSectionData(vorigeSection).Right == null)
            {
                GetSectionData(vorigeSection).Right = sectionData.Right;
                GetSectionData(vorigeSection).DistanceRight = 0;
                sectionData.Right = null;
                sectionData.DistanceRight = 0;
            }
            else if (GetSectionData(vorigeSection).Left == null)
            {
                GetSectionData(vorigeSection).Left = sectionData.Right;
                GetSectionData(vorigeSection).DistanceLeft = sectionData.DistanceRight - 100;
                sectionData.Right = null;
                sectionData.DistanceRight = 0;
            }
        }

        //save time and section per participant
        private void SaveTimeForSectionAndParticipant(Section section, IParticipant deelnemer, ElapsedEventArgs args)
        {
            long ticksLastRound = _sectionTijden[deelnemer];
            if (ticksLastRound == 0)
            {
                ticksLastRound = StartTime.Ticks;
            }
            TimeSpan timeSpan = new TimeSpan(args.SignalTime.Ticks - ticksLastRound);
            _sectionTijden[deelnemer] = timeSpan.Ticks;
            Data.Competition.SectionTijden.AddItemToList(new GegevensRondeTijdDeelnemer(){Deelnemer = deelnemer, Section = section, SectionTime = timeSpan});
        }

        //Participant finished -> position left : 0, right : 1
        private void ParticipantFinished(SectionData sectionData, int position)
        {
            if (position == 0)
            {
                eindstand.Push(sectionData.Left);
                SaveQuality(sectionData.Left);
                sectionData.Left = null;
                sectionData.DistanceLeft = 0;
                _amountOfFinishedParticipants++;
            }
            else
            {
                eindstand.Push(sectionData.Right);
                SaveQuality(sectionData.Right);
                sectionData.Right = null;
                sectionData.DistanceRight = 0;
                _amountOfFinishedParticipants++;
            }
        }

        // Save quality after race
        private void SaveQuality(IParticipant deelnemer)
        {
            Data.Competition.KwaliteitGegevens.AddItemToList(new GegevensQualityVoorNaRace(){Deelnemer = deelnemer, QualityVoorRace = _quality[deelnemer], QualityNaRace = deelnemer.Equipment.Quality, Track = Track});
        }

        // Broken randomizers
        private void SetRandomBroken(ElapsedEventArgs args)
        {
            foreach (IParticipant deelnemer in Deelnemers)
            {
                int randomizer = _random.Next(1, 100);
                if (randomizer % deelnemer.Equipment.Quality == 3)
                {
                    SetTimeBroken(deelnemer, args);
                    deelnemer.Equipment.isBroken = true;
                }
            }
        }
        private void SetUnBroken()
        {
            foreach (IParticipant deelnemer in Deelnemers)
            {
                if (deelnemer.Equipment.isBroken)
                {
                    if (_random.Next(1, 5) == 2)
                    {
                        deelnemer.Equipment.isBroken = false;
                        if (deelnemer.Equipment.Quality > 2)
                        {
                            deelnemer.Equipment.Quality--;
                        }
                        else if (deelnemer.Equipment.Performance > 15)
                        {
                            deelnemer.Equipment.Performance--;
                        }
                    }
                }
            }
        }

        //save and set time broken
        private void SetTimeBroken(IParticipant deelnemer, ElapsedEventArgs args)
        {
            TimeSpan timeSpan = new TimeSpan(args.SignalTime.Ticks - StartTime.Ticks);
            if (timeSpan != TimeSpan.Zero)
            {
                Data.Competition.TijdBroken.AddItemToList(new GegevensTijdBroken()
                    {Deelnemer = deelnemer, TimeSpan = timeSpan, Track = Track});
            }
        }
        private void SaveTimeBroken()
        {
            foreach (var VARIABLE in _timeBroken)
            {
                Data.Competition.TijdBroken.AddItemToList(new GegevensTijdBroken(){Deelnemer = VARIABLE.Key, TimeSpan = VARIABLE.Value, Track = Track});
            }
        }

        //Check if race is finished
        private void CheckRaceFinish()
        {
            if (_amountOfFinishedParticipants == Deelnemers.Count)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 10);
                Console.WriteLine("Game over");
                Stop();
            }
        }

    }
}
