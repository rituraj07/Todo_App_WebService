using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    class DataServices
    {
        private string url = "https://todo-web-xamarin.herokuapp.com/apis/todoes/";
        public async Task<List<Todo_>> GetTodos()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var todoes = JsonConvert.DeserializeObject<List<Todo_>>(json);
            return todoes;

        }
        public async Task PostTodo(Todo_post todo)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(todo);
            StringContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(url, content);
        }
        
        public async Task  DeleteTodoes(Todo_ todo)
        {
            var httpClient = new HttpClient();
            var responce = await httpClient.DeleteAsync(url+todo._id);
           
            

        }
    }
}
