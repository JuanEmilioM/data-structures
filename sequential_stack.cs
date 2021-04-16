using System;

namespace Pila_Secuencial
{
	public class Pila <tipoItem>
	{
		tipoItem[] items;
		int tope;
		int maximo;
		
		public Pila (int n)
		{
			items=new tipoItem[n];
			tope=-1;
			maximo=n;
			
			Inicializar();
		}
		
		public Pila (): this(20) {}
		
		private void Inicializar ()
		{
			for(int i=0; i<maximo; i++)
				items[i]=default(tipoItem);
		}
		
		public bool Vacia ()
		{
			return (tope==-1);
		}
		
		public int Insertar (tipoItem x)
		{
			if(tope >= maximo-1)
				throw new Exception("Espacio insuficiente");
			
			tope++;
			items[tope]=x;
			
			return 0;
		}
				
		public tipoItem Quitar ()
		{
			if(Vacia())
				throw new Exception("Pila vacía");
			
			tipoItem x=items[tope];
			items[tope]=default(tipoItem);
			tope--;
			
			return x;
		}
		
		public tipoItem Ultimo ()
		{
			if(Vacia())
				throw new Exception("Pila vacía");
			
			return items[tope];
		}
	}
}
