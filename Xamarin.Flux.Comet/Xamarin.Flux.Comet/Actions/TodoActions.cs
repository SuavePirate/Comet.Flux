using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluxToolkit;
using Xamarin.Flux.ActionTypes;
using Xamarin.Flux.Models;

namespace Xamarin.Flux.Actions
{
    /// <summary>
    /// Actions to be taken against Todo items
    /// </summary>
    public class TodoActions : IActions
    {
        public void AddTodo(string text)
        {
            Dispatcher.Send<IActions, string>(this, TodoActionTypes.ADD_TODO, text);
        }

        public void DeleteCompletedTodos()
        {
            Dispatcher.Send<IActions>(this, TodoActionTypes.DELETE_COMPLETED_TODOS);
        }

        public void DeleteTodo(string id)
        {
            Dispatcher.Send<IActions, string>(this, TodoActionTypes.DELETE_TODO, id);
        }

        public void EditTodo(string id, string text)
        {
            Dispatcher.Send<IActions, Todo>(this, TodoActionTypes.EDIT_TODO, new Todo
            {
                Id = id,
                Text = text
            });
        }

        public void StartEditingTodo(string id)
        {
            Dispatcher.Send<IActions, string>(this, TodoActionTypes.START_EDITING_TODO, id);
        }

        public void StopEditingTodo()
        {
            Dispatcher.Send<IActions>(this, TodoActionTypes.STOP_EDITING_TODO);
        }

        public void ToggleAllTodos()
        {
            Dispatcher.Send<IActions>(this, TodoActionTypes.TOGGLE_ALL_TODOS);
        }

        public void ToggleTodo(string id)
        {
            Dispatcher.Send<IActions, string>(this, TodoActionTypes.TOGGLE_TODO, id);
        }
        
    }
}
