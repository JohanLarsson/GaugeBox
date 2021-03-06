namespace Gu.Wpf.Gauges.Tests.Primitives.Linear
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using NUnit.Framework;

    [Apartment(ApartmentState.STA)]
    public class LinearLineBarTests
    {
        [TestCase(TickBarPlacement.Left, false, 1, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Left, true, 1, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Left, false, 6, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Left, true, 6, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Left, false, 1, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Left, true, 1, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Left, false, 6, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Left, true, 6, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Left, false, 1, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Left, true, 1, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Left, false, 6, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Left, true, 6, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Left, false, 1, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Left, true, 1, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Left, false, 6, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Left, true, 6, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Right, false, 1, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Right, true, 1, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Right, false, 6, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Right, true, 6, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Right, false, 1, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Right, true, 1, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Right, false, 6, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Right, true, 6, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Right, false, 1, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Right, true, 1, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Right, false, 6, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Right, true, 6, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Right, false, 1, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Right, true, 1, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Right, false, 6, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Right, true, 6, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Top, false, 1, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Top, true, 1, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Top, false, 6, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Top, true, 6, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Top, false, 1, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Top, true, 1, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Top, false, 6, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Top, true, 6, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Top, false, 1, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Top, true, 1, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Top, false, 6, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Top, true, 6, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Top, false, 1, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Top, true, 1, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Top, false, 6, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Top, true, 6, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Bottom, false, 1, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Bottom, true, 1, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Bottom, false, 6, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Bottom, true, 6, double.NaN, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Bottom, false, 1, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Bottom, true, 1, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Bottom, false, 6, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Bottom, true, 6, double.NaN, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Bottom, false, 1, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Bottom, true, 1, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Bottom, false, 6, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Bottom, true, 6, 3, PenLineCap.Flat, PenLineCap.Flat, null)]
        [TestCase(TickBarPlacement.Bottom, false, 1, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Bottom, true, 1, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Bottom, false, 6, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        [TestCase(TickBarPlacement.Bottom, true, 6, 3, PenLineCap.Round, PenLineCap.Triangle, "3,3")]
        public void Render(TickBarPlacement placement, bool isDirectionReversed, double strokeThickness, double value, PenLineCap startLineCap, PenLineCap endLineCap, string padding)
        {
            var tickBar = new LinearLineBar
            {
                StrokeThickness = strokeThickness,
                Minimum = 0,
                Maximum = 10,
                Stroke = Brushes.Black,
                StrokeStartLineCap = startLineCap,
                StrokeEndLineCap = endLineCap,
                Placement = placement,
                IsDirectionReversed = isDirectionReversed,
                Padding = padding.AsThickness(),
                Value = value,
            };

            ImageAssert.AreEqual(GetFileName(tickBar), tickBar);
        }

        [TestCase(TickBarPlacement.Left, false, 2, PenLineCap.Flat, PenLineCap.Flat, "0 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Left, true, 2, PenLineCap.Flat, PenLineCap.Flat, "0 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Left, false, 2, PenLineCap.Round, PenLineCap.Triangle, "0 0 0 0", "0,1,0,1")]
        [TestCase(TickBarPlacement.Left, true, 2, PenLineCap.Round, PenLineCap.Triangle, "0 0 0 0", "0,1,0,1")]
        [TestCase(TickBarPlacement.Left, false, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 0 0", "0,0,0,1")]
        [TestCase(TickBarPlacement.Left, true, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 0 0", "0,1,0,0")]
        [TestCase(TickBarPlacement.Left, false, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 0 0", "0,1,0,0")]
        [TestCase(TickBarPlacement.Left, true, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 0 0", "0,0,0,1")]
        [TestCase(TickBarPlacement.Left, false, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 0 1", "0,0,0,0")]
        [TestCase(TickBarPlacement.Left, true, 2, PenLineCap.Round, PenLineCap.Flat, "0 1 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Left, false, 2, PenLineCap.Flat, PenLineCap.Round, "0 1 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Left, true, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 0 1", "0,0,0,0")]
        [TestCase(TickBarPlacement.Bottom, false, 2, PenLineCap.Flat, PenLineCap.Flat, "0 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Bottom, true, 2, PenLineCap.Flat, PenLineCap.Flat, "0 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Bottom, false, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 0 0", "1,0,0,0")]
        [TestCase(TickBarPlacement.Bottom, true, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 0 0", "0,0,1,0")]
        [TestCase(TickBarPlacement.Bottom, false, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 0 0", "0,0,1,0")]
        [TestCase(TickBarPlacement.Bottom, true, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 0 0", "1,0,0,0")]
        [TestCase(TickBarPlacement.Bottom, false, 2, PenLineCap.Round, PenLineCap.Flat, "1 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Bottom, true, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 1 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Bottom, false, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 1 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Bottom, true, 2, PenLineCap.Flat, PenLineCap.Round, "1 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Top, false, 2, PenLineCap.Flat, PenLineCap.Flat, "0 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Top, true, 2, PenLineCap.Flat, PenLineCap.Flat, "0 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Top, false, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 0 0", "1,0,0,0")]
        [TestCase(TickBarPlacement.Top, true, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 0 0", "0,0,1,0")]
        [TestCase(TickBarPlacement.Top, false, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 0 0", "0,0,1,0")]
        [TestCase(TickBarPlacement.Top, true, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 0 0", "1,0,0,0")]
        [TestCase(TickBarPlacement.Top, false, 2, PenLineCap.Round, PenLineCap.Flat, "1 0 0 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Top, true, 2, PenLineCap.Round, PenLineCap.Flat, "0 0 1 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Top, false, 2, PenLineCap.Flat, PenLineCap.Round, "0 0 1 0", "0,0,0,0")]
        [TestCase(TickBarPlacement.Top, true, 2, PenLineCap.Flat, PenLineCap.Round, "1 0 0 0", "0,0,0,0")]
        public void Overflow(TickBarPlacement placement, bool isDirectionReversed, double strokeThickness, PenLineCap startLineCap, PenLineCap endLineCap, string padding, string expected)
        {
            var tickBar = new LinearLineBar
            {
                StrokeThickness = strokeThickness,
                Minimum = 0,
                Maximum = 10,
                Stroke = Brushes.Black,
                StrokeStartLineCap = startLineCap,
                StrokeEndLineCap = endLineCap,
                Placement = placement,
                IsDirectionReversed = isDirectionReversed,
                Padding = padding.AsThickness(),
            };

            var gauge = new LinearGauge { Content = tickBar };
            gauge.Arrange(new Rect(new Size(10, 10)));
            Assert.AreEqual(expected, gauge.ContentOverflow.ToString());
            Assert.AreEqual(expected, tickBar.Overflow.ToString());

            gauge.Measure(new Size(10, 10));
            gauge.Arrange(new Rect(new Size(10, 10)));
            Assert.AreEqual(expected, gauge.ContentOverflow.ToString());
            Assert.AreEqual(expected, tickBar.Overflow.ToString());
        }

        private static string GetFileName(LinearLineBar tickBar)
        {
            var padding = tickBar.Padding.IsZero()
                ? string.Empty
                : $"_Padding_{tickBar.Padding}";

            var value = double.IsNaN(tickBar.Value)
                ? string.Empty
                : $"_Value_{tickBar.Value}";

            return $@"LinearLineBar_Placement_{tickBar.Placement}_IsDirectionReversed_{tickBar.IsDirectionReversed}_Min_{tickBar.Minimum}_Max_{tickBar.Maximum}{value}{padding}_StrokeThickness_{tickBar.StrokeThickness}_StrokeStartLineCap_{tickBar.StrokeStartLineCap}_StrokeEndLineCap_{tickBar.StrokeEndLineCap}.png"
                .Replace(" ", "_");
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static void SaveImage(LinearLineBar tickBar)
        {
            var size = tickBar.Placement == TickBarPlacement.Left || tickBar.Placement == TickBarPlacement.Right
                ? new Size(10, 100)
                : new Size(100, 10);
            Directory.CreateDirectory(@"C:\Temp\LinearLineBar");
            tickBar.SaveImage(size, $@"C:\Temp\LinearLineBar\{GetFileName(tickBar)}");
        }
    }
}