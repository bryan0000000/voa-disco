namespace Voa_Disco;
public partial class GamePage : ContentPage
{
const int Gravidade=7;
const int TempoEntreFrames=20;
bool EstarMorto=true;
double LarguraDaJanela=200;
double AlturaDaJanela=200;
int Velocidade=7;
const int maxTempopulo=2;
int tempopulo=0;
bool estarPulo=false;
const int ForcaPulo=28;
const int AberturaMin=200;
int pomto=0;

void Inicializar()
{
	EstarMorto=false;
	cano2.TranslationX=-LarguraDaJanela;
	cano1.TranslationX=-LarguraDaJanela;
	navelol.TranslationX=0;
	navelol.TranslationY=0;
	pomto=0;
	MovimentacaoDosCanos();

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
		if(estarPulo)
		Aplicapulo();
		else
		AplicaGravidade();
		await Task.Delay(TempoEntreFrames);
		MovimentacaoDosCanos();
		if(VerificaColisao())
    {
	  EstarMorto=true;
	  framemorreu.IsVisible=true;
	  break;
	}

	}
	await Task.Delay(TempoEntreFrames);
	}
    

protected override void OnSizeAllocated ( double w, double h )
{
  LarguraDaJanela=w;
  AlturaDaJanela=h;
  cano2.WidthRequest=180;
  cano1.WidthRequest=180;
}
void MovimentacaoDosCanos()
{
 cano1.TranslationX -=Velocidade;
 cano2.TranslationX -=Velocidade;
 if (cano2.TranslationX<-LarguraDaJanela)
 {
	cano1.TranslationX=0;
    cano2.TranslationX=0;
	pomto++;
	LabelPomtos.Text="canos "+pomto.ToString("D3");
    var alturaMax=-100;
	var alturaMin=-cano1.HeightRequest;
	cano2.TranslationY=Random.Shared.Next((int)alturaMin, (int)alturaMax);
	cano1.TranslationY=cano1.TranslationY+AberturaMin+cano1.HeightRequest;
 }

}

async void morreu( object s,TappedEventArgs a)
{

	framemorreu.IsVisible =false;
	Inicializar();
	Desenhar();
	

}

bool VerificaColisao()
{
 
 
  return VerificaColisaoTeto()||
         VerificaColisaoChao()||
	     VerificaColisaoCanoCima()||
	     VerificaColisaoCanoBaixo();


}

bool VerificaColisaoTeto()
{
var minY=-AlturaDaJanela/2;
if(navelol.TranslationY<=minY)
return true;
else
return false;
}
bool VerificaColisaoChao()
{
	var maxY=AlturaDaJanela/2;
	if(navelol.TranslationY>=maxY)
	return true;
	else
	return false;
}
bool VerificaColisaoCanoCima()
{
    var posHNave = (LarguraDaJanela/2)-(navelol.HeightRequest/2);
	var posVNave = (AlturaDaJanela/2)-(navelol.HeightRequest/2)+navelol.TranslationY;
    if (posHNave >=Math.Abs(cano2.TranslationX)-cano2.HeightRequest &&
	posHNave <=Math.Abs(cano2.TranslationX)+cano2.WidthRequest &&
	posVNave <=cano2.HeightRequest +cano2.TranslationY)
	{
	return true;
	}	
	else
	{
	return false;
	}
	
}
bool VerificaColisaoCanoBaixo()
{
    var posHNave = (LarguraDaJanela/2)-(navelol.HeightRequest/2);
	var posVNave = (AlturaDaJanela/2)+(navelol.HeightRequest/2)+navelol.TranslationY;
	var yMaxcano = cano2.HeightRequest + cano2.TranslationY + AberturaMin;
    if (posHNave >=Math.Abs (cano1.TranslationX) - cano1.WidthRequest &&
	    posHNave <=Math.Abs (cano1.TranslationX) + cano1.WidthRequest &&
		posVNave >=yMaxcano)
	{
	return true;
	}	
	else
	{
	return false;
	}
	
}



void Aplicapulo()
 {
navelol.TranslationY-=ForcaPulo;
tempopulo++;
if(tempopulo>=maxTempopulo)
 {
	estarPulo=false;
	tempopulo=0;
 }
 }
 void pulagarai(object s, TappedEventArgs a)
 {
	estarPulo=true;
 }


}