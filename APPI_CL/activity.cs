using System;
using System.ComponentModel;

namespace APPI_CL
{
    public class activity : INotifyPropertyChanged
    {
        public activity()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string name = "Jens Anker Børge";

        public string Name { get => name; set {
                name = value;

                var args = new PropertyChangedEventArgs(nameof(Name));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public double responsible_latitude { get; set; }
        public double responsible_longitude { get; set; }
    }
}
