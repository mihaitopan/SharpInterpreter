using System;
using System.Collections.Generic;

namespace Interpretor.View {
    class TextMenu {
        Dictionary<string, Command> map;

        public TextMenu() {
            this.map = new Dictionary<string, Command>();
        }

        public void addCommand(Command c) {
            this.map.Add(c.getKey(), c);
        }

        private void printMenu() {
            Console.WriteLine("Menu");
            foreach (var item in this.map) {
                string line = item.Value.getKey() + " : " + item.Value.getDescription();
                Console.WriteLine(line);
            }
        }

        public void show() {
            while (true) {
                printMenu();
                Console.WriteLine("Option: ");
                string key = Console.ReadLine();
                Console.WriteLine("");
                Command command;
                this.map.TryGetValue(key, out command);
                if (command == null) {
                    Console.WriteLine("Invalid option");
                    continue;
                }
                command.execute();
            }
        }
    }
}
