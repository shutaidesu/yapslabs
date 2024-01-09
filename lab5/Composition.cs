using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Composition : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static int nextId = 1;

        public Composition()
        {
            Id = nextId++;
        }

        private string artist;
        public string Artist
        {
            get { return artist; }
            set
            {
                if (artist != value)
                {
                    artist = value;
                    OnPropertyChanged(nameof(Artist));
                }
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Artist} - {Title}";
        }
    }
}
