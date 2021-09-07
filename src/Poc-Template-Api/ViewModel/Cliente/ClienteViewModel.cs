﻿using System;

namespace Poc_Template_Api.ViewModel.Customer
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int UsuarioId { get; set; }
        public bool? Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}
