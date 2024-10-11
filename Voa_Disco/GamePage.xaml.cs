namespace Voa_Disco;
public partial class GamePage : ContentPage
{
const int Gravidade=5;
const int TempoEntreFrames=20;
bool EstarMorto=true;
double LarguraDaJanela=0;
double AlturaDaJanela=0;
int Velocidade=7;

void Inicializar()
{
	EstarMorto=false;
	navelol.TranslationY=0;
}

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
		MovimentacaoDosCanos();
	   }
	 }
    

protected override void OnSizeAllocated ( double w, double h )
{
  LarguraDaJanela=w;
  AlturaDaJanela=h;
}
void MovimentacaoDosCanos()
{
 cano1.TranslationX -= Velocidade;
 cano2.TranslationX -=Velocidade;

 if (cano1.TranslationX<-LarguraDaJanela)
 {
	cano1.TranslationX=0;
    cano2.TranslationX=0;
 }

}

void morreu( object s,TappedEventArgs a)
{

	framemorreu.IsVisible =false;
	Inicializar();
	Desenhar();
}









}