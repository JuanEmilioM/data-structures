using System;
using Arbol_Binario;
using Lista_Encadenada;

namespace Arbol_Binario.Arbol_BB
{
	public partial class ArbolBB <T> : ArbolBinario <T> where T : IComparable <T> 
	{
		private Nodo buscarMinimo (Nodo nodo)
		{
			if(nodo.Izquierdo!=null)
				nodo=buscarMinimo(nodo.Izquierdo);
			
			return nodo;
		}
		
		private Nodo buscarMaximo (Nodo nodo)
		{
			if(nodo.Derecho!=null)
				nodo=buscarMaximo(nodo.Derecho);
			
			return nodo;
		}
		
		private Nodo eliminarMinimo (Nodo nodo)
		{
			if(nodo==null)
				return null;
			
			if(nodo.Izquierdo != null)
				nodo.Izquierdo=eliminarMinimo(nodo.Izquierdo);
			else
				nodo=nodo.Derecho;
			
			return nodo;
		}
		
		protected Nodo Buscar (T valor, Nodo nodo)
		{
			if(nodo==null)
				throw new Exception();
			
			if(nodo.Clave.CompareTo(valor) > 0)
				return Buscar(valor,nodo.Izquierdo);
			else
				if(nodo.Clave.CompareTo(valor) < 0)
					return Buscar(valor,nodo.Derecho);
				else
					return nodo;
		}
		
		private Nodo Insertar (T valor, Nodo nodo)
		{
			if(nodo == null)
				nodo=new Nodo(valor);
			else
				if(nodo.Clave.CompareTo(valor) > 0)
					nodo.Izquierdo=Insertar(valor,nodo.Izquierdo);
				else
					if(nodo.Clave.CompareTo(valor) < 0)
						nodo.Derecho=Insertar(valor,nodo.Derecho);
					else
						throw new Exception("Elemento duplicado");
			
			return nodo;
		}
		
		private Nodo Eliminar (T valor, Nodo nodo)
		{
			if(nodo==null)
				throw new Exception("Elemento no encontrado");
			
			if(nodo.Clave.CompareTo(valor) > 0)
					nodo.Izquierdo=Eliminar(valor,nodo.Izquierdo);
				else
					if(nodo.Clave.CompareTo(valor) < 0)
						nodo.Derecho=Eliminar(valor,nodo.Derecho);
					else
						if((nodo.Izquierdo != null) && (nodo.Derecho != null)) // El nodo tiene dos hijos
						{
							nodo.Clave=buscarMinimo(nodo.Derecho).Clave;
							nodo.Derecho=eliminarMinimo(nodo.Derecho);
						}
						else // Cambio de raíz
							nodo=(nodo.Izquierdo != null)? nodo.Izquierdo : nodo.Derecho;
						
			return nodo;
		}
				
		
		private int Nivel (T valor, Nodo nodo)
		{		
			if ((nodo.Hoja()) && (nodo.Clave.CompareTo(valor) != 0))
                throw new Exception();
			
			if (nodo.Clave.CompareTo(valor) > 0)
				return 1 + Nivel(valor,nodo.Izquierdo);
			else
				if(nodo.Clave.CompareTo(valor) < 0)
					return 1 + Nivel(valor,nodo.Derecho);
				else
					return 1;
		}
				
		private bool Hijo (T hijo, T padre, Nodo nodo)
		{
			try 
			{
				Nodo aux=Buscar(padre,nodo);
				return((aux.Izquierdo.Clave.CompareTo(hijo) == 0) || (aux.Derecho.Clave.CompareTo(hijo) == 0));
			}
			catch
			{
				return false;
			}
		}
		
		private void Camino (T hasta, Nodo nodo, Lista<T> camino)
		{
			if(nodo==null) 
				throw new Exception();
			
				if(nodo.Clave.CompareTo(hasta) > 0)
					Camino(hasta,nodo.Izquierdo,camino);
				else
					if(nodo.Clave.CompareTo(hasta) < 0)
						Camino(hasta,nodo.Derecho,camino);
			
			camino.Insertar(nodo.Clave);
			
		}
	}
}
