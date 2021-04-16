using System;

namespace Tabla_Hash
{
	public class NodoHash <TKey,TValue>
	{
		struct Item
		{
			public TKey key;
			public TValue value;
		}

		Item item;
		bool activo;
		NodoHash<TKey,TValue> siguiente;

		public NodoHash (TKey key, TValue value)
		{
			item.key=key;
			item.value=value;
			activo=true;
		}

		public NodoHash<TKey,TValue> Siguiente
		{
			get{ return siguiente;}
			set{ siguiente = value;}
		}

		public TKey Key
		{
			get{ return item.key;}
		}

		public TValue Value
		{
			get{ return item.value;}
		}

		public bool Activo
		{
			get{ return activo;}
			set{ activo = value;}
		}
	}
}

