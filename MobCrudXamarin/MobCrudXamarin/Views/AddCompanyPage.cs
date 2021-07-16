using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;

using Xamarin.Forms;
using MobCrudXamarin.Models;

namespace MobCrudXamarin.Views
{
    public class AddCompanyPage : ContentPage
    {
        private Entry _nameEntry;
        private Entry _AddressEntry;
        private Button _SaveEntry;
        //Database
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"Mydb.db3");
        public AddCompanyPage()
        {
            this.Title = "Add Expenses";
            StackLayout stackLayout = new StackLayout();
            //Company Name
            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Item Spent on";
            stackLayout.Children.Add(_nameEntry);
            //Address
            _AddressEntry = new Entry();
            _AddressEntry.Keyboard = Keyboard.Numeric;
            _AddressEntry.Placeholder = "Amount Spent on Item";
            stackLayout.Children.Add(_AddressEntry);
            //Save Button
            _SaveEntry = new Button();
            _SaveEntry.Text = "Save";
            _SaveEntry.Clicked += _SaveEntry_Clicked;
            stackLayout.Children.Add(_SaveEntry);
            Content = stackLayout;
        }

        private async void _SaveEntry_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Company>();
            var maxpk = db.Table<Company>().OrderByDescending(i => i.Id).FirstOrDefault();
            Company company = new Company()
            {
                Id = (maxpk == null ? 1 : maxpk.Id + 1),
                Title = _nameEntry.Text,
                Amount = Convert.ToDecimal(_AddressEntry.Text)
            };
            db.Insert(company);
            await DisplayAlert("Update ", company.Title + " Saved Successfully", "Ok");
            await Navigation.PopAsync();
        }
    }
}