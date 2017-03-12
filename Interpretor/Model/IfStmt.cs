namespace Interpretor.Model {
    using Utils;

    class IfStmt : Statement {
        Expression expr;
        Statement first;
        Statement second;

        public IfStmt(Expression expr, Statement first, Statement second) {
            this.expr = expr;
            this.first = first;
            this.second = second;
        }

        public PrgState execute(PrgState p) {
            IExeStack<Statement> exe = p.ExeStack;
            ISymbolTable<string, int> t = p.getSymbolTable();
            int resExpr = this.expr.evaluate(t);
            if (resExpr != 0) {
                exe.push(this.first);
            } else {
                exe.push(this.second);
            }

            return p;
        }

        public override string ToString() {
            return " If " + this.expr + " Then " + this.first + " Else " + this.second + " ";
        }
    }
}
