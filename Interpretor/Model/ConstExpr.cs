namespace Interpretor.Model {
    using Utils;

    class ConstExpr : Expression {
        int value;

        public ConstExpr(int value) {
            this.value = value;
        }

        public int evaluate(ISymbolTable<string, int> s) {
            return this.value;
        }

        public override string ToString() {
            return "" + this.value;
        }
    }
}
