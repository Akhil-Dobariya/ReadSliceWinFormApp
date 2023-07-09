namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
		//private void SetText(object text)
		//{
		//	WriteTextSafe(Convert.ToString(text));
		//}
		private void WriteToUserBox(object text)
		{
			//if (textBox1.InvokeRequired)
			//{
			//	var d = new SafeCallDelegate(WriteTextSafe);
			//	textBox1.Invoke(d, new object[] { text });
			//}
			//else
			//{
			//	textBox1.Text = text;
			//}

			if (richTextBox1.InvokeRequired)
			{
				var d = new SafeCallDelegate(WriteToUserBox);
				richTextBox1.Invoke(d, new object[] { text });
			}
			else
			{
				richTextBox1.AppendText(text.ToString());
			}
		}

		private void WriteToTable(object text)
		{
			//if (textBox1.InvokeRequired)
			//{
			//	var d = new SafeCallDelegate(WriteTextSafe);
			//	textBox1.Invoke(d, new object[] { text });
			//}
			//else
			//{
			//	textBox1.Text = text;
			//}

			if (richTextBox2.InvokeRequired)
			{
				var d = new SafeCallDelegate(WriteToTable);
				richTextBox2.Invoke(d, new object[] { text });
			}
			else
			{
				richTextBox2.AppendText(text.ToString());
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedValue != null)
			{
				var template = templates.Where(t => t.TemplateId == Convert.ToInt16(comboBox1.SelectedValue));

				if (template.Count() < 1)
				{
					threadUserboxWrite = new Thread(new ParameterizedThreadStart(WriteToUserBox));
					threadUserboxWrite.Start("InValid Template Selected");
					Thread.Sleep(1000);
				}
				else
				{
					char specifiedChar = template.First().SpecifiedCharacter;
					int length = template.First().Length;

					Task.Run(() =>
					{
						using (var fs = new FileStream(@"D:\UpWork\test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
						using (var reader = new StreamReader(fs))
						{
							while (true)
							{
								var line = reader.ReadLine();

								if (!String.IsNullOrWhiteSpace(line))
								{
									//string texttoset = textBox1.Text + line + System.Environment.NewLine;
									string texttoset = line + System.Environment.NewLine;
									threadUserboxWrite = new Thread(new ParameterizedThreadStart(WriteToUserBox));
									threadUserboxWrite.Start(texttoset);

									char[] textchararr = line.ToCharArray();
									int charCount = 0;
									bool firstChar = true;

									bool write = true;
									while (write)
									{
										firstChar = true;
										string toWrite = "";

										for (int i = 0; i < length; i++)
										{
											if (charCount >= textchararr.Length)
											{
												//toWrite += System.Environment.NewLine;
												write = false;
												break;
											}

											if (firstChar)
											{
												toWrite += textchararr[charCount++];
												firstChar = false;
											}
											else
											{
												toWrite += " " + textchararr[charCount++];
											}
										}

										toWrite += System.Environment.NewLine+specifiedChar + System.Environment.NewLine;

										threadUserboxWrite = new Thread(new ParameterizedThreadStart(WriteToTable));
										threadUserboxWrite.Start(toWrite);
									}

									//richTextBox1.AppendText(line);
									//richTextBox1.AppendText("\n");
									//textBox1.Text += line + System.Environment.NewLine;
								}
								else
								{
									//break;
								}
								//Console.WriteLine("Line read: " + line);

							}
						}
					});

					
				}
			}

			

			//using (var fs = new FileStream(@"D:\UpWork\test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			//using (var reader = new StreamReader(fs))
			//{
			//	while (true)
			//	{
			//		var line = reader.ReadLine();

			//		if (!String.IsNullOrWhiteSpace(line))
			//		{
			//			//richTextBox1.AppendText(line);
			//			//richTextBox1.AppendText("\n");
			//			textBox1.Text += line + System.Environment.NewLine;
			//		}
			//		else
			//		{
			//			break;
			//		}
			//		//Console.WriteLine("Line read: " + line);

			//	}
			//}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}

		private void richTextBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void richTextBox2_TextChanged_1(object sender, EventArgs e)
		{

		}

		private void richTextBox3_TextChanged(object sender, EventArgs e)
		{

		}
	}
}