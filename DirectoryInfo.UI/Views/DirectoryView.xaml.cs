using System.Linq;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DirectoryInfo.Api.Domain.DirectoryInfoAggregate;
using DirectoryInfo.UI;

namespace Directory.Views
{
    public class DirectoryView : UserControl
    {
        private StringBuilder sb = new StringBuilder();

        public DirectoryView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var openDialog =
                new OpenFolderDialog()
                {
                    Title = "Select folder",
                };

            var selectedDir = await openDialog.ShowAsync(GetWindow());
            
            SetFolderText(selectedDir);
            SetOutputText(selectedDir);            
        }

        private void SetFolderText(string folder)
        {
            var textOutput = this.FindControl<TextBox>("mtext");
            textOutput.Text = folder;
        }

        private void SetOutputText(string folder)
        {
            sb.Clear();
            var service = (IDirectoryService)App._serviceProvider.GetService(typeof(IDirectoryService));
            var directoryTree = service.GetInfo(folder);
            var treeOutput = this.FindControl<TextBox>("tree");
            PrintTree(directoryTree);
            treeOutput.Text = sb.ToString();
        }

        private void PrintTree(AbstractFileInfo tree, string indent="", bool last=false)
        {
            var fileInfos = tree.FileInfos();

            var count = string.Empty;
            if (fileInfos.Any())
            {
                count = $" (contains {fileInfos.Count} file(s)/folder(s))";
            }

            sb.AppendLine($"{indent}+- {tree.Name}{count} || {tree.Size} bytes || Modified at {tree.UpdatedAt}");
            indent += last ? "   " : "|  ";

            for (int i = 0; i < fileInfos.Count; i++)
            {
                PrintTree(fileInfos[i], indent, i == fileInfos.Count - 1);
            }
        }

        Window GetWindow() => (Window)this.VisualRoot;
    }
}