using MauiSQLite.MVVM.ViewModels;
using MauiSQLite.Services;

namespace MauiSQLite.MVVM.Views;

public partial class ViewAgenda : ContentPage
{
	public ViewAgenda(IAgendaService service)
	{
		InitializeComponent();
		BindingContext = new ViewModelAgenda(service);
	}
}