using System;

namespace ColaEncadenada
{
    class Celda<tipoItem>
    {
        tipoItem item;
        Celda<tipoItem> sig;

        public Celda()
        {
            sig = null;
        }

        public tipoItem getItem()
        {
            return item;
        }

        public void setItem(tipoItem x)
        {
            item = x;
        }

        public void setSig(Celda<tipoItem> dir)
        {
            sig = dir;
        }

        public Celda<tipoItem> getSig()
        {
            return sig;
        }

        ~Celda() { }
    }

    public class Cola<tipoItem>
    {
        int cant;

        Celda<tipoItem> primero;
        Celda<tipoItem> ultimo;

        public Cola()
        {
            primero = null;
            ultimo = null;
            cant = 0;
        }

        public bool Vacia()
        {
            return (cant == 0);
        }

        public void Insertar(tipoItem x)
        {
            Celda<tipoItem> aux = new Celda<tipoItem>();
            aux.setItem(x);
            aux.setSig(null);

            if (ultimo == null)
            {
                primero = aux;
                cant++;
            }
            else
            {
                ultimo.setSig(aux);
                ultimo = aux;
                cant++;
            }
        }
        
        private tipoItem Suprimir()
        {
            Celda<tipoItem> aux;
            tipoItem x;

            if (Vacia())
                return default(tipoItem);

            x = primero.getItem();
            aux = primero;
            primero = primero.getSig();
            cant--;

            aux = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            return x;
        }


        public int Cantidad
        {
            get
            {
                return cant;
            }
        }

        // Devuelve el primer elemento de la Cola y lo elimina
        public tipoItem Primero
        {
            get
            {
                return Suprimir();
            }
        }
    }
}
