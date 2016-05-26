using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Wavefront2Roblox
{
    public partial class Form1 : Form
    {
        private WavefrontConverter currentConverter = new WavefrontConverter();
        private OpenFileDialog opf = new OpenFileDialog();
        private SaveFileDialog sfd = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();

            this.btnBrowseInput.Click += BtnBrowseInput_Click;
            // this.btnLoadRead.Click += BtnLoadRead_Click;
            this.ProgressUpdater.Tick += ProgressUpdater_Tick;
            // this.btnConvert.Click += BtnConvert_Click;
            this.btnOutputBrowse.Click += BtnOutputBrowse_Click;
            // this.btnWriteFile.Click += BtnWriteFile_Click;
            // this.btnWriteCSG.Click += BtnWriteCSG_Click;
            this.btnDOIT.Click += BtnDOIT_Click;
            this.saveWaiter.Tick += SaveWaiter_Tick;
            this.readWaiter.Tick += ReadWaiter_Tick;

            this.ProgressUpdater.Enabled = true;
        }

        private void ReadWaiter_Tick(object sender, EventArgs e)
        {
            if (this.currentConverter.ReadProgress >= 100)
            {
                this.lblstat.Text = "CONVERTING FILE";
                this.currentConverter.ConvertFileThreaded();
                this.saveWaiter.Enabled = true;
                this.readWaiter.Enabled = false;
            }
        }

        private void SaveWaiter_Tick(object sender, EventArgs e)
        {
            if (this.currentConverter.ConvertProgress >= 100)
            {
                int c = this.currentConverter.CountFaces();
                this.lblfaces.Text = string.Format("{0} faces, {1} parts", c, c * 2);
                this.lblstat.Text = "WRITING FILE";
                this.currentConverter.WriteFile(this.txtFileOutput.Text);
                this.lblstat.Text = "DONE";
                this.currentConverter = new WavefrontConverter();

                System.Media.SystemSounds.Exclamation.Play();
                this.saveWaiter.Enabled = false;
            }
        }

        private void BtnDOIT_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.txtFileInput.Text))
            {
                MessageBox.Show("Inputfile does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.txtFileOutput.Text == "")
            {
                string fp = this.txtFileInput.Text;
                fp = fp.Replace(".obj", ".lua");
                if (!fp.EndsWith(".lua"))
                {
                    fp += ".lua";
                }

                this.txtFileOutput.Text = fp;
            }

            if (File.Exists(this.txtFileOutput.Text))
            {
                System.Media.SystemSounds.Question.Play();
                if (MessageBox.Show("Overwrite the output file?", "Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
            }

            this.lblstat.Text = "LOADING FILE";
            this.currentConverter.LoadFile(this.txtFileInput.Text);
            this.lblstat.Text = "READING FILE";
            this.currentConverter.ReadFileThreaded();
            this.readWaiter.Enabled = true;
        }

        private void BtnWriteCSG_Click(object sender, EventArgs e)
        {
            if (this.sfd.ShowDialog() == DialogResult.OK)
            {
                this.currentConverter.ConvertToCSG();
                this.currentConverter.WriteCSGFile(this.sfd.FileName);
            }
        }

        private void BtnWriteFile_Click(object sender, EventArgs e)
        {
            this.currentConverter.WriteFile(this.txtFileOutput.Text);
        }

        private void BtnOutputBrowse_Click(object sender, EventArgs e)
        {
            if (this.sfd.ShowDialog() == DialogResult.OK)
            {
                this.txtFileOutput.Text = sfd.FileName;
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            this.currentConverter.ConvertFileThreaded();
        }

        private void ProgressUpdater_Tick(object sender, EventArgs e)
        {
            this.ReaderProgress.Value = this.currentConverter.ReadProgress;
            this.ConverterProgress.Value = this.currentConverter.ConvertProgress;
        }

        private void BtnLoadRead_Click(object sender, EventArgs e)
        {
            this.currentConverter.LoadFile(this.txtFileInput.Text);
            this.currentConverter.ReadFileThreaded();
        }

        private void BtnBrowseInput_Click(object sender, EventArgs e)
        {
            if (this.opf.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(this.opf.FileName))
                {
                    this.txtFileInput.Text = this.opf.FileName;
                }
                else
                {
                    MessageBox.Show("Selected file does not exist");
                }
            }
        }
    }
}
