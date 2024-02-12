public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _randomGenerator = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (var wordText in text.Split(" "))
        {
            _words.Add(new Word(wordText));
        }
    }

    public void Display()
    {
        _reference.Display();

        foreach (var word in _words)
        {
            word.Display();
            Console.Write(" ");
        }

        Console.WriteLine();
    }

    public void HideRandomWords(int hideCount)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        int finalHideCount = Math.Min(hideCount, visibleWords.Count);

        int hiddenCount = 0;
        while (hiddenCount < finalHideCount)
        {
            var nextWord = visibleWords[_randomGenerator.Next(visibleWords.Count)];
            if (!nextWord.IsHidden())
            {
                nextWord.Hide();
                hiddenCount++;
            }
        }
    }

    public bool AllWordsAreHidden()
    {
        foreach (var word in _words)
            if (!word.IsHidden())
            {
                return false;
            }

        return true;
    }
}
