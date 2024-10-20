using System;
using System.Collections.Generic;

namespace SimplesmenteUse
{
    public class ObjetoDigitalizado
    {
        public int Idobjeto { get; set; }
        public int Codigotipoobjeto { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Datacriacao { get; set; }
        public byte[]? Objeto { get; set; }
        public string? Nomearquivo { get; set; }
        public string? Localizacaofisica { get; set; }
        public int? Idusuariosalvou { get; set; }
        public short? NaoVisualizar { get; set; }
    }

    public class ObjetoDigitalizadoRequest
    {
        public int Codigotipoobjeto { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Datacriacao { get; set; }
        public IFormFile? Objeto { get; set; }
        public string? Nomearquivo { get; set; }
        public string? Localizacaofisica { get; set; }
        public int? Idusuariosalvou { get; set; }
        public short? NaoVisualizar { get; set; }
    }
}
