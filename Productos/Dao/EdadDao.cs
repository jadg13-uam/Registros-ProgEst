using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Dao
{
    public class EdadDao
    {
        public static int[] edades = new int[5];
        public static int pos = 0;

        public static double GetPromedio()
        {
            double suma = 0, promedio = 0 ;
            for(int i = 0; i < pos; i++)
            {
                suma += edades[i];
            }
            promedio = suma / pos;
            return promedio;
        }
    }
}
