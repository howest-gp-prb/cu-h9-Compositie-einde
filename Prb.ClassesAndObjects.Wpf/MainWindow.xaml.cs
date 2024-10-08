﻿using System;
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
using Prb.ClassesAndObjects.Core;

namespace Prb.ClassesAndObjects.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> cars;
        List<CarType> carTypes;
        public MainWindow()
        {
            InitializeComponent();
            cars = new List<Car>();
            carTypes = new List<CarType>();
            carTypes.Add(new CarType("Sedan", false));
            carTypes.Add(new CarType("Break", false));
            carTypes.Add(new CarType("SUV", false));
            carTypes.Add(new CarType("SUV", true));
            carTypes.Add(new CarType("Van", true));

            cmbCarType.ItemsSource = carTypes;
        }

        private void BtnAddNewCar_Click(object sender, RoutedEventArgs e)
        {
            if(cmbCarType.SelectedItem == null)
            {
                MessageBox.Show("Geef een type op", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                cmbCarType.Focus();
                return;
            }
            string color = txtColor.Text.Trim();
            string carbrand = txtCarBrand.Text.Trim();
            decimal.TryParse(txtPrice.Text.Trim(), out decimal price);
            int.TryParse(txtTopSpeed.Text.Trim(), out int topSpeed);
            CarType carType = (CarType)cmbCarType.SelectedItem;
            Car car = new Car();
            car.Color = color;
            car.Brand = carbrand;
            car.Price = price;
            car.TopSpeed = topSpeed;
            car.CarType = carType;
            cars.Add(car);
            UpdateCarListbox();
        }
        private void UpdateCarListbox()
        {
            lstCars.ItemsSource = cars;
            lstCars.Items.Refresh();
        }

        private void LstCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCars.SelectedItem != null)
            {
                Car car = (Car)lstCars.SelectedItem;
                txtCarBrand.Text = car.Brand;
                txtColor.Text = car.Color;
                txtPrice.Text = car.Price.ToString();
                txtTopSpeed.Text = car.TopSpeed.ToString();
                cmbCarType.SelectedItem = car.CarType;
            }
        }
    }
}
