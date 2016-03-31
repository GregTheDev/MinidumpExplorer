using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MinidumpExplorer.Controls
{
    internal class ToolStripCheckBoxMenuItem : ToolStripMenuItem
    {
        public ToolStripCheckBoxMenuItem(string text) : base(text) { }

        private void Initialize()
        {
            //CheckOnClick = true;
        }

        protected override void OnClick(EventArgs e)
        {
            this.Checked = !this.Checked;

            base.OnClick(e);
        }

        // Let the item paint itself, and then paint the RadioButton
        // where the check mark is normally displayed.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                // If the client sets the Image property, the selection behavior
                // remains unchanged, but the RadioButton is not displayed and the
                // selection is indicated only by the selection rectangle. 
                base.OnPaint(e);
                return;
            }
            else
            {
                // If the Image property is not set, call the base OnPaint method 
                // with the CheckState property temporarily cleared to prevent
                // the check mark from being painted.
                CheckState currentState = this.CheckState;
                this.CheckState = CheckState.Unchecked;
                base.OnPaint(e);
                this.CheckState = currentState;
            }

            // Determine the correct state of the RadioButton.
            CheckBoxState buttonState = CheckBoxState.UncheckedNormal;
            if (Enabled)
            {
                if (mouseDownState)
                {
                    if (Checked) buttonState = CheckBoxState.CheckedPressed;
                    else buttonState = CheckBoxState.UncheckedPressed;
                }
                else if (mouseHoverState)
                {
                    if (Checked) buttonState = CheckBoxState.CheckedHot;
                    else buttonState = CheckBoxState.UncheckedHot;
                }
                else
                {
                    if (Checked) buttonState = CheckBoxState.CheckedNormal;
                }
            }
            else
            {
                if (Checked) buttonState = CheckBoxState.CheckedDisabled;
                else buttonState = CheckBoxState.UncheckedDisabled;
            }

            // Calculate the position at which to display the RadioButton.
            Int32 offset = (ContentRectangle.Height - CheckBoxRenderer.GetGlyphSize(e.Graphics, buttonState).Height) / 2;
            Point imageLocation = new Point(ContentRectangle.Location.X + 4, ContentRectangle.Location.Y + offset);

            //// Paint the RadioButton. 
            //RadioButtonRenderer.DrawRadioButton(
            //    e.Graphics, imageLocation, buttonState);

            CheckBoxRenderer.DrawCheckBox(e.Graphics,
                  imageLocation, Rectangle.Empty, String.Empty,
                  this.Font, TextFormatFlags.HorizontalCenter,
                  true, buttonState);
        }

        private bool mouseHoverState = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            mouseHoverState = true;

            // Force the item to repaint with the new RadioButton state.
            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mouseHoverState = false;
            base.OnMouseLeave(e);
        }

        private bool mouseDownState = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseDownState = true;

            // Force the item to repaint with the new RadioButton state.
            Invalidate();

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDownState = false;
            base.OnMouseUp(e);
        }
    }
}
