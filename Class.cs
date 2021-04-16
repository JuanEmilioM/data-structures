using System;

namespace Lista_Encadenada
{
	class Nodo <tipoItem> 
	{
		int indice;
		tipoItem dato;
		Nodo<tipoItem> sig;
		
		public Nodo ()
		{
			dato=default(tipoItem);
			sig=null;
		}
		
		public Nodo <tipoItem> getSiguiente ()
		{
			return sig;
		}
		
		public void setSiguiente (Nodo<tipoItem> dir)
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
		
		public void setIndice (int i)
		{
			indice=i;
		}
	
		public int getIndice ()
		{
			return indice;
		}
	}
	
	public class Lista <tipoItem> where tipoItem : IComparable <tipoItem>
	{
		Nodo<tipoItem> cabeza;
		int nodos;
		
		public Lista ()
		{
			cabeza=null;
			nodos=0;
		}
		
		public bool Vacia ()
		{
			return(cabeza==null);
		}
				
		public void Insertar (tipoItem dato)
		{
				Nodo<tipoItem> nuevo=new Nodo<tipoItem>();
				nuevo.setIndice(1);
				nuevo.setDato(dato);
				
				if(Vacia())
					nuevo.setSiguiente();
				else
					nuevo.setSiguiente(cabeza);
			
				cabeza=nuevo;
				nodos++;
				
				if(!Vacia())
					IncrementarNodos(nuevo.getSiguiente());
		}
		
		private void Insertar (int i, tipoItem dato)
		{
			if((i < 1) || (i > nodos+1))
				throw new Exception("Posiciones válidas de 1 a " + (nodos+1));
												
			if(i==1) {
				Insertar(dato);
				return;
			}
			
			// Buscar posición de inserción
			int j=0;
			Nodo<tipoItem> aux=cabeza;
			Nodo<tipoItem> anterior=aux;;
			
			while((j < nodos) && (aux.getIndice() != i)) {
				anterior=aux;
				aux=aux.getSiguiente();
				j++;
			}
			
			Nodo<tipoItem> nuevo=new Nodo<tipoItem>();
			nuevo.setIndice(i);
			nuevo.setDato(dato);
			nuevo.setSiguiente(aux);
			anterior.setSiguiente(nuevo);
			nodos++;
			
			IncrementarNodos(nuevo.getSiguiente());
		}
				
		public void Agregar (tipoItem dato)
		{
			this[nodos+1]=dato;
		}
		
		public tipoItem Suprimir (int i)
		{
			int j=0;
			tipoItem x=default(tipoItem);
			Nodo<tipoItem> aux=cabeza;
			Nodo<tipoItem> anterior=aux;;
			
			if(Vacia())
				throw new Exception("Lista vacía");
			
			if((i-1 < 0) || (i > nodos))
				throw new Exception("Indice incorrecto");
			
			// Supresión del primer elemento de la Lista
			if(i == 1) {
				x=cabeza.getDato();
				cabeza=cabeza.getSiguiente();
				aux=null;
				nodos--;
				
				DecrementarNodos(cabeza);
				
				return x;
			}
			
			while((j < nodos) && (aux.getIndice() != i)) {
				anterior=aux;
				aux=aux.getSiguiente();
				j++;
			}
			
			anterior.setSiguiente(aux.getSiguiente());
			x=aux.getDato();
			aux=null;
			nodos--;
			
			DecrementarNodos(anterior.getSiguiente());
			
			return x;
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
		
		private tipoItem Recuperar (int i)
		{
			int j=0;
			Nodo<tipoItem> aux=cabeza;
			
			if(Vacia())
				throw new Exception("Lista vacía");
			
			if((i-1 < 0) || (i > nodos))
				throw new Exception("Indice incorrecto");
			
			while((j < nodos) && (aux.getIndice() != i)) {
				aux=aux.getSiguiente();
				j++;
			}
			
			return aux.getDato();
		}
		
		
		public tipoItem Primero ()
		{
			return this[1];
		}
		
		public tipoItem Ultimo ()
		{
			return this[nodos];
		}
		
		public int Buscar (tipoItem dato)
		{
			Nodo<tipoItem> aux=cabeza;
			
			while((aux != null) && (aux.getDato().CompareTo(dato)) != 0)
				aux=aux.getSiguiente();
			
			if(aux!=null)
				return aux.getIndice();
			else
				return -1;
		}
				
		public void Limpiar ()
		{	
			Nodo<tipoItem> aux;
			
			while(cabeza != null) {
				aux=cabeza;
				aux=null;
				cabeza=cabeza.getSiguiente();
			}
			
			nodos=0;
		}
			
		private void IncrementarNodos (Nodo<tipoItem> x)
		{
			while(x != null) {
				x.setIndice(x.getIndice()+1);
				x=x.getSiguiente();
			}
		}
		
		private void DecrementarNodos (Nodo<tipoItem> x)
		{
			while(x != null) {
				x.setIndice(x.getIndice()-1);
				x=x.getSiguiente();
			}
		}
		
		public int Nodos
		{
			get 
			{
				return nodos;
			}
		}
	}
}