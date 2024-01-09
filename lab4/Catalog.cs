namespace lab4
{
    public class Catalog
    {
        private List<Composition> compositions = new List<Composition>();

        public void AddComposition(Composition composition)
        {
            compositions.Add(composition);
        }

        public void RemoveComposition(Composition composition)
        {
            compositions.Remove(composition);
        }
        public List<Composition> Search(string artistCriteria, string TitleCriteria)
        {
            // Пример простого поиска по критерию в названии или исполнителе
            return compositions.FindAll(c =>
                c.Artist.Contains(artistCriteria, StringComparison.OrdinalIgnoreCase) ||
                c.Title.Contains(TitleCriteria, StringComparison.OrdinalIgnoreCase));
        }

        public List<Composition> GetAllCompositions()
        {
            return compositions;
        }
    }
}
