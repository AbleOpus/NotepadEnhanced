using System;
using System.Windows.Forms;
using System.Drawing;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced
{
    // Needs to be more encapsulated.
    internal class SaveAnimation : IDisposable
    {
        private bool appearing = true;
        private const int PADDING = 20;
        private int idleTicks;
        private readonly PictureBox pictureBox = new PictureBox();
        private readonly Timer timerAnimate = new Timer();
        private readonly Timer timerIdle = new Timer();
        private Point targetPos, startingPos;
        private readonly MainForm formMain;

        public SaveAnimation(MainForm formMain)
        {
            timerIdle.Interval = 1000;
            timerIdle.Tick +=timerIdle_Tick;
            this.formMain = formMain;
            pictureBox.Visible = false;
            formMain.Controls.Add(pictureBox);
            pictureBox.Image = Properties.Resources.Saved;
            pictureBox.Size = pictureBox.Image.Size;
            pictureBox.BackColor = Color.Transparent;
            timerAnimate.Interval = 1;
            timerAnimate.Tick += timerAnimate_Tick;
            SetTargetPosition();
            SetStartingPosition();
        }

        private void SetTargetPosition()
        {
            int xPos = formMain.DisplayRectangle.Width - pictureBox.Width - PADDING;
            int yPos = formMain.DisplayRectangle.Height - pictureBox.Height - PADDING;
            targetPos = new Point(xPos, yPos);
        }

        private void SetStartingPosition()
        {
            int xPos = formMain.DisplayRectangle.Width;
            int yPos = formMain.DisplayRectangle.Height - pictureBox.Height - PADDING;
            startingPos = new Point(xPos, yPos);
        }

        public void Animate()
        {
            pictureBox.Location = startingPos;
            pictureBox.Visible = true;
            pictureBox.BringToFront();
            timerAnimate.Start();
        }

        private void timerIdle_Tick(object sender, EventArgs e)
        {
            if (++idleTicks == 1)
            {
                timerAnimate.Start();
            }
        }

        private void timerAnimate_Tick(object sender, EventArgs e)
        {
            if (appearing)
            {
                if (pictureBox.Location.X != targetPos.X)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X - 2, pictureBox.Location.Y);
                }

                if (pictureBox.Location.Y != targetPos.Y)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - 2);
                }

                if (pictureBox.Location.X <= targetPos.X)
                {
                    appearing = false;
                    timerAnimate.Stop();
                    timerIdle.Start();
                }
            }
            else
            {
                if (pictureBox.Location.X != startingPos.X)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X + 2, pictureBox.Location.Y);
                }

                if (pictureBox.Location.Y != startingPos.Y)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + 2);
                }

                if (pictureBox.Location.X >= startingPos.X)
                {
                    Dispose();
                }
            }
        }

        public void Dispose()
        {
            pictureBox.Dispose();
            timerAnimate.Dispose();
            timerIdle.Dispose();
        }
    }
}