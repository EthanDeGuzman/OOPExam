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

        private void Window_Loaded(object sender, RoutedEventArgs e) // When Window is loaded execute code
        {
            // Create Sample Objects
            Random rnd = new Random(); // Random Number generator
            CurrentAccount ca1 = new CurrentAccount() { FirstName = "John", LastName = "Smith", Balance = 1500, AccountNumber = rnd.Next(1, 500000) };
            CurrentAccount ca2 = new CurrentAccount() { FirstName = "Barbara", LastName = "Wilson", Balance = 8300, AccountNumber = rnd.Next(1, 500000) };
            SavingsAccount sa1 = new SavingsAccount() { FirstName = "Linda", LastName = "Murphy", Balance = 5500, AccountNumber = rnd.Next(1, 500000) };
            SavingsAccount sa2 = new SavingsAccount() { FirstName = "Jake", LastName = "Walter", Balance = 4800, AccountNumber = rnd.Next(1, 500000) };

            Accounts.Add(ca1);
            Accounts.Add(ca2);
            Accounts.Add(sa1);
            Accounts.Add(sa2);

            SortListBox(); // Sort Method and prints out listbox
        }

        private void lstAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e) // Checks for any selection in the list box
        {
            Account selectedAccount = lstAccounts.SelectedItem as Account;

            //Make sure the selected account is not null to avoid errors
            if (selectedAccount != null)
            {
                tbxFirstName.Text = selectedAccount.FirstName;
                tbxLastName.Text = selectedAccount.LastName;
                tbxBalance.Text = selectedAccount.Balance.ToString();

                //Check if selected is a current account or a savings account
                if (selectedAccount is CurrentAccount)
                {
                    CurrentAccount selectedCurrent = selectedAccount as CurrentAccount;
                    tbxAccountType.Text = "Current Account";
                }
                else if (selectedAccount is SavingsAccount)
                {
                    SavingsAccount selectedSavings = selectedAccount as SavingsAccount;
                    tbxAccountType.Text = "Savings Account";
                }

                tbxInterest.Text = null;
            }
        }
        private void SortListBox() // Sort Method
        {
            // Prints out list box to the window
            if (chkCurrentAccount.IsChecked == true || chkSavingsAccount.IsChecked == true)
            { 
                lstAccounts.ItemsSource = null;
                filteredAccounts = new ObservableCollection<Account>(filteredAccounts.OrderBy(x => x.AccountNumber));
                lstAccounts.ItemsSource = filteredAccounts;
            }
            else
            {
                lstAccounts.ItemsSource = null;
                Accounts = new ObservableCollection<Account>(Accounts.OrderBy(x => x.AccountNumber));
                lstAccounts.ItemsSource = Accounts;
            }
            
        }

        private void Filter() //Filter Method
        {
            // Filters the Listbox using the checkbox
            filteredAccounts.Clear();
            lstAccounts.ItemsSource = null;

            if (chkCurrentAccount.IsChecked == true && chkSavingsAccount.IsChecked == true)
            {
                foreach (Account accounts in Accounts)
                {
                    filteredAccounts.Add(accounts);
                }
                lstAccounts.ItemsSource = filteredAccounts;
            }
            else if (chkCurrentAccount.IsChecked == true)
            {
                foreach (Account currentAccount in Accounts)
                {
                    if (currentAccount is CurrentAccount)
                    {
                        filteredAccounts.Add(currentAccount);
                    }
                }
                lstAccounts.ItemsSource = filteredAccounts;
            }
            else
            {
                foreach (Account savingsAccount in Accounts)
                {
                    if (savingsAccount is SavingsAccount)
                    {
                        filteredAccounts.Add(savingsAccount);
                    }
                }
                lstAccounts.ItemsSource = filteredAccounts;
            }

        }

        private void chkCurrentAccount_Click(object sender, RoutedEventArgs e) 
        {
            // When a checkbox is clicked filter list and sort it
            Filter();
            SortListBox();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e) // Deposit Method
        {
            Account selectedAccount = lstAccounts.SelectedItem as Account;
            if (selectedAccount != null)
            {
                double amount = double.Parse(tbxTransactionAmount.Text);
                selectedAccount.Balance += amount;
                tbxBalance.Text = selectedAccount.Balance.ToString();
            }
            tbxTransactionAmount.Text = "";
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = lstAccounts.SelectedItem as Account;
            if (selectedAccount != null)
            {
                double amount = double.Parse(tbxTransactionAmount.Text);
                selectedAccount.Balance -= amount;
                tbxBalance.Text = selectedAccount.Balance.ToString();
            }
            tbxTransactionAmount.Text = "";
        } // Withdraw Method

        private void btnInterest_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = lstAccounts.SelectedItem as Account;
            if (selectedAccount != null)
            {
                double interest = selectedAccount.CalculateInterest();
                tbxInterest.Text = interest.ToString();
                tbxInterestDate.Text = selectedAccount.InterestDate;
                double result = interest + selectedAccount.Balance;
                tbxBalance.Text = result.ToString();
            }
        } // Interest Method
    }
}
