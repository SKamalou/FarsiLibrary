using System;
using System.Globalization;
using FarsiLibrary.Utils;
using FarsiLibrary.Utils.Internals;
using FarsiLibrary.WinFormDemo.Demo;

namespace FarsiLibrary.WinFormDemo.Pages
{
    public partial class DateConversion : DemoBase
    {
        #region Ctor

        public DateConversion()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnToday_Click(object sender, EventArgs e)
        {
            if (!dp.SelectedDateTime.HasValue)
                return;

            DateTime dt = dp.SelectedDateTime.Value;
            PersianDate pd = dt.ToPersianDate();

            lblTodayGregorian.Text = dt.ToString("d", CultureHelper.NeutralCulture);
            lblTodayPersian.Text = dt.ToPersianDate().ToString("d");
            lblTodayPersianDate.Text = pd.ToWritten();
            lblPersianDateCtor.Text = new PersianDate(dt).ToString("G");
            lblDirectCast.Text = ((PersianDate)dt).ToWritten();
            lblConvertInvariant.Text = dt.ToString(CultureInfo.InvariantCulture);
        }

        #endregion
    }
}