using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen_ConsumirAPI.Models
{
    public class Carro
    {
        public CarroId id { get; set; }

        public string marca { get; set; }
        public string modelo { get; set; }
        public string color { get; set; }
        public string placa { get; set; }
        public int ano { get; set; }
        public int precio { get; set; }
        public string rutaimagen { get; set; }
    }
}
