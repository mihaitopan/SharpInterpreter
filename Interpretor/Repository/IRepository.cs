namespace Interpretor.Repository {
    using Model;

    interface IRepository {
        void addPrgState(PrgState ps);
        PrgState getCurrPrgState();
        void logPrgState(PrgState ps);
        void clearFile();
    }
}
