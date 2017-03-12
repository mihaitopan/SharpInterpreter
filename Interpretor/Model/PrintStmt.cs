namespace Interpretor.Model {
    using Utils;

    class PrintStmt : Statement {
        Expression expr;

        public PrintStmt(Expression expr) { this.expr = expr; }

        public PrgState execute(PrgState p) {
            IOutput<int> o = p.getOutput();
            ISymbolTable<string, int> t = p.getSymbolTable();
            int resExpr = this.expr.evaluate(t);
            o.add(resExpr);
            
            return p;
        }

        public override string ToString() {
            return " " + this.expr + " ";
        }
    }
}
