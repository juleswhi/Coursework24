namespace ChessMasterQuiz.Scraper;

public static class FormScraper
{
    public const string PATH = "FormDetails.txt";

    private static List<Form> PrintedForms = new();

    public static void PrintForm<T>(T form) where T : Form
    {
        using StreamWriter sw = new StreamWriter(PATH, true);
        if(PrintedForms.Any(x => x.GetType() == typeof(T))) {
            return;
        }

        sw.WriteLine($"---------------");
        sw.WriteLine($"{typeof(T).Name.ToUpper()}: ");
        sw.WriteLine($"---------------");
        // Size
        // Location
        // Colours
        // Font

        foreach(Control control in form.Controls)
        {
            sw.WriteLine($"{control.Name}:");
            sw.WriteLine($"\t\tSize: {control.Size}");
            sw.WriteLine($"\t\tLocation: {control.Location}");
            sw.WriteLine($"\t\tFore colour: {control.ForeColor.Name}");
            sw.WriteLine($"\t\tBack colour: {control.BackColor.Name}");
            sw.WriteLine($"\t\tFont: {control.Font.Name.ToString()}");
            sw.WriteLine($"\t\tFont Size: {control.Font.Size.ToString()}");
            sw.WriteLine();
        };
        sw.WriteLine();
        sw.WriteLine();
        sw.WriteLine();
    }
}
