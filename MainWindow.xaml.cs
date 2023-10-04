using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema2_CalculadoraBasica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtener operandos y operador
                double operand1 = double.Parse(textBoxOperand1.Text);
                double operand2 = double.Parse(textBoxOperand2.Text);
                string selectedOperator = (comboBoxOperator.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Realizar la operación
                double result = 0;
                switch (selectedOperator)
                {
                    case "+":
                        result = operand1 + operand2;
                        break;
                    case "-":
                        result = operand1 - operand2;
                        break;
                    case "*":
                        result = operand1 * operand2;
                        break;
                    case "/":
                        if (operand2 != 0)
                        {
                            result = operand1 / operand2;
                        }
                        else
                        {
                            MessageBox.Show("No se puede dividir por cero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        break;
                }

                // Mostrar el resultado
                resultTextBox.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa números válidos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Limpiar todos los campos
            textBoxOperand1.Clear();
            textBoxOperand2.Clear();
            comboBoxOperator.SelectedIndex = 0;
            resultTextBox.Clear();
        }
    }
}
