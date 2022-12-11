namespace Logger
{
    using System.Text;
    public class LogFile
    {
        private StringBuilder messages = new StringBuilder();

        public int Size { get; private set; }

        public void Write(string message)
        {
            messages.AppendLine(message);
            Size = GetASCISumOfAlphabetChars();
        }

        private int GetASCISumOfAlphabetChars()
        {
            var sum = 0;

            var messagesChars = messages.ToString().ToCharArray();

            foreach (var character in messagesChars)
            {
                var isAlhabetChar = ValidateChar(character);
                if (isAlhabetChar) sum += character;
            }

            return sum;
        }

        private bool ValidateChar(char character)
        {
            if (character < 65 || character > 122) return false;
            if (character > 90 && character < 97) return false;
            return true;
        }
    }
}
