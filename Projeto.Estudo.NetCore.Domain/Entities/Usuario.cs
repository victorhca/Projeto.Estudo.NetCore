﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Estudo.NetCore.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
