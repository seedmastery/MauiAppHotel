using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContrataçãoHospedagem : ContentPage
{

	App PropriedadesApp;

	public ContrataçãoHospedagem()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

		dtpck_checkin.MinimumDate = DateTime.Now;
		dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

		// Garantir que DateTime? seja convertido para DateTime antes de chamar AddDays/AddMonths
		var checkinDate = dtpck_checkin.Date ?? DateTime.Now;

		dtpck_checkout.MinimumDate = checkinDate.AddDays(1);
		dtpck_checkout.MaximumDate = checkinDate.AddMonths(6);

	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			if (pck_quarto.SelectedItem == null)
			{
				await DisplayAlert("Aviso", "Por favor selecione um quarto.", "OK");
				return;
			}

			Hospedagem h = new Hospedagem
			{
				QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
				QntAdultos = Convert.ToInt32(stp_adultos.Value),
				QntCriancas = Convert.ToInt32(stp_criancas.Value),
				DataCheckin = (DateTime)dtpck_checkin.Date,
				DataCheckout = (DateTime)dtpck_checkout.Date,
			};

			await Navigation.PushAsync(new HospedagemContratada()
			{
				BindingContext = h
			});
		} catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
	}

	private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
	{
		DatePicker elemento = sender as DatePicker;

		DateTime data_selecionada_checkin = elemento.Date ?? DateTime.Now;

		dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
		dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}