using System.Activities;

public sealed class EncryptCodeActivity : CodeActivity<string>
{
    public InArgument<string> PlainText { get; set; }
    public InArgument<int> Shift { get; set; }

    protected override string Execute(CodeActivityContext context)
    {
        string text = PlainText.Get(context);
        int shift = Shift.Get(context);
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            letter = (char)(letter + shift);
            buffer[i] = letter;
        }
        return new string(buffer);
    }
}