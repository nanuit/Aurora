///  TreeView Control with ContentItems
///  from https://www.codeproject.com/tips/1096924/tabcontrol-with-treeview-navigation
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Aurora.Wpf.Controls.TreeControl
{
    [ContentProperty("Items")]
    public class TreeControl : ItemsControl
    {
        #region References

        private TreeView TreeView
        {
            get; set;
        }

        #endregion

        #region DependencyProperties

        public static DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(TreeItem), typeof(TreeControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public TreeItem SelectedItem
        {
            get => (TreeItem)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static DependencyProperty ContentPaddingProperty = DependencyProperty.Register("ContentPadding", typeof(Thickness), typeof(TreeControl), new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Thickness ContentPadding
        {
            get => (Thickness)GetValue(ContentPaddingProperty);
            set => SetValue(ContentPaddingProperty, value);
        }

        public static DependencyProperty MenuWidthProperty = DependencyProperty.Register("MenuWidth", typeof(GridLength), typeof(TreeControl), new FrameworkPropertyMetadata(default(GridLength), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public GridLength MenuWidth
        {
            get => (GridLength)GetValue(MenuWidthProperty);
            set => SetValue(MenuWidthProperty, value);
        }

        public static DependencyProperty ContentWidthProperty = DependencyProperty.Register("ContentWidth", typeof(GridLength), typeof(TreeControl), new FrameworkPropertyMetadata(default(GridLength), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public GridLength ContentWidth
        {
            get => (GridLength)GetValue(ContentWidthProperty);
            set => SetValue(ContentWidthProperty, value);
        }

        public static DependencyProperty MenuBorderThicknessProperty = DependencyProperty.Register("MenuBorderThickness", typeof(Thickness), typeof(TreeControl), new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Thickness MenuBorderThickness
        {
            get => (Thickness)GetValue(MenuBorderThicknessProperty);
            set => SetValue(MenuBorderThicknessProperty, value);
        }

        public static DependencyProperty MenuBackgroundProperty = DependencyProperty.Register("MenuBackground", typeof(Brush), typeof(TreeControl), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Brush MenuBackground
        {
            get => (Brush)GetValue(MenuBackgroundProperty);
            set => SetValue(MenuBackgroundProperty, value);
        }

        public static DependencyProperty MenuBorderBrushProperty = DependencyProperty.Register("MenuBorderBrush", typeof(Brush), typeof(TreeControl), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Brush MenuBorderBrush
        {
            get => (Brush)GetValue(MenuBorderBrushProperty);
            set => SetValue(MenuBorderBrushProperty, value);
        }

        public static DependencyProperty ContentBorderThicknessProperty = DependencyProperty.Register("ContentBorderThickness", typeof(Thickness), typeof(TreeControl), new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Thickness ContentBorderThickness
        {
            get => (Thickness)GetValue(ContentBorderThicknessProperty);
            set => SetValue(ContentBorderThicknessProperty, value);
        }

        public static DependencyProperty ContentBackgroundProperty = DependencyProperty.Register("ContentBackground", typeof(Brush), typeof(TreeControl), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Brush ContentBackground
        {
            get => (Brush)GetValue(ContentBackgroundProperty);
            set => SetValue(ContentBackgroundProperty, value);
        }

        public static DependencyProperty ContentBorderBrushProperty = DependencyProperty.Register("ContentBorderBrush", typeof(Brush), typeof(TreeControl), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Brush ContentBorderBrush
        {
            get => (Brush)GetValue(ContentBorderBrushProperty);
            set => SetValue(ContentBorderBrushProperty, value);
        }

        public static DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<TreeItem>), typeof(TreeControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public new ObservableCollection<TreeItem> Items
        {
            get => (ObservableCollection<TreeItem>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(string), typeof(TreeControl), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedIndexChanged));
        public string SelectedIndex
        {
            get => (string)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }
        private static void OnSelectedIndexChanged(DependencyObject Object, DependencyPropertyChangedEventArgs e)
        {
            TreeControl TreeControl = (TreeControl)Object;
            TreeControl.SelectIndex(TreeControl.SelectedIndex);
        }

        #endregion

        #region TreeControl

        public TreeControl() : base()
        {
            this.Items = new ObservableCollection<TreeItem>();
            this.DefaultStyleKey = typeof(TreeControl);
        }

        public override void OnApplyTemplate()
        {
            base.ApplyTemplate();

            this.TreeView = this.Template.FindName("PART_TreeView", this) as TreeView;
            this.TreeView.SelectedItemChanged += this._SelectedItemChanged;

            //If a selected index is not specified, select first by default.
            if (!string.IsNullOrEmpty(this.SelectedIndex))
                this.SelectIndex(this.SelectedIndex);
            else
                this.SetSelectedIndex(0);
        }

        #endregion

        #region Methods

        public void SetSelectedIndex(params int[] Values)
        {
            string Temp = string.Empty;
            foreach (int i in Values) Temp += i.ToString() + ",";
            Temp = Temp.TrimEnd(',');
            this.SelectedIndex = Temp;
        }

        List<int> GetIndices(string Index)
        {
            if (!string.IsNullOrEmpty(Index))
            {
                List<int> Values = new List<int>();
                string[] OldValues = Index.Split(',');
                try
                {
                    for (int i = 0, Count = OldValues.Count(); i < Count; i++)
                        Values.Add(Convert.ToInt32(OldValues[i]));
                    return Values;
                }
                catch
                {

                }
            }
            return default(List<int>);
        }

        /// <summary>
        /// An array that represents the index depth.
        /// </summary>
        /// <param name="Index">0-based index.</param>
        void SelectIndex(string Index)
        {
            if (this.TreeView == null) return;
            List<int> Values = this.GetIndices(Index);
            if (Values == null) return;
            TreeItem Target = null;
            foreach (int i in Values)
            {
                if (Target == null)
                {
                    if (this.TreeView.Items.Count > i)
                        Target = this.TreeView.Items[i] as TreeItem; //Can never be null; guarentees Target != null after first pass or breaks.
                    else break;
                }
                else
                {
                    if (Target.Items.Count > i)
                        Target = Target.Items[i];
                    else break;
                }
            }
            if (Target != null) Target.IsSelected = true;
        }

        #endregion

        #region Events

        private void _SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if ((this.TreeView.SelectedItem as TreeItem).Content != null) this.SelectedItem = this.TreeView.SelectedItem as TreeItem;
        }

        #endregion
    }
}