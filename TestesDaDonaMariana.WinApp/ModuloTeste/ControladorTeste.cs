﻿using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.WinApp.ModuloDiciplina
{
    public class ControladorTeste
    {
        IRepositorioTeste repositorioTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste)
        {
            this.repositorioTeste = repositorioTeste;
        }
    }
}
