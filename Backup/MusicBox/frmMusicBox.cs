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

        StringBuilder buffer = new StringBuilder(128);
        string currentSong;

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
            currentSong = "Playing " + btnSong1.Text; ;
            lblStatus.Text = currentSong;
            player.LoadFile(@"mp3\" + btnSong1.Text + ".mp3");
            player.Play();
            
 
        }



    }
}
