using System.Collections.Generic;

namespace Interpretor.Utils {
    interface IOutput<E> {
        void add(E elem);
        int size();
        IEnumerable<E> getAll();
        string ToString();
    }
}
