using Avalonia;
using Avalonia.Controls;

namespace HappyCoding.GrpcCommunicationFeatures.DesktopClient;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
}