namespace MauiAppMinasCompras.Views;

public partial class EditarProduto : ContentPage
{
    private readonly object txt_preco;
    private object txt_descricao;
    private object txt_quantidade;

    public EditarProduto()
	{
		InitializeComponent();
	}

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto? produto_anexado = BindingContext as Produto;

            Produto p = new Produto
            {
                Id = produto_anexado = BindingContext as Produto;
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }


    }
}