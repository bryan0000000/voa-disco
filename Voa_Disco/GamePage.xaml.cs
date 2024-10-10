namespace Voa_Disco;
public partial class GamePage : ContentPage
{
const int Gravidade=5;
const int TempoEntreFrames=40;
bool EstarMorto=false;

    public GamePage()
	{
		InitializeComponent();
	}
	void AplicaGravidade()
	{
		navelol.TranslationY +=Gravidade;
	}
	

     async Task Desenhar()
	 {
       while (!EstarMorto)
       {
		AplicaGravidade();
		await Task.Delay(TempoEntreFrames);
	   }
	 }
    protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenhar();
    }






}