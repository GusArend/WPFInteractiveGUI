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

namespace WPFInteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void EnableElements()
        {
            tbFirstName.IsEnabled = true;
            tbLastName.IsEnabled = true;
            tbAge.IsEnabled = true;
            tbPhoneNo.IsEnabled = true;
            bDeletePerson.IsEnabled = true;
            if (controller.PersonIndex > 0)
            {
                bUp.IsEnabled = true;
            } else
            {
                bUp.IsEnabled = false;
            }

            if (controller.PersonIndex < controller.PersonCount - 1)
            {
                bDown.IsEnabled = true;
            } else
            {
                bDown.IsEnabled= false;
            }
        }
        private void setData()
        {
            EnableElements();
            Person currentPerson = controller.CurrentPerson;
            tbFirstName.Text = currentPerson.FirstName;
            tbLastName.Text = currentPerson.LastName;
            tbAge.Text = currentPerson.Age.ToString();
            tbPhoneNo.Text = currentPerson.TelephoneNo;
            lPersonCount.Content = $"Person Count {controller.PersonCount}";
            lIndex.Content = $"Index: {controller.PersonIndex}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            controller.AddPerson();
            setData();
            
        }

        private void bDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();
            controller.PrevPerson();
            setData();
        }

        private void bUp_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            setData();
        }

        private void bDown_Click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            setData();
        }

        private void tbFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Person currentPerson = controller.CurrentPerson ;
            currentPerson.FirstName = tbFirstName.Text;
        }

        private void tbLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Person currentPerson = controller.CurrentPerson;
            currentPerson.LastName = tbLastName.Text;
        }

        private void tbAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            Person currentPerson = controller.CurrentPerson;
            try
            {
                currentPerson.Age = int.Parse(tbAge.Text);
            } catch
            {
                currentPerson.Age = 0;
            }
            
        }

        private void tbPhoneNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Person currentPerson = controller.CurrentPerson;
            currentPerson.TelephoneNo = tbPhoneNo.Text;
        }

        
    }
}
