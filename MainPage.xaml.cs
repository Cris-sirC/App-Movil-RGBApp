using Microsoft.Maui.Graphics;

namespace ProyectoColores;

public partial class MainPage : ContentPage
{
    private bool isRandomizing = false;

    public MainPage()
    {
        InitializeComponent();
        ActualizarColor(); 
    }

    private void OnSliderValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if (!isRandomizing)
        {
            ActualizarColor();
        }
    }

    private void OnRandomClicked(object? sender, EventArgs e)
    {
        isRandomizing = true;
        Random random = new Random();
        
        SldRed.Value = random.Next(0, 256);
        SldGreen.Value = random.Next(0, 256);
        SldBlue.Value = random.Next(0, 256);
        
        isRandomizing = false;
        ActualizarColor();
    }

    private void ActualizarColor()
    {
        int r = (int)SldRed.Value;
        int g = (int)SldGreen.Value;
        int b = (int)SldBlue.Value;

        Color colorGenerado = Color.FromRgb(r, g, b);

        FondoApp.BackgroundColor = colorGenerado;

        LblHex.Text = colorGenerado.ToHex();
        
        if (!LblHex.Text.StartsWith("HEX Value:"))
        {
            LblHex.Text = $"HEX Value: {colorGenerado.ToHex()}";
        }
    }

    private async void OnCopyClicked(object? sender, EventArgs e)
    {
        string hexCode = LblHex.Text.Replace("HEX Value: ", "");
        
        await Clipboard.Default.SetTextAsync(hexCode);

        ToastFrame.IsVisible = true;
        
        await Task.Delay(2500); 
        
        ToastFrame.IsVisible = false;
    }
}