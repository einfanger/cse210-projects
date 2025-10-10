namespace JournalProgram
{
    public class Entry
    {
        private string _prompt;
        private string _content;
        private string _date;
        private int _mood;

        public string Prompt { get => _prompt; set => _prompt = value; }
        public string Content { get => _content; set => _content = value; }
        public string Date { get => _date; set => _date = value; }
        public int Mood { get => _mood; set => _mood = value; }

        public Entry() { }

        public Entry(string prompt, string content, string date, int mood)
        {
            _prompt = prompt;
            _content = content;
            _date = date;
            _mood = mood;
        }
    }
}
