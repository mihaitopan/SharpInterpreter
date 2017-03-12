using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Interpretor.Repository {
    using Model;
    using Utils;

    class Repository : IRepository {
        List<PrgState> repo;
        string filename;

        public Repository(string filename, PrgState ps) {
            this.repo = new List<PrgState>();
            this.filename = filename;
            this.repo.Add(ps);
        }

        public void addPrgState(PrgState ps) {
            this.repo.Add(ps);
        }

        public PrgState getCurrPrgState() {
            return this.repo[0];
        }
        
        public void logPrgState(PrgState ps) {
            try {
                StreamWriter logFile = File.AppendText(this.filename);

                StringBuilder s = new StringBuilder();
                s.Append(ps.ExeStack);
                s.Append(ps.getSymbolTable());
                s.Append(ps.getFileTable());
                s.Append(ps.getOutput());
                logFile.WriteLine(s.ToString());

                logFile.Close();
            } catch (IOException e) {
                throw new IException(e.Message);
            }
        }

        public void clearFile() {
            try {
                StreamWriter fileOut = new StreamWriter(this.filename);
                fileOut.WriteLine("");
                fileOut.Close();
            } catch (IOException e) {
                throw new IException(e.Message);
            }
        }
    }
}
