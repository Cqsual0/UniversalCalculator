using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}
		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double P;
			int year, n;
			int month = 0;
			double monthly_payment, yearly_interest_rate, i, month_interest_percentage;

			P = double.Parse(borrow.Text);
			year = int.Parse(years.Text);
			month = int.Parse(months.Text);
			yearly_interest_rate = double.Parse(YearInterestRate.Text) / 100;
			n = year * 12 + month;
			i = yearly_interest_rate / 12;
			monthly_payment = P * (i * Math.Pow(1 + i, n)) / (Math.Pow(1 + i, n) - 1);
			month_interest_percentage = i * 100;
			MonthInterestRate.Text = month_interest_percentage.ToString("F2");
			MonthRepayment.Text = monthly_payment.ToString("F2");
		}
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			// Close the application
			Windows.ApplicationModel.Core.CoreApplication.Exit();
		}
	}
}
