using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Windows.Input;

namespace SfDataGridDemo
{
    public class CustomCaptionSummaryRowControl : CaptionSummaryRowControl
    {
        public SfDataGrid sfDataGrid;

        public CustomCaptionSummaryRowControl()
            : base()
        {
            this.DefaultStyleKey = typeof(CustomCaptionSummaryRowControl);
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            var visualContainer = sfDataGrid.GetVisualContainer() as VisualContainer;
            var index = visualContainer.PointToCellRowColumnIndex(e.GetPosition(null));
            if (e.ClickCount == 1 && index.ColumnIndex != 0)
                return;
            base.OnPreviewMouseLeftButtonUp(e);
        }
        protected override void OnPreviewMouseDoubleClick(MouseButtonEventArgs e)
        {
            if (this.DataContext is Group)
            {
                var group = this.DataContext as Group;
                if (group.IsExpanded)
                    sfDataGrid.CollapseGroup(group);
                else
                    sfDataGrid.ExpandGroup(group);
            }
            base.OnPreviewMouseDoubleClick(e);
        }
    }
}
