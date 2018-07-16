using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Todo.ViewModels;
using Todo.Views;
using Xamarin.Forms;

namespace Todo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        private async void Addtodo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTodo());
        }
        public void Remove(object sender,EventArgs e)
        {
            var button = sender as Button;
          var todo =  button?.BindingContext as Todo_;
            var vm = BindingContext as MainViewModel;
            vm?.RemoveCommand.Execute(todo);
        }
    }
}
