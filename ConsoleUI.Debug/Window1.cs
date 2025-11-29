using ConsoleUI.Console;
using ConsoleUI.UI;

namespace ConsoleUI.Debug;

public class Window1 : ConsoleWindow
{
    Label label1 = new Label();
    Label label2 = new Label();
    TextBox textBox1 = new TextBox();
    public Window1()
    {
        InitializeComponent();
        RegisterElement(label1);
        RegisterElement(label2);
        RegisterElement(textBox1);
        
        
        SelectedElement = textBox1;
    }

    public void InitializeComponent()
    {
        label1.LocationX = 10;
        label1.LocationY = 10;

        label1.SizeX = 10;
        label1.SizeY = 10;
        
        label1.Text = "testText";

        label2.LocationX = 5;
        label2.LocationY = 5;
        
        label2.SizeX = 10;
        label2.SizeY = 10;
        label2.Text = "testText2";

        textBox1.LocationX = 5;
        textBox1.LocationY = 0;
        textBox1.SizeX = 10;
        textBox1.SizeY = 10;
        textBox1.Text = "test";

        label1.LeftElement = label2;
        label2.RightElement = label1;
        label2.TopElement = textBox1;
        textBox1.BottomElement = label2;



    }
}