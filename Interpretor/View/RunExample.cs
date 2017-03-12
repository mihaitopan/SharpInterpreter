using System;

namespace Interpretor.View {
    using Controller;

    class RunExample : Command {
        Controller ctrl;

        public RunExample(string key, string desc, Controller ctrl) : base(key, desc) {
            this.ctrl = ctrl;
        }

        public override void execute() {
            try {
                this.ctrl.executeAll();
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
