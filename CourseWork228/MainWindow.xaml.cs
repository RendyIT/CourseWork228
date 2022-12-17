using CourseWorkProgram.Classes;
using FireSharp;
using System;
using System.ComponentModel;
using System.Windows;
using FireSharp.Response;
using Newtonsoft.Json;
using CourseWork228;

namespace CourseWorkProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    
    {
        FireBase Base = new FireBase();//создаёт новую БД
        string PATH;
        private BindingList<VideoCard> dgList;//таблица хранящая в себе переменные для видеокарт
        private BindingList<CPU> bdList;//таблица хранящая в себе переменные для процессоров
        private BindingList<VideoCard> pupaList;//пустая таблица для реализации обновления списков

        public MainWindow()
        {
            InitializeComponent();
            Access();//доступ к БД FireBase
            ListLoad();//загрузка листов 
        }
        void Access()
        {
            Base.client = new FirebaseClient(Base.config);//Доступ к конфигам БД
        }
        void ListLoad()
        {
            FirebaseResponse response = Base.client.Get(@"VideoCards");//получение с БД информации
            dgList = JsonConvert.DeserializeObject<BindingList<VideoCard>>(response.Body);
            response = Base.client.Get(@"CPU");
            bdList = JsonConvert.DeserializeObject<BindingList<CPU>>(response.Body);
        }
        private void AD_SelectionChanged(object sender, RoutedEventArgs e)
        {
            switch (AD.SelectedIndex)
            {
                case 0:
                    List.ItemsSource = pupaList;
                    List.ItemsSource = dgList;
                    break;
                case 1:
                    List.ItemsSource = pupaList;
                    List.ItemsSource = bdList;
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)//кнопка добавления перемещает на новую форму
        {
            AddElements addelements = new AddElements();
            addelements.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)//кнопка обновления списков
        {
            ListLoad();
        }
        private void Info_Click(object sender,RoutedEventArgs e)//кнопка инфо - информация о разработчиках
        {
            Info info = new Info();
            info.Show();
        }
    }
    }
