using System.IO;

namespace Interpretor.Model {
    using Utils;

    class CloseFileStmt : Statement {
        string fileId;

        public CloseFileStmt(string fileId) {
            this.fileId = fileId;
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
                throw new IException("no such variable " + this.fileId);
            }
            
            try {
                fs.Close();
            } catch (IOException) {
                throw new IException("failed to close file");
            }

            p.getFileTable().remove(e);
            return p;
        }

        public override string ToString() {
            return " " + this.fileId + " CLOSED";
        }
    }
}
