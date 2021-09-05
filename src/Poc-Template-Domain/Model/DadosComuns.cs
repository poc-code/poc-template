using System;

namespace Poc_Template_Domain.Model
{
    public class DadosComuns
    {
        public DadosComuns()
        {
            CriadoEm = DateTime.Now;
        }

        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}
