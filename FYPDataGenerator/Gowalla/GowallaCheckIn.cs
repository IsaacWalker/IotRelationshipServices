using System;
using System.Collections.Generic;
using System.Text;

namespace FYPDataGenerator
{
    public sealed class GowallaCheckIn
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int LocationId { get; set; }
    }

    public sealed class AndroidModel
    { 
        public string Model { get; set; }

        public string Manufacturer { get; set; }
    }

}
