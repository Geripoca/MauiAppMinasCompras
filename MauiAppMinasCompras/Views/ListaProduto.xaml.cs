using MauiAppMinasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>(); 
	public ListaProduto()
	{
		InitializeComponent();

		lst_produtos.ItemsSource = lista;
	}
	
	protected async override void OnAppearing() 
	{
        List<Produtos> tmp = await App.Db.GetAll();

        tmp.ForEach(i => lista.Add(i));
    }
    
	
	private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try 
		{
			Navigation.PushAsync(new Views.NovoProduto());

		} catch (Exception ex) 
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
    }
}