using System;
using System.Windows;

namespace Вес_и_рост
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtHeight.Text, out double height) && double.TryParse(txtWeight.Text, out double weight))
            {
                if (height >= 130 && height <= 220 && weight >= 40 && weight <= 170)
                {
                    double normalWeight;
                    if (rbMale.IsChecked == true)
                        normalWeight = height - 100 + (height - 100) * 0.13;
                    else if (rbFemale.IsChecked == true)
                        normalWeight = height - 100 - (height - 100) * 0.10;
                    else
                    {
                        MessageBox.Show("Пожалуйста, выберите пол.");
                        return;
                    }

                    if (weight < normalWeight - 3)
                        txtResult.Text = "Ниже Нормы";
                    else if (weight > normalWeight + 3)
                        txtResult.Text = "Выше Нормы";
                    else
                        txtResult.Text = "Норма";
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректные значения роста (130-220 см) и веса (40-170 кг).");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите числовые значения для роста и веса.");
            }
        }
    }
}
