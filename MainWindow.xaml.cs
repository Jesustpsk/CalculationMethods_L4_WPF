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

namespace CalculationMethods_L4_WPF
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
        
        private static int size = 0;
        private double[,]? initA()
        {
             if (TB_b5.Text != "")
             {
                 double[,] A =
                 {
                     {Convert.ToDouble(TB_A1_1.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_1.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_1.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_1.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A5_1.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_2.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_2.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_2.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_2.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A5_2.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_3.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_3.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_3.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_3.Text.Replace('.', ',')), 
                         Convert.ToDouble(TB_A5_3.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_4.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_4.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_4.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_4.Text.Replace('.', ',')), 
                         Convert.ToDouble(TB_A5_4.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_5.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_5.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_5.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_5.Text.Replace('.', ',')), 
                         Convert.ToDouble(TB_A5_5.Text.Replace('.', ','))}
                 };
                 size = 5;
                 return A;
             }
             if (TB_b4.Text != "")
             {
                 double[,] A =
                 {
                     {Convert.ToDouble(TB_A1_1.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_1.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_1.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_1.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_2.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_2.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_2.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_2.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_3.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_3.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_3.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_3.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_4.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_4.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_4.Text.Replace('.', ',')), Convert.ToDouble(TB_A4_4.Text.Replace('.', ','))}
                 };
                 size = 4;
                 return A;
             }
             if (TB_b1.Text != "" && TB_b2.Text != "" && TB_b3.Text != "")
             {
                 double[,] A =
                 {
                     {Convert.ToDouble(TB_A1_1.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_1.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_1.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_2.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_2.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_2.Text.Replace('.', ','))},
                     {Convert.ToDouble(TB_A1_3.Text.Replace('.', ',')), Convert.ToDouble(TB_A2_3.Text.Replace('.', ',')),
                         Convert.ToDouble(TB_A3_3.Text.Replace('.', ','))}
                 };
                 size = 3;
                 return A;
             }
             MessageBox.Show("matrix A is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
             return null;
        }

        private double[]? initb()
        {
            if (TB_b5.Text != "")
            {
                double[] b =
                {
                    Convert.ToDouble(TB_b1.Text.Replace('.', ',')), Convert.ToDouble(TB_b2.Text.Replace('.', ',')),
                    Convert.ToDouble(TB_b3.Text.Replace('.', ',')), Convert.ToDouble(TB_b4.Text.Replace('.', ',')),
                    Convert.ToDouble(TB_b5.Text.Replace('.', ','))
                };
                return b;
            }
            if (TB_b4.Text != "")
            {
                double[] b =
                {
                    Convert.ToDouble(TB_b1.Text.Replace('.', ',')), Convert.ToDouble(TB_b2.Text.Replace('.', ',')),
                    Convert.ToDouble(TB_b3.Text.Replace('.', ',')), Convert.ToDouble(TB_b4.Text.Replace('.', ','))
                };
                return b;
            }
            if (TB_b1.Text != "" && TB_b2.Text != "" && TB_b3.Text != "")
            {
                double[] b =
                {
                    Convert.ToDouble(TB_b1.Text.Replace('.', ',')), Convert.ToDouble(TB_b2.Text.Replace('.', ',')),
                    Convert.ToDouble(TB_b3.Text.Replace('.', ','))
                };
                return b;
            }
            MessageBox.Show("matrix b is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            TbOutput.Text = "";
            var A = initA();
            var b = initb();
            if (size == 0) return;
            TbOutput.Text = KhaletskyMethod.Khaletsky(A, b, size);
        }
    }
}