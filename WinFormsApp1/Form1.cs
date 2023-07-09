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


		private void WriteToUserBox(object text)
		{
			if (richTextBox2.InvokeRequired)
			{
				var d = new SafeCallDelegate(WriteToUserBox);
				richTextBox2.Invoke(d, new object[] { text });
			}
			else
			{
				richTextBox2.AppendText(text.ToString());
			}
		}

		private void WriteToTable(object text)
		{

			if (richTextBox1.InvokeRequired)
			{
				var d = new SafeCallDelegate(WriteToTable);
				richTextBox1.Invoke(d, new object[] { text });
			}
			else
			{
				richTextBox1.AppendText(text.ToString());
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
					richTextBox1.Clear();
					richTextBox2.Clear();

					if (t1!=null)
					{
						//currenttokenSource.CancelAfter(100);
                        currenttokenSource.Cancel();
						//tokenSource.Dispose();
						previoustokenSource = currenttokenSource;
						currenttokenSource=new CancellationTokenSource();
						//t1.Dispose();
					}

					var token = currenttokenSource.Token;
					t1 = Task.Run(() =>
					{
						using (var fs = new FileStream(@"D:\UpWork\test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
						using (var reader = new StreamReader(fs))
						{
							while (true)
							{
								if (previoustokenSource.IsCancellationRequested)
								{
									previoustokenSource = new CancellationTokenSource();
									break;
								}
								
								var line = reader.ReadLine();

								if (!String.IsNullOrWhiteSpace(line))
								{
									string texttoset = line + System.Environment.NewLine;
									
									threadUserboxWrite = new Thread(new ParameterizedThreadStart(WriteToUserBox));
									threadUserboxWrite.Start(texttoset);
									threadUserboxWrite.Join();

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

										threadTableWrite = new Thread(new ParameterizedThreadStart(WriteToTable));
										threadTableWrite.Start(toWrite);
										threadTableWrite.Join();
									}
								}
							}
						}
					}, token);
					
				}
			}
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