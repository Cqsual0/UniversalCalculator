using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace currencyCalculators
{
	public sealed partial class MainPage : Page
	{
		private Dictionary<string, Dictionary<string, double>> conversionRates = new Dictionary<string, Dictionary<string, double>>
		{
			{ "US Dollar", new Dictionary<string, double> { { "Euro", 0.85189982 }, { "British Pound", 0.72872436 }, { "Indian Rupee", 74.257327 } } },
			{ "Euro", new Dictionary<string, double> { { "US Dollar", 1.1739732 }, { "British Pound", 0.8556672 }, { "Indian Rupee", 87.00755 } } },
			{ "British Pound", new Dictionary<string, double> { { "US Dollar", 1.371907 }, { "Euro", 1.1686692 }, { "Indian Rupee", 101.68635 } } },
			{ "Indian Rupee", new Dictionary<string, double> { { "US Dollar", 0.011492628 }, { "Euro", 0.013492774 }, { "British Pound", 0.0098339397 } } }
		};

		public MainPage()
		{
			this.InitializeComponent();
		}

		private void OnConvertClick(object sender, RoutedEventArgs e)
		{
			string fromCurrency = (FromCurrencySelector.SelectedItem as ComboBoxItem).Content.ToString();
			string toCurrency = (ToCurrencySelector.SelectedItem as ComboBoxItem).Content.ToString();

			if (double.TryParse(InputAmount.Text, out double amount))
			{
				double convertedAmount;

				if (fromCurrency == toCurrency)
				{
					convertedAmount = amount;
					ConversionRate1.Text = $"1 {fromCurrency} = 1.00 {toCurrency}";
					ConversionRate2.Text = $"1 {toCurrency} = 1.00 {fromCurrency}";
				}
				else
				{
					convertedAmount = amount * conversionRates[fromCurrency][toCurrency];
					ConversionRate1.Text = $"1 {fromCurrency} = {conversionRates[fromCurrency][toCurrency]:0.00} {toCurrency}";
					ConversionRate2.Text = $"1 {toCurrency} = {1 / conversionRates[fromCurrency][toCurrency]:0.00} {fromCurrency}";
				}

				OutputAmount.Text = $"{convertedAmount:0.00} {toCurrency}";
			}
			else
			{
				OutputAmount.Text = "Invalid input";
			}
		}


		private void OnExitClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}
	}
}
