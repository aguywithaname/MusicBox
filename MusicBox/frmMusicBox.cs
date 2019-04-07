using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace MusicBox
{
    public partial class frmMusicBox : Form
    {
        private cMP3Player player;
        int SongIdx = 0;

        StringBuilder buffer = new StringBuilder(128);
        string currentSong, LastAudioPos = "", CurrAudioPos = "0"; int Tsec = 0, WaitSec = 0;
        string PhotoDir = @"Photo\";

        public frmMusicBox()
        {
            InitializeComponent();
            player = new cMP3Player();
        }

        private void frmMusicBox_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

         private void btnSong1_Click(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked)  timer1.Enabled = true; 
            SongIdx = 1;
            btnSong1.Focus();
            currentSong =  btnSong1.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong1.Text + ".mp3");
            player.Play();
 
        }

        private void btnSong2_Click(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 2;
            btnSong2.Focus();
            currentSong = btnSong2.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong2.Text + ".mp3");
            player.Play();
        }

        private void btnSong3_Click(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 3;
            btnSong3.Focus();
            currentSong = btnSong3.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong3.Text + ".mp3");
            player.Play();
        }

        private void btnSong4_Click(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 4;
            btnSong4.Focus();
            currentSong = btnSong4.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong4.Text + ".mp3");
            player.Play();
        }

        private void btnSong5_Click(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 5;
            btnSong5.Focus();
            currentSong = btnSong5.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong5.Text + ".mp3");
            player.Play();
        }

        private void btnSong6_Click(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 6;
            btnSong6.Focus();
            currentSong = btnSong6.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong6.Text + ".mp3");
            player.Play();
        }

        private void btnSong7_Click_1(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 7;
            btnSong7.Focus();
            currentSong = btnSong7.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong7.Text + ".mp3");
            player.Play();
        }

        private void btnSong8_Click_1(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 8;
            btnSong8.Focus();
            currentSong = btnSong8.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong8.Text + ".mp3");
            player.Play();
        }

        private void btnSong9_Click_1(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 9;
            btnSong9.Focus();
            currentSong = btnSong9.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong9.Text + ".mp3");
            player.Play();
        }

        private void btnSong10_Click_1(object sender, EventArgs e)
        {
            Tsec = 0; LastAudioPos = ""; CurrAudioPos = "0";
            if (chkPlayAll.Checked) timer1.Enabled = true;
            SongIdx = 10;
            btnSong10.Focus();
            currentSong = btnSong10.Text;
            lblStatus.Text = "Playing " + currentSong;
            player.LoadFile(@"mp3\" + btnSong10.Text + ".mp3");
            player.Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            player.Pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            player.Play();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (SongIdx == 1) { btnSong2_Click(sender, e); return; }
            if (SongIdx == 2) { btnSong3_Click(sender, e); return; }
            if(SongIdx == 3) { btnSong4_Click(sender, e); return; }
            if (SongIdx == 4) { btnSong5_Click(sender, e); return; }
            if (SongIdx == 5) { btnSong6_Click(sender, e); return; }
            if (SongIdx == 6) { btnSong7_Click_1(sender, e); return; }
            if (SongIdx == 7) { btnSong8_Click_1(sender, e); return; }
            if (SongIdx == 8) { btnSong9_Click_1(sender, e); return; }
            if (SongIdx == 9) { btnSong10_Click_1(sender, e); return; }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
 
  
            if (CurrAudioPos == LastAudioPos)
            {
                timer1.Enabled = false;
                lblStatus.Text = "End: " + currentSong;
                pictureBox1.Visible = false; WaitSec = 0;
                btnNext_Click(sender, e);
            }
            else
            {
                Tsec = Tsec + 1; WaitSec = WaitSec + 1;
                if (WaitSec >= 5)
                {
                    WaitSec = 0;
                    pictureBox1.Visible = true;
                    if (Tsec % 25 == 5) pictureBox1.ImageLocation = PhotoDir + "P01.jpg";
                    if (Tsec % 25 == 10) pictureBox1.ImageLocation = PhotoDir + "P02.jpg";
                    if (Tsec % 25 == 15) pictureBox1.ImageLocation = PhotoDir + "P03.jpg";
                    if (Tsec % 25 == 20) pictureBox1.ImageLocation = PhotoDir + "P04.jpg";
                    if (Tsec % 25 == 0) pictureBox1.ImageLocation = PhotoDir + "P05.jpg";
                }

                LastAudioPos = CurrAudioPos;
                CurrAudioPos = player.Status() + "";
                lblStatus.Text = "Playing: " + currentSong + " " + Tsec.ToString() + " sec. Audio Pos=" + CurrAudioPos;
            }
        }
    }
}
