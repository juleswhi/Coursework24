namespace ChessMasterQuiz;

interface IContext
{
    protected Control.ControlCollection _controls { get; }
    public void UseContext(IEnumerable<DataContextTag> context) 
    {
        foreach(var dct in context)
        {
            IEnumerable<Control> controls = _controls.OfType<TextBox>().FindPlaceHolder(dct.tag);
            if (controls is null || controls.Count() < 1) continue;

            foreach(var control in controls)
            {
                (control as TextBox)!.PlaceholderText = (string)dct.data;
            }
        }
    }
}
