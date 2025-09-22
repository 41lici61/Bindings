using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bindings.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bindings.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    //decorador, privado, minuscula, sin get ni set (el observavbleproperty los implementa automaticamnete)
    [ObservableProperty]
    private string mensaje = string.Empty;

    [ObservableProperty] private bool avanzadas = false;

    [ObservableProperty] private List<Boligrafo> boligrafos= new();
    
    
    public string Greeting { get; } = "Welcome to Ocaña!";
    public string Saludo { set; get; } = "Saludos🛐";
    
    [ObservableProperty]
    private Boligrafo boli = new Boligrafo();

    public MainWindowViewModel()
    {
        CargarCombo();
        CargarBolis();
    }
    

    private void CargarBolis()
    {
        Boligrafo boli = new Boligrafo();
        boli.Codigo = "1";
        boli.Color = "Rosa";
        Boligrafos.Add(boli);
        
        Boligrafo boli2 = new Boligrafo();
        boli2.Codigo = "2";
        boli2.Color = "Perla";
        Boligrafos.Add(boli2);
        
        Boligrafo boli3 = new Boligrafo();
        boli3.Codigo = "3";
        boli3.Color = "Fucsia";
        Boligrafos.Add(boli3);
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
    
    

    [RelayCommand]
    public void MostrarBoli(object parameter)
    {
        if (parameter is false)
        {
            Mensaje = "Marcar el check";
            Console.WriteLine("Marcar el chek");
            
            return;
        }else if(string.IsNullOrWhiteSpace(Boli.Codigo))
        {
            Mensaje = "Codigo null";
            Console.WriteLine("Codigo null");
            
        }
        else
        {
            Mensaje = Boli.Codigo+" "+Boli.Color;
            Console.WriteLine(Boli.Codigo+" "+Boli.Color);
            Boligrafos.Add(Boli);
            Boli = new Boligrafo();//para borrar los campos, para ello el modelo debe ser observable
        }

    }
    [RelayCommand]
    public void MostrarOpcionesAvanzadas()
    {
        if (Avanzadas)
        {
            Avanzadas = false;
        }
        else
        {
            Avanzadas = true;
        }
    }

}