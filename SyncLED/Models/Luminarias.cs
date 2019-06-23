using System;
using System.Collections.Generic;

namespace SyncLED.Models
{
    public partial class Luminarias
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public bool? SensorPresenca { get; set; }
        public bool? ModoAuto { get; set; }
    }
}
