using ConsoleUI.Console;
using ConsoleUI.UI;

namespace ConsoleUI.Debug;

public class Window1 : ConsoleWindow
{
    Button label1 = new Button(); //Тут создание самих элементов управления
    Button label2 = new Button();
    TextBox textBox1 = new TextBox();
    public Window1() //конструктор окна
    {
        InitializeComponent();
        
        RegisterElement(label1); //регистрация элементов управления на окно
        RegisterElement(label2);
        RegisterElement(textBox1);
        
        
        SelectedElement = textBox1; //указание первого выбранного элемента(так нужно)
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

        label1.LeftElement = label2; //указание навигации, к какому элементу управления переходить на стрелочки относительно выбранного
        label2.RightElement = label1;
        label2.TopElement = textBox1;
        textBox1.BottomElement = label2;

        label1.OnClick += (sender, args) => textBox1.Text = (sender as Button).Name + "asjdaks";
        label2.OnClick += (sender, args) => textBox1.Text = (sender as Button).Name;



    }
}