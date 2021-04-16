using System;
using Arbol_Binario;
using Lista_Encadenada;

namespace Arbol_Binario.Arbol_BB
{				
	public partial class ArbolBB <T> : IArbolBinario <T>
	{
		public ArbolBB () : base() {}
										
		public int Buscar (T valor)
		{
			if(Vacio())
				throw new Exception("Árbol vacio");
			
			try
			{
				Buscar(valor,raiz);
				return 0; // Elemento encontrado
			}
			catch 
			{
				return -1; // Elemento no encontrado
			}
		}
				
		public int Insertar (T valor) 
		{
			try 
			{
				raiz=Insertar(valor,raiz);
			}
			catch (Exception error)
			{
				throw error;
			}
			
			return 0; 
		}
		
		public int Eliminar (T valor)
		{
			if(Vacio())
				throw new Exception("Árbol vacio");
				                    
			try
			{
				raiz=Eliminar(valor,raiz);
			}
			catch (Exception error)
			{
				throw error;
			}
			
			return 0; 
		}
		
		public int EliminarMinimo ()
		{
			if(Vacio())
				throw new Exception("Árbol vacio");
				
			try 
			{
				return Eliminar(buscarMinimo(raiz).Clave);
			}
			catch (Exception error)
			{
				throw error;
			}
		}
		
		public int EliminarMaximo ()
		{
			if(Vacio())
				throw new Exception("Árbol vacio");
				
			
			try 
			{
				return Eliminar(buscarMaximo(raiz).Clave);
			}
			catch (Exception error)
			{
				throw error;
			}
		}
				
		public T Minimo ()
		{
			if(Vacio())
				throw new Exception("Árbol vacio");
			else
				return buscarMinimo(raiz).Clave;
		}
		
		public T Maximo ()
		{
			if(Vacio())
				throw new Exception("Árbol vacio");
			else
				return buscarMaximo(raiz).Clave;
		}
										
		public int Nivel (T valor)
		{
			if(Vacio())
				return 0;
			
			try 
			{
				return Nivel(valor,raiz);
			}
			catch 
			{
				return 0;
			}
		}
				
		public bool Hijo (T hijo, T padre)
		{
			if(Vacio())
				return false;
			else
				return Hijo(hijo,padre,raiz);
		}
		
		public bool Padre (T padre, T hijo)
		{
			if(Vacio())
				return false;
			else
				return Hijo(hijo,padre,raiz);
		}
		
		public bool Hoja (T valor)
		{
			if(Vacio())
				return false;
			
			try 
			{
				return (Buscar(valor,raiz).Hoja());
			}
			catch
			{
				return false;
			}
		}
		
		// Este método devuelve una lista de claves que conforman
		// el camino <desde....hasta>
		public Lista<T> Camino (T desde, T hasta)
		{
			try
			{
				Nodo aux=Buscar(desde,raiz);
				Lista<T> camino=new Lista<T>();
				Camino(hasta,aux,camino);
				return camino;
			}
			catch 
			{
				return null;
			}
		}
	}
}
