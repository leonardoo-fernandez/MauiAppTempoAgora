using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            tryHome
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n" +
                                         $"Temperatura máxima: {t.temp_max} \n" +
                                         $"Temperatura mínima: {t.temp_min} \n" +
                                         $"Descrição do tempo: {t.description} \n" +
                                         $"Velocidade do vento: {t.speed} \n" +
                                         $"Visibilidade: {t.visibility} \n";

                        lbl_result.Text = dados_previsao;
                    }
                    else
                    {
                        lbl_result.Text = "Cidade não encontrada";
                    }
                }
                else
                {
                    lbl_result.Text = "Preencha a cidade";
                }


            }
            catch (HttpRequestException httpEx)
            {
                await DisplayAlert("Sem conexão a internet", "Verifique sua conexão e tente novamente", "OK");

            }catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            
        }
    }

}
