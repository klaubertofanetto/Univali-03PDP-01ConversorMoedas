using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        btnFromDollar.Active = true;
        btnReal.Active = true;
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }



    protected void clickButton(object sender, EventArgs e)
    {
        double entryValue = double.Parse(txtInput.Text);
        string convertedValue;

        if (btnFromReal.Active && btnDollar.Active)
        {
            convertedValue = (Math.Round(entryValue / 5.41, 2)).ToString();
             
        } else if (btnFromReal.Active && btnEuro.Active)
        {
            convertedValue = (Math.Round(entryValue / 6.39, 2)).ToString();
        }
        else if (btnFromDollar.Active && btnEuro.Active)
        {
            convertedValue = (Math.Round(entryValue / 1.18, 2)).ToString();
        }
        else if (btnFromDollar.Active && btnReal.Active)
        {
            convertedValue = (Math.Round(entryValue * 5.41, 2)).ToString();
        }
        else if (btnFromEuro.Active && btnDollar.Active)
        {
            convertedValue = (Math.Round(entryValue * 1.18, 2)).ToString();
        }
        else if (btnFromEuro.Active && btnReal.Active)
        {
            convertedValue = (Math.Round(entryValue * 6.39, 2)).ToString();
        }
        else
        {
            convertedValue = "Selecione opções válidas";
        }

        txtOutput.Text = convertedValue;
}

   protected void dollarOn(object sender, EventArgs e)
    {
        if (((ToggleButton)btnFromDollar).Active)
        {
            btnDollar.ChildVisible = false;
            btnEuro.ChildVisible = true;
            btnReal.ChildVisible = true;
        }
    }

    protected void euroOn(object sender, EventArgs e)
    {
        if (((ToggleButton)btnFromEuro).Active)
        {
            btnEuro.ChildVisible = false;
            btnDollar.ChildVisible = true;
            btnReal.ChildVisible = true;
        }
    }

    protected void realOn(object sender, EventArgs e)
    {
        if (((ToggleButton)btnFromReal).Active)
        {
            btnReal.ChildVisible = false;
            btnEuro.ChildVisible = true;
            btnDollar.ChildVisible = true;
        }
    }
}
