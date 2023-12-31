﻿using GestionSolicitudes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DAL.Repositorios.Contrato
{
    public interface ISolicitudRepository : IGenericRepository<Solicitud>
    {
        Task<Solicitud> Alta(Solicitud solicitud);
    }
}
