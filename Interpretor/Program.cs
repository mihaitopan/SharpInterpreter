using System.IO;

namespace Interpretor.Program {
    using View;
    using Repository;
    using Controller;
    using Model;
    using Utils;

    class Program {
        static void Main(string[] args) {
            // Example 1
            Statement stmt1 = new CompStmt(
                                new OpenFileStmt("1stFile.txt", "1stFile"),
                                new CompStmt(new PrintStmt(new ArithmeticExpr('-', new ConstExpr(10), new ConstExpr(5))),
                                        new CompStmt(new AssignStmt(new ConstExpr(11), "b"),
                                        new CompStmt(new IfStmt(new ConstExpr(0),
                                                new PrintStmt(new ConstExpr(1)),
                                                new PrintStmt(new ConstExpr(2))),
                                                new AssignStmt(new ConstExpr(10), "x")))));
            PrgState prg1 = new PrgState(stmt1,
                                new ExeStack<Statement>(),
                                new SymbolTable<string, int>(),
                                new FileTable<int, FileStream>(),
                                new Output<int>());
            IRepository repo1 = new Repository("logFile.txt", prg1);
            Controller ctrl1 = new Controller(repo1);

            // Example 2
            Statement stmt2 = new AssignStmt(new ArithmeticExpr('/', new ConstExpr(3), new ConstExpr(0)), "var");
            PrgState prg2 = new PrgState(stmt2,
                                new ExeStack<Statement>(),
                                new SymbolTable<string, int>(),
                                new FileTable<int, FileStream>(),
                                new Output<int>());
            IRepository repo2 = new Repository("logFile.txt", prg2);
            Controller ctrl2 = new Controller(repo2);

            // Example 3
            Statement stmt3 = new CompStmt(
                                new OpenFileStmt("2ndFile.txt", "2ndFile"),
                                new CompStmt(new ReadFileStmt("2ndFile.txt", "h1"),
                                        new CompStmt(new ReadFileStmt("2ndFile.txt", "h2"), new CloseFileStmt("2ndFile.txt"))));
            PrgState prg3 = new PrgState(stmt3,
                                new ExeStack<Statement>(),
                                new SymbolTable<string, int>(),
                                new FileTable<int, FileStream>(),
                                new Output<int>());
            IRepository repo3 = new Repository("logFile.txt", prg3);
            Controller ctrl3 = new Controller(repo3);

            // Example 4
            Statement stmt4 = new CompStmt(
                                new OpenFileStmt("2ndFile.txt", "2ndFile"),
                                new CompStmt(new CompStmt(new ReadFileStmt("2ndFile.txt", "h1"),
                                        new CompStmt(new ReadFileStmt("2ndFile.txt", "h2"), new CloseFileStmt("2ndFile.txt"))),
                                new CompStmt(new OpenFileStmt("1stFile.txt", "1stFile"),
                                        new CompStmt(new ReadFileStmt("1stFile.txt", "h"), new CloseFileStmt("1stFile.txt")))));
            PrgState prg4 = new PrgState(stmt4,
                                new ExeStack<Statement>(),
                                new SymbolTable<string, int>(),
                                new FileTable<int, FileStream>(),
                                new Output<int>());
            IRepository repo4 = new Repository("logFile.txt", prg4);
            Controller ctrl4 = new Controller(repo4);

            // MENU
            TextMenu menu = new TextMenu();
            menu.addCommand(new ExitCommand("0", "exit"));
            menu.addCommand(new RunExample("1", stmt1.ToString(), ctrl1));
            menu.addCommand(new RunExample("2", stmt2.ToString(), ctrl2));
            menu.addCommand(new RunExample("3", stmt3.ToString(), ctrl3));
            menu.addCommand(new RunExample("4", stmt4.ToString(), ctrl4));
            menu.show();
        }
    }
}
