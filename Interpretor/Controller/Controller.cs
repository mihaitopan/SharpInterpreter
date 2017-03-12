using System;

namespace Interpretor.Controller {
    using Utils;
    using Model;
    using Repository;

    class Controller {
        IRepository repo;

        public Controller(IRepository repo) {
            this.repo = repo;
        }

        public PrgState oneStep(PrgState state) {
            IExeStack<Statement> exeStack = state.ExeStack;
            if (exeStack.isEmpty()) {
                throw new IException("exe stack is empty");
            }
            Statement stmt = exeStack.pop();
            Console.WriteLine(stmt);
            return stmt.execute(state);
        }

        public void executeAll() {
            try {
                repo.clearFile();
            } catch (IException e) {
                throw new IException(e.Message);
            }

            PrgState ps = this.repo.getCurrPrgState();

            try {
                while (true) {
                    Console.WriteLine(ps);
                    oneStep(ps);
                    this.repo.logPrgState(ps);
                }
            } catch (IException e) {
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
