using CrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Data;
using CrudApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        Products productdetails;
        public AddProduct(Products details)
        {
            InitializeComponent();
            if (details != null)
            {
                productdetails = details;
                PopulateDetails(productdetails);
            }
        }

        private void PopulateDetails(Products details)
        {
            name.Text = details.Name;
            Description.Text = details.Description;
            Prix.Text = Convert.ToString(details.prix);
           
            saveBtn.Text = "Update";
            this.Title = "Edit Employee";
        }

        private void SaveProduct(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {

                Products products = new Products();
                products.Name = name.Text;
                products.Description = Description.Text;
                products.prix = Convert.ToDouble(Prix.Text);


                
                bool res = DependencyService.Get<ISQLite>().SaveProduct(products);
                if(res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Save", "Ok");
                }
            }
            else
            {
                // update employee
                productdetails.Name = name.Text;
                productdetails.Description = Description.Text;
                productdetails.prix = Convert.ToDouble(Prix.Text);
           

                bool res = DependencyService.Get<ISQLite>().UpdateProduct(productdetails);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Update", "Ok");
                }
            }
        }
       
    }
}