using System;

namespace Pila_Encadenada
{
	class Celda <tipoItem>
	{
		tipoItem dato;
		Celda<tipoItem> sig;
		
		public Celda ()
		{
			dato=default(tipoItem);
			sig=null;
		}
		
		public Celda <tipoItem> getSiguiente ()
		{
			return sig;
		}
		
		public void setSiguiente (Celda<tipoItem> dir)
		{
			sig=dir;
		}
		
		public void setSiguiente ()
		{
			sig=null;
		}
		
		public tipoItem getDato ()
		{
			return dato;
		}
		
		public void setDato (tipoItem x)
		{
			dato=x;
		}
	}
	
	public class Pila <tipoItem>
	{
		Celda<tipoItem> tope;
		
		public Pila () 
		{
			tope=null;
		}
		
		public bool Vacia ()
		{
			return (tope==null);
		}
		
		public int Insertar (tipoItem x)
		{
			Celda<tipoItem> aux=new Celda<tipoItem>();
			aux.setDato(x);
			aux.setSiguiente(tope);
			tope=aux;
			
			return 0;
		}
		
		public tipoItem Quitar ()
		{
			if(Vacia())
				throw new Exception("Pila vacía");
			
			Celda<tipoItem> aux=tope;
			tipoItem x = aux.getDato();
			tope= aux.getSiguiente();
			
			aux = null;
			
			return x;
		}
		
		public tipoItem Ultimo ()
		{
			if(Vacia())
				throw new Exception("Pila vacía");
			
			return tope.getDato();
		}
	}
}