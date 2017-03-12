namespace Interpretor.View {
    class ExitCommand : Command {
        public ExitCommand(string key, string desc) : base(key, desc) { }

        public override void execute() {
            System.Environment.Exit(0);
        }
    }
}
