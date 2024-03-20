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
using Assignment2_wpf.Functions;
using static Assignment2_wpf.MainWindow;

namespace Assignment2_wpf
{
    // 10 features:
    // 1. ListView: yes
    // 2. Slider: yes
    // 3. CheckBox : yes
    // 4. Combo box : yes
    // 5. Image : yes
    // 6. Radio : yes
    // 7. Border : yes
    // 8. ListBox : yes
    // 9. TreeView: yes
    // 10. ScrollViewer : yes

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Result
        {
            public double O { get; set; }
            public double Sin { get; set; }
            public double Log { get; set; }

            public override string ToString()
            {
                return $"O: {O}, Sin: {Sin}, Log: {Log}";
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            minValue.IsEnabled = false;
            maxValue.IsEnabled = false;
        }


        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            minValue.IsEnabled = true;
            maxValue.IsEnabled = true;
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
    
            double min, max, interval;
            int num;
            func function = new func();
            List<Result> resultList = new List<Result>();

            if (!double.TryParse(minValue.Text, out min) ||
                !double.TryParse(maxValue.Text, out max) ||
                !int.TryParse(numValue.Value.ToString(), out num))
            {
                MessageBox.Show("Invalid input");
                return;
            }
            if (min >= max || num <= 0)
            {
                MessageBox.Show("Invalid input: Check minimum, maximum, and number of intervals.");
                return;
            }

            interval = (max - min) / num;
            while (min < max + interval)
            {
                Result resultItem = new Result
                {
                    O = Math.Round(min, 2),
                    Sin = Math.Round(SinComponent.calculateSin(min), 2),
                    Log = Math.Round(function.fun(min), 2)
                };
                resultList.Add(resultItem);
                min += interval;
            }

            listView.ItemsSource = resultList;
            listBox1.Items.Clear();
            treeView1.Items.Clear();
            textBlock1.Text = "";

            string textBlockResult = "";
            foreach (var i in resultList)
            {
                listBox1.Items.Add(i);
                TreeViewItem rootItem = new TreeViewItem { Header = $"O: {i.O}" };
                rootItem.Items.Add(new TreeViewItem { Header = $"Sin: {i.Sin}" });
                rootItem.Items.Add(new TreeViewItem { Header = $"Log: {i.Log}" });
                treeView1.Items.Add(rootItem);
                textBlockResult += i.ToString() + "\n";
            }
            textBlock1.Text += textBlockResult + "\n";
        }
        private void rbMode_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;

            if (selectedRadioButton == rbLightMode)
            {
                mainGrid.Background = Brushes.LightGray;
            }
            else if (selectedRadioButton == rbDarkMode)
            {
                mainGrid.Background = Brushes.DarkGray;
            }
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedControl = selectedItem.Content.ToString();
                listView.Visibility = selectedControl == "ListView" ? Visibility.Visible : Visibility.Hidden;
                listBox1.Visibility = selectedControl == "ListBox" ? Visibility.Visible : Visibility.Hidden;
                treeView1.Visibility = selectedControl == "TreeView" ? Visibility.Visible : Visibility.Hidden;
                textGrid.Visibility = selectedControl == "TextBlock" ? Visibility.Visible : Visibility.Hidden;
            }
        }
    }
}
