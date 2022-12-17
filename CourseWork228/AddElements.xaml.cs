using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using CourseWorkProgram.Classes;
using FireSharp;

namespace CourseWorkProgram
{
    /// <summary>
    /// Логика взаимодействия для AddElements.xaml
    /// </summary>
    public partial class AddElements : Window
    {
        string PATH;
        FireBase Base = new FireBase();
        public AddElements()
        {
            InitializeComponent();
            Base.client = new FirebaseClient(Base.config);//Доступ к конфигам БД
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)//Выбор листов
        {
            RadioButton pressed = (RadioButton)sender;
            switch (pressed.Name)
            {
                case "VideoCards":
                    PATH = "VideoCards";
                    break;
                case "CPU":
                    PATH = "CPU";
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Кнопка добавить 
        {
            if(PATH == "VideoCards")
            {
                VideoCard m = new VideoCard { Num1 = tb1.Text, Name1 = tb2.Text, Memory1 = tb3.Text, Freq = tb4.Text, Cost = tb5.Text };//назначение TextBox'ов и им переменным
                var setter = Base.client.Set($"{PATH}/"+Convert.ToInt32(tb6.Text),m);//нумерация
            }
            else if(PATH == "CPU")
            {
                CPU m = new CPU { Num1 = tb1.Text, Name1 = tb2.Text, Freq = tb3.Text, TypeMemory = tb4.Text, Cost = tb5.Text };
                var setter = Base.client.Set($"{PATH}/" + Convert.ToInt32(tb6.Text),m);
            }
        }
    }
 }
