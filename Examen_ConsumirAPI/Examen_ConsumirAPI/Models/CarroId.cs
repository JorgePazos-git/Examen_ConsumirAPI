using System;
using System.Collections.Generic;
using System.Text;

namespace Examen_ConsumirAPI.Models
{
    public class CarroId
    {
        public long timestamp { get; set; }
        public int machine { get; set; }
        public int pid { get; set; }
        public int increment { get; set; }
        public DateTime creationTime { get; set; }
    }
}
