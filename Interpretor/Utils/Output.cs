using System.Collections.Generic;
using System.Text;

namespace Interpretor.Utils {
    class Output<E> : IOutput<E> {
        List<E> array;

        public Output() {
            this.array = new List<E>();
        }

        public void add(E elem) {
            this.array.Add(elem);
        }

        public int size() {
            return this.array.Count;
        }


        public IEnumerable<E> getAll() {
            return array;
        }
        
        public override string ToString() {
            StringBuilder s = new StringBuilder();
            foreach (var item in this.array) {
                s.Append(item);
            }

            return "Output\n\t" + s.ToString() + "\n";
        }
    }
}
