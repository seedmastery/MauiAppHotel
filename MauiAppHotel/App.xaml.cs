using MauiAppHotel.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto { Descricao = "Suíte Super Luxo", ValorDiariaAduto = 110.0, ValorDiariaCrianca = 55.0 },
            new Quarto { Descricao = "Suíte Luxo",       ValorDiariaAduto =  80.0, ValorDiariaCrianca = 40.0 },
            new Quarto { Descricao = "Suíte Single",     ValorDiariaAduto =  50.0, ValorDiariaCrianca = 25.0 },
            new Quarto { Descricao = "Suíte Crise",      ValorDiariaAduto =  25.0, ValorDiariaCrianca = 12.5 }
        };


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ContrataçãoHospedagem());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;


            return window;
        }
    }
}