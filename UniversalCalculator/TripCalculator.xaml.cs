using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
	/// <summary>
	/// 
	/// </summary>
	public sealed partial class TripCalculator : Page
	{
		public TripCalculator()
		{
			this.InitializeComponent();
		}

		// Calculate Price based on input
		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Reset border color of textboxes in case they were previously marked as incorrect
				startKmTextBox.ClearValue(Control.BorderBrushProperty);
				endKmTextBox.ClearValue(Control.BorderBrushProperty);
				daysHiredTextBox.ClearValue(Control.BorderBrushProperty);
				pricePerDayTextBox.ClearValue(Control.BorderBrushProperty);
				hireDatePicker.ClearValue(Control.BackgroundProperty);

				int startingKm = Convert.ToInt32(startKmTextBox.Text);
				int endingKm = Convert.ToInt32(endKmTextBox.Text);
				int daysHired = Convert.ToInt32(daysHiredTextBox.Text);
				decimal rate = Convert.ToDecimal(pricePerDayTextBox.Text);

				decimal totalAmount = CalculatePrice(daysHired, rate);

				payAmountTextBox.Text = totalAmount.ToString();
				traveledTextBlock.Text = "Traveled " + (endingKm - startingKm).ToString() + "km";
			}
			catch (FormatException)
			{
				// Highlight the incorrect textbox with a red border.
				if (!int.TryParse(startKmTextBox.Text, out _))
					startKmTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
				if (!int.TryParse(endKmTextBox.Text, out _))
					endKmTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
				if (!int.TryParse(daysHiredTextBox.Text, out _))
					daysHiredTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
				if (!decimal.TryParse(pricePerDayTextBox.Text, out _))
					pricePerDayTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
				if (hireDatePicker.SelectedDate == null)
					hireDatePicker.Background = new SolidColorBrush(Colors.LightPink);
			}
		}
		// Sets Selected Date to Todays Date
		private void todayDateButton_Click(object sender, RoutedEventArgs e)
		{
			hireDatePicker.SelectedDate = DateTime.Today;
		}
		// Exits the application
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
            Windows.UI.Xaml.Application.Current.Exit();
		}
		// Returns totalAmount given daysHired and rate
		private decimal CalculatePrice(decimal daysHired, decimal rate)
		{
			decimal totalAmount = daysHired * rate;

			return totalAmount;
		}
		//Clears the form
		private void clearButton_Click(object sender, RoutedEventArgs e)
		{
			startKmTextBox.Text = "";
			endKmTextBox.Text = "";
			daysHiredTextBox.Text = "";
			pricePerDayTextBox.Text = "";
			payAmountTextBox.Text = "";
			traveledTextBlock.Text = "";

			// Reset border color of textboxes in case they were previously marked as incorrect
			startKmTextBox.ClearValue(Control.BorderBrushProperty);
			endKmTextBox.ClearValue(Control.BorderBrushProperty);
			daysHiredTextBox.ClearValue(Control.BorderBrushProperty);
			pricePerDayTextBox.ClearValue(Control.BorderBrushProperty);
			hireDatePicker.ClearValue(Control.BackgroundProperty);
		}
	}
}
