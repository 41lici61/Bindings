using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
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
    
    [ObservableProperty]
    private Boligrafo boliSeleccionado = new Boligrafo();

    public MainWindowViewModel()
    {
        CargarCombo();
        CargarBolis();
    }

    [RelayCommand]
    public void ComprobarFecha()
    {
        CheckDate();
    }

    private bool CheckDate()
    {
        if (Boli.Fecha < DateTime.Today)
        {
            Mensaje = "Fecha inferior a hoy";
            return false;
        }
        else
        {
            Mensaje = "";
            return true;
        }
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

    [RelayCommand]//para que salga command en la vista
    public void CargarBoliSeleccionado()
    {
        Boli = BoliSeleccionado;
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
    public void EstadoInicialCheck(Object parameter)//cambia el color de las letras del check segun su estado
    {
        CheckBox check = (CheckBox)parameter;
        if (check.IsChecked == true)
        {
            check.Foreground=Brushes.DeepPink;
            check.FontWeight = FontWeight.Normal;
        }else{
            check.Foreground=Brushes.CadetBlue;
            check.FontWeight = FontWeight.Normal;
        }
    }


    [RelayCommand]
    public void MostrarBoli(object parameter)
    {
        if (!CheckDate())
        {
            return;
        }

        CheckBox check = (CheckBox)parameter;
        if (check.IsChecked is false)
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
            check.IsChecked = false;
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