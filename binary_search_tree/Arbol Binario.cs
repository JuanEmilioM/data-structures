namespace Arbol_Binario
{
	public partial class ArbolBinario <T>
	{
		protected class Nodo                                 
        {
			T clave;
			Nodo izquierdo;
			Nodo derecho;
			
			public Nodo (T valor)
			{
				clave=valor;
				izquierdo=derecho=null;
			}
			
			public bool Hoja ()
			{
				return((izquierdo==null) && (derecho==null));
			} 
			
			public T Clave
			{
				get
				{
					return clave;
				}
				
				set
				{
					clave=value;
				}
			}
			
			public Nodo Izquierdo
			{
				get
				{
					return izquierdo;
				}
				
				set
				{
					izquierdo=value;
				}
			}
			
			public Nodo Derecho
			{
				get
				{
					return derecho;
				}
				
				set
				{
					derecho=value;
				}
			}
		}
		
		protected Nodo raiz;
		
		public ArbolBinario ()
		{
			raiz=null;
		}
		
		public bool Vacio ()
		{
			return(raiz==null);
		}
		
		public string PreOrden ()
		{
			if(Vacio())
				return "Árbol vacio";
			
			string lista="";
			PreOrden(ref lista,raiz);
			return lista;
		}
		
		public string InOrden ()
		{
			if(Vacio())
				return "Árbol vacio";
			
			string lista="";
			InOrden(ref lista,raiz);
			return lista;
		}
		
		public string PostOrden ()
		{
			if(Vacio())
				return "Árbol vacio";
			
			string lista="";
			PostOrden(ref lista,raiz);
			return lista;
		}
		
		public void Limpiar ()
		{
			raiz=Limpiar(raiz);
		}
		
		public int Altura ()
		{
			if(Vacio())
				return 0;
			else
				return Altura(raiz);
		}
	}
}
