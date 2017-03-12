namespace Interpretor.Model {
    using Utils;

    class CompStmt : Statement {
        Statement first;
        Statement second;

        public CompStmt(Statement first, Statement second) {
            this.first = first;
            this.second = second;
        }

        public PrgState execute(PrgState p) {
            IExeStack<Statement> exe = p.ExeStack;
            exe.push(this.second);
            exe.push(this.first);
            return p;
        }

        public override string ToString() {
            return "{" + this.first + ";" + this.second + "}";
        }
    }
}
