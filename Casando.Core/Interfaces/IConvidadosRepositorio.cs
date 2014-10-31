﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Casando.Core.Modelos;

namespace Casando.Core.Interfaces
{
    public interface IConvidadosRepositorio : IRepositorio<Convidado>
    {
        IDictionary<string, int> Totais();
    }
}