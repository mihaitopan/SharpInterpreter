using System.Collections.Generic;

namespace Interpretor.Utils {
    interface IExeStack<E> {
        void push(E elem);
        E top();
        E pop();
        bool isEmpty();
        IEnumerable<E> getAll();
        string ToString();
    }
}
