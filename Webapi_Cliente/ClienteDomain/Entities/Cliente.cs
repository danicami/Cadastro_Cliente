﻿namespace Webapi_Cliente.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }

    }
}
