using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Mock
{
    public interface ITransporte
    {
        int Capacidad { get; set; }

        double PorcentajeCarga();
        int Cargar(int peso);
    }
}
