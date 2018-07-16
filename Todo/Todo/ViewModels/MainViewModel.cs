using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.Models;
using Todo.Services;
using Xamarin.Forms;

namespace Todo.ViewModels 
{
    class MainViewModel : INotifyPropertyChanged
    {
        private List<Todo_> _todos;
        private DataServices _dataService = new DataServices();
        
        public List<Todo_> Todos
        {
            get { return _todos; }
            set
            {
                _todos = value;
                OnPropertyChanged();
            }
        }
       
        public MainViewModel()
        {
            //SelectedTodo = new Todo_();
            GetTodoes();
        }
        private bool _isRefreshing { get; set; }
        public bool IsRefreshing { get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private async Task GetTodoes()
        {
            IsRefreshing = true;
            Todos = await _dataService.GetTodos();
            IsRefreshing = false;

        }
        private async Task delTodoes(Todo_ todo)
        {
            await _dataService.DeleteTodoes(todo);

        }
        public Todo_ SelectedTodo { get; set; }
          public Command<Todo_> RemoveCommand
        {
            get
            {
                return new Command<Todo_>((todo) =>
                {
                     delTodoes(todo);
                });
            }
        }
           //public void del()
       // {
         //   Debug.WriteLine(YourSelectedItem.Title);
        //}
        Todo_ _yourSelectedItem;
        public Todo_ YourSelectedItem
        {
            get
            {
                return _yourSelectedItem;
            }

            set
            {
                _yourSelectedItem = value;
                OnPropertyChanged();

            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand RefreshCommand => new Command(async() =>
        {
            await GetTodoes();
        });
    }
}
