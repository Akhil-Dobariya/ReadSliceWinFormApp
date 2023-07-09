namespace WinFormsApp1
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private delegate void SafeCallDelegate(string text);
		private static Thread threadTableWrite = null;
		private static Thread threadUserboxWrite = null;
		private List<TemplateModel> templates = new List<TemplateModel>();
		Task t1 = null;
		CancellationTokenSource currenttokenSource = new CancellationTokenSource();
		CancellationTokenSource previoustokenSource = new CancellationTokenSource();
		CancellationToken token = new CancellationToken();
		bool runnext = true;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			templates.Add(new TemplateModel() {TemplateId=1, TemplateName="Template1",Length=5,SpecifiedCharacter='a'});

			DropdownItem dropdownItem5 = new DropdownItem();
			DropdownItem dropdownItem6 = new DropdownItem();
			comboBox1 = new ComboBox();
			richTextBox1 = new RichTextBox();
			richTextBox2 = new RichTextBox();
			richTextBox3 = new RichTextBox();
			SuspendLayout();
			int width = Screen.PrimaryScreen.WorkingArea.Width;
			int height = Screen.PrimaryScreen.WorkingArea.Height;

			int paddingleft = (int)(((int)(width / 9)) / 3);
			int paddingtop = (int)(((int)(height / 8)) / 2);

			// 
			// richTextBox1
			//
			richTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			richTextBox1.Margin = new Padding(paddingleft, paddingtop,0,0);
			richTextBox1.Location = new Point(0, 0);
			richTextBox1.Name = "richTextBox1";
			int w = (int)(((int)((width-paddingleft) / 9)) * 4);
			int h = (int)(((int)((height-paddingtop) / 9))*9);
			richTextBox1.Size = new Size(w, h);
			richTextBox1.TabIndex = 4;
			richTextBox1.Text = "";
			richTextBox1.TextChanged += richTextBox1_TextChanged;

			// 
			// comboBox1
			// 
			dropdownItem5.Id = 1;
			dropdownItem5.Text = "Template1";
			dropdownItem6.Id = 2;
			dropdownItem6.Text = "Template2";
			comboBox1.DataSource = new DropdownItem[] { dropdownItem5 };
			comboBox1.DisplayMember = "Text";
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(w+paddingleft, 0+paddingtop);
			//comboBox1.Margin = new Padding(4, 5, 4, 5);
			comboBox1.Name = "comboBox1";
			int w1 = (int)(((int)((width - paddingleft) / 9)) * 2);
			int h1 = (int)(((int)((height - paddingtop) / 9)) * 2);
			comboBox1.Size = new Size(w1, h1);
			comboBox1.TabIndex = 1;
			comboBox1.ValueMember = "Id";
			comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

			// 
			// richTextBox2
			// 
			richTextBox2.Margin = new Padding(paddingleft, paddingtop*4, 0, 0);
			richTextBox2.Location = new Point(w + paddingleft, h1+2*paddingtop);
			richTextBox2.Name = "richTextBox2";
			int w2 = (int)(((int)((width - paddingleft) / 9)) * 2);
			int h2 = (int)(((int)((height - paddingtop) / 9)) * 5);
			richTextBox2.Size = new Size(w2, h2);
			//richTextBox2.Size = new Size(150, 144);
			richTextBox2.TabIndex = 5;
			richTextBox2.Text = "";
			richTextBox2.TextChanged += richTextBox2_TextChanged_1;
			// 
			// richTextBox3
			// 
			richTextBox3.Margin = new Padding(paddingleft, paddingtop * 4, 0, 0);
			richTextBox3.Location = new Point(w + 2*paddingleft+w2, h1 + 2 * paddingtop);
			richTextBox3.Name = "richTextBox3";
			int w3 = (int)(((int)((width - paddingleft) / 9)) * 2);
			int h3 = (int)(((int)((height - paddingtop) / 9)) * 5);
			richTextBox3.Size = new Size(w3, h3);
			//richTextBox3.Size = new Size(150, 144);
			richTextBox3.TabIndex = 6;
			richTextBox3.Text = "Addition Window for Future Use";
			richTextBox3.TextChanged += richTextBox3_TextChanged;

			
			
			
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new Size(width, height);
			Controls.Add(richTextBox3);
			Controls.Add(richTextBox2);
			Controls.Add(richTextBox1);
			Controls.Add(comboBox1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion
		private ComboBox comboBox1;
		private RichTextBox richTextBox1;
		private RichTextBox richTextBox2;
		private RichTextBox richTextBox3;
	}
}