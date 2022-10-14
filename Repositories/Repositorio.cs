using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlUniversitario.Repositories
{
    internal interface Repositorio<T,ID> 
    {
        T Agregar(T t);
        T Actualizar(T t);
        bool Elimninar(ID id);
        List<T> Todos();



    }
}
