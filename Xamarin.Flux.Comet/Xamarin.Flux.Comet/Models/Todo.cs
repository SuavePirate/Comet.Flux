using System.ComponentModel;

namespace Xamarin.Flux.Models
{
    /// <summary>
    /// Data model for a todo item
    /// </summary>
    public class Todo : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool IsComplete { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
