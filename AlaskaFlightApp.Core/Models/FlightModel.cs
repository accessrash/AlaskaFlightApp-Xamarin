using System;
using System.Collections.Generic;

namespace AlaskaFlightApp.Core.Models
{
    public class CodeShare
    {
        public string FltId { get; set; }
        public string Carrier { get; set; }
    }

    public class FlightModel
    {
        public string OrigZuluOffset { get; set; }
        public string DestZuluOffset { get; set; }
        public string FltId { get; set; }
        public string Carrier { get; set; }
        public string Orig { get; set; }
        public string Dest { get; set; }
        public string CutOffTime { get; set; }
        public int FltDirection { get; set; }
        public DateTime SchedDepTime { get; set; }
        public DateTime EstDepTime { get; set; }
        public DateTime SchedArrTime { get; set; }
        public DateTime EstArrTime { get; set; }
        public string ActualTime { get; set; }
        public string DestGate { get; set; }
        public string OrigGate { get; set; }
        public List<CodeShare> CodeShares { get; set; }
        public string TailId { get; set; }
        public string FleetType { get; set; }
        public string Status { get; set; }
    }
}
