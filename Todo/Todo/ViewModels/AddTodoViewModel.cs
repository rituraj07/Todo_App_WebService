using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Todo.Models;
using Todo.Services;
using Xamarin.Forms;

namespace Todo.ViewModels
{
    class AddTodoViewModel : INotifyPropertyChanged
    {
        private DataServices _dataService = new DataServices();
        public Todo_post SelectedTodo { get; set; }
        public ICommand SetTodoCommand => new Command(async () =>
        {
            SelectedTodo.UpdatedAt = DateTime.UtcNow.ToString();
            Random rnd = new Random();

            //SelectedTodo._id = rnd.Next(1, 1000).ToString();
            await _dataService.PostTodo(SelectedTodo);
        });
        public AddTodoViewModel()
        {
            SelectedTodo = new Todo_post();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
