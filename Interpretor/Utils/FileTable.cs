using System.Collections.Generic;
using System.Text;

namespace Interpretor.Utils {
    class FileTable<E, F> : IFileTable<E, F> {
        Dictionary<E, F> map;

        public FileTable() {
            this.map = new Dictionary<E, F>();
        }

        public void add(E key, F value) {
            if (!this.map.ContainsKey(key)) {
                this.map.Add(key, value);
            }
        }

        public void remove(E key) {
            if (!this.map.ContainsKey(key)) {
                this.map.Remove(key);
            }
        }

        public bool contains(E key) {
            return this.map.ContainsKey(key);
        }

        public F getValue(E key) {
            F value;
            this.map.TryGetValue(key, out value);
            if (value == null) {
                throw new IException("no such key");
            }
            return value;
        }

        public void setValue(E key, F value) {
            if (this.map.ContainsKey(key)) {
                this.map[key] = value;
            }
        }

        public int size() {
            return this.map.Count;
        }

        public Dictionary<E, F>.Enumerator getAll() {
            return this.map.GetEnumerator();
        }

        public Dictionary<E, F> getMap() {
            return this.map;
        }
        
        public override string ToString() {
            StringBuilder s = new StringBuilder();
            foreach (var item in this.map) {
                s.Append("\n\t" + item.Key + " : " + item.Value);
            }

            return "File Table" + s.ToString() + "\n";
        }
    }
}
