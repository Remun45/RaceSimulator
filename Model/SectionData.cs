﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class SectionData
    {
        IParticipant Left { get; set; }
        int DistanceLeft { get; set; }
        IParticipant right { get; set; }
        int DistanceRight { get; set; }
    }
}