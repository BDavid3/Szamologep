using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szamologep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GombokElhelyezese();
        }

        private void GombokElhelyezese()
        {
            for (int i = 0; i < 4; i++) {
                grid_btn.RowDefinitions.Add(new RowDefinition());
                grid_btn.ColumnDefinitions.Add(new ColumnDefinition());
            }

            string[,] feliratok ={
                {"7","8","9","/"},
                {"4","5","6","*"},
                {"1","2","3","-"},
                {"C","0","=","+"}
            };

            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    string label = feliratok[i, j];
                    Button btn = new Button
                    {
                        Content = label,
                        FontSize = 20, 
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(3)
                    };

                    if (char.IsDigit(label[0]))
                    {
                        btn.Background = Brushes.WhiteSmoke;
                    }
                    else if (label == "C")
                    {
                        btn.Background = Brushes.IndianRed;
                        btn.Foreground = Brushes.White;
                    }
                    else
                    {
                        btn.Background = Brushes.DodgerBlue;
                        btn.Foreground = Brushes.White;
                    }

                    btn.Click += Button_Click;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);

                    grid_btn.Children.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string felirat = clickedButton.Content.ToString();
            txtblock_kijelzo.Text += felirat;
        }        
    }
}