using System;
using System.Collections.ObjectModel;
using Bindings.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bindings.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    //decorador, privado, minuscula, sin get ni set
    [ObservableProperty]
    private string mensaje = string.Empty;
    public string Greeting { get; } = "Welcome to Ocaña!";
    public string Saludo { set; get; } = "Saludos🛐";

    public MainWindowViewModel()
    {
        CargarCombo();
    }

    public ObservableCollection<string> Lista { set; get; } = new()
    {
        "Rosa", "Fucsia", "Perla", "topacio", "oro viejo", "Pastel"
    };
    
    private void CargarCombo()
    {
        Lista = new ObservableCollection<string>()
        {
            "Rosa", "Fucsia", "Perla", "topacio", "oro viejo", "Pastel"
        };
        Boli.Color = Lista[0];
    }
    
    public Boligrafo Boli { get; set; } = new Boligrafo();

    [RelayCommand]
    public void MostrarBoli(object parameter)
    {
        if (parameter is false)
        {
            Mensaje = "eres imbecil";
            Console.WriteLine("eres imbecil");
            
            return;
        }

        if (string.IsNullOrWhiteSpace(Boli.Codigo))
        {
            Mensaje = "eres super imbecil";
            Console.WriteLine("eres super imbecil");
            
        }

    }

}