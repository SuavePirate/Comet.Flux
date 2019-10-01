using System;
using System.Collections.Generic;
using System.Linq;
using Comet;
using FluxToolkit;
using Xamarin.Flux.Actions;
using Xamarin.Flux.ActionTypes;
using Xamarin.Flux.Models;
using Xamarin.Flux.Stores;
using Xamarin.Flux.Views;

namespace Xamarin.Flux
{
    public class MainPage : View
    {
        private readonly TodoStore _todoStore = new TodoStore();
        private readonly TodoActions _actions = new TodoActions();
        [State]
        readonly State<List<Todo>> Todos;
        public MainPage()
        {
            Todos = _todoStore.Data.ToList();
            _todoStore.OnEmitted += TodoStore_OnEmitted;
        }

        private void ResetState()
        {
            Todos.Value = _todoStore.Data.ToList();
        }

        /// <summary>
        /// Processes events from the todo store and updates any UI that isn't handled automatically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TodoStore_OnEmitted(object sender, StoreEventArgs e)
        {
            switch (e.EventType)
            {
                case TodoActionTypes.ADD_TODO:
                    if (_todoStore.Error == null)
                    {
                        System.Console.WriteLine("Item added");
                        ResetState();
                    }
                    break;
                case TodoActionTypes.DELETE_COMPLETED_TODOS:
                    if (_todoStore.Error == null)
                    {
                        System.Console.WriteLine("Items deleted");
                        ResetState();
                    }
                    break;
                case TodoActionTypes.DELETE_TODO:
                    if (_todoStore.Error == null)
                    {
                        System.Console.WriteLine("Item deleted");
                        ResetState();
                    }
                    break;
                case TodoActionTypes.TOGGLE_ALL_TODOS:
                    if (_todoStore.Error == null)
                    {
                        System.Console.WriteLine("Items toggled");
                        ResetState();
                    }
                    break;
                case TodoActionTypes.TOGGLE_TODO:
                    if (_todoStore.Error == null)
                    {
                        System.Console.WriteLine("Item toggled");
                        ResetState();
                    }
                    break;
            }
            if (_todoStore.Error != null)
            {
                System.Console.WriteLine(_todoStore.Error);
            }
        }

        [Body]
        View body() => new VStack {
            new HStack {
                new Button("Add", () => _actions.AddTodo("Todo again")),
                new Button("Toggle All", () => _actions.ToggleAllTodos())
            },
            new TodoListView(Todos.Value)
        };
    }
}
