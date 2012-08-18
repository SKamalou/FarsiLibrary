using System.ComponentModel;
using System.Windows;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;
using FarsiLibrary.WPF.Controls;
using System;

namespace FarsiLibrary.WPF.VisualStudio.Design
{
    public class MonthViewDesignAdorner : PrimarySelectionAdornerProvider
    {
        private readonly MonthViewDesignerUI _designerUI;
        private AdornerPanel _adornersPanel;
        private ModelItem _calendarModelItem;

        public MonthViewDesignAdorner()
        {
            _designerUI = new MonthViewDesignerUI();
        }

        protected override void Activate(ModelItem item)
        {
            _calendarModelItem = item;

            CreateAdornerPanel();
            PlaceAdornerPanel();
            SubscribeDesignerEvents();

            base.Activate(item);
        }

        protected override void Deactivate()
        {
            UnsubscribeDesignerEvents();

            base.Deactivate();
        }

        private void OnDesignerUIPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ModelProperty prop = _calendarModelItem.Properties[e.PropertyName];
            var args = e as DesignerPropertyChangedEventArgs;

            if (prop != null && args != null)
            {
                prop.SetValue(args.Value);
            }
        }

        private void PlaceAdornerPanel()
        {
            AdornerPanel.SetHorizontalStretch(_designerUI, AdornerStretch.Stretch);
            AdornerPanel.SetVerticalStretch(_designerUI, AdornerStretch.Stretch);

            var placement = new AdornerPlacementCollection();
            placement.PositionRelativeToContentHeight(0, -10);
            placement.PositionRelativeToContentWidth(1, 0);
            placement.SizeRelativeToAdornerDesiredHeight(1, 0);
            placement.SizeRelativeToAdornerDesiredWidth(1, 0);
            AdornerPanel.SetPlacements(_designerUI, placement);
        }

        private void OnDesignerUILoaded(object sender, RoutedEventArgs e)
        {
            _designerUI.ShowEmptyButton = (bool) _calendarModelItem.Properties[FXMonthView.ShowEmptyButtonProperty.Name].ComputedValue;
            _designerUI.ShowTodayButton = (bool) _calendarModelItem.Properties[FXMonthView.ShowTodayButtonProperty.Name].ComputedValue;
            _designerUI.ShowWeekDayNames = (bool) _calendarModelItem.Properties[FXMonthView.ShowWeekDayNamesProperty.Name].ComputedValue;
            _designerUI.SelectedDateTime = (DateTime?) _calendarModelItem.Properties[FXMonthView.SelectedDateTimeProperty.Name].ComputedValue;
            _designerUI.MaxDate = (DateTime) _calendarModelItem.Properties[FXMonthView.MaxDateProperty.Name].ComputedValue;
            _designerUI.MinDate = (DateTime) _calendarModelItem.Properties[FXMonthView.MinDateProperty.Name].ComputedValue;
        }

        private void SubscribeDesignerEvents()
        {
            _designerUI.Loaded += OnDesignerUILoaded;
            _designerUI.PropertyChanged += OnDesignerUIPropertyChanged;
        }

        private void UnsubscribeDesignerEvents()
        {
            _designerUI.Loaded -= OnDesignerUILoaded;
            _designerUI.PropertyChanged -= OnDesignerUIPropertyChanged;
        }

        private void CreateAdornerPanel()
        {
            if (_adornersPanel != null) 
                return;

            _adornersPanel = new AdornerPanel();
            _adornersPanel.IsContentFocusable = true;
            _adornersPanel.Children.Add(_designerUI);

            Adorners.Add(_adornersPanel);
        }
    }
}