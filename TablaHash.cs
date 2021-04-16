using System;

namespace Tabla_Hash
{
	public class TablaHash <TKey,TValue> where TKey : IEquatable <TKey>
	{
		NodoHash<TKey,TValue>[] buckets;
		int tamanyo;
		int cuenta;

		public int Cuenta
		{ get { return cuenta; } }

		public TablaHash (int tamanyo)
		{
			buckets=new NodoHash<TKey, TValue>[tamanyo];
			this.tamanyo=tamanyo;
			cuenta=0;
		}

		public TablaHash () : this(11) {}

		public TValue this[TKey key]
		{
			get{ return Buscar(key);}
			set{ Insertar(key, value);}
		}

		public bool Vacia()
		{
			return (cuenta == 0);
		}

		public void Limpiar()
		{
			for(int i=0; i<tamanyo; i++)
				buckets[i]=null;

			cuenta=0;
			GC.Collect ();
			GC.WaitForPendingFinalizers ();
		}

		public int Insertar (TKey key, TValue value)
		{
			int i = Math.Abs (key.GetHashCode () % tamanyo);
			NodoHash<TKey,TValue> nodo = new NodoHash<TKey, TValue>(key, value);

			if ((i < 0) || (i >= tamanyo))
				throw new Exception("Indice fuera de rango");

			if (buckets [i] == null) {
				buckets [i] = nodo;
				nodo.Siguiente = null;
			} else {
				nodo.Siguiente = buckets[i];
				buckets[i] = nodo;
			}

			cuenta++;

			return 0;
		}

		public TValue Buscar (TKey key)
		{
			int i = Math.Abs (key.GetHashCode () % tamanyo);

			if ((i < 0) || (i >= tamanyo))
				throw new Exception("Indice fuera de rango");

			if (buckets[i] == null)
				return default(TValue);

			return Explorar(i,key);
		}

		private TValue Explorar (int i, TKey key)
		{
			NodoHash<TKey,TValue> pivote=buckets[i];

			while (pivote != null)
				if (!pivote.Activo)
					pivote=pivote.Siguiente;
				else
					if (pivote.Key.Equals(key))
						return pivote.Value;
					else
						pivote=pivote.Siguiente;

			return default(TValue);
		}

		public TValue Eliminar (TKey key)
		{
			int i = Math.Abs (key.GetHashCode () % tamanyo);

			if ((i < 0) || (i >= tamanyo))
				throw new Exception("Indice fuera de rango");

			NodoHash<TKey,TValue> pivote = buckets [i];

			while (pivote != null)
				if (!pivote.Activo)
					pivote = pivote.Siguiente;
				else
					if (pivote.Key.Equals(key)) {
						pivote.Activo = false;
						cuenta--;
						return pivote.Value;
					}
					else
						pivote=pivote.Siguiente;

			return default(TValue);
		}
	}
}

