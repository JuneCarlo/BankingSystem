using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankingSystem
{
    class FormSlideEffect
    {
        static Timer time = new Timer();
        static Form fade;
        static string frmAction;
        static double c = 1; //100% opacity
        static double o = 0; //0% opacity

        public enum Action
        {
            Open,
            Close
        }

        public enum Slides
        {
            Up,
            Down,
            Left,
            Right
        }

        #region Transition: FadeIn FadeOut
        public static void fadeForm(Form form, Action action)
        {
            time.Interval = 99;
            time.Start();
            fade = form;
            frmAction = action.ToString();
            time.Tick += new EventHandler(time_Tick);
        }

        static void time_Tick(object sender, EventArgs e)
        {
            if (frmAction == "Open")
            {
                fade.Opacity = o;
                o = o + 0.2;
                if (fade.Opacity == 1)
                {
                    o = 0;
                    time.Stop();
                }
            }
            else
            {
                c = c - 0.2;
                fade.Opacity = c;
                if (fade.Opacity == 0)
                {
                    c = 1;
                    fade.Hide();
                    time.Stop();
                    time.Dispose();
                }
            }
        }
        #endregion

        #region Transition: SlideUp SlideDown SlideLeft SlideRight
        public static void Slide(Form form, Slides Direction)
        {
            if (Direction == Slides.Up)
            {
                for (int i = 0; i <= form.Height; i++)
                {
                    form.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Size.Width - form.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Size.Height - i) / 6);
                }
            }
            else if (Direction == Slides.Down)
            {
                for (int i = form.Height; i >= 0; i--)
                {
                    form.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Size.Width - form.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Size.Height - i) / 6);
                }
            }
            else if (Direction == Slides.Left)
            {
                for (int i = 0; i <= form.Width; i++)
                {
                    form.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Size.Width - i) / 2, (Screen.PrimaryScreen.WorkingArea.Size.Height - form.Height) / 2);
                }
            }
            else if (Direction == Slides.Right)
            {
                for (int i = form.Width; i >= 0; i--)
                {
                    form.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Size.Width - i) / 3, (Screen.PrimaryScreen.WorkingArea.Size.Height - form.Height) / 2);
                }
            }
        }

        #endregion
    }
}
