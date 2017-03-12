using System.IO;

namespace Interpretor.Model {
    using Utils;

    class OpenFileStmt : Statement {
        string filename;
        string varName;

        public OpenFileStmt(string filename, string varName) {
            this.filename = filename;
            this.varName = varName;
        }

        public PrgState execute(PrgState p) {
            if (isOpen(this.filename, p.getFileTable())) {
                throw new IException("file already open");
            }

            try {
                FileStream fs = new FileStream(this.filename, FileMode.Open, FileAccess.ReadWrite);
                int id = Generator.generateFileTableId();
                p.getFileTable().add(id, fs);
                p.getSymbolTable().add(this.filename, id);
            } catch (IOException) {
                throw new IException("no such file");
            }

            return p;
        }

        bool isOpen(string filename, IFileTable<int, FileStream> ft) {
            foreach (var item in ft.getMap()) {
                int workDirLen = Directory.GetCurrentDirectory().Length + 1; // !!! + 1 because of windows slashes !!!
                string fullPath = item.Value.Name;
                string relativePath = fullPath.Substring(workDirLen, fullPath.Length - workDirLen);
                if (filename.Equals(relativePath)) {
                    return true;
                }
            }
            return false;
        }

        public override string ToString() {
            return " " + this.filename + " OPENED";
        }
    }
}
