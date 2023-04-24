using System.Collections.ObjectModel;

namespace SignalRModels.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
    }
}
