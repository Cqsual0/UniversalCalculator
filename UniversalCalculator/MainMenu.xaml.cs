﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		private void mathCalcButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(Calculator.MainPage)); // Replace with the appropriate page for Math Calculator
		}

		private void currencyCalcButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(currencyCalculators.MainPage)); // Replace with the appropriate page for Currency Calculator
		}

		private void mortgageCalcButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(Calculator.MortgageCalculator)); // Replace with the appropriate page for Mortgage Calculator
		}

		private async void TripCalcButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(Calculator.TripCalculator)); // Replace with the appropriate page for Mortgage Calculator
		}


		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit(); // Close the application
		}
	}
}
