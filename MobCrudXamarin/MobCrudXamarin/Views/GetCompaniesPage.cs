using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;

using Xamarin.Forms;
using MobCrudXamarin.Models;
using System.Collections.ObjectModel;

namespace MobCrudXamarin.Views
{
    public class GetCompaniesPage : ContentPage
    {
        private ListView _listView;
        private ListView _listViews;
        private Button _SaveEntry;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Mydb.db3");
        public GetCompaniesPage()
        {
            this.Title = $"List of Expenses";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            var ent = db.ExecuteScalar<int>("SELECT SUM(Amount) FROM Company WHERE Amount > 0");
            _SaveEntry = new Button();
            string amount = Convert.ToString(ent);
            String.Format("{0:#,###,###.##}", ent);
            _SaveEntry.Text = $"Total Amount Spent: {String.Format("{0:#,###,###.##}", ent)} NGN";
            _SaveEntry.Clicked += _SaveEntry_Clicked;
            stackLayout.Children.Add(_SaveEntry);
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(n => n.Title).ToList();
            _listViews = new ListView();
            ObservableCollection<Company> fbproducts = new ObservableCollection<Company>();
            string total = fbproducts.Select(a => new { Converted = Convert.ToDouble(a.Amount) }).ToList().Sum(a => a.Converted).ToString("#,0.00");          
            
            stackLayout.Children.Add(_listView);
            Content = stackLayout;
        }

        private async void _SaveEntry_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            var ent = db.ExecuteScalar<int>("SELECT SUM(Amount) FROM Company WHERE Amount > 0");
            await DisplayAlert("Total", $"{String.Format("{0:#,###,###.##}", ent)}" + " NGN", "Ok");
        }
    }
}