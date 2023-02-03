using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace padding_v_margin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Main form Margin in light blue
            BackColor = Color.LightSkyBlue;
            Padding = new Padding(25);

            flowLayoutPanel.BackColor = Color.LightSalmon;
            // Set these to 0 and let the individual controls
            // manage the padding and margins.
            flowLayoutPanel.Margin = new Padding(all: 0);
            flowLayoutPanel.Padding = new Padding(all: 0);

            for (int i = 0; i < 6; i++)
            {
                var panel = new TableLayoutPanel
                {
                    Name = $"panel{i}",
                    Size = new Size(200, 100),

                    // Margin 'outside' the panel will show in Light Salmon.
                    // This will space the panels inside the FlowLayoutPanel
                    Margin = new Padding(left: 10, top: 10, right: 0, bottom: 40),

                    // The button inside this panel will have Padding around it.
                    Padding = new Padding(all: 15),

                    BackColor = Color.LightGreen,
                    BackgroundImage = new Bitmap(
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            "Images",
                            "back-image.png"
                        )),
                    BackgroundImageLayout = ImageLayout.Stretch,
                };
                // Add button to internal panel
                var button = new Button
                {
                    Name = $"button{i}",
                    Text = $"Button {i}",
                    BackColor = Color.DarkSeaGreen,
                    ForeColor = Color.WhiteSmoke,
                    // By anchoring the button, it will autosize
                    // respecting the Padding of its parent.
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                    Margin = new Padding(all: 0),
                    Padding = new Padding(all: 0),
                };
                panel.Controls.Add(button);

                flowLayoutPanel.Controls.Add(panel);
            }
        }
    }
}
