﻿using static ChessMasterQuiz.Helpers.FormatDirection;
namespace ChessMasterQuiz.Helpers;


public enum FormatDirection
{
    X,
    Y
}

public static class ControlHelper
{
    public static Control? FindTag(this IEnumerable<Control> controls, string tag)
    {
        foreach(var control in controls)
        {
            if (control.Tag is null) continue;
            if ((string)control.Tag == tag) return control;
        }
        return null;
    }

    public static IEnumerable<TextBox> FindPlaceHolder(this IEnumerable<TextBox> controls, string text)
    {
        foreach(var control in controls)
        {
            if (control.PlaceholderText is null) continue;
            if (control.PlaceholderText.ToLower() == text) yield return control;
        }
    }

    public static IEnumerable<DataContextTag> ToDCT(this IEnumerable<object> objs)
    {
        List<DataContextTag> dcts = new();
        foreach(var o in objs)
        {
            dcts.Add((DataContextTag)o);
        }
        return dcts;
    }

    /// <summary>
    /// Reference to Main Form with correct Typing [ Alternative to "(ActiveForm as formMain)" ]
    /// </summary>
    public static formMain Main => (Form.ActiveForm as formMain)!;

    public static void ActivateForm<T>(params DataContextTag[] context) where T : Form, new()
    {
        // Create the form
        formMain.ChildForm = CreateForm<T>(context);

        // All the boring stuff to display the form
        formMain.ChildForm.TopLevel = false;
        formMain.ChildForm.Dock = DockStyle.Fill;
        formMain.ChildForm.FormBorderStyle = FormBorderStyle.None;
        formMain.ChildForm.Enabled = true;
        formMain.ChildForm.Visible = true;

        formMain.GetPanelHolder().Controls.Clear();
        formMain.GetPanelHolder().Controls.Add(formMain.ChildForm);
        formMain.GetPanelHolder().Show();
    }

    /// <summary>
    /// Creates a Form which passes context through if needed
    /// </summary>
    /// <typeparam name="T">The Type of Form to Create</typeparam>
    /// <param name="context">Enumerable of <c>DataContextTag</c>'s to pass</param>
    /// <returns>The Form Created</returns>
    public static Form CreateForm<T>(IEnumerable<DataContextTag> context) where T : Form, new() {
        // Create the Form
        var instance = Activator.CreateInstance<T>()!;

        // Grab the method FROM THE INTERFACE!!
        var method = typeof(IContext).GetMethod("UseContext");

        // If the method exists | The form impl the interface
        if (method is not null)
        {
            method!.Invoke(instance, new object[] { context });
        }
        // Return the form
        return instance;
    }

    /// <summary>
    /// Returns an Action that will center the Control in the active form 
    /// </summary>
    /// <param name="control">The Control to be centered</param>
    /// <returns>Action to center</returns>
    public static void Center(this Control control, FormatDirection d)
    {
        switch (d)
        {
            case X:
                control.Location = new((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width), control.Location.Y);
                break;
            case Y:
                control.Location = new((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width), control.Location.Y);
                break;
        };
    }

    public static void Center(this Control control, FormatDirection direction, float distance)
    {
        switch (direction)
        {
            case X:
                control.Location = new(((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width)) + (int)distance, control.Location.Y);
                break;
            case Y:
                control.Location = new(((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width)) + (int)distance, control.Location.Y);
                break;
        };

    }


    public static void RedIfWrong(this TextBox textbox, bool isRight)
    {
        if(isRight)
        {
            textbox.BackColor = Color.FromArgb(255, 81, 94, 74);
        }
        else
        {
            textbox.BackColor = Color.FromArgb(255, 225, 117, 111);
        } 
    }

    public static void CreateEquidistantIntervals<T>(this List<T> controls, float distance, int index = 0) where T : Control
    {
        if (index >= controls.Count() - 1) return;
        var bottom = controls[index].Bottom;
        controls[index + 1].Top = bottom + (int)distance;

        controls.CreateEquidistantIntervals(distance, index++);
    }


}