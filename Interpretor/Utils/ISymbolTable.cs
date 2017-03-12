using System.Collections.Generic;

namespace Interpretor.Utils {
    interface ISymbolTable<E, F> {
        void add(E key, F value);
        bool contains(E key);
        F getValue(E key);
        void setValue(E key, F value);
        int size();
        Dictionary<E, F>.Enumerator getAll();
        Dictionary<E, F> getMap();
        string ToString();
    }
}
