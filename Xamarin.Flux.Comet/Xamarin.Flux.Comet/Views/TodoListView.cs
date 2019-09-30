using System.Collections.Generic;
using Comet;
using Xamarin.Flux.Models;

namespace Xamarin.Flux.Views
{
    public class TodoListView : ListView<Todo>
    {
        private readonly IList<Todo> _items;
        public TodoListView(IList<Todo> list) : base(list)
        {
            _items = list;
        }
        protected override View ViewFor(int index)
        {
            var item = _items[index];
            return new HStack
            {
                new VStack(HorizontalAlignment.Leading, spacing:2)
                {
                    new Text (item.Text).FontSize(17),
                    new Text (item.IsComplete ? "Complete" : "Incomplete").Color(Color.Grey)
                }.FontSize(12)
            }.Frame(height: 60, alignment: Alignment.Leading);
        }
    }
}