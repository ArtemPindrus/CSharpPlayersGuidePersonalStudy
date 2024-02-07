using The_Feud.IField;
using The_Feud.McDroid;
using McDroidPig = The_Feud.McDroid.Pig;
using IFieldPig = The_Feud.IField.Pig;

namespace The_Feud
{
    internal class Program {
        static void Main() {
            Sheep sheep = new();
            IFieldPig IFieldsPig = new();

            Cow cow = new();
            McDroidPig McDroidsPig = new();
        }
    }
}