using System;
using System.IO;

namespace Interpretor.Model {
    using Utils;

    class ReadFileStmt : Statement {
        string fileId;
        string name;

        public ReadFileStmt(string fileId, string name) {
            this.fileId = fileId;
            this.name = name;
        }

        public PrgState execute(PrgState p) {
            int e;

            try {
                e = p.getSymbolTable().getValue(this.fileId);
            } catch (IException) {
                throw new IException("no such variable " + this.fileId);
            }

            FileStream fs = p.getFileTable().getValue(e);
            if (fs == null) {
                throw new IException("no such value");
            }

            StreamReader r = new StreamReader(fs);
            try {
                int v = Int32.Parse(r.ReadLine());
                p.getSymbolTable().add(this.name, v);
            } catch (ArgumentNullException) {
                p.getSymbolTable().add(this.name, 0);
            } catch (FormatException) {
                p.getSymbolTable().add(this.name, 0);
            } catch (OverflowException) {
                p.getSymbolTable().add(this.name, 0);
            } catch (IOException) {
                throw new IException("reading error");
            }

            return p;
        }

        public override string ToString() {
            return " " + this.fileId + " READ";
        }
    }
}
