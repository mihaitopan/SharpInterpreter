namespace Interpretor.Model {
    using Utils;

    class ArithmeticExpr : Expression {
	    char oper;
	    Expression first, second;
	
	    public ArithmeticExpr(char oper, Expression first, Expression second) {
		    this.oper = oper;
		    this.first = first;
		    this.second = second;
	    }
	
	    public int evaluate(ISymbolTable<string, int> s) {
		    int resFirst = this.first.evaluate(s);
		    int resSecond = this.second.evaluate(s);
		
		    switch(this.oper) {
			    case '+':
				    return resFirst + resSecond;
			    case '-':
				    return resFirst - resSecond;
			    case '*':
				    return resFirst * resSecond;
			    case '/':
				    if (0 == resSecond) {
					    throw new IException("you try divide by 0!");
				    }
				    return resFirst / resSecond;
			    default:
				    throw new IException("invalid operator");
		    }
	    }

        public override string ToString() {
            return "" + this.first + " " + this.oper + " " + this.second;
	    }
    }
}
