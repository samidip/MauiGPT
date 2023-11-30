using ChatGptNet;
using ChatGptNet.Models;

namespace MauiGPT;

public partial class MainPage : ContentPage
{
    private IChatGptClient _chatGptClient;
    private Guid _sessionGuid = Guid.Empty;

    public MainPage()
	{
		InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }

    private void MainPage_Loaded(object sender, EventArgs e)
    {
        _chatGptClient = Handler.MauiContext.Services.GetService<IChatGptClient>();
    }

    private async void OnAttractionsClicked(object sender, EventArgs e)
    {
        await GetAttractions();
    }

    private async void OnHotelsClicked(object sender, EventArgs e)
    {
        await GetHotels();
    }

    private async Task GetAttractions()
    {
        if (string.IsNullOrWhiteSpace(LocationEntry.Text))
        {
            await DisplayAlert("Empty location", "Please enter a location (city or postal code)", "OK");
            return;
        }

        if (_sessionGuid == Guid.Empty)
        {
            _sessionGuid = Guid.NewGuid();
        }

        ChatGptResponse response = await _chatGptClient.AskAsync(_sessionGuid, "What are some attractions in " + LocationEntry.Text);

        var message = response.GetContent();
        this.attractionsResponseLabel.Text = message;
    }

    private async Task GetHotels()
    {
        if (string.IsNullOrWhiteSpace(LocationEntry.Text))
        {
            await DisplayAlert("Empty location", "Please enter a location (city or postal code).", "OK");
            return;
        }

        if (_sessionGuid == Guid.Empty)
        {
            _sessionGuid = Guid.NewGuid();
        }

        ChatGptResponse response = await _chatGptClient.AskAsync(_sessionGuid, "What are some hotels in " + LocationEntry.Text);

        var message = response.GetContent();
        this.hotelsResponseLabel.Text = message;
    }
}


