namespace Interpretor.Model {
    using Utils;

    class VarExpr : Expression {
        string name;

        public VarExpr(string name) {
            this.name = name;
        }

        public int evaluate(ISymbolTable<string, int> s) {
            if (s.contains(this.name)) {
                return s.getValue(this.name);
            } else {
                throw new IException("no such variable " + this.name);
            }
        }

        public override string ToString() {
            return this.name;
        }
    }
}
