using System;

namespace Cola_Encadenada
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
	
	public class Cola <tipoItem>
	{
		Celda<tipoItem> primero;
		Celda<tipoItem> ultimo;
		
		public Cola ()
		{
			primero=null;
			ultimo=null;
		}
		
		public bool Vacia ()
		{
			return (primero == null);
		}
		
		public int Insertar (tipoItem x)
		{
			Celda<tipoItem> aux = new Celda<tipoItem>();
			
			aux.setDato(x);
			aux.setSiguiente();
			
			if(ultimo == null) {
				primero=aux;
				ultimo=aux;
			}
			else {
				ultimo.setSiguiente(aux);
				ultimo=aux;
			}
			
			return 0;
		}
		
		public tipoItem Quitar ()
		{
			if(Vacia())
				throw new Exception("Cola vacía");
			
			Celda<tipoItem> aux=primero;
			tipoItem x = aux.getDato();
			primero= aux.getSiguiente();
			
			aux=null;
			
			if(primero == null)
				ultimo=null;
				
			return x;
		}
		
		public tipoItem Primero ()
		{
			if(Vacia())
				throw new Exception("Cola vacía");
			
			return primero.getDato();
		}
	}
}
