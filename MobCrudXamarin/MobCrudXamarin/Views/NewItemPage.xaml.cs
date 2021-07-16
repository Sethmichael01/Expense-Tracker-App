using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobCrudXamarin.Models;

namespace MobCrudXamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();
        }

        private async void View_list(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetCompaniesPage());
        }

        private async void Add_List(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCompanyPage());
        }

        private async void Edit_list(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompanyPage());
        }
        private async void Delete_list(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCompanyPage());
        }
    }
}