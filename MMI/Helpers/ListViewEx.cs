using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MMI
{
    public class ListViewEx : ListView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);

            var listItem = element as ListViewItem;
            var binding = new Binding
            {
                Mode = BindingMode.TwoWay,
                Source = item,
                Path = new PropertyPath("IsSelected") // in viewmodel
            };
            listItem?.SetBinding(ListViewItem.IsSelectedProperty, binding);
        }
    }
}