One way to think about it (generally) is that `Margin` is something that happens _outside_ the control whereas `Padding` is something that happens _inside_. Also, the "total" effect can be the result of the parent's padding added to the margin of the child control.

[![screenshot][1]][1]

- The `MainForm` has **padding** of 25 (shown in blue) and contains a `FlowLayoutPanel` set to `Dock.Fill`. _To avoid confusion, the padding and margin of the flow layout panel is set to 0._
- The 6 child controls of the flow layout panel set their own left-top **margin** to 10 and bottom **margin** to 40. _At the top left and the bottom of each child the `BackColor` of `LightSalmon` shows through. There is a total of 50 from the bottom of one child to the top of the next one below._ Each child control also sets its **padding** value to 15 which will apply on all four sides of the buttons it contains.
- The padding and margin of `Button` are also set to 0. The the button is auto-sized and centered because it is anchored on all sides.

***

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

            for (int i = 1; i <= 6; i++)
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
                    Text = $"Button {(char)(64 + i)}",
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


  [1]: https://i.stack.imgur.com/ur69n.png