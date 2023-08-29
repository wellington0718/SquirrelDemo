using Squirrel;
using System;
using System.Windows;

namespace SquirrelDemo;

public partial class MainWindow : Window
{
    UpdateManager? updateManager;
    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Load;
    }

    private async void MainWindow_Load(object sender, RoutedEventArgs e)
    {
        updateManager = await UpdateManager.GitHubUpdateManager("https://github.com/wellington0718/SquirrelDemo");
        CurrentVersionTextBox.Text = updateManager.CurrentlyInstalledVersion().ToString();
    }

    private async void CheckForUpdates_Click(object sender, RoutedEventArgs e)
    {
        var updateAvailable = await updateManager!.CheckForUpdate();

        if (updateAvailable.ReleasesToApply.Count > 0)
        {
            UpdateButton.IsEnabled = true;
        }
        else
        {
            UpdateButton.IsEnabled = false;
        }
    }

    private async void Update_Click(object sender, RoutedEventArgs e)
    {
       await updateManager!.UpdateApp();
        MessageBox.Show("Updated successfuly");
    }
}
