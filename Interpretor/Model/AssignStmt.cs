namespace Interpretor.Model {
    using Utils;

    class AssignStmt : Statement {
	    Expression expr;
	    string var;
	
	    public AssignStmt(Expression expr, string var) {
		    this.expr = expr;
		    this.var = var;
	    }
    
	    public PrgState execute(PrgState p) {
		    ISymbolTable<string, int> t = p.getSymbolTable();
		    int resExpr = this.expr.evaluate(t);
		    if (t.contains(var)) {
			    t.setValue(var, resExpr);
		    } else {
			    t.add(var, resExpr);
		    }
            
		    return p;
	    }

        public override string ToString() {
            return " " + this.var + " = " + this.expr + " ";
	    }
    }
}
