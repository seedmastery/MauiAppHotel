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

	private void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			Navigation.PushAsync(new HospedagemContratada());
		} catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
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