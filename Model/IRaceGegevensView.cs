using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model
{
    public interface IRaceGegevensView
    {
        public IParticipant Deelnemer { get; set; }
        public void Add(List<IRaceGegevensView> list);
        public string GetBestParticipant(List<IRaceGegevensView> list);
    }
}
