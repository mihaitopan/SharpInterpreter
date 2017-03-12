using System.Text;
using System.IO;

namespace Interpretor.Model {
    using Utils;

    class PrgState {
        Statement initialProg;
        IExeStack<Statement> exeStack;
        ISymbolTable<string, int> symTable;
	    IFileTable<int, FileStream> fileTable;
        IOutput<int> output;

	    public PrgState(Statement ip,
					    IExeStack<Statement> es, 
					    ISymbolTable<string, int> st,
                        IFileTable<int, FileStream> ft,
                        IOutput<int> o) {
		    this.initialProg = ip;
		    this.exeStack = es; this.exeStack.push(ip);
		    this.symTable = st;
            this.fileTable = ft;
		    this.output = o;
	    }

	    public bool isNotCompleted() {
		    return !this.exeStack.isEmpty();
	    }

        public Statement Statement { get { return this.initialProg; } set { this.initialProg = value; } }

        public IExeStack<Statement> ExeStack { get { return this.exeStack; } set { this.exeStack = value; } }
	
	    public ISymbolTable<string, int> getSymbolTable() {
		    return this.symTable;
        }
        public void setSymbolTable(ISymbolTable<string, int> st) {
		    this.symTable = st;
        }

	    public IFileTable<int, FileStream> getFileTable() {
		    return this.fileTable;
	    }
	    public void setFileTable(IFileTable<int, FileStream> ft) {
		    this.fileTable = ft;
	    }
	
	    public IOutput<int> getOutput() {
		    return this.output;
        }
        public void setOutput(IOutput<int> o) {
		    this.output = o;
        }

	    public override string ToString() {
		    StringBuilder s = new StringBuilder();
		    s.Append(this.exeStack);
		    s.Append(this.symTable);
		    s.Append(this.fileTable);
		    s.Append(this.output);
		    return s.ToString();
	    }
    }
}
