using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Momiji.Bot.V5.Core.Controls
{
	public class CircularPictureBox : PictureBox
	{
		protected override void OnPaint(PaintEventArgs pe)
		{
			GraphicsPath path = new GraphicsPath();
			path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
			Region = new System.Drawing.Region(path);
			base.OnPaint(pe);
		}
	}
}
