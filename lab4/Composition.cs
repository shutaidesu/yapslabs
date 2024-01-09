namespace lab4
{
    public class Composition
    {
        private static int nextId = 1;
        public string Artist { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Artist} - {Title}";
        }
    }
}
