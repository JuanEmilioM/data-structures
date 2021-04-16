using System;
using System.Runtime.CompilerServices;

namespace Lista_Secuencial
{
	public class Lista <tipoItem> where tipoItem : IEquatable <tipoItem>
    {
        tipoItem[] items;
        int maximo;
        int ultimo;

        public Lista(int n)
        {
            items = new tipoItem[n];
            maximo = n;
            ultimo = -1;

            Inicializar();
        }

        public Lista() : this(20) { }

        public bool Vacia()
        {
            return (ultimo == -1);
        }

        private void Inicializar()
        {
            for (int i = 0; i < maximo; i++)
                items[i] = default(tipoItem);
        }

        private void OffsetR (int i)
        {
            for(int j=ultimo; j>=i; j--)
                items[j+1]=items[j];
        }

        private void OffsetL (int i)
        {
            for(int j=i; j<ultimo; j++)
                items[j]=items[j+1];

            items[ultimo] = default(tipoItem);
        }
        
        public tipoItem this [int indice]
        {
        	get
        	{
        		return Recuperar(indice);
        	}
        	
        	set
        	{
        		Insertar(indice,value);
        	}
        }
        
        public void Insertar (tipoItem dato)
        {
        	Insertar(1,dato);
        }

        private void Insertar(int i, tipoItem dato)
        {
            i--;
			
            if(ultimo+1 >= maximo)
            	throw new Exception("Espacio insuficiente");
            
            if ((i < 0) || (i > ultimo + 1))
            	throw new Exception("Posiciones válidas de 1 a " + (ultimo+2));            
                        
            OffsetR(i);
            items[i] = dato;
            ultimo++;
        }
        
        public void Agregar (tipoItem dato)
        {
        	this[ultimo+2]=dato;
        }

        public tipoItem Suprimir(int i)
        {
            i--;

            tipoItem x;

            if(Vacia()) 
                throw new Exception("Lista vacía");
                
            if((i < 0) || (i > ultimo))
            	throw new Exception("Indice incorrecto");

            x = items[i];
            OffsetL(i);
            ultimo--;

            return x;
        }

        private tipoItem Recuperar(int i)
        {
            i--;

            if(Vacia()) 
            	throw new Exception("Lista vacía");
            
            if((i<0) || (i>ultimo))
            	throw new Exception("Indice incorrecto");
            
            return items[i];
        }

        public int Buscar(tipoItem dato)
        {
            int i = 0;
            while ((i <= ultimo) && (!items[i].Equals(dato)))
            	i++;

            if (i > ultimo)
                return -1;
            else
                return i+1;
        }

        public void Limpiar ()
        {
            Inicializar();
            ultimo = -1;
        }

        public tipoItem Primero ()
        {
        	return this[1];
        }

        public tipoItem Ultimo()
        {
        	return this[ultimo+1];
        }

        public int Cantidad
        {
            get
            {
                return ultimo + 1;
            }
        }
    }
}
