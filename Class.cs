using System;

namespace Monticulo_Binario
{
	public partial class MonticuloBinario <T> where T : IComparable <T>
	{
		T[] vector;
		int tamActual;
		bool ordenado;
		
		public MonticuloBinario (int n)
		{
			GetVector(n);
			tamActual=0; // Tamaño actual
			ordenado=true;
			
			Inicializar();
		}

		public MonticuloBinario() : this(20) { }

		public bool Vacio()
		{
			return(tamActual==0);
		}

		private void Inicializar()
		{
			for(int i = 0; i < vector.Length; i++)
				vector[i] = default(T);
		}
		
		public void Limpiar ()
		{
			Inicializar();
			tamActual = 0;
			ordenado=true;
		}
		
		public T Minimo ()
		{
			if(Vacio())
				throw new Exception("Árbol vacio");
			
			if(!ordenado)
				ArreglarMonticulo();
			return vector[1];
		}
		
		public int Introducir (T valor)
		{
			ComprobarTamanio();
			vector[++tamActual]=valor;
			
			if(tamActual == 1)
				ordenado=true;
			else
				if(valor.CompareTo(vector[tamActual/2]) < 0)
					ordenado=false;
			
			return 0;
		}
		
		public int Insertar (T valor)
		{
			if(Vacio()) {
				vector[++tamActual]=valor;
				return 0;
			}
			
			if(!ordenado)
				return Introducir(valor);
			
			ComprobarTamanio();
			
			// Reflotamiento
			int hueco= ++tamActual;
			while(valor.CompareTo(vector[hueco/2])<0) {
				vector[hueco]=vector[hueco/2];
				hueco/=2;
				if(vector[hueco/2]==null)
					break;
			}
			
			vector[hueco]=valor;
			
			return 0;
		}
		
		public T EliminarMinimo ()
		{
			T minimo=Minimo();
			vector[1]=vector[tamActual--];
			Hundir(1);
			
			return minimo;
		}
		
	}
}