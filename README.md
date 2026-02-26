# How-to-Expand-or-Collapse-a-Group-on-Double-Click-in-WPF-SfDataGrid

In [WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) (SfDataGrid), the group rows expand or collapse with a single click by default.

To enable expand or collapse a group row on double-click instead, you can customize the RowGenerator class and CaptionSummaryRowControl class, and override the OnPreviewMouseLeftButtonUp and OnPreviewMouseDoubleClick methods in the CaptionSummaryRowControl class.

**C#**
```

//setting custom row generator to datagrid

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.dataGrid.RowGenerator = new CustomRowGenerator(this.dataGrid);
    }
}


//custom row generator

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


 //custom caption summary rowcontrol

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
```

![Expand or collapse group row in double-click](Expand%20Collapse%20Group%20In%20Double%20Click.gif)

Take a moment to peruse the [WPF DataGrid - Grouping](https://help.syncfusion.com/wpf/datagrid/grouping) documentation, to learn more about grouping with examples.