namespace Interpretor.Model {
    interface Statement {
        PrgState execute(PrgState p);
        string ToString();
    }
}
