namespace Interpretor.Model {
    using Utils;

    interface Expression {
        int evaluate(ISymbolTable<string, int> st);

        string ToString();
    }
}
