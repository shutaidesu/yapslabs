using lab5;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace lab5
{
    public class Catalog : INotifyPropertyChanged
    {
        private ObservableCollection<Composition> compositions = new ObservableCollection<Composition>();

        public ObservableCollection<Composition> Compositions
        {
            get { return compositions; }
            set
            {
                if (compositions != value)
                {
                    compositions = value;
                    OnPropertyChanged(nameof(Compositions));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Catalog()
        {
            compositions.CollectionChanged += Compositions_CollectionChanged;
        }

        private void Compositions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Compositions));
        }

        public void AddComposition(Composition composition)
        {
            while (compositions.Any(c => c.Id == composition.Id))
            {
                composition = new Composition();
            }

            compositions.Add(composition);
        }

        public void RemoveComposition(Composition composition)
        {
            compositions.Remove(composition);
        }

        public ObservableCollection<Composition> Search(string criteria)
        {
            var searchResults = new ObservableCollection<Composition>(
                compositions.Where(c =>
                    c.Artist.Equals(criteria, StringComparison.Ordinal) ||
                    c.Title.Equals(criteria, StringComparison.Ordinal))
            );

            return searchResults;
        }

        public ObservableCollection<Composition> Search(string artistCriteria, string titleCriteria)
        {
            var searchResults = new ObservableCollection<Composition>(
                compositions.Where(c =>
                    c.Artist.Equals(artistCriteria, StringComparison.Ordinal) &&
                    c.Title.Equals(titleCriteria, StringComparison.Ordinal))
            );

            return searchResults;
        }

        public ObservableCollection<Composition> GetCompositions()
        {
            return Compositions;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
