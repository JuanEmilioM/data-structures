using System;

namespace Monticulo_Binario
{
	public partial class MonticuloBinario <T>
	{
		private void GetVector (int tamanio)
		{
			vector=new T[tamanio];
		}
		
		private void ComprobarTamanio ()
		{
			if(tamActual >= vector.Length) {
				T[] auxVector=vector;
				GetVector(tamActual*2);
				for(int i=0; i<auxVector.Length; i++)
					vector[i]=auxVector[i];
			}
		}
		
		private void Hundir (int hueco)
		{
			int hijo;
			T temp=vector[hueco];
			
			for(; hueco*2 <= tamActual; hueco=hijo) {
				hijo=hueco*2;
				if((hijo != tamActual) && (vector[hijo+1].CompareTo(vector[hijo]) < 0))
					hijo++;
				
				if(vector[hijo].CompareTo(temp) < 0)
					vector[hueco]=vector[hijo];
				else
					break;
			}
				
			vector[hueco]=temp;
		}
		
		private void ArreglarMonticulo ()
		{
			for(int i=tamActual/2; i>0; i--)
				Hundir(i);
			ordenado=true;
		}
	}
}
