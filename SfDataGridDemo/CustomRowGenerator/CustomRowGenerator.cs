using Syncfusion.UI.Xaml.Grid;

namespace SfDataGridDemo
{
    public class CustomRowGenerator : RowGenerator
    {
        public CustomRowGenerator(SfDataGrid dataGrid)
            : base(dataGrid)
        {
        }

        protected override VirtualizingCellsControl GetVirtualizingCellsControl<T>()
        {
            if (typeof(T) == typeof(CaptionSummaryRowControl))
            {
                CustomCaptionSummaryRowControl rowcontrol = new CustomCaptionSummaryRowControl();
                rowcontrol.sfDataGrid = this.Owner;
                return rowcontrol;
            }
            return base.GetVirtualizingCellsControl<T>();
        }
    }
}
