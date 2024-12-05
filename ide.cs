using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RSCRIPTIDE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;

            // Save the code to a temporary file
            string tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, code);

            // Run the custom language interpreter
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "custom_lang", // Path to the compiled C++ interpreter
                Arguments = tempFileName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    MessageBox.Show(output, "Output", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
