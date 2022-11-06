using Autonoma.UI.Operation.Monitor.Views;
using Autonoma.UI.Presentation.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Core2D.ViewModels.Docking.Documents;
using Core2D.ViewModels.Editor;
using Dock.Model.ReactiveUI.Core;
using System;

namespace Autonoma.UI.Operation
{
    public class ViewLocator : IDataTemplate
    {
        public ViewLocator()
        {

        }

        public virtual IControl Build(object data)
        {

            var name = data.GetType().AssemblyQualifiedName!
                .Replace("ControlViewModel", "Control")
                .Replace("ViewModel", "View");

            Type type;
            if (data.GetType() == typeof(ProjectEditorViewModel))
                type = typeof(FrameView);
            else
                type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public virtual bool Match(object data)
        {
            return data is ViewModelBase || data is DockableBase;
        }
    }
}