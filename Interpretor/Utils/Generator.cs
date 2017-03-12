namespace Interpretor.Utils {
    class Generator {
        static int fileTableId = 0;

        public static int generateFileTableId() {
            return ++fileTableId;
        }
    }
}
