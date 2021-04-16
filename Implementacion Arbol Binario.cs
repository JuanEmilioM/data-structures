using System;

namespace Arbol_Binario
{
	public partial class ArbolBinario <T> : IArbolBinario <T>
	{
		private void PreOrden (ref string lista, Nodo nodo)
		{			
			if(nodo!=null) {
				lista+=nodo.Clave.ToString() + ", ";
				PreOrden(ref lista,nodo.Izquierdo);
				PreOrden(ref lista,nodo.Derecho);
			}
		}
		
		private void InOrden (ref string lista, Nodo nodo)
		{			
			if(nodo!=null) {
				PreOrden(ref lista,nodo.Izquierdo);
				lista+=nodo.Clave.ToString() + ", ";
				PreOrden(ref lista,nodo.Derecho);
			}
		}
		
		private void PostOrden (ref string lista, Nodo nodo)
		{			
			if(nodo!=null) {
				PreOrden(ref lista,nodo.Izquierdo);
				PreOrden(ref lista,nodo.Derecho);
				lista+=nodo.Clave.ToString() + ", ";
			}
		}
		
		private Nodo Limpiar (Nodo nodo)
		{
			if(nodo != null) {
				nodo.Izquierdo=Limpiar(nodo.Izquierdo);
				nodo.Derecho=Limpiar(nodo.Derecho);	
			}
			
			return null;
		}
		
		private int Altura (Nodo nodo)
		{
			if(nodo!=null)
				return 1 + Math.Max(Altura(nodo.Izquierdo),Altura(nodo.Derecho));
			else
				return 0;
		}
	}
}
