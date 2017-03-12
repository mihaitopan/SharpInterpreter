using System.Collections.Generic;

namespace Interpretor.Utils {
    interface IFileTable<E, F> {
        void add(E key, F value);
        void remove(E key);
        bool contains(E key);
        F getValue(E key);
        void setValue(E key, F value);
        int size();
        Dictionary<E, F>.Enumerator getAll();
        Dictionary<E, F> getMap();
        string ToString();
    }
}
