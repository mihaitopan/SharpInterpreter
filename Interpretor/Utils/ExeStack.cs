using System.Collections.Generic;
using System.Text;

namespace Interpretor.Utils {
    class ExeStack<E> : IExeStack<E> {
        Stack<E> stack;

        public ExeStack() {
            this.stack = new Stack<E>();
        }

        public void push(E elem) {
            this.stack.Push(elem);
        }

        public E top() {
            return this.stack.Peek();
        }

        public E pop() {
            return this.stack.Pop();
        }

        public bool isEmpty() {
            return this.stack.Count == 0;
        }

        public IEnumerable<E> getAll() {
            return this.stack;
        }

        public override string ToString() {
            StringBuilder s = new StringBuilder();
            foreach (var item in this.stack) {
                s.Append(item);
            }

            return "ExeStack\n\t" + s.ToString() + "\n";
        }
    }
}
