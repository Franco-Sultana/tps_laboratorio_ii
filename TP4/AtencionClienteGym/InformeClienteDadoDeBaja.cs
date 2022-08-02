using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void NotificarBajaCliente(InformeClienteDadoDeBaja sender);
    public class InformeClienteDadoDeBaja
    {
        private DateTime diaBaja;

        public InformeClienteDadoDeBaja(DateTime diaBaja)
        {
            this.diaBaja = diaBaja;
        }

        public DateTime DiaBaja { get => diaBaja; set => diaBaja = value; }

        public event NotificarBajaCliente OnNotificarBaja;



        public void EnviarNotificacionBaja()
        {
            if (OnNotificarBaja is not null)
            {
                OnNotificarBaja(this);
            }
        }

    }
}
