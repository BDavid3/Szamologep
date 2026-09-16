using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using NCalc;

namespace Szamologep
{
    public partial class MainWindow : Window
    {
        private string rawEquation = String.Empty;
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
            Button pressedButton = (Button)sender;
            string textOfButton = pressedButton.Content.ToString();

            if (textOfButton != "C" && textOfButton != "=")
            {
                rawEquation += textOfButton;
                txtblock_kijelzo.Text = rawEquation;
            }

            else if (textOfButton == "=")
            {
                char lastChar = rawEquation[rawEquation.Length - 1];
                bool isLastCharOperator = "+-*/".Contains(lastChar);

                if (rawEquation.Length > 0 && !isLastCharOperator)
                {
                    NCalc.Expression expression = new NCalc.Expression(rawEquation);
                    int output = Convert.ToInt32(expression.Evaluate());
                    txtblock_kijelzo.Text = output.ToString();
                    rawEquation = output.ToString();
                }
            }
            else
            {
                rawEquation = String.Empty;
                txtblock_kijelzo.Text = rawEquation;
            }
        }
      
    }

}