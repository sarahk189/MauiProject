using MauiProject.ViewModels;

namespace MauiProject.Pages;

public partial class UpdatePage : ContentPage
{
	public UpdatePage(UpdatePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}