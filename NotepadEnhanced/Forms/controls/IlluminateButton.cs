using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a button configured for displaying an image.
    /// The image will illuminate when the mouse hovers over this control.
    /// </summary>
    class IlluminateButton : Button
    {
        // To keep track of unmodified images
        private Image leaveImage;

        #region Properties
        public override bool AutoSize
        {
            get
            {
                // So it doesn't get all small
                if (Image == null) return false;
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = string.Empty; }
        }

        // Hide selection rectangle
        protected override bool ShowFocusCues
        {
            get { return false; }
        }

        private bool hideFocusBorder = true;
        /// <summary>
        /// Gets or sets a value indicating if the black focus rectangle appears when the button is the accept button.
        /// </summary>
        [DefaultValue(true)]
        [Description("Determines if the black focus rectangle appears when the button is the accept button.")]
        [Category("Appearance")]
        public bool HideFocusBorder
        {
            get { return hideFocusBorder; }
            set { hideFocusBorder = value; }
        }

        /// <summary>
        /// Gets or sets the brightness of the image when the mouse hovers over this button.
        /// </summary>
        [Description("The brightness of the image when the mouse hovers over this button.")]
        [Category("Appearance")]
        [DefaultValue(1)]
        public float HoverBrightness { get; set; }

        /// <summary>
        /// Gets or sets the contrast of the image when the mouse hovers over this button.
        /// </summary>
        [Description("The contrast of the image when the mouse hovers over this button.")]
        [Category("Appearance")]
        [DefaultValue(1)]
        public float HoverContrast { get; set; }

        /// <summary>
        /// Gets or sets the gamma of the image when the mouse hovers over this button.
        /// </summary>
        [Description("The gamma of the image when the mouse hovers over this button.")]
        [Category("Appearance")]
        [DefaultValue(1.2f)]
        public float HoverGamma { get; set; }

        /// <summary>
        /// Gets or sets the brightness of the image when the mouse depresses this button.
        /// </summary>
        [Description("The brightness of the image when the mouse depresses this button.")]
        [Category("Appearance")]
        [DefaultValue(1)]
        public float DepressBrightness { get; set; }

        /// <summary>
        /// Gets or sets the contrast of the image when the mouse depresses this button.
        /// </summary>
        [Description("The contrast of the image when the mouse depresses this button.")]
        [Category("Appearance")]
        [DefaultValue(1)]
        public float DepressConstrast { get; set; }

        /// <summary>
        /// Gets or sets the gamma of the image when the mouse depresses this button.
        /// </summary>
        [Description("The gamma of the image when the mouse depresses this button.")]
        [Category("Appearance")]
        [DefaultValue(1.2f)]
        public float DepressGamma { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="IlluminateButton"/> class.
        /// </summary>
        public IlluminateButton()
        {
            base.Cursor = Cursors.Hand;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //Disable additional graphics
            FlatAppearance.BorderSize = 0;
            base.BackColor = Color.Transparent;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            HoverBrightness = 1;
            HoverContrast = 1.2f;
            HoverGamma = 1.2f;
            DepressBrightness = 1;
            DepressConstrast = 1;
            DepressGamma = 1;
        }

        /// <summary>
        /// Adjusts the brightness, contrast, and gamma of an image.
        /// </summary>
        private static Image AdjustImage(Image image, float brightness, float contrast, float gamma)
        {
            if (gamma <= 0)
            {
                throw new ArgumentOutOfRangeException("gamma", "Value must be greater than 0");
            }

            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray =
            {
                new[] {contrast, 0, 0, 0, 0}, // scale red
                new[] {0, contrast, 0, 0, 0}, // scale green
                new[] {0, 0, contrast, 0, 0}, // scale blue
                new[] {0, 0, 0, 1.0f, 0},     // don't scale alpha
                new[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}
            };

            Bitmap adjustedImage = new Bitmap(image);

            using (var imageAttributes = new ImageAttributes())
            {
                imageAttributes.ClearColorMatrix();
                imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), 
                    ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
       
                using (Graphics graphics = Graphics.FromImage(adjustedImage))
                {
                    Rectangle rect = new Rectangle(Point.Empty, adjustedImage.Size);
                    graphics.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }

            return adjustedImage;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (hideFocusBorder && Parent != null)
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Parent.BackColor, ButtonBorderStyle.Solid);
            }
        }

        #region Mouse Events
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (Image != null)
            {
                leaveImage = Image;
                Image = AdjustImage(Image, HoverBrightness, HoverContrast, HoverGamma);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (Image != null) Image = leaveImage;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            if (Image != null)
            {
                Image = AdjustImage(Image, DepressBrightness, DepressConstrast, DepressGamma);
            }
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (Image != null) Image = leaveImage;
        }
        #endregion
    }
}
