
namespace ilovs {

    internal class Program {


        private static void Main(string[] args) {

            Synctor.ManualSync("sync/origin/source.json", "sync/target/target.json");
        }
    }
}