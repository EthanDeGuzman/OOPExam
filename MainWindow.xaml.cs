using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OOPExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    /*
     ========================================================
     GITHUB LINK: https://github.com/EthanDeguzman/OOPExam
     ========================================================
     */

    public partial class MainWindow : Window
    {
        ObservableCollection<Account> Accounts = new ObservableCollection<Account>();
        ObservableCollection<Account> filteredAccounts = new ObservableCollection<Account>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            CurrentAccount ca1 = new CurrentAccount() { FirstName = "John", LastName = "Smith", Balance = 1500, AccountNumber = rnd.Next(1,500000)};
            SavingsAccount sa1 = new SavingsAccount() { FirstName = "Linda", LastName = "Murphy", Balance = 5500, AccountNumber = rnd.Next(1, 500000) };

            Accounts.Add(ca1);
            Accounts.Add(sa1);

            lstAccounts.ItemsSource = Accounts;
        }

        private void lstAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account selectedAccount = lstAccounts.SelectedItem as Account;

            if (selectedAccount != null)
            {
                tbxFirstName.Text = selectedAccount.FirstName;
                tbxLastName.Text = selectedAccount.LastName;
                tbxBalance.Text = selectedAccount.Balance.ToString();

                if (selectedAccount is CurrentAccount)
                {
                    CurrentAccount selectedCurrent = selectedAccount as CurrentAccount;
                    tbxAccountType.Text = "Current Account";
                    tbxInterest.Text = selectedCurrent.CalculateInterest().ToString();
                    tbxInterestDate.Text = selectedCurrent.InterestDate;
                }
                else if (selectedAccount is SavingsAccount)
                {
                    SavingsAccount selectedSavings = selectedAccount as SavingsAccount;
                    tbxAccountType.Text = "Savings Account";
                    tbxInterest.Text = selectedSavings.CalculateInterest().ToString();
                    tbxInterestDate.Text = selectedSavings.InterestDate;
                }
            }
        }
    }
}
