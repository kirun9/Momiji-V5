using System;
using System.Drawing;
using System.Windows.Forms;

namespace Momiji.Bot.V5.Core.Controls
{
	public partial class TabButton : UserControl
	{
		[System.ComponentModel.Browsable(true)]
		public bool Selected { get; set; }
		
		[System.ComponentModel.Browsable(true)]
		public Color MarkerColor { get; set; }

		[System.ComponentModel.Browsable(true)]
		public string ButtonText { get; set; }

		public TabButton()
		{
			InitializeComponent();
			Selected = false;
			ButtonText = Name;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			ButtonMark.BackColor = Selected ? MarkerColor : BackColor;
			ButtonLabel.Text = ButtonText;
			base.OnPaint(e);
		}

		private void TabButton_MouseClick(Object sender, MouseEventArgs e)
		{
			var controls = Parent.Controls;
			foreach (var control in controls)
			{
				if (control is TabButton button)
				{
					button.Selected = (button == this);
					button.Invalidate();
				}
			}
		}
	}
}
