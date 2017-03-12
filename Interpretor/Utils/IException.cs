using System;

namespace Interpretor.Utils {
    class IException : Exception {
        public IException(string message) : base(message) { }
    }
}
