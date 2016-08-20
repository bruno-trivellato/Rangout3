using Rang_Out.Common;
using Rang_Out.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rang_Out.ViewModels
{
    public class TodoItemViewModel : BindableBase
    {
        private TodoItem _todoItem;

        public TodoItem TodoItem
        {
            get { return _todoItem; }
            set { SetProperty( ref _todoItem, value); }
        }
        

        private RelayCommand _InsertTodoItemCommand;

        public RelayCommand InsertTodoItemCommand
        {
            get
            {
                if (_InsertTodoItemCommand == null)
                {
                    _InsertTodoItemCommand = new RelayCommand(
                      async () =>
                      {
                          
                          await App.MobileService.GetTable<TodoItem>().InsertAsync(TodoItem);
                      },
                      () =>
                      {
                          return true;
                      });
                    
                }
                return _InsertTodoItemCommand;
            }
        }

        public TodoItemViewModel()
        {
            TodoItem = new TodoItem();
        }

    }
}
