using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CrudApp.Views;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

      

        protected override void OnAppearing()
        {
            PopulateProductList();
        }
        public void PopulateProductList()
        {
            EmployeeList.ItemsSource = null;
            EmployeeList.ItemsSource = DependencyService.Get<ISQLite>().GetProduct();
        }

        private async void AddProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProduct(null));
        }

        private void EditEmployee(object sender, ItemTappedEventArgs e)
        {
            Products details = e.Item as Products;
            if (details != null)
            {
                Navigation.PushAsync(new AddProduct(details));
            }
        }
        private async void DeleteEmployee(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete employee?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Products details = menu.CommandParameter as Products;
                DependencyService.Get<ISQLite>().DeleteProduct(details.Id);
                PopulateProductList();
            }
        }
    }
}
